CREATE DATABASE Application
go
use Application
go

----TẠO BẢNG
create table HESOLUONG
(
	MaChucVu char(5) primary key,
	TenChucVu nvarchar(50),
	HeSo float
)
go

create table NHANVIEN
(
	MaNV char(5) primary key,
	TenNV nvarchar(50),
	NgaySinh smalldatetime,
	GioiTinh nvarchar(3),
	DiaChi nvarchar(200),
	MaChucVu char(5) foreign key references HESOLUONG(MaChucVu),
	NgayVaoLam smalldatetime,
	SDT varchar(10),
	MatKhau varchar(30)
)

go
create table LOAISANPHAM
(
	MaLoai char(5) primary key,
	TenLoai nvarchar(50)
)

go
create table SANPHAM
(
	MaSP char(5) primary key,
	TenSP nvarchar(50),
	DonGiaNhap money,
	DonGiaBan money,
	DonVi nvarchar(20),
	MaLoai char(5) foreign key references LOAISANPHAM(MaLoai),
	SoLuongTon int
)

go
create table DONNHAPHANG
(
	MaDonNhapHang char(5) primary key,
	NgayNhap smalldatetime,
	TongGiaTri money
)

go
create table CHITIETNHAPHANG
(
	MaSP char(5) foreign key references SANPHAM(MaSP),
	MaDonNhapHang char(5) foreign key references DONNHAPHANG(MaDonNhapHang),
	SoLuong int,
	DonGiaNhap money,
	primary key (MaSP, MaDonNhapHang)
)

go
create table HOADON
(
	MaHD char(5) primary key,
	NgayGio smalldatetime,
	MaNV char(5) foreign key references NHANVIEN(MaNV),
	TongTienHD money
)

go
create table CHITIETHOADON
(
	MaHD char(5) foreign key references HOADON(MaHD),
	MaSP char(5) foreign key references SANPHAM(MaSP),
	SoLuong int,
	DonGiaHienTai money,
	ThanhTien money,
	primary key (MaHD, MaSP)
)

go
create table BANGCHAMCONG
(
	MaChamCong char(5) primary key,
	Thang int,
	Nam int,
	MaNV char(5) foreign key references NHANVIEN(MaNV),
	TongGioLam int,
	LuongCB money,
	TongLuong money
)

go
create table CHITIETCHAMCONG
(
	MaCTChamCong char(5) primary key,
	MaChamCong char(5) foreign key references BANGCHAMCONG(MaChamCong),
	GioBatDau smalldatetime,
	GioKetThuc smalldatetime
)

SET DATEFORMAT DMY
------------------------------------------------------------------------
-- Tạo dữ liệu LOAISANPHAM
insert into LOAISANPHAM values ('ML001',N'Hoá mỹ phẩm')
insert into LOAISANPHAM values ('ML002',N'Thực phẩm')
insert into LOAISANPHAM values ('ML003',N'Đồ uống')
insert into LOAISANPHAM values ('ML004',N'Đồ dùng sinh hoạt')
insert into LOAISANPHAM values ('ML005',N'Văn phòng phẩm')

------------------------------------------------------------------------
-- Tạo dữ liệu SANPHAM
insert into SANPHAM values ('SP001',N'7 up','5000','8000',N'lon','ML003',10)
insert into SANPHAM values ('SP002',N'Cocacola','5000','8000',N'lon','ML003',10)
insert into SANPHAM values ('SP003',N'Sting','5000','8000',N'lon','ML003',10)
insert into SANPHAM values ('SP004',N'7 up','5000','8000',N'chai','ML003',10)
insert into SANPHAM values ('SP005',N'Cocacola','5000','8000',N'chai','ML003',10)
insert into SANPHAM values ('SP006',N'Sting','5000','8000',N'chai','ML003',10)
insert into SANPHAM values ('SP007',N'333','10000','13000',N'lon','ML003',10)
insert into SANPHAM values ('SP008',N'Strongbow','13000','18000',N'chai','ML003',10)
insert into SANPHAM values ('SP009',N'Heniken','15000','20000',N'lon','ML003',10)
insert into SANPHAM values ('SP010',N'Aquafina','3000','6000',N'chai','ML003',10)

insert into SANPHAM values ('SP011',N'Colgate','19000','25000',N'tuýp','ML001',10)
insert into SANPHAM values ('SP012',N'PS','5000','8000',N'tuýp','ML001',10)
insert into SANPHAM values ('SP013',N'Nước rửa chén','18000','23000',N'chai','ML001',10)
insert into SANPHAM values ('SP014',N'Sữa tắm','35000','45000',N'chai','ML001',10)
insert into SANPHAM values ('SP015',N'Dầu gội','35000','45000',N'chai','ML001',10)
insert into SANPHAM values ('SP016',N'Khăn ướt','7000','10000',N'bịch','ML001',10)
insert into SANPHAM values ('SP017',N'Khăn giấy','3000','5000',N'bịch','ML001',10)
insert into SANPHAM values ('SP018',N'Dầu xả','40000','50000',N'chai','ML001',10)
insert into SANPHAM values ('SP019',N'Nước xả','30000','40000',N'chai','ML001',10)
insert into SANPHAM values ('SP020',N'Bột giặt','40000','50000',N'bịch','ML001',10)

