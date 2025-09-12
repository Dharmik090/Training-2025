/*
1.	Create tables:
    o	Students (student_id, name, age, gender, course_id)
    o	Courses (course_id, course_name, duration)
    o	Marks (mark_id, student_id, subject, score)
2.	Modify Students table to add a new column email.
3.	Drop the Marks table and recreate it with the same structure.
*/

USE StudentDB;

-- 1. 
CREATE TABLE Courses (
    course_id INT PRIMARY KEY,
    course_name VARCHAR(20),
    duration INT
);

CREATE TABLE Students (
    student_id INT PRIMARY KEY,
    name VARCHAR(50),
    age INT,
    gender VARCHAR(10),
    course_id INT,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id)
);

CREATE TABLE Marks (
    mark_id INT PRIMARY KEY,
    student_id INT,
    subject VARCHAR(20),
    score INT,
    FOREIGN KEY (student_id) REFERENCES Students(student_id)
);

-- 2. 
ALTER TABLE Students
ADD COLUMN email VARCHAR(50);

-- 3. 
DROP TABLE Marks;

CREATE TABLE Marks (
    mark_id INT PRIMARY KEY,
    student_id INT,
    subject VARCHAR(20),
    score INT,
    FOREIGN KEY (student_id) REFERENCES Students(student_id)
);
