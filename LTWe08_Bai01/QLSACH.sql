CREATE DATABASE QLSACH;
GO

USE QLSACH;
GO

CREATE TABLE CHUDE (
    MaCD INT IDENTITY(1,1) PRIMARY KEY,
    TenChuDe NVARCHAR(100)
);

CREATE TABLE NHAXUATBAN (
    MaNXB INT IDENTITY(1,1) PRIMARY KEY,
    TenNXB NVARCHAR(100),
    DiaChi NVARCHAR(200)
);

CREATE TABLE TACGIA (
    MaTG INT IDENTITY(1,1) PRIMARY KEY,
    TenTG NVARCHAR(100),
    DiaChi NVARCHAR(200),
    DienThoai VARCHAR(20)
);

CREATE TABLE KHACHHANG (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100),
    TaiKhoan NVARCHAR(50),
    MatKhau NVARCHAR(50),
    Email NVARCHAR(100),
    DiaChi NVARCHAR(200),
    DienThoai VARCHAR(20),
    NgaySinh DATE
);

CREATE TABLE SACH (
    MaSach INT IDENTITY(1,1) PRIMARY KEY,
    TenSach NVARCHAR(200),
    GiaBan MONEY,
    MoTa NVARCHAR(MAX),
    AnhBia NVARCHAR(255),
    NgayCapNhat DATE,
    SoLuongTon INT,
    MaCD INT,
    MaNXB INT,
    FOREIGN KEY (MaCD) REFERENCES CHUDE(MaCD),
    FOREIGN KEY (MaNXB) REFERENCES NHAXUATBAN(MaNXB)
);

CREATE TABLE VIETSACH (
    MaTG INT,
    MaSach INT,
    VaiTro NVARCHAR(50),
    PRIMARY KEY (MaTG, MaSach),
    FOREIGN KEY (MaTG) REFERENCES TACGIA(MaTG),
    FOREIGN KEY (MaSach) REFERENCES SACH(MaSach)
);

CREATE TABLE DONDATHANG (
    MaDonHang INT IDENTITY(1,1) PRIMARY KEY,
    MaKH INT,
    NgayDat DATE,
    TriGia MONEY,
    FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH)
);


CREATE TABLE CHITIETDONDATHANG (
    MaDonHang INT,
    MaSach INT,
    SoLuong INT,
    DonGia MONEY,
    PRIMARY KEY (MaDonHang, MaSach),
    FOREIGN KEY (MaDonHang) REFERENCES DONDATHANG(MaDonHang),
    FOREIGN KEY (MaSach) REFERENCES SACH(MaSach)
);

GO


INSERT INTO CHUDE (TenChuDe) VALUES
(N'Tin học - Chính trị'),  
(N'Luật'),                 
(N'Thiếu nhi'),            
(N'Kinh tế'),            
(N'Văn học');           

INSERT INTO NHAXUATBAN (TenNXB, DiaChi) VALUES
(N'Nhà xuất bản Trẻ', N'161B Lý Chính Thắng, Q3, TP.HCM'), 
(N'NXB Lao Động', N'175 Giảng Võ, Hà Nội'),           
(N'NXB Giáo Dục', N'81 Trần Hưng Đạo, Hà Nội');         

INSERT INTO TACGIA (TenTG, DiaChi, DienThoai) VALUES
(N'Nguyễn Văn A', N'TP.HCM', '0909000111'),       
(N'Lê Thị B', N'Hà Nội', '0908333222'),           
(N'Phạm Quốc Cường', N'Đà Nẵng', '0908777666'), 
(N'Trần Minh Dũng', N'Cần Thơ', '0919000444');   

INSERT INTO KHACHHANG (HoTen, TaiKhoan, MatKhau, Email, DiaChi, DienThoai, NgaySinh) VALUES
(N'Lê Hồng Phong', 'lehongphong', '123456', 'phong@gmail.com', N'TP.HCM', '0908123456', '1995-03-21'), 
(N'Nguyễn Thị Hoa', 'hoanguyen', 'abc123', 'hoa@gmail.com', N'Hà Nội', '0912333444', '1997-11-15');     


INSERT INTO SACH (TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaCD, MaNXB) VALUES
(N'Giáo trình Tin học cơ bản', 28000,
 N'Nội dung của cuốn: Tin Học Cơ Bản Windows XP gồm có 7 chương. Chương 1: Một số vấn đề cơ bản... Chương 7: Hỏi và đáp các thắc mắc.',
 N'~/Content/Images/tinhoccoban.jpg', '2014-10-25', 120, 1, 1), 

(N'Giáo trình Tin học văn phòng', 120000,
 N'Cuốn sách gồm 3 phần: soạn thảo văn bản, bảng tính, trình chiếu.',
 N'~/Content/Images/tinhocvanphong.jpg', '2013-09-23', 25, 2, 2),

(N'Lập trình cơ sở dữ liệu với VB.NET', 110000,
 N'Giới thiệu lập trình cơ sở dữ liệu bằng Visual Basic 2008 và ADO.NET 2.0.',
 N'~/Content/Images/vbnet.jpg', '2014-12-21', 23, 1, 1), 

(N'Cơ sở dữ liệu quan hệ', 95000,
 N'Giải thích chi tiết mô hình quan hệ và SQL nâng cao.',
 N'~/Content/Images/sql.jpg', '2015-05-10', 40, 4, 3);


INSERT INTO DONDATHANG (MaKH, NgayDat, TriGia) VALUES
(1, '2024-10-05', 148000), 
(2, '2024-11-02', 230000); 


INSERT INTO VIETSACH (MaTG, MaSach, VaiTro) VALUES
(1, 1, N'Chủ biên'),
(2, 2, N'Đồng tác giả'),
(3, 3, N'Chủ biên'),
(4, 4, N'Tác giả');

INSERT INTO CHITIETDONDATHANG (MaDonHang, MaSach, SoLuong, DonGia) VALUES
(1, 1, 2, 28000),    
(1, 3, 1, 110000),   
(2, 2, 1, 120000),   
(2, 4, 1, 95000);    
GO