insert into SANPHAM values ('SP021',N'Bánh mì tươi KINHDO','3000','6000',N'cái','ML002',10)
insert into SANPHAM values ('SP022',N'Snack POCA','4000','7000',N'bịch','ML002',10)
insert into SANPHAM values ('SP023',N'Mì Hảo Hảo','6000','9000',N'ly','ML002',10)
insert into SANPHAM values ('SP024',N'Mì chay Reevan','4000','6000',N'gói','ML002',10)
insert into SANPHAM values ('SP025',N'Snack Bí đỏ','3000','5000',N'bịch','ML002',10)
insert into SANPHAM values ('SP026',N'Kem Calano','14000','18000',N'cây','ML002',10)
insert into SANPHAM values ('SP027',N'Sữa chua Vinamilk','3000','5000',N'hũ','ML002',10)
insert into SANPHAM values ('SP028',N'Sữa chua TH','5000','8000',N'hũ','ML002',10)
insert into SANPHAM values ('SP029',N'Oreo','10000','13000',N'cây','ML002',10)
insert into SANPHAM values ('SP030',N'Mì xào táo quân','5000','8000',N'gói','ML002',10)

insert into SANPHAM values ('SP031',N'Bàn chải đánh răng','9000','11000',N'cái','ML004',10)
insert into SANPHAM values ('SP032',N'Bàn chải','5000','8000',N'cái','ML004',10)
insert into SANPHAM values ('SP033',N'Kiềm cắt móng','20000','25000',N'cái','ML004',10)
insert into SANPHAM values ('SP034',N'Ly','8000','13000',N'cái','ML004',10)
insert into SANPHAM values ('SP035',N'Chén','8000','13000',N'cái','ML004',10)
insert into SANPHAM values ('SP036',N'Đũa','5000','8000',N'cái','ML004',10)
insert into SANPHAM values ('SP037',N'Muỗng','5000','8000',N'cái','ML004',10)
insert into SANPHAM values ('SP038',N'Gương','10000','15000',N'cái','ML004',10)
insert into SANPHAM values ('SP039',N'Dũa móng tay','3000','5000',N'cái','ML004',10)
insert into SANPHAM values ('SP040',N'Khăn','5000','8000',N'cái','ML004',10)

insert into SANPHAM values ('SP041',N'Bút chì','5000','8000',N'cây','ML005',10)
insert into SANPHAM values ('SP042',N'Bút mực','5000','8000',N'cây','ML005',10)
insert into SANPHAM values ('SP043',N'Bút xoá','10000','15000',N'cây','ML005',10)
insert into SANPHAM values ('SP044',N'Ruột bút chì','9000','14000',N'hộp','ML005',10)
insert into SANPHAM values ('SP045',N'Tẩy','5000','8000',N'cái','ML005',10)
insert into SANPHAM values ('SP046',N'Bút dạ quang','10000','15000',N'cái','ML005',10)
insert into SANPHAM values ('SP047',N'Thước kẻ','5000','8000',N'cây','ML005',10)
insert into SANPHAM values ('SP048',N'Thước ê-ke','5000','8000',N'cây','ML005',10)
insert into SANPHAM values ('SP049',N'Vở','8000','12000',N'quyển','ML005',10)
insert into SANPHAM values ('SP050',N'Sổ tay','10000','15000',N'quyển','ML005',10)

------------------------------------------------------------------------
-- Tạo dữ liệu HESOLUONG
INSERT INTO HESOLUONG(MaChucVu,TenChucVu,HeSo) VALUES ('CV000',N'Quản trị viên','5')
INSERT INTO HESOLUONG(MaChucVu,TenChucVu,HeSo) VALUES ('CV001',N'Quản lý','5')
INSERT INTO HESOLUONG(MaChucVu,TenChucVu,HeSo) VALUES ('CV002',N'Cấp 1','4')
INSERT INTO HESOLUONG(MaChucVu,TenChucVu,HeSo) VALUES ('CV003',N'Cấp 2','3')
INSERT INTO HESOLUONG(MaChucVu,TenChucVu,HeSo) VALUES ('CV004',N'Cấp 3','2')

------------------------------------------------------------------------
-- Tạo dữ liệu NHANVIEN
INSERT INTO NHANVIEN(MaNV,TenNV,SDT,DiaChi,NgaySinh,MaChucVu,GioiTinh,NgayVaoLam,MatKhau) VALUES ('NV001',N'Nguyễn Minh Hiếu','023456780',N'Quận Thủ Đức, TP.HCM','12/05/1998','CV000',N'Nam','14/10/2018','1')
INSERT INTO NHANVIEN(MaNV,TenNV,SDT,DiaChi,NgaySinh,MaChucVu,GioiTinh,NgayVaoLam,MatKhau) VALUES ('NV002',N'Nguyễn Đặng Mỹ Ngọc','01234679',N'Quận 2, TP.HCM','22/02/1998','CV001',N'Nữ','14/10/2018','1')
INSERT INTO NHANVIEN(MaNV,TenNV,SDT,DiaChi,NgaySinh,MaChucVu,GioiTinh,NgayVaoLam,MatKhau) VALUES ('NV003',N'Võ Hồng Mỹ Duyên','07843688',N'Quận 1, TP.HCM','16/09/1998','CV002',N'Nữ','20/10/2018','1')
INSERT INTO NHANVIEN(MaNV,TenNV,SDT,DiaChi,NgaySinh,MaChucVu,GioiTinh,NgayVaoLam,MatKhau) VALUES ('NV004',N'Nguyễn Văn Thinh','03472422',N'Quận 5, TP.HCM','25/02/1998','CV003',N'Nam','22/10/2018','1')
INSERT INTO NHANVIEN(MaNV,TenNV,SDT,DiaChi,NgaySinh,MaChucVu,GioiTinh,NgayVaoLam,MatKhau) VALUES ('NV005',N'Trần Văn B','07914203',N'Quận 12, TP.HCM','15/04/2000','CV004',N'Nam','5/11/2018','1')



