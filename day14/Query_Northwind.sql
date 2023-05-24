use Northwind

select * from Categories

--Sub Queries


--Fetch the products under the category of Seafood

-- Brute Force Method
select CategoryID from Categories where CategoryName = 'Seafood'
select * from Products where CategoryID = 8


--Sub query lvl 1

select * from Products where CategoryID = 
(select CategoryID from Categories where CategoryName = 'Seafood')


--Sub query multi lvl
select * from Products where CategoryID in
(select CategoryID from Categories where CategoryName like '%p%')

--Get all the order details for the product 'valkoinen suklaa'

select * from Products where ProductName = 'valkoinen suklaa'

select * from [Order Details] where ProductID = (select ProductID from Products where ProductName = 'valkoinen suklaa')


select * from [Order Details] where ProductID in (select ProductID from Products where ProductName like '%p%')

--Two Level nested sub query
select * from Orders where OrderID in (
select distinct OrderID from [Order Details] where ProductID = (
select ProductID from Products where ProductName = 'valkoinen suklaa'))


--Get all the info about the customers who ordered 'valkoinen suklaa'
select * from Customers where CustomerID in
(select distinct CustomerID from Orders where OrderID in 
(select distinct OrderID from [Order Details] where ProductID = 
(select ProductID from Products where ProductName = 'valkoinen suklaa')))


select * from Region

--Get Employee details who are all from northern region
select * from Employees where EmployeeID in 
(select distinct EmployeeID from EmployeeTerritories where TerritoryID in 
(select distinct TerritoryID from Territories where RegionID = 
(select RegionID from Region where RegionDescription = 'northern')))

select * from Employees where EmployeeID in 
(select distinct EmployeeID from EmployeeTerritories where TerritoryID in 
(select distinct TerritoryID from Territories where RegionID = 
(select RegionID from Region where RegionDescription like ('norther%'))))


select  Territor COUNT(Em) from Territories where TerritoryID in 
(select TerritoryID from Territories where RegionID =
(select RegionID from Region where RegionDescription like ('norther%'))) group by TerritoryID



--Get the number of products ordered by the customer that the product comes under the category of 'Beverages'
select CustomerID , count(CustomerID) No_of_Customers from Orders where OrderID in 
(select OrderID  from [Order Details] where ProductID in 
(select ProductID from Products where CategoryID = 
(select CategoryID from Categories where CategoryName = 'Beverages')) )
group by CustomerID having count(CustomerID) > 0 order by count(CustomerID) asc


select count(orderID) 'No of Orders by Speedy Express' from Orders  where ShipVia = 
(select ShipperID from Shippers where CompanyName = 'Speedy Express')

select * from Shippers

select EmployeeID,count(orderID) 'No of Orders executed by Employees' from Orders where EmployeeID in  
(select distinct EmployeeID from EmployeeTerritories where TerritoryID in 
(select distinct TerritoryID from Territories where RegionID = 
(select RegionID from Region where RegionDescription like ('norther%'))))
group by EmployeeID


select * from orders

--Joins 

select ProductName , CategoryName from Products inner join Categories on Products.CategoryID = Categories.CategoryID

select ProductName , CategoryName from Products join Categories on Products.CategoryID = Categories.CategoryID


--print the customer name  , order id , order date from customer and order table
select Orders.OrderID , OrderDate ,ContactName from Orders join  Customers on Orders.CustomerID = Customers.CustomerID

--or using instance name
select OrderID , OrderDate ,ContactName 
from Orders o 
join  Customers c
on o.CustomerID = c.CustomerID

--Joining more than two tables
--SupplierID , CompanyName , ProductName , CategoryName

select ProductName , CategoryName  , CompanyName 
from Products p
join Categories c on p.CategoryID = c.CategoryID
join Suppliers s on p.SupplierID = s.SupplierID


--where in joins
select ProductName , CategoryName  , CompanyName 
from Products p
join Categories c on p.CategoryID = c.CategoryID
join Suppliers s on p.SupplierID = s.SupplierID
where CategoryName like '%e%'


select ProductName , CategoryName  , CompanyName 
from Products p
join Categories c on p.CategoryID = c.CategoryID
join Suppliers s on p.SupplierID = s.SupplierID
where ProductID in (select distinct ProductID from [Order Details] where ProductID = 24)

select * from [Order Details]

select CategoryName , count(productid) 'Number of products' from 
Products p join Categories c on 
p.CategoryID = c.CategoryID
group by CategoryName


select * 
from Products p
join Categories c on p.CategoryID > c.CategoryID
join Suppliers s on p.SupplierID < s.SupplierID


select ContactName , COUNT(orderid) 'Number of orders'
from Orders o join  Customers c
on o.CustomerID = c.CustomerID 
group by ContactName

select EmployeeID , COUNT(orderid) from orders group by EmployeeID

-- Join On Single Table
select CONCAT(Emp.FirstName , ' ' ,Emp.LastName )  'Employee Name' , CONCAT(Mgr.FirstName , ' ' ,Mgr.LastName ) 'Manager Name' from 
Employees Emp join Employees Mgr 
on Emp.ReportsTo = Mgr.EmployeeID

select CONCAT(Emp.FirstName , ' ' ,Emp.LastName )  'Employee Name' , CONCAT(Mgr.FirstName , ' ' ,Mgr.LastName ) 'Manager Name' from 
Employees Emp left outer join Employees Mgr 
on Emp.ReportsTo = Mgr.EmployeeID

select mgr.FirstName 'Manager Name' , count(Emp.FirstName)  'Employee Name'  from 
Employees Emp left outer join Employees Mgr 
on Emp.ReportsTo = Mgr.EmployeeID group by mgr.FirstName


---Manager Name and number of employees reporting him
select mgr.FirstName 'Manager Name' , count(Emp.EmployeeID)  'Number of Employees'  from 
Employees Emp join Employees Mgr 
on Emp.ReportsTo = Mgr.EmployeeID group by mgr.FirstName


select CONCAT(Mgr.FirstName , ' ' ,Mgr.LastName ) 'Manager Name' , count(Emp.EmployeeID)  'Number of Employees'  from 
Employees Emp join Employees Mgr 
on Emp.ReportsTo = Mgr.EmployeeID group by CONCAT(Mgr.FirstName , ' ' ,Mgr.LastName )




select FirstName , LastName, RegionDescription , TerritoryDescription 
from Region join Territories on Region.RegionID = Territories.RegionID

select * from Employees