USE master
CREATE DATABASE QLNhanVien
GO

USE QLNhanVien
GO


 
CREATE TABLE CapBac (
    MaCB char(10) PRIMARY KEY,
    TenCB NVARCHAR(50),
	HSLuong int
)
GO
 
CREATE TABLE PhongBan (
    MaPB char(10) PRIMARY KEY,
    TenPB NVARCHAR (50),
    MaTP char(10),
    NNC date
)
GO
 
CREATE TABLE NhanVien (
    MaNV char(10) PRIMARY KEY,
    HoTen NVARCHAR (50),
    GioiTinh nchar(10),
	NgaySinh date,
    SDT VARCHAR (20),
	DiaChi nvarchar(50),  
    MaCB char(10),
    MaPB char(10),
	Luong int,
    FOREIGN KEY (MaCB) REFERENCES CapBac (MaCB) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (MaPB) REFERENCES PhongBan (MaPB) ON DELETE CASCADE ON UPDATE CASCADE,
)
GO
 
insert into CapBac
values
('cb1',N'Trưởng Phòng',5),
('cb2',N'Phó Trưởng Phòng',3),
('cb3',N'Nhân Viên',5)

insert into PhongBan
values
('pb1',N'Phòng Nhân Sự','nv1','1-1-2000'),
('pb2',N'Phòng Kế Tóa','nv2','2-1-2000'),
('pb3',N'Phòng Kế Hoạch','nv3','3-1-2000')

insert into NhanVien
values
('nv1',N'Lê Nguyễn Minh Hiếu',N'Nam','1-1-2000','0123456789',N'Hà Nội','cb1','pb1',5000),
('nv2',N'Nguyễn Đức Thành',N'Nam','2-1-2000','0123456789',N'Hà Nội','cb2','pb2',1000),
('nv3',N'Đỗ Ngọc Hà',N'Nữ','3-1-2000','0123456789',N'Hà Nội','cb2','pb3',2000)

