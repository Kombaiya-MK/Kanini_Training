use pubs;

select * from employee;

use Northwind

select * from [Order Details]
exec sp_help [Order Details]

use dbEmployeeDetails

--DDL Queries

--Create table
create table tblArea
(area varchar(50) , zipcode char(6))

select * from tblArea

drop table tblArea

sp_help tblArea

--create table with primary key
create table tblArea
(area varchar(50) primary key , zipcode char(6))

--table with primary key with constraints
create table tblArea
(area varchar(50)constraint pk_area primary key , zipcode char(6))

--dropping primary key
alter table tblArea
drop constraint pk_area

--adding primary key
alter table tblArea
add constraint pk_area primary key(area)

--changing attributes to nullable and not nullable
alter table tblArea
alter column zipcode char(10) not null;

--add & drop columns
alter table tblArea
add extra text

sp_help tblArea

alter table tblArea
drop column extra


create table tblSkill
(skill varchar(50) constraint pk_skill primary key, skill_description varchar(50)) 

sp_help tblSkill

-- Primary & Foreign Key creation - way 1
create table tblEmployee
(id int identity(101 ,1) constraint pk_emp primary key ,
name varchar(50) not null ,
phonenumber varchar(15) unique,
area varchar(50) constraint fk_area foreign key references tblArea(area))

sp_help tblEmployee

-- Primary & Foreign Key creation - way 2
create table tblEmployee2
(id int identity(101 ,1) constraint pk_emp primary key ,
name varchar(50) not null ,
phonenumber varchar(15) unique,
area varchar(50) constraint fk_area foreign key references tblArea(area))

create table tblEmployeeSkill
(emp_id int constraint fk_eid foreign key references tblEmployee(id),
skill varchar(50)constraint fk_skill foreign key references tblSkill(skill) ,
skill_level float check(skill_level >= 1 and skill_level <= 10), constraint pk_empskill primary key(emp_id , skill))


sp_help tblEmployeeSkill


create database dbShop



