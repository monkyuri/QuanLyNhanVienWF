USE master
CREATE DATABASE QLNhanVien
GO

USE QLNhanVien
GO

CREATE TABLE DiaChi (
    MaDC INT IDENTITY(1,1) PRIMARY KEY,
    DiaChi1 NVARCHAR (200) DEFAULT NULL,
    DiaChi2 NVARCHAR (200) DEFAULT NULL,
    ThanhPho NVARCHAR (30) NOT NULL,
)
GO
 
CREATE TABLE CapBac (
    MaCB INT IDENTITY(1,1) PRIMARY KEY,
    TenCB NVARCHAR (35) NOT NULL,
    MinLuong DECIMAL (10, 2) DEFAULT NULL,
    MaxLuong DECIMAL (10, 2) DEFAULT NULL
)
GO
 
CREATE TABLE PhongBan (
    MaPB INT IDENTITY(1,1) PRIMARY KEY,
    TenPB NVARCHAR (30) NOT NULL,
    MaTP INT DEFAULT NULL,
    NG_NHANCHUC DATETIME DEFAULT(GETDATE())
)
GO
 
CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    HoNV NVARCHAR (20) DEFAULT NULL,
    TenNV NVARCHAR (25) NOT NULL,
    email NVARCHAR (100) NOT NULL,
    SDT NVARCHAR (20) DEFAULT NULL,
    NgayThue DATE NOT NULL,
    MaCB INT NOT NULL,
    Luong DECIMAL (10, 2) NOT NULL,
    MaPB INT DEFAULT NULL,
    MaDC INT DEFAULT NULL
    FOREIGN KEY (MaCB) REFERENCES CapBac (MaCB) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (MaPB) REFERENCES PhongBan (MaPB) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (MaDC) REFERENCES DiaChi (MaDC) ON DELETE CASCADE ON UPDATE CASCADE,
)
GO
ALTER TABLE NhanVien Alter COLUMN Luong  DECIMAL (10, 2);


CREATE TABLE ThanNhan (
    MaTN INT IDENTITY(1,1) PRIMARY KEY,
    HoTN NVARCHAR (50) NOT NULL,
    TenTN NVARCHAR (50) NOT NULL,
    TenQuanHe NVARCHAR (25) NOT NULL,
    MaNV INT NOT NULL,
    FOREIGN KEY (MaNV) REFERENCES NhanVien (MaNV) ON DELETE CASCADE ON UPDATE CASCADE
)
GO
insert into DiaChi
values 
(N'Đồng Xa-Mai Dịch',N'Cầu Giấy',N'Hà Nội'),
(N'Mỹ Đình',N'Cầu Giấy',N'Hà Nội'),
(N'Minh Khai',N'Đống Đa',N'Hà Nội'),
(N'Thụy Khuê',N'Tây Hồ',N'Hà Nội'),
(N'Kiều Mai',N'Bắc Từ Liêm',N'Hà Nội'),
(N'Nguyễn Trãi',N'Thanh Xuân',N'Hà Nội');
select *from DiaChi

insert into CapBac
values 
(N'Trưởng phòng',20000000.0,35000000.0),
(N'Nhân Viên',10000000.0,25000000.0),
(N'Kế Toán',5000000.0,15000000.0),
(N'IT',20000000.0,35000000.0);

insert into PhongBan
values 
(N'Phòng Tài chính','05','12/15/2004'),
(N'Phòng Kế hoạch','03','08/05/1993'),
(N'Phòng Vật tư','01','10/30/2005'),
(N'Phòng Kỹ thuật','02','07/21/2009');
insert into ThanNhan
values
(N'Trần',N'Văn Hiệp',N'Bố','3'),
(N'Nguyễn',N'Văn An',N'Anh Trai','5'),
(N'Đinh',N'Duy Tú',N'Bố','4'),
(N'Nguyễn',N'Duy Nhất',N'Bố','6')

insert into NHANVIEN
values
(N'Nguyễn',N'Văn Minh','vanan123@gmail.com','0125849756','10/30/2001','7','22000000.0','3','3'),
(N'Nguyễn',N'Đình Toàn','dinhtoan456@gmail.com','0125523465','11/02/1988','8','12000000.0','4','4'),
(N'Trần',N'Minh Kiên','minhkien@gmail.com','0944365824','10/30/1990','9','12000000.0','5','5'),
(N'Đinh',N'Đức Thuận','ducthuan@gmail.com','0125849756','10/30/2001','10','12000000.0','6','6');

select *from NHANVIEN
delete from PhongBan