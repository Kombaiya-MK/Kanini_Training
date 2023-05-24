use northwind

--Query 1 - create a stored procedure that will insert details of order
-- The procedure should take all the details to make entry in to orders, Order Details tables
--The procedure should also update teh stock in the product table
-- Let presume the order is just for 2  items as of now
--Stored procedure will give an out of message indicating Success/Failue

alter proc proc_updateStocks
( @Cid varchar , @eid int , @orderDate datetime ,@rdate datetime , @sdate datetime , @svia int , 
@freight money , @sname nvarchar(50) ,@sadd nvarchar(50) , @scity nvarchar(20) , @sregion nvarchar(20), 
@spcode int,@scntry nvarchar(30), @pid1 int , @pid2 int ,  @qty1 smallint ,@qty2 smallint  , @res bit out)
as
begin
	declare 
		@orderID  int, @uprice1 float ,@uprice2 float,@discount1 real,@discount2 real
	begin tran
	begin try
		save tran sp1
		if (@Cid in (select CustomerID from Customers) and 
		@eid in (select EmployeeID from Employees) and 
		@svia in (select shipperID from Shippers))
			insert into Orders values(@Cid , @eid ,@orderDate,@rdate,@sdate,@svia,@freight, @sname ,@sadd,@scity,@sregion,@spcode,@scntry)
			set @res = 1
		
		set @orderID = (select max(orderID) from Orders)
		set @uprice1 = (select UnitPrice from Products where ProductID = @pid1)
		set @uprice2 = (select UnitPrice from Products where ProductID = @pid2)
		set @discount1 = (select Discount from [Order Details] where ProductID = @pid1)
		set @discount2 = (select Discount from [Order Details] where ProductID = @pid2)
		insert into [Order Details] values(@orderID , @pid1 , @uprice1,@qty1,@discount1)
		insert into [Order Details] values(@orderID , @pid2 , @uprice2,@qty2,@discount2)
		if ((select (UnitsInStock - @qty1)  from Products where ProductID = @pid1) > 0 and 
		(select (UnitsInStock - @qty2)  from Products where ProductID = @pid2) > 0)
		begin
			update Products set UnitsInStock = UnitsInStock - @qty1 where ProductID = @pid1
			update Products set UnitsInStock = UnitsInStock - @qty2 where ProductID = @pid2
			commit
			print 'Success'
		end
		else
		begin
			rollback tran sp1
			print 'Partial Success'
			set @res = 1
		end
		end try

	begin catch
		rollback 
		print 'Failure'
		set @res = 0
	end catch
end

declare 
@res bit
begin 
	exec proc_updateStocks  'VINET',6,'1998-04-30 00:00:00.000','1998-05-28 00:00:00.000','1998-05-06 00:00:00.000',3,63.34,'Vins et alcools Chevalier','59 rue de l Abbaye'
	,'Reims',NULL,'51100','France',10,11,1,10,@res out
	print @res
end


	select * from orders
	select * from [Order Details]
	select * from Products
	select * from Customers
	select * from Employees
	select * from Shippers

use pubs

sp_help sales
sp_help stores


--Query 2 create a stored procedure that will take the stor_id
--ord_num
--ord_date
--qty
--payterms
--title_id
--for an order(presume the order is for only one book per order)
--If the stor_id is not present then insert in to the stores table. 
--If the title is not present then roll back the sales

alter proc proc_add_StoreInfo(@stor_id char(4), @ord_num varchar(20), @ord_date datetime, 
@qty smallint,  @payterms varchar(12), @title_id varchar(50),
 @stor_name varchar(40),@stor_address varchar(40),
 @city varchar(20),@state char(2),@zip char(5) , @res bit out)
as
begin
	begin tran
	if(@stor_id not in (select stor_id from sales))
		begin
		insert into stores values(@stor_id, @stor_name, @stor_address, @city, @state, @zip)  
		set @res = 1
		end
	else
		begin
		insert into sales values(@stor_id, @ord_num, @ord_date, @qty, @payterms, @title_id) 
		set @res = 0
		end
	if(@title_id in (select title_id from sales))
		begin
			insert into 
			commit
			set @res = 1
		end
	else
		begin
			rollback
			set @res = 0
		end
 end

declare 
@res bit 
begin
	exec proc_add_StoreInfo '1234','14FEB2K1' ,'2001-02-14 00:00:00.000' , 8 , 'Net 60','BU1032',
	'AOT reads' , '89 Madison St.' , 'Shibuya' , 'Tokyo' , '65728' , @res out
	print @res
end


exec proc_add_StoreInfo '5555','8043','1992-06-15 00:00:00.000',32,'Net 30','BU1032', 'Hello There','23,New road','Madras','TN',7523

 select * from stores
 select * from sales



select * from sales
select * from stores

if ('BU1032' in (select title_id from sales))
	print 'Irukan da'
else
	print 'Oditanla'
sp_help sales

select stor_id from sales group by stor_id having count(stor_id) >= 1