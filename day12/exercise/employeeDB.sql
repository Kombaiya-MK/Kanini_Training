create database dbEmployee
use dbEmployee

--EMP table Creation

create table tblEmp(
	emp_no int constraint pk_emp primary key ,  
	emp_name varchar(50), 
	emp_salary int , 
	emp_deptname varchar(50) , 
	emp_bossno int constraint fk_emp_no foreign key(emp_bossno) references tblEmp(emp_no)
)

sp_help tblEmp

insert into tblEmp
values(1,'Alice',75000,'Management',null),
(2,'Ned',45000,'Marketing',1),
(3,'Andrew',25000,'Marketing',2),
(4,'Clare',22000,'Marketing',2),
(5,'Todd',38000,'Accounting',1),
(6,'Nancy',22000,'Accounting',5),
(7,'Brier',43000,'Purchasing',1),
(8,'Sarah',56000,'Purchasing',7),
(9,'Sophile',35000,'Personnel',1),
(10,'Sanjay',15000,'Navigation',3),
(11,'Rita',15000,'Books',4),
(12,'Giji',16000,'Clothes',4),
(13,'Maggie',11000,'Clothes',4),
(14,'Paul',15000,'Equipment',3),
(15,'James',15000,'Equipment',3),
(16,'Pat',15000,'Furniture',3),
(17,'Mark',15000,'Recreation',3)


--creation of department table
create table tblDept(
	dept_name varchar(50),
	dept_floor int,
	dept_phone int,
	mgr_id int constraint fk_mgr_id foreign key references tblEmp(emp_no) Not Null,
	constraint pk_key primary key(dept_name)
)

--Insertion of records into department table
insert into tblDept
values('Management',5,34,1),
('Books',1,81,4),
('Clothes',2,24,4),
('Equipment',3,57,3),
('Furniture',4,14,3),
('Navigation',1,41,3),
('Recreation',2,29,4),
('Accounting',5,35,5),
('Purchasing',5,36,7),
('Personnel',5,37,9),
('Marketing',5,38,2)

--creation of Item's table

create table tblItem(
	item_name varchar(50) constraint pk_item_name primary key,
	item_type varchar(50),
	item_color varchar(50)
)


--Insertion of records into items table
insert into tblItem
values('Pocket Knife-Nile','E','Brown'),
('Pocket Knife-Avon','E','Brown'),
('Compass','N',Null),
('Geo positioning system','N',NULL),
('Elephant Polo stick','R','Bamboo'),
('Camel Saddle','R',NULL),
('Sextant','N',NULL),
('Map Measure','N','Green'),
('Boots-snake proof','C','Khaki'),
('Pith Helmet','C','White'),
('Hat-polar Explorer','C',NULL),
('Exploring in 10 Easy Lessons','B','Khaki'),
('Hammock','F','Brown'),
('How to win foreign friends','B',NULL),
('Map case','E','Brown'),
('Safari chair','F','Khaki'),
('Safari cooking kit','F','Khaki'),
('Stetson','C','Black'),
('Tent-2 person','F','Khaki'),
('Tent-8 person','F','Khaki')

--Creation of Sales Table
create table tblSales(
	sales_no int constraint pk_sales_no primary key,
	sale_qty int,
	item_name varchar(50),
	dept_name varchar(50) constraint fk_dept_name foreign key references tblDept(dept_name),
	constraint fk_item_name foreign key(item_name) references tblItem(item_name)
)

--Insertion of records into sales table
insert into tblSales
values(101,2,'Boots-snake proof','Clothes'),
(102,1,'Pith Helmet','Clothes'),
(103,1,'Sextant','Navigation'),
(104,3,'Hat-polar Explorer','Clothes'),
(105,5,'Pith Helmet','Equipment'),
(106,2,'Pocket Knife-Nile','Clothes'),
(107,3,'Pocket Knife-Nile','Recreation'),
(108,1,'Compass','Navigation'),
(109,5,'Geo Positioning system','Navigation'),
(110,1,'Map Measure','Navigation'),
(111,1,'Geo positioning system','Books'),
(112,3,'Sextant','Books'),
(113,1,'Pocket Knife-Nile','Books'),
(114,1,'Pocket Knife-Nile','Navigation'),
(115,1,'Pocket Knife-Nile','Equipment'),
(116,1,'Sextant','Clothes'),
(117,1,'Sextant','Equipment'),
(118,1,'Sextant','Recreation'),
(119,1,'Sextant','Furniture'),
(120,1,'Pocket Knife-Nile','Furniture'),
(121,1,'Exploring in 10 easy lessons','Books'),
(122,1,'How to win foreign friends','Books'),
(123,1,'Compass','Books'),
(124,1,'Pith Helmet','Books'),
(125,1,'Elephant Polo stick','Recreation'),
(126,1,'Camel Saddle','Recreation')



select *from tblSales
select *from tblItem


