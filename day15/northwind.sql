use Northwind

select ProductName , CategoryName from Products p
right  outer join Categories c on 
p.CategoryID = c.CategoryID

select count(productName) from Products

---Outer Join 
use dbEmployeeDetails

select * from tblEmployee
select * from tblArea

select name , e.area , zipcode from 
tblEmployee e right outer join tblArea  a
on e.area = a.area


use pubs

select concat(au_fname , ' ',au_lname) Author_name ,pub_name , title  from titleauthor ta 
right outer join titles t on t.title_id = ta.title_id
join authors a on ta.au_id = a.au_id
join publishers p on p.pub_id = t.pub_id


use Northwind

 use Northwind

 select emp.firstname 'Employee Name',
mgr.FirstName 'Manager Name'
from Employees emp left join Employees mgr
on emp.reportsTO = mgr.EmployeeID

use pubs

select pub_name , title , au_fname from titles t 
right join publishers p 
on t.pub_id = p.pub_id
left outer join titleauthor ta 
on ta.title_id = t.title_id
left outer join authors a 
on a.au_id = ta.au_id


use Northwind

 select emp.firstname 'Employee Name',
mgr.FirstName 'Manager Name'
from Employees emp left outer join Employees mgr
on emp.reportsTO = mgr.EmployeeID


select * from Products where exists (select * from Shippers)

select * from Products union 
select * from Shippers

select AVG(unitprice) from Products
--Print the product details that have price greater than the products that comes under the category 'seafood'

	select * from Products  where UnitPrice >
	(select max(unitprice) from Products where CategoryID = 
	(select CategoryID from Categories where CategoryName = 'seafood'))
--or

select * from Products  where UnitPrice > all
(select unitprice from Products where CategoryID = 
(select CategoryID from Categories where CategoryName = 'seafood'))


--Print the product details that have price less than the products that comes under the category 'seafood'

select * from Products  where UnitPrice >
	(select min(unitprice) from Products where CategoryID = 
	(select CategoryID from Categories where CategoryName = 'seafood'))
--or

select * from Products  where UnitPrice > any
(select unitprice from Products where CategoryID = 
(select CategoryID from Categories where CategoryName = 'seafood'))

select * from Products where CategoryID = (select CategoryID from Categories where CategoryName = 'seafood') 


--Co-related Sub queries
--the average price of the products from the same category

select * from products p1 where unitprice > 
(select avg(unitprice) from Products p2 where 
p1.CategoryID = p2.CategoryID group by CategoryID)

select * from Products p1 where unitprice > 
(select avg(unitprice) from Products p2 where
p1.CategoryID = p2.CategoryID
group by CategoryID)

--print the product details of products which have been ordered
-- if the ordered quantity is less than the average of quantity ordered 

select * from [Order Details]
select * from Products
select * from Products where ProductID in 
(select ProductID from  [Order Details] p1 where Quantity < 
(select avg(quantity) from [Order Details] p2 where
p1.ProductID = p2.ProductID group by ProductID))


--union & Union all

select * from products where CategoryID = 
(select CategoryID from Categories where CategoryName ='seafood')
union
select * from Products where ProductID in 
(select ProductID from [Order Details] where Quantity > 100)

select * from products where CategoryID = 
(select CategoryID from Categories where CategoryName ='seafood')
union all
select * from Products where ProductID in 
(select ProductID from [Order Details] where Quantity > 100)

select * from products where CategoryID = 
(select CategoryID from Categories where CategoryName ='seafood')
intersect
select * from Products where ProductID in 
(select ProductID from [Order Details] where Quantity > 100)

select   * from Products , Employees

select * from Products cross join Employees