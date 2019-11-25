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
CREATE OR ALTER PROCEDURE ws_Get_SanPham_Inf
	-- Add the parameters for the stored procedure here
@masp char(5)
----------------DEBUG
--DECLARE @masp char(5)
--set @masp = 'sp001'
----------------DEBUG
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT * INTO
	#PRODUC_TEMP 
	FROM Application..SANPHAM
	WHERE MASP = @masp
    -- Insert statements for procedure here
	SELECT * FROM #PRODUC_TEMP

	DROP TABLE #PRODUC_TEMP
END
GO
