use pubs

select * from titles

--Query 1 - Print all the titles names

select title from titles


--Query 2 - Print all the titles that have been published by 1389

select * from titles where pub_id = 1389

--Query 3 - Print the books that have price in rangeof 10 to 15

select * from titles where price between 10 and 15

--Query 4 Print those books that have no price

select * from titles where price is null

--Query 5 Print the book names that start with 'The'

select * from titles where title like ('the%')

--Query 6 Print the book names that do not have 'v' in their name

select * from titles where title not like ('%v%')

--Query 7  print the books sorted by the royalty

select * from titles order by royalty

--Query 8 print the books sorted by publisher in descending then by types in asending then by price in descending


select * from titles order by pub_id desc , type asc , price desc

--Query 9 Print the average price of books in every type

select type , avg(price) 'Average Book Price' from titles group by type

--Query 10 print all the types in uniques
select distinct(type) 'Unique Types' from titles

--Query 11 Print the first 2 costliest books

select top 2 title from titles order by price desc

select * from titles
--Query 12 Print books that are of type business and have price less than 20 which also have advance greater than 7000

select * from titles where type = 'business' and (price < 20) and (advance > 7000)

--Query 13 Select those publisher id and number of books which have price between 15 to 25 and have 'It' in its name. Print only those which have count greater than 2. Also sort the result in ascending order of count

select pub_id , count(title_id) from titles
where price between 15 and 25 and title like ('%lt%') group by pub_id having count(title_id) > 2 order by count(title_id) asc

--Query 14 Print the Authors who are from 'CA'

select * from authors

select au_fname , au_lname  from authors where state = 'CA'

--Query 15 Print the count of authors from every state

select state , count(au_id) from authors group by state
