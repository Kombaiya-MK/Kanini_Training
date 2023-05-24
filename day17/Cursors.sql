use northwind

use dbEmployeeDetails
--Cursors

declare cur_getMultipleInfo cursor 
for 
	select * from tblS1
	declare 
		@f1 int ,
		@f2 varchar(10)
	open cur_getMultipleInfo
	fetch cur_getMultipleInfo into @f1 , @f2
	while (@@FETCH_STATUS = 0)
		begin
			print 'The value of f1 is ' +  convert(varchar(5) , @f1)
			print 'The value of f1 is ' + @f2
			print '---------------------------------'
			fetch cur_getMultipleInfo into @f1 , @f2
		end
	close cur_getMultipleInfo
deallocate cur_getMultipleInfo
	


use Northwind
declare cur_getOrderInfo cursor 
for 
	select OrderID , ContactName from Orders o join
	Customers c on o.CustomerID = c.CustomerID
	declare 
		@oid int ,
		@cname varchar(10)
	open cur_getOrderInfo
	fetch cur_getOrderInfo into @oid , @cname
	while (@@FETCH_STATUS = 0)
		begin
			print 'The value of f1 is ' +  convert(varchar(5) , @oid)
			print 'The value of f1 is ' + @cname
			print '---------------------------------'
			select * from [Order Details] where OrderID = @oid
			fetch cur_getOrderInfo into @oid , @cname
		end
	close cur_getOrderInfo
deallocate cur_getOrderInfo


--Nested Cursor

declare cur_getOrderInfo cursor 
for 
	select OrderID , ContactName from Orders o join
	Customers c on o.CustomerID = c.CustomerID
	declare 
		@oid int ,
		@cname varchar(100)
	open cur_getOrderInfo
	fetch cur_getOrderInfo into @oid , @cname
	while (@@FETCH_STATUS = 0)
		begin
			print 'Order ID ' +  convert(varchar(5) , @oid)
			print 'Customer Name : ' + @cname
			declare cur_InnerCursor cursor
				for 
					select ProductID , UnitPrice , Quantity , Discount from [Order Details] where OrderID = @oid
					declare 
						@pid int ,
						@uprice money,
						@qty int,
						@dis real
					open cur_InnerCursor
					fetch cur_InnerCursor into @pid , @uprice,@qty,@dis
					while (@@FETCH_STATUS = 0)
					begin
						print 'Product Id : ' + convert(varchar(30),@pid)
						print 'Unit Price : ' + convert(varchar(30),@uprice)
						print 'Quantity : ' + convert(varchar(30),@qty)
						print 'Discount : ' + convert(varchar(30),@dis)
						print '---------------------------------'
						fetch cur_InnerCursor into @pid , @uprice,@qty,@dis
					end
					close cur_InnerCursor
					deallocate cur_InnerCursor
			fetch cur_getOrderInfo into @oid , @cname
		end
	close cur_getOrderInfo
deallocate cur_getOrderInfo
	


declare cur_OrderData cursor
for
select orderId , ContactName from Orders o join CUstomers c
on o.CustomerID = c.CustomerID
declare 
@oid int,@cname varchar(100)
open cur_OrderData
Fetch cur_OrderData into @oid,@cname
while(@@FETCH_STATUS =0)
begin
    print 'Customer Name : '+@cname
	print 'Order ID : '+convert(varchar(5),@oid)
	declare cur_InnerOrder cursor
	for
	select ProductID,UnitPrice,Quantity,Discount from [Order Details] where OrderID=@oid
	declare
	@pid int,@uprice money,@qty int,@dis float
	open cur_InnerOrder
	fetch cur_InnerOrder into @pid,@uprice,@qty,@dis
	while(@@FETCH_STATUS =0)
	begin
		print 'Product ID : '+convert(varchar(5),@pid)
		print 'Product Price : '+convert(varchar(5),@uprice)
		print 'Product Quantity : '+convert(varchar(5),@qty)
		print 'Discount : '+convert(varchar(5),@dis)
		fetch cur_InnerOrder into @pid,@uprice,@qty,@dis
		print '************'
	end
	close cur_InnerOrder
	deallocate cur_InnerOrder
	print '------------------'
	Fetch cur_OrderData into @oid,@cname
end
close cur_OrderData
deallocate cur_OrderData