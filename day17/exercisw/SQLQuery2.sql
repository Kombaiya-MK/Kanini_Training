use pubs

--Query 1 - Create a cursor that will take every Publisher and print the publisher name, city
--Books details
--Name price 

select * from publishers
select * from titles
declare cur_PubInfo cursor 
	for (select pub_name , city ,title,price from publishers p join
	titles t on p.pub_id = t.pub_id)
	declare 
		@sno int,
		@pname varchar(50),
		@city varchar(50),
		@title varchar(50),
		@price money
	open cur_PubInfo
	fetch cur_PubInfo into @pname,@city,@title,@price
	set @sno = 1
	while (@@FETCH_STATUS = 0)
		begin
			print 'Serial No      : ' + convert(varchar(5) , @sno)
			print 'Publisher Name : ' + @pname
			print 'Publisher City : ' + @city
			print 'Book Title     : ' + @title
			print 'Book Price     : ' + convert(varchar(5) , @price)
			print '***********************************************************************'
			set @sno = @sno + 1
			fetch cur_PubInfo into @pname,@city,@title,@price
		end
	close cur_PubInfo
deallocate cur_PubInfo


select * from publishers p join 
titles t on p.pub_id = t.pub_id

--Query 2 -  Create a trigger for the Employeeskill table for insert that will insert the skill 
--if it is not already present in the skills table(Skill description not required)

use dbEmployeeDetails

select * from tblskill
select * from tblEmployeeSkill

drop trigger trg_InsertSkills

Alter trigger trg_skills
on tblskill
instead of Insert
as
begin
	declare
	@entered_skill varchar(50),
	@entered_des varchar(50)
	set @entered_skill=(select skill from inserted)
	set @entered_des=(select skill_description from inserted)
	declare temp_cursor cursor
	for (select 'true' from tblSkill where skill = @entered_skill)
	declare
	@check_variable varchar(5)
	set @check_variable='false'
	open temp_cursor
	fetch temp_cursor into @check_variable
	close temp_cursor
	deallocate temp_cursor
	if(@check_variable = 'true')
	begin
		print 'Skill is Already Exist'
	end
	else
		insert into tblSkill values(@entered_skill,@entered_des)
end

insert into tblSkill values('Big Data' ,'Blooming Field')
insert into tblSkill values('SQL' ,'RDBMS')
insert into tblSkill values('PL/SQL' ,'Advanced SQL')

select * from tblSkill

--Query 3 - Create a cursor that takes Every Sale details and print the invoice
--Sale Number: 
--Book name   |  Quantity | Price
------------------------------
--total 			XXXX.XX
-------------------------------


declare cur_Invoice cursor
	for (select title , qty , price from titles t join
	sales s on s.title_id = t.title_id)
	declare 
		@title varchar(50),
		@qty int,
		@price money,
		@total_price money
		open cur_Invoice
		fetch cur_Invoice into @title , @qty , @price
		while (@@FETCH_STATUS = 0)
			begin
					print 'Book Name is ' + @title + '|' + 'Quantity: ' + convert(varchar(50),@qty) + '|' + 'Price: ' + convert(varchar(50),@price)
					print '-------------------------------'
					print 'Total                     '+convert(varchar(50),@qty*@price)
					print '-------------------------------'
				fetch cur_Invoice into @title , @qty , @price
			end
		close cur_Invoice
		deallocate cur_Invoice




