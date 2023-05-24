use dbEmployeeDetails


--DML Queries

--insert Query

insert into tblArea(area , zipcode) values('TVL' , '627001')

insert into tblArea(area , zipcode) values('CBE' , '641001')
insert into tblArea(area , zipcode) values('CHE' , '600001')

insert into tblArea(area , zipcode) values('TUT' , '628001') , ('TEN' , '630001') , ('MDU' , '626001') ,('KNK' , '631001')
insert into tblArea values('ABC' , '651001')

select * from tblArea


select * from tblEmployee

insert into tblEmployee values('Naruto' , '9994291196' , 'TVL')

insert into tblEmployee values('Eren' , '9878787677' , 'CHE')

insert into tblEmployee values('Asta' , '9455271000' , 'CBE')

insert into tblEmployee values('Asta' , '9455271001' , 'CHE')



--Failure Cases

--Not possible to insert the foreign key value which is not available in the domain.

insert into tblEmployee values('Eren' , '9878787677' , 'PDY')

-----------------------------------------------------------------------------

insert into tblEmployee values('mikasa' , '9878787676' , null)

insert into tblEmployee(name,phonenumber) values('Touka' , '6382205871')

----------------------------------------------------------------------------------

select * from tblSkill

sp_help tblSkill

insert into tblSkill values('C' , 'PLT'),('C#' ,'WEB') , ('SQL' , 'RDBMS')

-----------------Employee Skill table-------------------------------------------------


sp_help tblEmployeeSkill

insert into tblEmployeeSkill values(101 , 'C' , 8.9),(101,'C#',9.2) , (102 , 'SQL' , 6.9)

select * from tblEmployeeSkill

-------------False Cases---------------

insert into tblEmployeeSkill values(101 , 'C' , 9.9)

insert into tblEmployeeSkill values(103 , 'C' , 19.9)

--------------------------------------------

select * from tblEmployee

delete from  tblEmployee where id=106

delete from tblEmployee where area is null;


----failure case
delete from  tblEmployee where id=101


------------------------------
select * from tblSkill

sp_help tblSkill



---------------------------------------
create table tblSample1
(col1 int unique not null,
col2 varchar(20))

create table tblSample2
(col21 int primary key,
col22 int references tblSample1(col1) on delete cascade)

insert into tblSample1 values(1,'ABC'),(2,'ABD'),(3,'ABE')

select * from tblSample1

delete from tblSample1


truncate table tblSample1


drop table tblSample2
go
drop table tblSample1

select * from tblSample1

insert into tblSample2 values(101 , 1),(102 , 1),(103 , 2)

select * from tblSample2

delete from tblSample1 where col1 = 2

select * from tblArea

update tblArea set zipcode = '625001' where area = 'MDU'

update tblArea set zipcode = case zipcode
when '625001' then '625002'
when '600001' then '600002'
when '627001' then '627002'
end

select * from tblEmployeeSkill
insert into tblEmployeeSkill values(102 ,'C#',8.6)

update tblEmployeeSkill set skill_level = 8.0 where skill = 'C#'

update tblEmployeeSkill set skill_level = 8.8 where skill = 'C#' and emp_id = 101


create table tbl1
(f1 int unique not null,f2 varchar(20))

create table tbl2
(f11 int primary key,
f21 int references tbl1(f1) on update cascade null)

insert into tbl1 values(4,'abc'),(5,'eee'),(6,'ttt')
insert into tbl2 values(101,4),(102,5),(103,6)

select * from tbl1
select * from tbl2

update tbl1 set f1=null where f1=6 






