/*
1.	Find students who scored above the average score using a subquery.
2.	Get students enrolled in the same course as “John” using a correlated subquery.
*/

-- 1.
SELECT name
FROM Students
WHERE student_id IN (
    SELECT student_id
    FROM Marks
    WHERE score > (
        SELECT AVG(score) 
        FROM Marks
    )
);


-- 2.
SELECT name
FROM Students s1
WHERE course_id = (
    SELECT course_id
    FROM Students s2
    WHERE s2.name = 'John'
);