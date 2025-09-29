USE [InterviewDemo]
GO
IF OBJECT_ID('dbo.DailySales', 'U') IS NOT NULL
    DROP TABLE dbo.DailySales;

-- 2️⃣ Create a sample DailySales table
CREATE TABLE dbo.DailySales (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SaleDate DATE NOT NULL,
    TotalSales DECIMAL(10,2) NOT NULL
);
GO
-- 3️⃣ Insert sample data for 30 days
INSERT INTO dbo.DailySales (SaleDate, TotalSales)
VALUES
('2025-01-01', 100.00),
('2025-01-02', 120.00),
('2025-01-03', 90.00),
('2025-01-04', 150.00),
('2025-01-05', 200.00),
('2025-01-06', 130.00),
('2025-01-07', 170.00),
('2025-01-08', 110.00),
('2025-01-09', 140.00),
('2025-01-10', 180.00),
('2025-01-11', 160.00),
('2025-01-12', 190.00),
('2025-01-13', 175.00),
('2025-01-14', 155.00),
('2025-01-15', 200.00),
('2025-01-16', 210.00),
('2025-01-17', 195.00),
('2025-01-18', 220.00),
('2025-01-19', 230.00),
('2025-01-20', 240.00),
('2025-01-21', 245.00),
('2025-01-22', 260.00),
('2025-01-23', 270.00),
('2025-01-24', 280.00),
('2025-01-25', 290.00),
('2025-01-26', 300.00),
('2025-01-27', 310.00),
('2025-01-28', 320.00),
('2025-01-29', 330.00),
('2025-01-30', 340.00);
GO
IF OBJECT_ID('dbo.HourlySales', 'U') IS NOT NULL
    DROP TABLE dbo.HourlySales;

CREATE TABLE dbo.HourlySales (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SaleDateTime DATETIME2 NOT NULL,
    TotalSales DECIMAL(10,2) NOT NULL
);
GO
-- Insert 48 hours of sample data (2 days)------------------------------------------------
DECLARE @start DATETIME2 = '2025-01-01 00:00:00';
DECLARE @i INT = 0;
-------------------------
WHILE @i < 200
BEGIN
    INSERT INTO dbo.HourlySales (SaleDateTime, TotalSales)
    VALUES (DATEADD(HOUR, @i, @start), 100 + (RAND()*100));  -- random sales
    SET @i += 1;
END

SELECT
    SaleDate,
    TotalSales,
    SUM(TotalSales) OVER (
        ORDER BY SaleDate
        ROWS BETWEEN 60  PRECEDING AND CURRENT ROW
    ) AS Rolling14DayTotal
FROM dbo.DailySales
ORDER BY SaleDate;
GO
SELECT
    SaleDateTime,
    TotalSales,
    SUM(TotalSales) OVER (
        ORDER BY SaleDateTime
        ROWS BETWEEN 23 PRECEDING AND CURRENT ROW
    ) AS Rolling24HourTotal
FROM dbo.HourlySales
ORDER BY SaleDateTime;
GO
CREATE TABLE MyNumbers (
    num INT
);
GO
INSERT INTO MyNumbers (num) VALUES
(8), (8), (3), (3), (1), (4), (5), (6);
GO
SELECT 
    MAX(num) AS num
FROM (
    SELECT 
    MAX(num) AS num
FROM MyNumbers
GROUP BY num
HAVING COUNT(*) = 1
) AS single_nums;
GO
-- Create the table
CREATE TABLE Cinema (
    id INT PRIMARY KEY,
    movie VARCHAR(255),
    description VARCHAR(255),
    rating DECIMAL(18,2)
);
GO
-- Insert sample data
INSERT INTO Cinema (id, movie, description, rating) VALUES
(1, 'War', 'great 3D', 8.9),
(2, 'Science', 'fiction', 8.5),
(3, 'irish', 'boring', 6.2),
(4, 'Ice song', 'Fantacy', 8.6),
(5, 'House card', 'Interesting', 9.1);
GO
SELECT *
FROM Cinema
WHERE id % 2 = 1
  AND LOWER(description) <> 'boring'
