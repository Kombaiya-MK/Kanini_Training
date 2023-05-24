
create table products
(product_id int identity(1,1) constraint pk_products primary key ,
product_name varchar(50) , product_price int )

sp_help products

create table supplier 
(supplier_id int constraint pk_supplier primary key , supplier_name varchar(50))

drop table supplier

sp_help supplier


create table tblProductSupplier
(product_id int identity(1,1) constraint fk_product foreign key references tblProducts(product_id),
supplier_id int constraint fk_supplier foreign key references tblSupplier(supplier_id) , constraint pk_productSupplier primary key(product_id,supplier_id))

sp_help tblProductSupplier

create table customer
(customer_id int identity(1,1) constraint pk_customer primary key , customer_name varchar(50))

drop table customer

