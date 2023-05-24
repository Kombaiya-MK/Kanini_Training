use pubs

select * from stores

select * from sales

--Query 1 Print the store ID and number of orders from the store

select s1.stor_id , count(ord_num) 'Number of Orders' from 
stores s1 join sales s2 
on s1.stor_id = s2.stor_id
group by s1.stor_id

--Query 1 Print the store ID and number of orders from the store
select stor_id , COUNT(ord_num) 'Number of Orders' from sales group by stor_id

--Query 2 print the numebr of orders for every title

select * from titles
select * from sales

select title , count(ord_num) from 
titles t join sales s
on t.title_id = s.title_id
group by title

--Query 3 print the publisher name and book name

select pub_name , title from 
publishers p join
titles t on
p.pub_id = t.pub_id

--Query 4 Print the author full name for all the authors

select * from authors

select CONCAT(au_fname , ' ' , au_lname) 'Author Fullname' from authors

--Query 5 Print the price of every book with tax (price+price*12.36/100)

--Method 1
select title , (price + (price*12.36/100)) as 'Updated Price' from titles

--Method 2
update titles set price = price + (price*12.36/100)
select title , price from titles

--Query 6 Print the author name, title name

select CONCAT(au_fname , ' ' , au_lname) 'Author Fullname' , title from 
 titleauthor ta join titles t on
 ta.title_id = t.title_id
 join authors a on
 ta.au_id = a.au_id
 
 --Query 7 print the author name, title name and the publisher name

 select CONCAT(au_fname , ' ' , au_lname) 'Author Fullname' , title ,pub_name from 
 titleauthor ta join titles t on
 ta.title_id = t.title_id
 join authors a on
 ta.au_id = a.au_id
 join publishers p on
 t.pub_id = p.pub_id

 --Query 8 Print the average price of books pulished by every publicher

 select * from publishers

 select pub_name , avg(price) 'Average book price' from 
 publishers p join titles  t
 on p.pub_id = t.pub_id
 group by pub_name


  --Query 9 print the books written by 'Marjorie'

  select * from authors

  select CONCAT(au_fname , ' ' , au_lname) 'Author Fullname' , title from 
 titleauthor ta join titles t on
 ta.title_id = t.title_id
 join authors a on
 ta.au_id = a.au_id
 where au_fname = 'Marjorie'

 --Query 10 Print the order numbers of books published by 'New Moon Books'

 select  title , ord_num from titles t
 join publishers p on t.pub_id = p.pub_id
 join sales s on t.title_id = s.title_id
 where pub_name='New Moon Books'

 --Query 11 Print the number of orders for every publisher
 select pub_name , count(ord_num) 'Total Number of Orders' from titles t
 join publishers p on t.pub_id = p.pub_id
 join sales s on t.title_id = s.title_id
 group by pub_name

 --Query 12  print the order number , book name, quantity, price and the total price for all orders
 select title , ord_num , price , qty , (qty*price) as total_price from titles t
 join publishers p on t.pub_id = p.pub_id
 join sales s on t.title_id = s.title_id

 --Query 13 print the total order quantity for every book
select title , sum(qty) 'Total order quantity' from titles t
 join publishers p on t.pub_id = p.pub_id
 join sales s on t.title_id = s.title_id
 group by title

 --Query 14 print the total ordervalue for every book
 select title , sum(qty*price) as total_price from titles t
 join publishers p on t.pub_id = p.pub_id
 join sales s on t.title_id = s.title_id
 group by title

 --Query 15 print the orders that are for the books published by the publisher for which 'Paolo' works for

 select title , ord_num , ord_date , price , qty , payterms  from titles t
 join sales s on t.title_id = s.title_id
 join employee e on t.pub_id = e.pub_id
 where fname = 'Paolo'










