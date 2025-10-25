CREATE DATABASE QL_NhanSu;
GO

USE QL_NhanSu;
GO

CREATE TABLE Department (
    DeptId INT PRIMARY KEY,
    Name NVARCHAR(255)
);

CREATE TABLE Employee (
    Id INT PRIMARY KEY,
    Name NVARCHAR(255),
    Gender NVARCHAR(10),
    City NVARCHAR(100),
	Img NVARCHAR(500) NULL,
    DeptId INT,
    FOREIGN KEY (DeptId) REFERENCES Department(DeptId)
);
GO

INSERT INTO Department (DeptId, Name) VALUES
(1, N'Khoa CNTT'),
(2, N'Khoa Ngoại Ngữ'),
(3, N'Khoa Tài Chính'),
(4, N'Khoa Thực Phẩm'),
(5, N'Phòng Đào Tạo');

INSERT INTO Employee (Id, Name, Gender, City, Img,DeptId) VALUES
(1, N'Nguyễn Hải Yến', N'Nữ', N'Đà Lạt', '~/Content/Images/1.jpg',1),
(2, N'Trương Mạnh Hùng', N'Nam', N'TP.HCM', '~/Content/Images/1.jpg',1),
(3, N'Đinh Duy Minh', N'Nam', N'Thái Bình', '~/Content/Images/1.jpg',2),
(4, N'Ngô Thị Ngguyệt', N'Nữ', N'Long An', '~/Content/Images/1.jpg',2),
(5, N'Đào Minh Châu', N'Nữ', N'Bạc Liêu', '~/Content/Images/1.jpg',3),
(14, N'Phan Thị Ngọc Mai', N'Nữ', N'Bến Tre', '~/Content/Images/1.jpg',3),
(15, N'Trương Nguyễn Quỳnh Anh', N'Nữ', N'TP.HCM', '~/Content/Images/1.jpg',4),
(16, N'Lê Thanh Liêm', N'Nam', N'TP.HCM', '~/Content/Images/1.jpg',4);
GO