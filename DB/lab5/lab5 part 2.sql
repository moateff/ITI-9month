USE AdventureWorks2012;

-- 1. Display the SalesOrderID, ShipDate of the SalesOrderHeader table (Sales schema) to show SalesOrders that occurred within the period ‘7/28/2002’ and ‘7/29/2014’
SELECT SalesOrderID, ShipDate
FROM Sales.SalesOrderHeader
WHERE OrderDate BETWEEN '7/28/2002' AND '7/29/2014'

-- 2. Display only Products(Production schema) with a StandardCost below $110.00 (show ProductID, Name only)
SELECT ProductID, Name
FROM Production.Product
WHERE StandardCost < 110

-- 3. Display ProductID, Name if its weight is unknown
SELECT ProductID, Name
FROM Production.Product
WHERE Weight IS NULL

-- 4. Display all Products with a Silver, Black, or Red Color
SELECT *
FROM Production.Product
WHERE Color IN ('Silver', 'Black', 'Red')

-- 5. Display any Product with a Name starting with the letter B
SELECT *
FROM Production.Product
WHERE Name LIKE 'B%'

-- 6. Run the following Query
UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3

-- Then write a query that displays any Product description with underscore value in its description.
SELECT Description
FROM Production.ProductDescription
WHERE Description LIKE '%[_]%'

-- 7. Calculate sum of TotalDue for each OrderDate in Sales.SalesOrderHeader table for the period between  '7/1/2001' and '7/31/2014'
SELECT sum(TotalDue) AS 'Sum'
FROM Sales.SalesOrderHeader
GROUP BY OrderDate
HAVING OrderDate BETWEEN '7/1/2001' AND '7/31/2014'

-- 8. Display the Employees HireDate (note no repeated values are allowed)
SELECT DISTINCT HireDate 
FROM HumanResources.Employee

-- 9. Calculate the average of the unique ListPrices in the Product table
SELECT AVG(DISTINCT ListPrice) AS 'Average'
FROM Production.Product

-- 10. Display the Product Name and its ListPrice within the values of 100 and 120 the list should has the following format "The [product name] is only! [List price]" (the list will be sorted according to its ListPrice value)
SELECT 'The '+ Name + ' is only! ' + convert(varchar(20), ListPrice) AS 'Product Price'
FROM Production.Product
WHERE ListPrice BETWEEN 100 AND 120
ORDER BY ListPrice

-- 11.	
-- a) Transfer the rowguid ,Name, SalesPersonID, Demographics from Sales.Store table  in a newly created table named [store_Archive]
-- Note: Check your database to see the new table and how many rows in it?
SELECT rowguid ,Name, SalesPersonID, Demographics
INTO Sales.store_Archive
FROM Sales.Store;

-- b) Try the previous query but without transferring the data? 
SELECT rowguid ,Name, SalesPersonID, Demographics
INTO Sales.store_Archive
FROM Sales.Store
WHERE 1 = 0;

-- 12. Using union statement, retrieve the today’s date in different styles using convert or format funtion.
SELECT CONVERT(VARCHAR(30), GETDATE(), 101) AS Date
UNION
SELECT CONVERT(VARCHAR(30), GETDATE(), 103)
UNION
SELECT CONVERT(VARCHAR(30), GETDATE(), 105)
UNION
SELECT CONVERT(VARCHAR(30), GETDATE(), 106)
UNION
SELECT FORMAT(GETDATE(), 'hh:mm tt, MMM dd yyyy'); 