/*
  * Employees (emp_id, name, dept_id, salary)
  * Departments (dept_id, dept_name)
  * Salaries (emp_id, month, amount)
  * Salary_Log (for auditing via trigger)
*/


-- 1) Create Database
CREATE DATABASE IF NOT EXISTS mini_payroll;
USE mini_payroll;


-- 2) Tables

CREATE TABLE Departments (
  dept_id INT PRIMARY KEY,
  dept_name VARCHAR(100) NOT NULL
);

CREATE TABLE Employees (
  emp_id INT PRIMARY KEY,
  name VARCHAR(100) NOT NULL,
  dept_id INT,
  salary DECIMAL(10,2) NOT NULL,
  FOREIGN KEY (dept_id) REFERENCES Departments(dept_id)
);

CREATE TABLE Salaries (
  salary_id INT AUTO_INCREMENT PRIMARY KEY,
  emp_id INT,
  month VARCHAR(7) NOT NULL, -- format YYYY-MM
  amount DECIMAL(10,2) NOT NULL,
  FOREIGN KEY (emp_id) REFERENCES Employees(emp_id),
  UNIQUE KEY (emp_id, month)
);

CREATE TABLE Salary_Log (
  log_id INT AUTO_INCREMENT PRIMARY KEY,
  emp_id INT,
  month VARCHAR(7),
  amount DECIMAL(10,2),
  logged_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


-- 3) Insert Sample Data
INSERT INTO Departments VALUES
(10, 'Engineering'),
(20, 'HR'),
(30, 'Sales');

INSERT INTO Employees VALUES
(101, 'Alice Johnson', 10, 6000),
(102, 'Bob Smith', 10, 5500),
(103, 'Carol Lee', 20, 4000),
(104, 'David Kim', 30, 4500);

INSERT INTO Salaries (emp_id, month, amount) VALUES
(101, '2024-01', 6000),
(101, '2024-02', 6000),
(102, '2024-01', 5500),
(103, '2024-01', 4000),
(104, '2024-01', 4500);


-- 4) Complex Join (example query)

-- SELECT e.emp_id, e.name, d.dept_name, s.month, s.amount
-- FROM Employees e
-- JOIN Departments d ON e.dept_id = d.dept_id
-- JOIN Salaries s ON e.emp_id = s.emp_id;


-- 5) Subquery: Employees earning above dept average

-- SELECT e.emp_id, e.name, d.dept_name, e.salary, avg_table.avg_salary
-- FROM Employees e
-- JOIN Departments d ON e.dept_id = d.dept_id
-- JOIN (
--   SELECT dept_id, AVG(salary) AS avg_salary
--   FROM Employees
--   GROUP BY dept_id
-- ) avg_table ON e.dept_id = avg_table.dept_id
-- WHERE e.salary > avg_table.avg_salary;


-- 6) Stored Procedure: Calculate yearly salary
DELIMITER $$
CREATE PROCEDURE calculate_yearly_salary(IN p_emp_id INT)
BEGIN
  SELECT p_emp_id AS emp_id, COALESCE(SUM(amount), 0) AS yearly_salary
  FROM Salaries
  WHERE emp_id = p_emp_id;
END$$
DELIMITER ;

-- Example call:
-- CALL calculate_yearly_salary(101);


-- 7) Trigger: Auto-log salary insertions
DELIMITER $$
CREATE TRIGGER trg_after_salary_insert
AFTER INSERT ON Salaries
FOR EACH ROW
BEGIN
  INSERT INTO Salary_Log (emp_id, month, amount)
  VALUES (NEW.emp_id, NEW.month, NEW.amount);
END$$
DELIMITER ;


-- 8) View: Employee Salary Summary
CREATE VIEW v_employee_salary_summary AS
SELECT e.emp_id, e.name, d.dept_name,
       e.salary AS base_salary,
       COALESCE(SUM(s.amount), 0) AS total_paid
FROM Employees e
LEFT JOIN Departments d ON e.dept_id = d.dept_id
LEFT JOIN Salaries s ON e.emp_id = s.emp_id
GROUP BY e.emp_id, e.name, d.dept_name, e.salary;

-- Example: SELECT * FROM v_employee_salary_summary;
