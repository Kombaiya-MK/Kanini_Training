 use northwind
 create proc proc_OutExample(@num int,@result int out)
 as
 begin
   set @result = @num * @num
 end


 declare 
 @res int
 begin
exec proc_OutExample 34,@res out
print @res
end

---change
 create proc proc_OutExample1(@num int  out)
 as
 begin
   set @num = @num * @num
 end

 declare 
 @res int 
 begin
 set @res = 10
exec proc_OutExample1 @res out
print @res
end

--Exception
--Take the category name give out the average of unit price in that category
alter proc proc_AverageOfCategory(@cname varchar(20),@avg float out)
as
begin
   declare
   @sum money,@count int,@cid int
   set @cid = (select categoryID from Categories where CategoryName=@cname)
   set @count = (select count(productID) from products where CategoryID = @cid)
   set @sum = (select sum(UnitPrice) from products where CategoryID = @cid)
   set @count = @count-5
   begin try
	set @avg = @sum/@count
	print 'The average of the products of '+@cname +' is Rs.'+convert(varchar(20),round(@avg,2))
   end try
   begin catch
     print ERROR_MESSAGE()
   end catch
end

declare 
@res int 
begin
 exec proc_AverageOfCategory 'Produce', @res out
 print @res
end


select * from Categories
select count(productid),CategoryID from products group by CategoryID