use pubs

--Query 1 - Print all the author details sorted by their lastname in 
--descending order then by firstname in ascending order
select * from authors order by au_lname desc , au_fname asc

--Query 2 - Print the number of books by every author(id)

select  au_id 'Author Id', count(au_id)'Number of books' from 
titleauthor 
group by au_id


--For every author
select  a.au_id 'Author Id', count(ta.au_id)'Number of books' from authors a 
left outer join titleauthor ta on 
ta.au_id = a.au_id 
group by a.au_id

select * from titleauthor

--Query 3 - print the number of author for every book(id)


select * from authors
select * from titles
select * from titleauthor order by title_id

select title_id 'Book ID' , count(title_id) 'Number of authors' from titleauthor
group by title_id

--For every book
select t.title_id 'Book ID' , count(ta.title_id) 'Number of authors' from titles t left outer join
titleauthor ta on ta.title_id = t.title_id
group by t.title_id

--Query 4 - print the highest priced book by every publisher id

select * from publishers
select * from titles

select p.pub_id, max(price)'price' from publishers p left join 
titles t on t.pub_id = p.pub_id 
group by p.pub_id



 --Using Co-related sub queries

select pub_name , title, t2.price from titles t1 join
(select p.pub_id, max(price)'price' from publishers p left join 
titles t on t.pub_id = p.pub_id 
group by p.pub_id) t2
on t1.pub_id = t2.pub_id and t1.price = t2.price
right outer join publishers p 
on p.pub_id = t1.pub_id




--Query 5 - print the first 5 heighest quantity sales

select TOP 5 * from sales order by qty desc


--Query 6 - print the books that are priced not more than 25 not less than 10
select title 'books that are priced not more than 25 not less than 10' , price from titles where price between 10 and 25

--Query 7 - Print the books that are price higher than the books that are of type 'cook'
select title 'Book that are priced higher than book the books that are of type cook' , price from titles where price > 
(select max(price) from titles where type like('%cook%'))

--Query 8 -  print the books that have 'e' and 'a' in their name
select title 'Books that have e and a in their name' from titles where title like ('%e%') and title like ('%a%')

--Query 9 - print the number and the sum of their price of books that have been published by authors from 'CA'
select count(ta.title_id) 'Number of Books from state CA', sum(price) 'Sum of Book price from state CA'  from titles t join
titleauthor ta on ta.title_id = t.title_id
join authors a on  ta.au_id = a.au_id
where state = 'CA'
group by state

use pubs

--Query 10 - print the publisher name and the average of books published
select pub_name , avg(price) 'Average price of books published' , avg(qty) 'Number of Books' from publishers p left outer join
titles t on p.pub_id = t.pub_id
left join sales s on s.title_id = t.title_id
group by pub_name

select * from titles

--Query 11 - Create a procedure that takes the title id and prints the total amount of sale for it

select title_id , sum(qty) from sales group by title_id
select * from sales
select sum(qty) from sales where title_id = 'BU1032'
sp_help titles
create or alter procedure proc_TotalAmountOfSales(@title_id varchar(10))
as
begin
	declare
		@price money,
		@qty bigint,
		@totalAmount money
	set @price = (select price from titles where title_id = @title_id)
	set @qty = (select sum(qty) from sales where title_id = @title_id)
	set @totalAmount = @qty * @price
	print 'Quantity : ' + convert(varchar(50) , @qty)
	print 'Total Amount of sales for ' + @title_id + ' : ' + convert(varchar(50) , @totalAmount)
end


exec proc_TotalAmountOfSales 'BU2075'

select price from titles where title_id =  'BU1032'
select * from sales

--Query 12 - Create a function that takes the author last name and print his last name and the book name authored


sp_help authors
create or alter function udf_authorInfo(@lname varchar(50))
returns @AuthorInfo table (AuthorFirstName  varchar(50) , bookName varchar(50))
as
begin
	insert into @AuthorInfo
		select au_lname , title from authors a left outer join
		titleauthor ta on a.au_id = ta.au_id
		join titles t on t.title_id = ta.title_id
		where au_lname = @lname
	return
end
select * from authors
select * from dbo.udf_authorInfo('Ringer')

--Query 13 - Create a procedure that will take the price and prints the count of book that are priced less than that
create or alter procedure proc_CountBooks(@Maximumprice money)
as
begin
	declare 
		@Count int
	set @Count = (select count(title_id) from titles where price < @Maximumprice)
	print 'Number of books less than ' + convert(varchar(50) ,@Maximumprice) + ' : ' +  convert(varchar(50) ,@Count) 
end

exec proc_CountBooks 19.99

select * from titles

--Query 14 - Find a way to ensure that the price of books are not updated if the price is below 7

create or alter trigger  trg_PriceUpdateConstraint
on titles
instead of update 
as
begin
	declare 
		@entered_price money,
		@title_id varchar(50)
		set @entered_price = (select price from inserted)
		set @title_id = (select title_id from inserted)
		if (@entered_price > 7)
			update titles set price = @entered_price where title_id = @title_id
		else
			print 'Update action is restricted'
end

update titles set price = 28 where title_id = 'BU1032'
update titles set price = 2 where title_id = 'BU1032'

select max(price) from titles
select * from titles
select * from sales
sp_help sales
--Query 15 - Create a set of queries that will take the insert for sale 
--but of the price is greater than 40 then the insert should not happen
create or alter trigger tgr_InsertSaleInfo
on sales
instead of insert 
as 
begin
	declare 
		@qty smallint,
		@price money
	set @qty = (select qty from inserted)
	set @price = (select price from titles where title_id = (select title_id from inserted))

	if (@price*@qty  > 40)
		print 'Insertion operation is restricted (Price is not supposed to be greater than 40)'
	else
		begin
			print 'Insertion Success'
			insert into sales select *  from inserted
		end
end

select * from sales
insert into sales values(8042, 'QA8712','1993-02-21 00:00:00.000' ,10,'ON invoice','BU1032')
insert into sales values(7131, 'F14aK1',SYSDATETIME() ,1,'ON invoice','BU1032')
sp_help sales