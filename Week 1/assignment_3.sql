/*
1.	Insert at least 5 rows into each table.
2.	Update one student’s course.
3.	Delete a student record.
*/

-- 1. 
INSERT INTO Courses VALUES
(1, 'Computer Science', 36),
(2, 'Mathematics', 24),
(3, 'Physics', 30),
(4, 'Chemistry', 30),
(5, 'English Literature', 20);

INSERT INTO Students VALUES
(101, 'Alice', 22, 'Female', 1, 'alice@mail.com'),
(102, 'Bob', 19, 'Male', 2, 'bob@mail.com'),
(103, 'Charlie', 21, 'Male', 3, 'charlie@mail.com'),
(104, 'Diana', 20, 'Female', 1, 'diana@mail.com'),
(105, 'John', 23, 'Male', 2, 'john@mail.com');

INSERT INTO Marks VALUES
(1, 101, 'Algorithms', 88),
(2, 102, 'Calculus', 76),
(3, 103, 'Mechanics', 92),
(4, 104, 'Databases', 81),
(5, 105, 'Linear Algebra', 69);

-- 2. 
UPDATE Students
SET course_id = 3
WHERE student_id = 102;

-- 3. 
DELETE FROM Students
WHERE student_id = 105;
