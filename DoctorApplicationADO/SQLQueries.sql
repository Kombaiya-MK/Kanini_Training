create database doctorAppointment
use doctorAppointment

drop table doctors

create table doctors
(doctor_id int identity(101,1) constraint pk_doctors primary key ,
doctor_name varchar(50),
doctor_experience int);

drop table patients
create table patients
(patient_id int identity(101,1) constraint pk_patients primary key,
patient_name varchar(50),
patient_age int,
patient_phoneNumber varchar(10))

drop table BookAppointment
create table BookAppointment
(Appointment_id int identity(1,1),
patient_id int constraint fk_patient Foreign Key references patients(patient_id),
doctor_id int constraint fk_doctors Foreign Key references doctors(doctor_id),
slot int constraint fk_slot_Booking foreign key references SessionDetails(Session_slot) 
Primary Key(patient_id , doctor_id,slot));

sp_help BookAppointment
drop table SessionDetails

create table SessionDetails
(Session_slot int,
Consultant_Fee Money,
constraint pk_session Primary Key(Session_slot));

select * from SessionDetails

alter table SessionDetails
add AppointmentDate date;
sp_help doctors

--Procedure for adding doctors
create proc proc_addDoctors(@name varchar(50) , @exp int)
as
	insert into doctors values(@name , @exp)



exec proc_addDoctors 'Naruto' , 10

create proc proc_showDoctors
as
	select * from doctors

exec proc_showDoctors

select * from patients
sp_help patients

create proc proc_addPatients(@name varchar(50) , @age int , @phn varchar(10))
as
	insert into patients values(@name , @age , @phn)

exec proc_addPatients 'Hinata Hyuga' , 21 , '9807181723'

create proc proc_showPatients
as	
	select * from patients	

create proc proc_GetSinglePatient(@id int)
as
	select * from patients where patient_id = @id
exec proc_GetSinglePatient 101
exec proc_showPatients

create proc proc_delDoctors(@id int)
as
	delete doctors where doctor_id = @id
exec proc_delDoctors 101
exec proc_showDoctors

--Del patients
create proc proc_delPatients(@id int)
as
	delete patients where patient_id = @id

exec proc_delPatients 101
exec proc_showPatients

--Get recent doctor id
create proc proc_GetRecentId
as 
	select max(doctor_id) from doctors

exec proc_GetRecentId

exec proc_showDoctors

create proc proc_GetRecentPid
as 
	select max(patient_id) from patients
exec proc_GetRecentPid

exec proc_showPatients
exec proc_showDoctors

exec proc_addPatients 'abc' , 22 , '9876543210'

create proc proc_GetSingleDoctor(@id int)
as
	select * from doctors where doctor_id = @id
exec proc_GetSingleDoctor 102

exec proc_delPatients

select * from BookAppointment
drop table SessionDetails
sp_help BookAppointment
alter table BookAppointment
add ConsultantFee money;
-------------------------------------------
--Add Appointments
create proc proc_AddAppointments(@pId int , @dId int ,@slot int , @fee money)
as
	insert into BookAppointment values( @pId , @dId , @slot , @fee)

exec proc_AddAppointments 102,102,1,200
-----------------------------------------
--Show All Appointments
create proc proc_ShowAllAppointments
as 
	select * from BookAppointment

exec proc_ShowAllAppointments
----------------------------------------
--Show Patient Appointments
create proc proc_ShowPatientAppointments(@pid int)
as
	select * from BookAppointment where patient_id = @pid
exec proc_ShowPatientAppointments 102
----------------------------------------------
--Del appointments
create proc proc_DelAppointment(@AppId int)
as
	delete BookAppointment where Appointment_id = @AppId
------------------------------------------------------
--Get Recent ID
create proc proc_GetRecentAppId
as
	select max(Appointment_id) from BookAppointment
exec proc_GetRecentAppId

sp_help BookAppointment
exec proc_AddAppointments 102 , 102 , 2 , 200
exec proc_ShowAllAppointments
alter table BookAppointment
Drop constraint PK__BookAppo__0457AA0E9FDAE5D5

alter table BookAppointment
Add Constraint Pk_BookApp Primary Key(doctor_id , slot)

alter table BookAppointment
alter column ConsultantFee float

select * from doctors
select * from patients

select * from BookAppointment

exec proc_DelAppointment 4