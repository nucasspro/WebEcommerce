-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE or ALTER PROCEDURE ws_Get_NhanVien_Inf
	-- Add the parameters for the stored procedure here
	@manv char(5)
AS

----------------------DEBUG
--DECLARE @manv char(5)
--SET @manv = 'NV001'
----------------------DEBUG
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	INTO #TEMP
	FROM Application..NHANVIEN
	WHERE MaNV = @manv

	SELECT * FROM #TEMP

	DROP TABLE #TEMP
END
GO
