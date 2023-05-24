use Northwind


--Selection Query--


---Select all the data from products
select * from Products

--data which has unitprice greater than 15
select * from Products where UnitPrice >= 15

--data which has ReorderLevel greater than 0
select * from Products where ReorderLevel > 0

--data which has ReorderLevel greater than 0 and less than 20
select * from Products where ReorderLevel > 0 and ReorderLevel < 20

--data which has ReorderLevel between 0 and 20
select * from Products where ReorderLevel between 1 and 20

--data which has SupplierID equal to 8
select * from Products where SupplierID = 8

--data which has SupplierID equal to 8 and 13
select * from Products where SupplierID = 8 or SupplierID = '13'


--products supplied by suppliers 8 , 13 , 21 and 24
select * from Products where SupplierID = 8 or SupplierID = '13'  or SupplierID = '21' or SupplierID = '24'

select * from Products where SupplierID in (8,13,21,24)

select * from Products where UnitPrice > 12

select * from Products where UnitPrice > min(12 , 16)


select * from Products where UnitsInStock > 0

select * from Products where UnitPrice <= 25

select * from Products where Discontinued = 1


--Projection Queries
select ProductName , UnitPrice from Products where UnitPrice >= 25

--Renaming Column name in projection

--Way 1
select ProductName , UnitPrice as PricePerUnit from Products where UnitPrice >= 25
--Way 2
select ProductName , UnitPrice  PricePerUnit from Products where UnitPrice >= 25
--Way 3
select ProductName , UnitPrice  'Price Per Unit' from Products where UnitPrice >= 25


select 'hello'
select 'hello' 'column1' , 12 'column2'
print 'hellll'

select ProductName 'ProductName' from Products
select * from Products


--print the product name and its Discontinued status which is in Stock and price range between 10 and 20
select ProductName , Discontinued 'Discontinued Status' from Products where UnitsInStock > 0 and UnitPrice between 10 and 20

--products which are not discontinued and not having the supplier id of 8 and 13
select ProductName 'Product Name', UnitPrice 'Price Per Unit' from Products where Discontinued = 0 and SupplierID not in (8,13)
select ProductName 'Product Name', UnitPrice 'Price Per Unit' from Products where Discontinued = 0 and SupplierID != 8 and SupplierID != 13


--Products that been reorderd and from the categories of (2,3,7)
select ProductName 'Product Name', QuantityPerUnit 'Quantity Per Unit' from Products where ReorderLevel > 0 and CategoryID in (2,3,7)

select ProductName 'Product Name', QuantityPerUnit 'Quantity Per Unit' from Products where ReorderLevel > 0 and CategoryID = 2 or CategoryID = 3 or CategoryID = 7 

select ProductName 'Product Name', QuantityPerUnit 'Quantity Per Unit' from Products where ReorderLevel > 0 and (CategoryID = 2 or CategoryID = 3 or CategoryID = 7 )


select * from products

--Filtering in String values
select * from products where QuantityPerUnit like ('%jars%')
select * from products where ProductName like ('_o%')

select * from products where ProductName like ('_o%') and ProductName not like('% %')


--products with last char as e
select * from products where ProductName like ('%e')

--products with last but one char as b
select * from products where ProductName like ('%b_')

--products which are measured in kg
select * from products where QuantityPerUnit like ('%kg%') and QuantityPerUnit not like ('%pkg%')


--Select only first two records of the table

select top 20 percent * from Products

select top 2 productName , UnitPrice from products 


select CategoryID from Products

select distinct CategoryID from Products

select distinct CategoryID , SupplierID from Products

--Sorting---

select * from products order by CategoryID ASC

select * from products order by CategoryID DESC 

select * from products order by CategoryID , UnitsInStock

select * from products order by CategoryID desc , UnitsInStock asc 


--print the products that contains o and e in their name and have stock and not discontinued
-- and also sort them unitprice in ascending order

select * from products where ProductName like('%o%') and ProductName like('%e%') and UnitsInStock > 0 and Discontinued = 0 order by UnitPrice desc   

select * from products where ProductName like('e%')

--print the product name and quantity per unit that have been reordered and have unitprice between 20 and 25 and not supplied by 7,11 and 14
--sort them by category id and then supplier id
select ProductName , QuantityPerUnit from products where ReorderLevel > 0 and UnitPrice between 20 and 25 and SupplierID not in (7,11,14) order by CategoryID , SupplierID


---Aggregation Functions
select sum(unitprice) 'Sum of Price' , avg(UnitPrice) 'Average of Price' from products

select CategoryID, sum(unitprice) 'Sum of Price' , avg(UnitPrice) 'Average of Price' from products where  CategoryID % 2 = 0 --CategoryID in(1,2,4,8)

select discontinued, sum(unitprice) 'Sum of Price' , avg(UnitPrice) 'Average of Price' from products group by Discontinued

select CategoryID, sum(unitprice) 'Sum of Price' , avg(UnitPrice) 'Average of Price' from products group by CategoryID order by avg(UnitPrice)

select 
	CategoryID, 
	sum(unitprice) 'Sum of Price' , 
	avg(UnitPrice) 'Average of Price' 
from products group by CategoryID order by 2 --second column in the projection

select 
	CategoryID, 
	sum(unitprice) 'Sum of Price' , 
	avg(UnitPrice) 'Average of Price' 
from products where Discontinued = 0  group by CategoryID 
having sum(unitprice) > 200 order by 'Average of Price'

select 
	CategoryID, 
	sum(unitprice) 'Sum of Price' , 
	avg(UnitPrice) 'Average of Price' 
from products where CategoryID % 2 = 0  group by CategoryID 
having sum(unitprice) > 200  order by 'Average of Price'

select * from Products

select SupplierID , sum(UnitsInStock) 'Sum of Stocks' from Products
where 
	CategoryID not in (3,4) and 
	ReorderLevel > 0 and 
	Discontinued = 0 
group by SupplierID having sum(UnitsInStock) > 30 order by SupplierID  desc


select * from Products
where SOUNDEX(productName) = SOUNDEX('chaii')

select cast(125.99 as int) 
select round(125.99 , 1) 
select round(125.99 , -1)
select round(125.99 , -2)