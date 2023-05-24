use northwind

create procedure p 
as 
select * from Shippers

execute p


--Stored Procedures

create procedure procedure1( @num int  , @result int  out)
as
	begin
		set @result = @num * @num
	end

alter procedure procedure1( @num int  , @result int  out)
as
	begin
		set @result = @num * @num * @num
	end

declare
	@res int
	begin 
		exec procedure1 2 , @res out
		print @res
	end


select * from Categories

drop procedure proc_NumberOfItemsUnderCategory

create procedure proc_AvgOfCategory(@CategoryName varchar(20) , @avg float out)
begin
	declare 
		@CategoryID int
		set @avg = (select avg(unitprice) from Products where CategoryID = @CategoryID)
		set @CategoryID = (select CategoryID from  Categories where CategoryName = @CategoryName)
	end


---Transactions
--It's only applied to DML queries -(Insert , Update , Delete)
use dbEmployeeDetails


create table tblS1
(f1 int primary key,
f2 varchar(20))

create table tblS2
(c1 int primary key references tblS1(f1),
c2 date)
		
begin tran
	insert into tblS1 values(101 , 'Abc')
	insert into tblS2 values(101 , '03-13-2023')
commit

select * from tblS1
select * from tblS2

begin tran
	insert into tblS1 values(102 , 'Bcd')
	insert into tblS2 values(102 , '03-12-2023')
	if ((select c2 from tblS2 where c1 = 102) < SYSDATETIME() )
		commit
	rollback


begin tran
	insert into tblS1 values(104 , 'Bcd')
	insert into tblS2 values(104 , '03-15-2023')
	if ((select c2 from tblS2 where c1 = 104) < SYSDATETIME() )
		commit
	rollback


print SYSDATETIME()

--Save Point

begin tran
	insert into tblS1 values(105 , 'nmaa x')
	save tran sptbl2
	insert into tblS2 values(105 , '03-15-2023')
	if ((select c2 from tblS2 where c1 = 105) < SYSDATETIME() )
		commit
	else
		begin
			rollback tran sptbl2
			commit
		end

select * from tblS1
select * from tblS2

--Transaction within stored procedure

create proc proc_TransacInProcedure(@f1 int , @f2 varchar(20) , @f3 date , @f4 bit out)
as
begin
	declare 
		@f5 int
		set @f5 = 5
	begin tran
	begin try
	set @f5 = @f5 / (@f5-5)
	insert into tblS1 values(@f1 , @f2)
	save tran sptbl2
	insert into tblS2 values(@f1 , @f3)
	if ((select c2 from tblS2 where c1 = @f1) < SYSDATETIME() )
		begin
			commit
			set @f4 = 1;
		end
	else
		begin
			rollback tran sptbl2
			commit
		end
	end try

	begin catch
		rollback
		set @f4 = 0;
	end catch
end

alter proc proc_TransacInProcedure(@f1 int , @f2 varchar(20) , @f3 date , @f4 bit out)
as
begin
	declare 
		@f5 int
		set @f5 = 5
	begin tran
	begin try
	set @f5 = @f5 / (@f5-5)
	insert into tblS1 values(@f1 , @f2)
	save tran sptbl2
	insert into tblS2 values(@f1 , @f3)
	if ((select c2 from tblS2 where c1 = @f1) < SYSDATETIME() )
		begin
			commit
			set @f4 = 1;
		end
	else
		begin
			rollback tran sptbl2
			commit
		end
	end try

	begin catch
		rollback
		set @f4 = 0;
		print ERROR_MESSAGE()
	end catch
end


declare @res bit
begin 
exec proc_TransacInProcedure 106 , 'Mk' , '02-14-2023' , @res out
print @res
end

use Northwind
select * from orders
select * from [Order Details]

sp_help orders
sp_help [Order Details]

alter proc proc_InsertOrder
( @Cid varchar , @eid int , @orderDate datetime ,@rdate datetime , @sdate datetime , @svia int , 
@freight money , @sname nvarchar(50) ,@sadd nvarchar(50) , @scity nvarchar(20) , @sregion nvarchar(20), 
@spcode int,@scntry nvarchar(30), @pid1 int , @pid2 int ,  @uprice float , @qty1 int ,@qty2 int  , @discount real)
as
begin
	declare 
		@orderID  int;
	begin tran
	begin try
		
		insert into Orders values(@Cid , @eid ,@orderDate,@rdate,@sdate,@svia,@freight, @sname ,@sadd,@scity,@sregion,@spcode,@scntry)
		print('Im here')
		set @orderID = (select max(orderID) from Orders)
		
		insert into [Order Details] values(@orderID , @pid1 , @uprice,@qty1,@discount)
		insert into [Order Details] values(@orderID , @pid2 , @uprice,@qty2,@discount)
		save tran sp1
		
		if ((select (UnitsInStock - @qty1)  from Products where ProductID = @pid1) >= 0 and 
		(select (UnitsInStock - @qty2)  from Products where ProductID = @pid2) >= 0)
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
		end
		end try

	begin catch
		rollback 
		print 'Failure'
	end catch
end



----

exec proc_InsertOrder 'CHOPS',6,'03-13-2023','03-23-2023','03-18-2023',1,11.34,'Que Delícia','Av. dos Lusíadas, 23'
,'London','SP','28001','Germany',21,22,40.67,1,10,0
	

select * from Orders
select * from [Order Details]
select * from products where ProductID in (21,22)
		
		
		


select UnitsInStock - 10 from Products

select * from [Order Details]

select max(orderId) from Orders



create proc proc_