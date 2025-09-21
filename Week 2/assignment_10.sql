/*
1.	Create a View StudentCourseView that shows student name + course name.
2.	Query from the view to find students enrolled in “Database Systems”.
3.	Export your database using Workbench (Backup).
4.	Restore it into a new schema StudentDB_Copy.
*/

-- 1.
CREATE VIEW StudentCourseView AS
SELECT s.name AS student_name, c.course_name
FROM Students s
JOIN Courses c ON s.course_id = c.course_id;

-- 2.
SELECT * FROM StudentCourseView
WHERE course_name = 'Database Systems';

