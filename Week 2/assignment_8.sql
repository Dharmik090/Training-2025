/*
1.	Add a PRIMARY KEY on student_id.
2.	Add an AUTO_INCREMENT to course_id.
3.	Create an INDEX on email for faster search.
4.	Prove query optimization difference using EXPLAIN with and without index.
*/

-- 1.
ALTER TABLE Students
ADD PRIMARY KEY (student_id);

-- 2.
ALTER TABLE Courses
MODIFY course_id INT AUTO_INCREMENT;

-- 3.
CREATE INDEX idx_email ON Students(email);

-- 4.
EXPLAIN SELECT * FROM Students WHERE email = 'alice.johnson@email.com';