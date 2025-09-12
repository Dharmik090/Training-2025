/*
1.	Display students with their enrolled course names using INNER JOIN.
2.	Display all students even if they are not enrolled in any course (LEFT JOIN).
3.	Display all courses and their students (RIGHT JOIN).
4.	Find highest, lowest, and average marks per subject.
5.	Count how many male and female students exist.
*/

-- 1. 
SELECT s.student_id, s.name, c.course_name
FROM Students s
INNER JOIN Courses c ON s.course_id = c.course_id;

-- 2. 
SELECT s.student_id, s.name, c.course_name
FROM Students s
LEFT JOIN Courses c ON s.course_id = c.course_id;

-- 3. 
SELECT s.student_id, s.name, c.course_name
FROM Students s
RIGHT JOIN Courses c ON s.course_id = c.course_id;

-- 4. 
SELECT subject,
       MAX(score) AS highest,
       MIN(score) AS lowest,
       AVG(score) AS average
FROM Marks
GROUP BY subject;

-- 5. 
SELECT gender, COUNT(*) AS total
FROM Students
GROUP BY gender;