ORDER BY rating DESC;
-------------
GO
------------
-- Create the table
CREATE TABLE Seat (
    id INT PRIMARY KEY,
    student VARCHAR(255)
);
GO
-- Insert sample data
INSERT INTO Seat (id, student) VALUES
(1, 'Abbot'),
(2, 'Doris'),
(3, 'Emerson'),
(4, 'Green'),
(5, 'Jeames');
GO
CREATE TABLE Salary (
    id INT PRIMARY KEY,
    name VARCHAR(255),
    sex ENUM('m', 'f'),
    salary INT
);
GO
-- Insert sample data
INSERT INTO Salary (id, name, sex, salary) VALUES
(1, 'John', 'm', 5000),
(2, 'Alice', 'f', 6000),
(3, 'Bob', 'm', 5500),
(4, 'Carol', 'f', 7000);
GO
UPDATE Salary
SET sex = CASE 
            WHEN sex = 'm' THEN 'f'
            WHEN sex = 'f' THEN 'm'
          END;

		  GO 
  CREATE TABLE RequestLog (
    Id INT IDENTITY PRIMARY KEY,
    IpAddress VARCHAR(50),
    Url NVARCHAR(255),
    RequestTime DATETIME2
);
GO 
INSERT INTO dbo.RequestLog (IpAddress, Url, RequestTime)
VALUES
-- IP 1
('192.168.1.1', '/home', GETDATE()),
('192.168.1.1', '/home', GETDATE()),
('192.168.1.1', '/home', GETDATE()),
('192.168.1.1', '/home', GETDATE()),
('192.168.1.1', '/about',GETDATE()),

-- IP 2
('192.168.1.2', '/home',    GETDATE()),
('192.168.1.2', '/contact', GETDATE()),
('192.168.1.2', '/home',    GETDATE()),
('192.168.1.2', '/contact', GETDATE()),

-- IP 3
('192.168.1.3', '/home',   GETDATE()),
('192.168.1.3', '/about',  GETDATE()),
('192.168.1.3', '/home',   GETDATE()),
('192.168.1.3', '/about',  GETDATE()),

-- IP 4
('192.168.1.4', '/services', GETDATE()),
('192.168.1.4', '/services', GETDATE()),
('192.168.1.4', '/home',     GETDATE()),
('192.168.1.4', '/home',     GETDATE()),

-- IP 5
('192.168.1.5', '/contact', GETDATE()),
('192.168.1.5', '/contact', GETDATE()),
('192.168.1.5', '/about',   GETDATE()),
('192.168.1.5', '/about',   GETDATE());

GO

DECLARE @i INT = 1;
DECLARE @ipBase VARCHAR(20);
DECLARE @urlList TABLE (Url VARCHAR(50));
DECLARE @randomUrl VARCHAR(50);
--
-- Insert sample URLs
INSERT INTO @urlList (Url)
VALUES ('/home'), ('/about'), ('/contact'), ('/services'), ('/products');

WHILE @i <= 120  -- 120 unique requests
BEGIN
    -- Random IP between 192.168.1.1 to 192.168.1.10
    SET @ipBase = CONCAT('192.168.1.', CAST(1 + CAST(RAND() * 10 AS INT) AS VARCHAR));

    -- Random URL from list
    SELECT TOP 1 @randomUrl = Url FROM @urlList ORDER BY NEWID();

    -- Random timestamp between '2025-09-24 10:00:00' and '2025-09-24 10:05:59'
    INSERT INTO dbo.RequestLog (IpAddress, Url, RequestTime)
    VALUES (
        @ipBase,
        @randomUrl,
        DATEADD(SECOND, CAST(RAND() * 360 AS INT), GETDATE())
    );

    SET @i = @i + 1;
END
GO
SELECT 
    IpAddress,
    Url,
    WindowStart,
    COUNT(*) OVER (PARTITION BY IpAddress, Url, WindowStart) AS RequestCount
