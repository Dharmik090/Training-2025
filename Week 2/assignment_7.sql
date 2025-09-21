/*
1.	Write a query to list all distinct course names from Courses and Marks tables (use UNION).
2.	Write another query to include duplicates (use UNION ALL).
*/

-- 1.
SELECT course_name AS name FROM Courses
UNION
SELECT subject AS name FROM Marks;


-- 2.
SELECT course_name AS name FROM Courses
UNION ALL
SELECT subject AS name FROM Marks;