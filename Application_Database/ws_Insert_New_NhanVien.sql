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
CREATE PROCEDURE ws_Insert_New_NhanVien 
	 --Add the parameters for the stored procedure here
	@manv char(5),
	@tennv nvarchar(50),
	@ngaysinh smalldatetime,
	@gioitinh nvarchar(3),
	@diachi nvarchar(200),
	@machucvu char(5),
	@ngayvaolam smalldatetime,
	@sdt varchar(10),
	@matkhau varchar(30)
AS

	----------Debug
	--DECLARE @manv char(5),
	--@tennv nvarchar(50),
	--@ngaysinh smalldatetime,
	--@gioitinh nvarchar(3),
	--@diachi nvarchar(200),
	--@machucvu char(5),
	--@ngayvaolam smalldatetime,
	--@sdt varchar(10),
	--@matkhau varchar(30)

	----SET 
	----@manv char(5) = ,
	----@tennv nvarchar(50) = ,
	----@ngaysinh smalldatetime = ,
	----@gioitinh nvarchar(3) = ,
	----@diachi nvarchar(200) = ,
	----@machucvu char(5) = ,
	----@ngayvaolam smalldatetime = ,
	----@sdt varchar(10) = ,
	----@matkhau varchar(30)
	----------Debug


BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO NHANVIEN VALUES(@manv, @tennv, @ngaysinh, @gioitinh, @diachi, @machucvu, @ngaysinh, @sdt, @matkhau);
END
GO
