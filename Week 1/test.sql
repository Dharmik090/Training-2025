/*
Create Database & Tables
*/

CREATE DATABASE LibraryDB;

USE LibraryDB;

CREATE TABLE Authors (
    author_id INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    country VARCHAR(50)
);

CREATE TABLE Books (
    book_id INT PRIMARY KEY,
    title VARCHAR(200) NOT NULL,
    author_id INT NOT NULL,
    year_published INT,
    genre VARCHAR(50),
    FOREIGN KEY (author_id) REFERENCES Authors(author_id)
);

CREATE TABLE Borrowers (
    borrower_id INT PRIMARY KEY,
    book_id INT NOT NULL,
    borrow_date DATE NOT NULL,
    return_date DATE,
    FOREIGN KEY (book_id) REFERENCES Books(book_id)
);


/*
Insert Sample Data
*/

-- Add a new author
INSERT INTO Authors (author_id, name, country)
VALUES (1, 'Isaac Asimov', 'USA');

-- Add a new book
INSERT INTO Books (book_id, title, author_id, year_published, genre)
VALUES (101, 'Foundation', 1, 1951, 'Science Fiction');

-- Add a borrower record
INSERT INTO Borrowers (borrower_id, book_id, borrow_date, return_date)
VALUES (1001, 101, '2025-09-01', NULL);


/*
Update Operations
*/

UPDATE Books
SET title = 'Foundation and Empire'
WHERE book_id = 101;

-- Update a book's genre
UPDATE Books
SET Genre = 'Classic Sci-Fi'
WHERE BookID = 101;

-- Mark a borrowed book as returned
UPDATE Borrowers
SET ReturnDate = '2025-09-10'
WHERE BorrowerID = 1001
  AND BookID = 101;


/*
Delete Operations
*/

-- Delete a borrower record (book returned and archived)
DELETE FROM Borrowers
WHERE BorrowerID = 1001;

-- Delete a book (if it’s no longer in the library)
DELETE FROM Books
WHERE BookID = 101;

-- Delete an author (only if they have no books linked!)
DELETE FROM Authors
WHERE AuthorID = 1;

