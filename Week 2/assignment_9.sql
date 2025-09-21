/*
1.	Write a Stored Procedure to return all students enrolled in a given course.
2.	Create a Function to calculate grade based on marks (e.g., A/B/C).
3.	Create a Trigger to log deleted student records into a new table DeletedStudents.
*/

-- 1.
DELIMITER $$

CREATE PROCEDURE GetStudentsByCourse(IN course_name VARCHAR(100))
BEGIN
    SELECT s.student_id, s.name, s.age, s.gender, c.course_name
    FROM Students s
    JOIN Courses c ON s.course_id = c.course_id
    WHERE c.course_name = course_name;
END$$

DELIMITER ;

-- Example call: CALL GetStudentsByCourse('English Literature');

-- 2.
DELIMITER $$

CREATE FUNCTION CalculateGrade(marks INT) RETURNS CHAR(1)
BEGIN
    DECLARE grade CHAR(1);
    IF marks >= 90 THEN
        SET grade = 'A';
    ELSEIF marks >= 80 THEN
        SET grade = 'B';
    ELSEIF marks >= 70 THEN
        SET grade = 'C';
    ELSEIF marks >= 60 THEN
        SET grade = 'D';
    ELSE
        SET grade = 'F';
    END IF;
    RETURN grade;
END$$   
DELIMITER ;

-- Example usage: SELECT student_id, subject, score, CalculateGrade(score) AS grade FROM Marks;

-- 3.
CREATE TABLE DeletedStudents (
    student_id INT,
    name VARCHAR(100),
    age INT,
    gender ENUM('M','F'),
    course_id INT,
    deleted_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

DELIMITER $$

CREATE TRIGGER trg_AfterStudentDelete
AFTER DELETE ON Students
FOR EACH ROW
BEGIN
    INSERT INTO DeletedStudents(student_id, name, age, gender, course_id)
    VALUES (OLD.student_id, OLD.name, OLD.age, OLD.gender, OLD.course_id);
END$$

DELIMITER ;