FROM (
    SELECT *,
        -- Bucket each request into a 60-second window
        DATEADD(SECOND, (DATEDIFF(SECOND, '1970-01-01', RequestTime) / 60) * 60, '1970-01-01') AS WindowStart
    FROM dbo.RequestLog
    WHERE RequestTime >= DATEADD(MINUTE, -5, GETDATE())  -- last 5 minutes only
) AS t
ORDER BY IpAddress, Url, WindowStart;
GO
-- Group Sold Products By The Date
IF OBJECT_ID('dbo.Activities', 'U') IS NOT NULL
    DROP TABLE dbo.Activities;
GO
CREATE TABLE Activities (
    sell_date DATE,
    product   VARCHAR(50)
);
GO
INSERT INTO Activities (sell_date, product) VALUES
('2020-05-30', 'Headphone'),
('2020-06-01', 'Pencil'),
('2020-06-02', 'Mask'),
('2020-05-30', 'Basketball'),
('2020-06-01', 'Bible'),
('2020-06-02', 'Mask'),
('2020-05-30', 'T-Shirt'),
('2020-05-30', 'Shirt'),
('2020-05-30', 'Pen'),
('2020-05-30', 'Bible'),
('2020-05-30', 'Mobile');

GO

SELECT 
    a.sell_date,
    COUNT(DISTINCT a.product) AS num_sold,
    STUFF((
        SELECT ',' + p.product
        FROM (
            SELECT DISTINCT sell_date, product
            FROM Activities
        ) p
        WHERE p.sell_date = a.sell_date
        ORDER BY p.sell_date,p.product
        FOR XML PATH('')
    ), 1, 1, '') AS products
FROM Activities a
GROUP BY a.sell_date
ORDER BY a.sell_date;
-- Customer Who Visited but Did Not Make Any Transactions
GO
CREATE TABLE Visits (
    visit_id INT PRIMARY KEY,
    customer_id INT
);
GO
CREATE TABLE Transactions (
    transaction_id INT PRIMARY KEY,
    visit_id INT,
    amount INT
);
GO
-- Insert data into Visits table
INSERT INTO Visits (visit_id, customer_id) VALUES
(1, 23),
(2, 9),
(4, 30),
(5, 54),
(6, 96),
(7, 54),
(8, 54);
GO
-- Insert data into Transactions table
INSERT INTO Transactions (transaction_id, visit_id, amount) VALUES
(2, 5, 310),
(3, 5, 300),
(9, 5, 200),
(12, 1, 910),
(13, 2, 970);


SELECT v.customer_id, COUNT(customer_id) AS count_no_trans
FROM Visits v 
LEFT JOIN Transactions t ON v.visit_id = t.visit_id       
WHERE t.transaction_id  IS NULL
GROUP BY v.customer_id  
GO
--Bank Account Summary II
CREATE TABLE Users (
    account INT PRIMARY KEY,
    name VARCHAR(50)
);
GO
CREATE TABLE TransactionsWithAcount (
    trans_id INT PRIMARY KEY,
    account INT,
    amount INT,
    transacted_on DATE
);
GO
-- Insert data into Users table
INSERT INTO Users (account, name) VALUES
(900001, 'Alice'),
(900002, 'Bob'),
(900003, 'Charlie');
GO
-- Insert data into Transactions table
INSERT INTO TransactionsWithAcount (trans_id, account, amount, transacted_on) VALUES
(1, 900001, 7000, '2020-08-01'),
(2, 900001, 7000, '2020-09-01'),
(3, 900001, -3000, '2020-09-05'),
(4, 900002, 1000, '2020-09-12'),
(5, 900003, 6000, '2020-08-07'),
(6, 900003, 6000, '2020-09-07'),
(7, 900003, -4000, '2020-09-11');
GO
SELECT u.name,SUM(t.account) balance FROM users u INNER JOIN TransactionsWithAcount t on u.account = t.account
GROUP BY  u.name
Having SUM(t.amount) > 10000

