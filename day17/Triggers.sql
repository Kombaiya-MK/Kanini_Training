use dbEmployeeDetails

select * from tblS1


--Triggers
create trigger trg_insertTblS1
on tbls1
for insert
as
begin
	print 'Hello'
end

insert into tblS1 values(107,'Bot')

drop trigger trg_insertTblS1

create trigger trg_insertTblS1
on tbls1
for insert
as
begin
	declare
		@MyF2 varchar(30)
		set @MyF2 = (select F2 from inserted)
		print @MyF2

end


insert into tblS1 values(109,'mwlk')

create trigger trg_insert2
on tbls1
for insert
as
begin
	declare
		@MyF1 varchar(30)
		set @MyF1 = (select F1 from inserted)
		insert into tblS2 values(@MyF1 , SYSDATETIME())

end

drop trigger trg_insert2
select * from tblS1
select * from tblS2

insert into tblS1 values(110,'nskn')


create view vwTable
as
select f1 , f2 , c2 from tblS1 join
tblS2 on
tblS1.f1 = tblS2.c1

select * from vwTable

create trigger tgr_InsertIntoViews
on vwTable
instead of insert
as
begin
	insert into tblS1 select f1,f2 from inserted
	insert into tblS2 select f1,c2 from inserted
end
drop trigger tgr_InsertIntoViews

insert into vwTable values(115,'naruto',SYSDATETIME())
select * from vwTable



use Northwind

select * from [Order Details]

alter trigger tgr_updateUnitPrice
on [Order Details]
for update
as
begin
	declare 
	@updatedPrice money,
	@orderid int,
	@productid int
	set @updatedPrice = (select Unitprice from inserted)
	set @orderid = (select OrderID from inserted)
	set @productid = (select ProductID from inserted)
	if (@updatedPrice) > 50
		update [Order Details] set Discount = 0.2 where OrderID = @orderid and ProductID = @productid
end

update [Order Details] set UnitPrice = 55 where OrderID = 10248 and ProductID = 11
select * from [Order Details]


