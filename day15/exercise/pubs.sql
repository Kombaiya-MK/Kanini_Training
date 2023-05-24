use pubs

--Query 1 Fetch all the titles and the details of titles that have been sold

select distinct title from titles t
right outer join sales s on 
t.title_id = s.title_id

--Query 2 Print the book name, publisher name and the sale quantity of all the titles and fetch all the publisher

select title , pub_name , qty from titles t 
left outer join sales s on t.title_id = s.title_id
right outer join publishers p on t.pub_id = p.pub_id


--Query 3 print the details of the sale when the sale quantity is greater than the sale quantity of all the same titles sold in the same store

select * from sales s1 where qty >
(select sum(qty) from sales s2 
where s1.stor_id = s2.stor_id and 
s1.title_id = s2.title_id
group by stor_id , title_id
)


--Query 4 Print the average price of every author's books withthe author's full name

select CONCAT(au_fname , ' ' , au_lname) 'Author Fullname' , avg(price) 'Average Income' from titleauthor ta
join titles t on ta.title_id = t.title_id
right outer join authors a on a.au_id = ta.au_id 
group by CONCAT(au_fname , ' ' , au_lname)

--Query 5 Print the schema of the titles table and locate all teh constrants
sp_help titles

--Query 6 Print the sale details of the books 
--that are authored by authors who come from city 
--which has more authors than the count of authors coming from 'UT'

select * from sales where title_id in  
(select title_id from titleauthor where au_id in 
(select au_id from authors where state in 
(select state from authors group by state having count(au_id) > 
(select COUNT(au_id) from authors where state = 'UT' )))
)


--Query 7 Print the Store details if any sale is made for the book sold in quantity 3

select * from stores where stor_id in 
(select stor_id from sales where qty = 3)

--Query 8 Print the details of the books that have been authored by more than 1 author.

select * from titles where title_id in 
(select title_id from titleauthor 
group by title_id having count(title_id) > 1)

--Query 9 Print the number of books that been authored by more than one author and 
--published by publisher who have more than 2 employees

select count(distinct title_id) 'Number of books' from titleauthor where title_id in 
(select title_id  from titleauthor where title_id in 
(select title_id from titles where pub_id in 
(select pub_id from publishers where pub_id in 
(select pub_id from employee group by pub_id having count(emp_id) > 2 )))
group by title_id having COUNT(title_id) > 1)



select count(distinct title) 'Number of books' from titleauthor  ta
join titles t on t.title_id = ta.title_id
join publishers p on p.pub_id = t.pub_id
join employee e on e.pub_id = p.pub_id
group by e.pub_id , ta.title_id having COUNT(ta.title_id) > 1 and count(e.emp_id) > 2 

--Query 10 Print the store name, title name,, quantity, sale amount, pulisher name, author name for all the sales. 
--Also print those books which have not been sold and authors who have not written.

select stor_name , title , qty , (qty * price) 'Sale Amount' , pub_name , CONCAT(au_fname , ' ' , au_lname) 'Author Fullname' from titles t
left outer join publishers p on t.pub_id = p.pub_id
full outer join titleauthor ta on ta.title_id = t.title_id
full outer join authors a on a.au_id = ta.au_id
left outer join sales s on s.title_id = t.title_id
full outer join stores st on st.stor_id = s.stor_id


