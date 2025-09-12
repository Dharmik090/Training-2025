/*
1.	Write a query to fetch all students above age 20.
2.	Fetch all students ordered by name alphabetically.
3.	Show total number of students enrolled in each course using GROUP BY.
4.	Show courses that have more than 2 students using HAVING.
*/

-- 1. 
SELECT * FROM Students
WHERE age > 20;

-- 2. 
SELECT * FROM Students
ORDER BY name ASC;

-- 3. 
SELECT course_id, COUNT(*) AS total_students
FROM Students
GROUP BY course_id;

-- 4. 
SELECT course_id, COUNT(*) AS total_students
FROM Students
GROUP BY course_id
HAVING COUNT(*) > 2;
