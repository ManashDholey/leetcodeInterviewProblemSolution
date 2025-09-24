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
-------
GO-
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
