--------------------------Database Creation----------------
create database CowBullGame
use CowBullGame


-------------Table for storing users-------------------------
create table Users
(id int identity(101,1) constraint pk_users primary key,
name varchar(50),
age int,
password varchar(50))

drop table Users

------------Table for storing user attempts-------------------------
create table Attempts
(id int constraint fk_user foreign key references Users(id),
Gueword varchar(50),
Givword varchar(50) ,
AttemptCount int)

drop table Attempts
-------------------------Procedure to get user details-----------------

create proc proc_GetUsers(@id int)
as
	select * from users where id = @id

exec proc_GetUsers 101

drop proc proc_GetUsers

---------------------------Procedure to add user details----------------
create or alter proc proc_AddUsers(@name varchar(50) , @age int , @password varchar(50))
as
	insert into Users values(@name ,@age,@password)

exec proc_AddUsers 'Mikasa' , 22 , 'Mikasa22'

drop proc proc_AddUsers

-------------------------Procedure To Add Attempt Details---------------------
create proc proc_AddAttempts(@id int ,@Gueword varchar(50), @Givword varchar(50) , @Attempts int) 
as
	insert into Attempts values(@id , @Gueword ,@Givword , @Attempts)

exec proc_AddAttempts 101 , 'Grisha' , 2
----------------------------Get Recent Id----------------------------------------
create proc proc_GetRecentUserid
as
	select max(id) from users
exec proc_GetRecentUserid

drop proc proc_AddAttempts
-----------------------------Procedure To Get Attempt Details-----------------
create proc proc_GetAttempts(@id int)
as
	select * from Attempts where id = @id
exec proc_GetAttempts 101

drop proc proc_GetAttempts

------------------------------------------------------------------------------

-----------------Procedure To Get All Attempts----------------
create proc proc_GetAllAttempts
as
	select * from Attempts
---------------------------------------------------------------
-------------------Procedure to Get All Users------------------------
create proc proc_GetAllUsers
as
	select * from Users
exec proc_GetAllUsers

exec proc_GetAllAttempts

select * from Users
select * from Attempts
