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
SELECT u.name,SUM(t.amount) balance FROM Users u INNER JOIN TransactionsWithAcount t on u.account = t.account
GROUP BY t.account,u.name
Having SUM(t.amount) > 10000
--Triangle Judgement
GO
CREATE TABLE Triangle (
    x INT,
    y INT,
    z INT,
    PRIMARY KEY (x, y, z)
);
GO
INSERT INTO Triangle (x, y, z) VALUES
(13, 15, 30),
(10, 20, 15),
(5, 7, 10),
(8, 8, 15);
GO
SELECT 
    x,
    y,
    z,
    CASE 
        WHEN x + y > z AND x + z > y AND y + z > x THEN 'Yes'
        ELSE 'No'
    END AS triangle
FROM Triangle;
--Actors and Directors Who Cooperated At Least Three Times
GO
CREATE TABLE ActorDirector (
    actor_id INT,
    director_id INT,
    timestamp INT PRIMARY KEY
);
GO
INSERT INTO ActorDirector (actor_id, director_id, timestamp) VALUES
(1, 1, 0),
(1, 1, 1),
(1, 1, 2),
(1, 2, 3),
(1, 2, 4),
(2, 1, 5),
(2, 1, 6);
GO

SELECT actor_id, director_id FROM ActorDirector
GROUP BY actor_id, director_id
HAVING COUNT(actor_id) >=3
GO
--Product Sales Analysis I
CREATE TABLE Product (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50)
);

CREATE TABLE Sales (
    sale_id INT,
    product_id INT,
    year INT,
    quantity INT,
    price INT,
    PRIMARY KEY (sale_id, year),
    FOREIGN KEY (product_id) REFERENCES Product(product_id)
);

INSERT INTO Product (product_id, product_name) VALUES
(100, 'Nokia'),
(200, 'Apple'),
(300, 'Samsung');

INSERT INTO Sales (sale_id, product_id, year, quantity, price) VALUES
(1, 100, 2008, 10, 5000),
(2, 100, 2009, 12, 5000),
(7, 200, 2011, 15, 9000);
GO
SELECT 
    p.product_name,
    s.year,
    s.price
FROM Sales s
INNER JOIN Product p
ON s.product_id = p.product_id;
GO
CREATE TABLE Employee (
    employee_id INT PRIMARY KEY,
    name VARCHAR(50),
    experience_years INT NOT NULL
);
GO
CREATE TABLE Project (
    project_id INT,
    employee_id INT,
    PRIMARY KEY (project_id, employee_id),
    FOREIGN KEY (employee_id) REFERENCES Employee(employee_id)
);
GO
-- Insert data into Employee table
INSERT INTO Employee (employee_id, name, experience_years) VALUES
(1, 'Khaled', 3),
(2, 'Ali', 2),
(3, 'John', 1),
(4, 'Doe', 2);
GO
-- Insert data into Project table
INSERT INTO Project (project_id, employee_id) VALUES
(1, 1),
(1, 2),
(1, 3),
(2, 1),
(2, 4);
GO
SELECT 
    p.project_id,
    ROUND(AVG(e.experience_years), 2) AS average_years
FROM Project p
JOIN Employee e 
    ON p.employee_id = e.employee_id
GROUP BY p.project_id;
GO

CREATE TABLE ProductWithUnitePrice (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    unit_price INT
);
GO
CREATE TABLE SalesOne (
    seller_id INT,
    product_id INT,
    buyer_id INT,
    sale_date DATE,
    quantity INT,
    price INT,
    FOREIGN KEY (product_id) REFERENCES ProductWithUnitePrice(product_id)
);
GO
-- Insert sample data into Product
INSERT INTO ProductWithUnitePrice (product_id, product_name, unit_price) VALUES
(1, 'S8', 1000),
(2, 'G4', 800),
(3, 'iPhone', 1400);
GO
-- Insert sample data into Sales
INSERT INTO SalesOne (seller_id, product_id, buyer_id, sale_date, quantity, price) VALUES
(1, 1, 1, '2019-01-21', 2, 2000),
(1, 2, 2, '2019-02-17', 1, 800),
(2, 2, 3, '2019-06-02', 1, 800),
(3, 3, 4, '2019-05-13', 2, 2800);
GO
SELECT DISTINCT 
    p.product_id,
    p.product_name
FROM ProductWithUnitePrice p
JOIN SalesOne s 
    ON p.product_id = s.product_id
WHERE s.sale_date BETWEEN '2019-01-01' AND '2019-03-31'
  AND NOT EXISTS (
        SELECT 1 
        FROM SalesOne s2
        WHERE s2.product_id = p.product_id
          AND (s2.sale_date NOT BETWEEN '2019-01-01' AND '2019-03-31')
  );
  GO
  --Article Views I
  CREATE TABLE Views (
    article_id INT,
    author_id INT,
    viewer_id INT,
    view_date DATE
);
GO
-- Insert sample data
INSERT INTO Views (article_id, author_id, viewer_id, view_date) VALUES
(1, 3, 5, '2019-08-01'),
(1, 3, 6, '2019-08-02'),
(2, 7, 7, '2019-08-01'),
(2, 7, 6, '2019-08-02'),
(4, 7, 1, '2019-07-22'),
(3, 4, 4, '2019-07-21'),
(3, 4, 4, '2019-07-21');
GO
SELECT DISTINCT 
    author_id AS id
FROM Views
WHERE author_id = viewer_id
ORDER BY id;
GO
CREATE TABLE Department (
    id INT,
    revenue INT,
    month VARCHAR(10),
    PRIMARY KEY (id, month)
);
GO
-- Insert sample data
INSERT INTO Department (id, revenue, month) VALUES
(1, 8000, 'Jan'),
(2, 9000, 'Jan'),
(3, 10000, 'Feb'),
(1, 7000, 'Feb'),
(1, 6000, 'Mar');
GO
SELECT 
    id,
    MAX(CASE WHEN month = 'Jan' THEN revenue END) AS Jan_Revenue,
    MAX(CASE WHEN month = 'Feb' THEN revenue END) AS Feb_Revenue,
    MAX(CASE WHEN month = 'Mar' THEN revenue END) AS Mar_Revenue,
    MAX(CASE WHEN month = 'Apr' THEN revenue END) AS Apr_Revenue,
    MAX(CASE WHEN month = 'May' THEN revenue END) AS May_Revenue,
    MAX(CASE WHEN month = 'Jun' THEN revenue END) AS Jun_Revenue,
    MAX(CASE WHEN month = 'Jul' THEN revenue END) AS Jul_Revenue,
    MAX(CASE WHEN month = 'Aug' THEN revenue END) AS Aug_Revenue,
    MAX(CASE WHEN month = 'Sep' THEN revenue END) AS Sep_Revenue,
    MAX(CASE WHEN month = 'Oct' THEN revenue END) AS Oct_Revenue,
    MAX(CASE WHEN month = 'Nov' THEN revenue END) AS Nov_Revenue,
    MAX(CASE WHEN month = 'Dec' THEN revenue END) AS Dec_Revenue
FROM Department
GROUP BY id
ORDER BY id;