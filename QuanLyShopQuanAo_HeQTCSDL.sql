-- Tạo cơ sở dữ liệu
use master
CREATE DATABASE QuanLyShopQuanAo_HeQTCSDL;
USE QuanLyShopQuanAo_HeQTCSDL;

-- Tạo bảng phân loại sản phẩm
CREATE TABLE PhanLoai (
    MaPhanLoai INT PRIMARY KEY IDENTITY(1,1),  
    TenPhanLoai NVARCHAR(100) NOT NULL
);

-- Tạo bảng thương hiệu sản phẩm
CREATE TABLE ThuongHieu (
    MaThuongHieu INT PRIMARY KEY IDENTITY(1,1),  
    TenThuongHieu NVARCHAR(100) NOT NULL UNIQUE
);

-- Tạo bảng sản phẩm
CREATE TABLE SanPham (
    MaSanPham INT PRIMARY KEY IDENTITY(1,1), 
    TenSanPham NVARCHAR(100) NOT NULL,
    MaPhanLoai INT, 
    MaThuongHieu INT,  
    GioiTinh NVARCHAR(50),  
    GiaGoc DECIMAL(10,2) CHECK (GiaGoc > 0),
    GiaBan DECIMAL(10, 2) CHECK (GiaBan > 0),
    MoTa NVARCHAR(MAX),   
    HinhAnh CHAR(255),  
    FOREIGN KEY (MaPhanLoai) REFERENCES PhanLoai(MaPhanLoai),
    FOREIGN KEY (MaThuongHieu) REFERENCES ThuongHieu(MaThuongHieu)
);

-- Tạo bảng màu sắc sản phẩm
CREATE TABLE MauSac (
    MaMauSac INT PRIMARY KEY IDENTITY(1,1), 
    TenMauSac NVARCHAR(50) NOT NULL UNIQUE
);

-- Tạo bảng kích thước sản phẩm
CREATE TABLE KichThuoc (
    MaKichThuoc INT PRIMARY KEY IDENTITY(1,1), 
    TenKichThuoc NVARCHAR(50) NOT NULL UNIQUE
);

-- Bảng liên kết sản phẩm với màu sắc và kích thước
CREATE TABLE SanPhamMauSacKichThuoc (
    MaSanPham INT,           
    MaMauSac INT,            
    MaKichThuoc INT,         
    SoLuong INT,                     
    PRIMARY KEY (MaSanPham, MaMauSac, MaKichThuoc),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham),
    FOREIGN KEY (MaMauSac) REFERENCES MauSac(MaMauSac),
    FOREIGN KEY (MaKichThuoc) REFERENCES KichThuoc(MaKichThuoc)
);

-- Tạo bảng vai trò
CREATE TABLE VaiTro (
    MaVaiTro INT PRIMARY KEY IDENTITY(1,1), 
    TenVaiTro NVARCHAR(100) NOT NULL UNIQUE
);

-- Tạo bảng người dùng
CREATE TABLE NguoiDung (
    MaNguoiDung INT PRIMARY KEY IDENTITY(1,1),  
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(255) NOT NULL,
    HoTen NVARCHAR(50),
    DienThoai NVARCHAR(20),
    MaVaiTro INT,  
    FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro) ON DELETE SET NULL  
);


-- Tạo bảng khách hàng
CREATE TABLE KhachHang (
    MaKhachHang INT PRIMARY KEY IDENTITY(1,1), 
    Ho NVARCHAR(50) NOT NULL,
    Ten NVARCHAR(50) NOT NULL,
    DienThoai NVARCHAR(20),
    DiaChiDayDu NVARCHAR(255),  
    MaNguoiDung INT,  
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung)
);

-- Tạo bảng đơn hàng
CREATE TABLE DonHang (
    MaDonHang INT PRIMARY KEY IDENTITY(1,1),  
    MaKhachHang INT,  
    NgayDat DATETIME,
    DiaChiGiaoHang NVARCHAR(255),
    TrangThaiDonHang NVARCHAR(50),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);

-- Tạo bảng chi tiết đơn hàng
-- Tạo bảng chi tiết đơn hàng liên kết với màu sắc và kích thước
CREATE TABLE ChiTietDonHang (
    MaDonHang INT,  
    MaSanPham INT,  
    MaMauSac INT,          -- Mã màu sắc của sản phẩm
    MaKichThuoc INT,       -- Mã kích thước của sản phẩm
    SoLuong INT,
    ThanhTien DECIMAL(10, 2) CHECK (ThanhTien > 0),
    PRIMARY KEY (MaDonHang, MaSanPham, MaMauSac, MaKichThuoc),  -- Khóa chính mới cho từng sản phẩm theo màu sắc và kích thước
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham),
    FOREIGN KEY (MaMauSac) REFERENCES MauSac(MaMauSac),
    FOREIGN KEY (MaKichThuoc) REFERENCES KichThuoc(MaKichThuoc)
);


-- Tạo bảng căn cước công nhân
CREATE TABLE CanCuocCongNhan (
    SoCanCuoc NVARCHAR(20) PRIMARY KEY,         
    MaNguoiDung INT UNIQUE,  
    NgayCap DATE,                            
    NoiCap NVARCHAR(100),                    
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung) ON DELETE CASCADE 
);

-- Tạo bảng nhà cung cấp
CREATE TABLE NhaCungCap (
    MaNhaCungCap INT PRIMARY KEY IDENTITY(1,1),  
    TenNhaCungCap NVARCHAR(100) NOT NULL UNIQUE,
    DiaChi NVARCHAR(255),
    DienThoai NVARCHAR(20),
    Email NVARCHAR(100)
);

-- Tạo bảng phiếu nhập
CREATE TABLE PhieuNhap (
    MaPhieuNhap INT PRIMARY KEY IDENTITY(1,1),  
    MaNhaCungCap INT,  
    NgayNhap DATETIME,
    TongTien DECIMAL(10, 2) CHECK (TongTien > 0),
    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);

-- Tạo lại bảng ChiTietPhieuNhap với thông tin kích thước và màu sắc
CREATE TABLE ChiTietPhieuNhap (
    MaPhieuNhap INT,  
    MaSanPham INT,  
    MaMauSac INT,           -- Mã màu sắc của sản phẩm
    MaKichThuoc INT,        -- Mã kích thước của sản phẩm
    SoLuong INT,            -- Số lượng nhập của sản phẩm với màu sắc và kích thước cụ thể
    GiaNhap DECIMAL(10, 2) CHECK (GiaNhap > 0), -- Giá nhập của sản phẩm
    PRIMARY KEY (MaPhieuNhap, MaSanPham, MaMauSac, MaKichThuoc), -- Khóa chính cho từng màu sắc và kích thước
    FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhap(MaPhieuNhap),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham),
    FOREIGN KEY (MaMauSac) REFERENCES MauSac(MaMauSac),
    FOREIGN KEY (MaKichThuoc) REFERENCES KichThuoc(MaKichThuoc)
);

-- Thêm dữ liệu vào bảng PhanLoai
INSERT INTO PhanLoai (TenPhanLoai) VALUES
(N'Thời trang nữ'),
(N'Thời trang nam'),
(N'Đồ thể thao'),
(N'Phụ kiện');

-- Thêm dữ liệu vào bảng ThuongHieu
INSERT INTO ThuongHieu (TenThuongHieu) VALUES
(N'Nike'),
(N'Adidas'),
(N'Gucci'),
(N'Puma');

-- Thêm dữ liệu vào bảng SanPham
INSERT INTO SanPham (TenSanPham, MaPhanLoai, MaThuongHieu, GioiTinh, GiaGoc, GiaBan, MoTa, HinhAnh) VALUES
(N'Áo thun nữ', 1, 1, N'Nữ', 250000, 300000, N'Áo thun cotton, thoáng mát', N'ao_thun_nu.jpg'),
(N'Quần jean nam', 2, 2, N'Nam', 500000, 600000, N'Quần jean thời trang', N'quan_jean_nam.jpg'),
(N'Balo du lịch', 3, 4, N'Unisex', 350000, 400000, N'Balo tiện lợi cho du lịch', N'balo_du_lich.jpg');

-- Thêm dữ liệu vào bảng MauSac
INSERT INTO MauSac (TenMauSac) VALUES
(N'Đỏ'),
(N'Xanh'),
(N'Đen'),
(N'Trắng');

-- Thêm dữ liệu vào bảng KichThuoc
INSERT INTO KichThuoc (TenKichThuoc) VALUES
(N'S'),
(N'M'),
(N'L'),
(N'XL');
-- Nhập dữ liệu vào bảng SanPhamMauSacKichThuoc

INSERT INTO SanPhamMauSacKichThuoc (MaSanPham, MaMauSac, MaKichThuoc, SoLuong)
VALUES
  
  (1, 1, 2, 10),  
  (1, 1, 3, 5),  
  (1, 2, 2, 8),   
  (1, 3, 3, 12),
  (2, 3, 4, 10), 
  (2, 3, 1, 15),
  (2, 3, 2, 20),
  (2, 3, 3, 12), 
  (2, 4, 4, 8), 
  (2, 4, 1, 18), 
  (2, 4, 2, 15), 
  (2, 4, 3, 10); 

-- Thêm dữ liệu vào bảng VaiTro
INSERT INTO VaiTro (TenVaiTro) VALUES
(N'Quản trị viên'),
(N'Nhân viên');

-- Thêm dữ liệu vào bảng NguoiDung
INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, DienThoai, MaVaiTro) VALUES
(N'admin', N'password123', N'Nguyễn Văn A', N'0901234567', 1),
(N'nhanvien1', N'password456', N'Trần Thị B', N'0907654321', 2);

-- Thêm dữ liệu vào bảng KhachHang
INSERT INTO KhachHang (Ho, Ten, DienThoai, DiaChiDayDu, MaNguoiDung) VALUES
('User', '',null,null,null),
(N'Nguyễn', N'Văn C', N'0912345678', N'Số 123, Đường ABC, Quận 1', 1),
(N'Trần', N'Văn D', N'0912345679', N'Số 456, Đường DEF, Quận 2', 2);

-- Thêm dữ liệu vào bảng DonHang
INSERT INTO DonHang (MaKhachHang, NgayDat, DiaChiGiaoHang, TrangThaiDonHang)
VALUES
(1, '2024-12-02', '123 Đường ABC, Quận 1, TP.HCM', 'Đang xử lý'),
(2, '2024-12-01', '456 Đường XYZ, Quận 2, TP.HCM', 'Đang giao'),
(3, '2024-12-03', '789 Đường DEF, Quận 3, TP.HCM', 'Đã hoàn thành');

-- Thêm dữ liệu vào bảng ChiTietDonHang
INSERT INTO ChiTietDonHang (MaDonHang, MaSanPham, MaMauSac, MaKichThuoc, SoLuong, ThanhTien)
VALUES
(1, 1, 1, 1, 2, 500000),   
(1, 2, 2, 1, 1, 300000),   
(2, 3, 1, 2, 3, 1200000),
(2, 1, 3, 2, 2, 600000),   
(3, 2, 1, 3, 1, 450000),   
(3, 3, 2, 3, 2, 900000);   


-- Thêm dữ liệu vào bảng CanCuocCongNhan
INSERT INTO CanCuocCongNhan (SoCanCuoc, MaNguoiDung, NgayCap, NoiCap) VALUES
(N'123456789', 2, '2022-01-01', N'CA');

-- Thêm dữ liệu vào bảng NhaCungCap
INSERT INTO NhaCungCap (TenNhaCungCap, DiaChi, DienThoai, Email) VALUES
(N'Nhà cung cấp 1', N'Số 789, Đường GHI, Quận 3', N'0911111111', N'nhacungcap1@example.com');

-- Thêm dữ liệu vào bảng PhieuNhap 
INSERT INTO PhieuNhap (MaNhaCungCap, NgayNhap, TongTien) VALUES
(1, GETDATE(), 3000000);

-- Thêm dữ liệu vào bảng ChiTietPhieuNhap
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSanPham, MaMauSac, MaKichThuoc, SoLuong, GiaNhap) VALUES
(1, 1, 1, 2, 10, 200000),  -- Ví dụ: Nhập 10 sản phẩm áo thun nữ màu đỏ, kích thước M
(1, 2, 2, 3, 5, 500000);    -- Ví dụ: Nhập 5 sản phẩm quần jean nam màu xanh, kích thước L

--------------LẬP TRÌNH CSDL------------------------------------
--dùng để Kiểm tra số điện thoại đã tồn tại hay chưa
CREATE TRIGGER trg_KiemTraSoDienThoaiKhachHang
ON KhachHang
INSTEAD OF INSERT,UPDATE
AS
BEGIN
    -- Kiểm tra nếu số điện thoại trùng với số đã tồn tại
    IF EXISTS (
        SELECT 1
        FROM KhachHang k
        INNER JOIN inserted i ON k.DienThoai = i.DienThoai
        WHERE k.DienThoai IS NOT NULL AND i.DienThoai IS NOT NULL
    )
    BEGIN
        -- Ngăn chặn thao tác và thông báo lỗi
        RAISERROR ('Số điện thoại đã tồn tại .', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Nếu không trùng, cho phép thêm dữ liệu
    INSERT INTO KhachHang (Ho, Ten, DienThoai, DiaChiDayDu, MaNguoiDung)
    SELECT Ho, Ten, DienThoai, DiaChiDayDu, MaNguoiDung
    FROM inserted;
END;
GO

--Đổi mật khẩu
CREATE PROCEDURE DoiMatKhau
    @TenDangNhap NVARCHAR(50),
    @MatKhauCu NVARCHAR(255),
    @MatKhauMoi NVARCHAR(255)
AS
BEGIN
    -- Kiểm tra xem tài khoản có tồn tại và mật khẩu cũ đúng không
    IF EXISTS (
        SELECT 1
        FROM NguoiDung
        WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhauCu
    )
    BEGIN
        -- Cập nhật mật khẩu mới
        UPDATE NguoiDung
        SET MatKhau = @MatKhauMoi
        WHERE TenDangNhap = @TenDangNhap;

        PRINT 'Đổi mật khẩu thành công cho khách hàng';
    END
    ELSE
    BEGIN
        -- Thông báo lỗi nếu mật khẩu cũ không khớp
        RAISERROR('Tên đăng nhập hoặc mật khẩu cũ không chính xác', 16, 1);
    END
END;
GO

--Tính tổng số đơn
CREATE FUNCTION TongSoDonHang(@MaKhachHang INT)
RETURNS INT
AS
BEGIN
    DECLARE @SoDonHang INT;
    SELECT @SoDonHang = COUNT(*) FROM DonHang WHERE MaKhachHang = @MaKhachHang;
    RETURN @SoDonHang;
END
GO

--Lấy danh sách khách hàng
CREATE PROCEDURE LayDanhSachKhachHang
AS
BEGIN
    SELECT 
        k.MaKhachHang,
        k.Ho,
        k.Ten,
        k.DienThoai,
        k.DiaChiDayDu,
        k.MaNguoiDung,
        n.TenDangNhap
    FROM KhachHang k
    LEFT JOIN NguoiDung n ON k.MaNguoiDung = n.MaNguoiDung
    ORDER BY k.MaKhachHang;
END
GO

--Thêm khách hàng mới
CREATE PROCEDURE ThemKhachHang
    @Ho NVARCHAR(50),
    @Ten NVARCHAR(50),
    @DienThoai NVARCHAR(20),
    @DiaChiDayDu NVARCHAR(255),
    @MaNguoiDung INT
AS
BEGIN
    INSERT INTO KhachHang (Ho, Ten, DienThoai, DiaChiDayDu, MaNguoiDung)
    VALUES (@Ho, @Ten, @DienThoai, @DiaChiDayDu, @MaNguoiDung);
END
GO

--Xóa khách hàng
CREATE PROCEDURE XoaKhachHang
    @MaKhachHang INT
AS
BEGIN
    DELETE FROM KhachHang
    WHERE MaKhachHang = @MaKhachHang;
END
GO

--Cập nhật thông tin khách hàng
CREATE PROCEDURE SuaKhachHang
    @MaKhachHang INT,
    @Ho NVARCHAR(50),
    @Ten NVARCHAR(50),
    @DienThoai NVARCHAR(20),
    @DiaChiDayDu NVARCHAR(255)
AS
BEGIN
    UPDATE KhachHang
    SET Ho = @Ho,
        Ten = @Ten,
        DienThoai = @DienThoai,
        DiaChiDayDu = @DiaChiDayDu
    WHERE MaKhachHang = @MaKhachHang;
END
GO

--Tìm kiếm khách hàng
CREATE PROCEDURE TimKiemKhachHang
    @MaKH INT = NULL,
    @Ten NVARCHAR(50) = NULL,
    @DienThoai NVARCHAR(20) = NULL
AS
BEGIN
    SELECT *
    FROM KhachHang
    WHERE (@MaKH IS NULL OR MaKhachHang = @MaKH)
      AND (@Ten IS NULL OR Ten LIKE '%' + @Ten + '%')
      AND (@DienThoai IS NULL OR DienThoai LIKE '%' + @DienThoai + '%');
END
GO

--Lấy danh sách phân loại sản phẩm
CREATE PROCEDURE LayDanhSachLoaiSanPham
AS
BEGIN
    SELECT MaPhanLoai, TenPhanLoai
    FROM PhanLoai;
END;
GO

--Thêm phân loại sản phẩm
CREATE PROCEDURE ThemLoaiSanPham
    @TenLoai NVARCHAR(100)
AS
BEGIN
    INSERT INTO PhanLoai(TenPhanLoai)
    VALUES (@TenLoai);
END;
GO

--SỬa phân loại 
CREATE PROCEDURE SuaLoaiSanPham
    @MaLoai INT,
    @TenLoai NVARCHAR(100)
AS
BEGIN
    UPDATE PhanLoai
    SET TenPhanLoai = @TenLoai
    WHERE MaPhanLoai = @MaLoai;
END;
GO

--Xóa phân loại 
CREATE PROCEDURE XoaLoaiSanPham
    @MaLoai INT
AS
BEGIN
    DELETE FROM PhanLoai
    WHERE MaPhanLoai = @MaLoai;
END;
GO

--Lấy danh sách thương hiệu
CREATE PROCEDURE LayDanhSachThuongHieu
AS
BEGIN
    SELECT MaThuongHieu, TenThuongHieu FROM ThuongHieu;
END
GO

--Thêm thương hiệu
CREATE PROCEDURE ThemThuongHieu
    @TenThuongHieu NVARCHAR(100)
AS
BEGIN
    INSERT INTO ThuongHieu (TenThuongHieu)
    VALUES (@TenThuongHieu);
END
GO

--Cập nhật thương hiệu
CREATE PROCEDURE SuaThuongHieu
    @MaThuongHieu INT,
    @TenThuongHieu NVARCHAR(100)
AS
BEGIN
    UPDATE ThuongHieu
    SET TenThuongHieu = @TenThuongHieu
    WHERE MaThuongHieu = @MaThuongHieu;
END
GO

--Xóa thương hiệu
CREATE PROCEDURE XoaThuongHieu
    @MaThuongHieu INT
AS
BEGIN
    DELETE FROM ThuongHieu
    WHERE MaThuongHieu = @MaThuongHieu;
END
GO

--Lấy danh sách màu sắc
CREATE PROCEDURE LayDanhSachMauSac
AS
BEGIN
    SELECT MaMauSac, TenMauSac FROM MauSac;
END
GO

--Thêm màu sắc
CREATE PROCEDURE ThemMauSac
    @TenMau NVARCHAR(100)
AS
BEGIN
    INSERT INTO MauSac (TenMauSac)
    VALUES (@TenMau);
END
GO

--Cập nhật màu sắc
CREATE PROCEDURE SuaMauSac
    @MaMau INT,
    @TenMau NVARCHAR(100)
AS
BEGIN
    UPDATE MauSac
    SET TenMauSac = @TenMau
    WHERE MaMauSac = @MaMau;
END
GO

--Xóa màu sắc
CREATE PROCEDURE XoaMauSac
    @MaMau INT
AS
BEGIN
    DELETE FROM MauSac
    WHERE MaMauSac = @MaMau;
END
GO

--Lấy danh sách kích thước
CREATE PROCEDURE LayDanhSachKichThuoc
AS
BEGIN
    SELECT MaKichThuoc, TenKichThuoc FROM KichThuoc;
END
GO

--Thêm kích thước
CREATE PROCEDURE ThemKichThuoc
    @TenKichThuoc NVARCHAR(100)
AS
BEGIN
    INSERT INTO KichThuoc (TenKichThuoc)
    VALUES (@TenKichThuoc);
END
GO

--Cập nhật kích thước
CREATE PROCEDURE SuaKichThuoc
    @MaKichThuoc INT,
    @TenKichThuoc NVARCHAR(100)
AS
BEGIN
    UPDATE KichThuoc
    SET TenKichThuoc = @TenKichThuoc
    WHERE MaKichThuoc = @MaKichThuoc;
END
GO

--Xóa kích thước
CREATE PROCEDURE XoaKichThuoc
    @MaKichThuoc INT
AS
BEGIN
    DELETE FROM KichThuoc
    WHERE MaKichThuoc = @MaKichThuoc;
END
GO

--cập nhật trạng thái đơn hàng khi khách hàng hủy đơn
CREATE TRIGGER trgCapNhatTrangThaiHuyDon
ON DonHang
AFTER UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted WHERE TrangThaiDonHang = N'Hủy')
    BEGIN
        UPDATE DonHang
        SET TrangThaiDonHang = N'Đã hủy'
        WHERE MaDonHang IN (SELECT MaDonHang FROM inserted);
    END
END
GO


--duyệt qua danh sách khách hàng và gửi email chúc mừng
DECLARE @MaKhachHang INT, @Ho NVARCHAR(50), @Ten NVARCHAR(50);
DECLARE khachHang_cursor CURSOR 
FOR
	SELECT MaKhachHang, Ho, Ten FROM KhachHang;
OPEN khachHang_cursor;
FETCH NEXT FROM khachHang_cursor INTO @MaKhachHang, @Ho, @Ten;
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT N'Gửi email chúc mừng tới khách hàng có mã : ' + convert(char(4),@MaKhachHang) + N', Họ và tên :' + @Ho + ' ' + @Ten;
    FETCH NEXT FROM khachHang_cursor INTO @MaKhachHang, @Ho, @Ten;
END
CLOSE khachHang_cursor;
DEALLOCATE khachHang_cursor;
GO

------------------------------------------------------------------------------------------------------------------------------------
--Thêm sản phẩm
CREATE PROCEDURE THEM_SANPHAM
    @TenSanPham NVARCHAR(100),
    @MaPhanLoai INT,
    @MaThuongHieu INT,
    @GioiTinh NVARCHAR(50),
    @GiaGoc DECIMAL(10,2),
    @GiaBan DECIMAL(10,2),
    @MoTa NVARCHAR(MAX),
    @HinhAnh CHAR(20)
AS
BEGIN
    INSERT INTO SanPham (TenSanPham, MaPhanLoai, MaThuongHieu, GioiTinh, GiaGoc, GiaBan, MoTa, HinhAnh)
    VALUES (@TenSanPham, @MaPhanLoai, @MaThuongHieu, @GioiTinh, @GiaGoc, @GiaBan, @MoTa, @HinhAnh);
END;

--Tính trung bình theo phân loại
CREATE FUNCTION GIATRUNGBINH_THEOLOAI(@MaPhanLoai INT)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @GiaTrungBinh DECIMAL(10, 2);
    SELECT @GiaTrungBinh = AVG(GiaBan)
    FROM SanPham
    WHERE MaPhanLoai = @MaPhanLoai;
    RETURN @GiaTrungBinh;
END;

--CẬp nhật sản phẩm
CREATE PROCEDURE CAPNHAT_SANPHAM
	@MaSanPham int,
    @TenSanPham NVARCHAR(100),
    @GioiTinh NVARCHAR(50),
    @GiaGoc DECIMAL(10,2),
    @MoTa NVARCHAR(MAX)
AS
BEGIN
    UPDATE SanPham
	SET TenSanPham = @TenSanPham, GiaGoc = @GiaGoc, GioiTinh = @GioiTinh, MoTa = @MoTa
	WHERE MaSanPham = @MaSanPham
END;

--Trigger cập nhật giá bán khi giá gốc được thay đổi
CREATE TRIGGER TRG_CAPNHAT_GIABAN
ON SanPham
AFTER UPDATE
AS
BEGIN
    UPDATE SanPham
    SET GiaBan = SanPham.GiaGoc * 1.2 --Giả sử giá bán là 120% giá gốc
    FROM SanPham
    JOIN inserted i ON SanPham.MaSanPham = (select MaSanPham from inserted)
    WHERE (select MaSanPham from inserted) <> SanPham.GiaGoc;
END;

--Hàm kiểm tra khóa ngoại của sản phẩm trước khi xóa
create function kiemtra_khoangoai_sp(@MaSanPham int)
returns int 
as
begin 
	if exists (select 1 from ChiTietDonHang where MaSanPham = @MaSanPham)
		return 0;
	if exists (select 1 from ChiTietPhieuNhap where MaSanPham = @MaSanPham)
		return 0;
	if exists (select 1 from SanPhamMauSacKichThuoc where MaSanPham = @MaSanPham)
		return 0;--dính khóa ngoại
	return 1;-- xóa được
end

--Xóa sản phẩm
create procedure Xoa_SP @masp int
as 
begin
	delete from SanPham where MaSanPham = @masp
end

--Lấy danh sách
create procedure DSSP
as
begin
	select * from SanPham
end

--Lấy danh sách theo phân loại
create procedure SP_Loai @maphanloai int
as
begin
	select * from SanPham where MaPhanLoai = @maphanloai
end

--Lấy thương hiệu theo phân loại
create procedure SP_ThuongHieu @mathuonghieu int
as
begin
	select * from SanPham where MaPhanLoai = @mathuonghieu
end

--Load thương hiệu
create procedure Load_ThuongHieu
as
begin
	select * from ThuongHieu
end

--thủ tục load loại sản phẩm
create procedure Load_Loaisp
as
begin
	select * from PhanLoai
end


-----------------------------------------------------------------------------------------------------------------------
--Bổ sung nhà cung cấp
-- hiển thị nhà cung cấp bằng thủ tục
GO
CREATE PROCEDURE GetNhaCungCap
AS
BEGIN
    SELECT MaNhaCungCap, TenNhaCungCap, DiaChi, DienThoai, Email
    FROM NhaCungCap;
END;

EXEC GetNhaCungCap;

-- Thêm nhà cung cấp bằng thủ tục:
GO
CREATE PROCEDURE ThemNhaCungCap
    @TenNhaCungCap NVARCHAR(100),
    @DiaChi NVARCHAR(200),
    @DienThoai NVARCHAR(50),
    @Email NVARCHAR(100)
AS
BEGIN
        INSERT INTO NhaCungCap (TenNhaCungCap, DiaChi, DienThoai, Email)
        VALUES (@TenNhaCungCap, @DiaChi, @DienThoai, @Email);
END;


--Cập nhật nhà cung cấp bằng thủ tục
GO
CREATE PROCEDURE sp_UpdateNhaCungCap
    @MaNhaCungCap INT,
    @TenNhaCungCap NVARCHAR(255),
    @DiaChi NVARCHAR(255),
    @DienThoai NVARCHAR(50),
    @Email NVARCHAR(255)
AS
BEGIN
    UPDATE NhaCungCap
    SET 
        TenNhaCungCap = @TenNhaCungCap,
        DiaChi = @DiaChi,
        DienThoai = @DienThoai,
        Email = @Email
    WHERE MaNhaCungCap = @MaNhaCungCap;
END;

-- xóa nhà cung cấp bằng thủ tục: 
GO
CREATE PROCEDURE sp_DeleteNhaCungCap
    @MaNhaCungCap INT
AS
BEGIN
    DELETE FROM NhaCungCap
    WHERE MaNhaCungCap = @MaNhaCungCap;
END;

--Bổ sung nhân viên
-- hiển thị dữ liệu bằng function
GO
CREATE FUNCTION GetNguoiDungDetails()
RETURNS TABLE
AS
RETURN
(
    SELECT 
        nd.MaNguoiDung, 
        nd.TenDangNhap, 
        nd.MatKhau, 
        nd.HoTen, 
        nd.DienThoai, 
        vt.MaVaiTro, 
        cccd.SoCanCuoc, 
        cccd.NgayCap, 
        cccd.NoiCap
    FROM 
        NguoiDung nd
    LEFT JOIN 
        VaiTro vt ON nd.MaVaiTro = vt.MaVaiTro
    LEFT JOIN 
        CanCuocCongNhan cccd ON nd.MaNguoiDung = cccd.MaNguoiDung
);

SELECT * FROM GetNguoiDungDetails();

--Thêm người dùng bằng thủ tục kết hợp transaction: 
-- Gọi thủ tục AddNguoiDungWithVaiTroAndCanCuoc với các tham số
GO
CREATE PROCEDURE AddNguoiDungWithVaiTroAndCanCuoc
    @MaVaiTro INT,
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(255),
    @HoTen NVARCHAR(50),
    @DienThoai NVARCHAR(20),
    @SoCanCuoc NVARCHAR(20),
    @NgayCap DATE,
    @NoiCap NVARCHAR(100)
AS
BEGIN
    -- Bắt đầu giao dịch
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Thêm dữ liệu vào bảng NguoiDung
        DECLARE @MaNguoiDung INT;
        INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, DienThoai, MaVaiTro)
        VALUES (@TenDangNhap, @MatKhau, @HoTen, @DienThoai, @MaVaiTro);

        -- Lấy MaNguoiDung vừa thêm
        SET @MaNguoiDung = SCOPE_IDENTITY();

        -- Thêm dữ liệu vào bảng CanCuocCongNhan
        INSERT INTO CanCuocCongNhan (SoCanCuoc, MaNguoiDung, NgayCap, NoiCap)
        VALUES (@SoCanCuoc, @MaNguoiDung, @NgayCap, @NoiCap);

        -- Nếu tất cả thành công, commit giao dịch
        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH
        -- Nếu có lỗi, rollback giao dịch
        ROLLBACK TRANSACTION;

        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;

-- Xóa người dùng với thủ tục: 
GO
CREATE PROCEDURE DeleteNguoiDung
    @MaNguoiDung INT
AS
BEGIN
    DELETE FROM NguoiDung WHERE MaNguoiDung = @MaNguoiDung;
END;

-- cập nhật người dùng cùng với cccd với thủ tục và transaction
GO
CREATE PROCEDURE UpdateNguoiDungAndCCCD
    @MaNguoiDung INT,
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(50),
    @HoTen NVARCHAR(100),
    @DienThoai NVARCHAR(20),
    @MaVaiTro INT,
    @SoCanCuoc NVARCHAR(20),
    @NgayCap DATE,
    @NoiCap NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Cập nhật thông tin người dùng
        UPDATE NguoiDung
        SET TenDangNhap = @TenDangNhap, 
            MatKhau = @MatKhau, 
            HoTen = @HoTen, 
            DienThoai = @DienThoai, 
            MaVaiTro = @MaVaiTro
        WHERE MaNguoiDung = @MaNguoiDung;

        -- Cập nhật thông tin CCCD
        UPDATE CanCuocCongNhan
        SET SoCanCuoc = @SoCanCuoc, 
            NgayCap = @NgayCap, 
            NoiCap = @NoiCap
        WHERE MaNguoiDung = @MaNguoiDung;

        COMMIT TRANSACTION;  -- Commit nếu thành công
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;  -- Rollback nếu có lỗi
        THROW;  -- Ném lỗi để có thể xử lý trong C#
    END CATCH
END;

-------------------------------------------------------------------------------------------------------------------------
--Thêm đơn hàng
CREATE TYPE ChiTietDonHangType AS TABLE
(
    MaSanPham INT,    -- Mã sản phẩm
    SoLuong INT,      -- Số lượng
    ThanhTien DECIMAL(18,2), -- Thành tiền
    MaMauSac INT,        -- Mã màu sắc
    MaKichThuoc INT   -- Mã kích thước
);
-- Cập nhật thủ tục sp_ThemDonHangMoi
CREATE PROCEDURE sp_ThemDonHangMoi
    @MaKhachHang INT,              -- Mã khách hàng
    @DiaChiGiaoHang NVARCHAR(255),  -- Địa chỉ giao hàng
    @TrangThaiDonHang NVARCHAR(50), -- Trạng thái đơn hàng
    @ChiTietDonHang dbo.ChiTietDonHangType READONLY -- Biến bảng chứa chi tiết đơn hàng
AS
BEGIN
    -- Khai báo biến cho MaDonHang và NgayDat
    DECLARE @MaDonHang INT;
    DECLARE @NgayDat DATETIME;

    -- Lấy ngày và giờ hiện tại
    SET @NgayDat = GETDATE();

    -- Thêm đơn hàng mới vào bảng DonHang
    INSERT INTO DonHang (MaKhachHang, NgayDat, DiaChiGiaoHang, TrangThaiDonHang)
    VALUES (@MaKhachHang, @NgayDat, @DiaChiGiaoHang, @TrangThaiDonHang);

    -- Lấy MaDonHang của đơn hàng vừa thêm vào
    SET @MaDonHang = SCOPE_IDENTITY();

    -- Thêm chi tiết đơn hàng vào bảng ChiTietDonHang từ biến bảng @ChiTietDonHang
    INSERT INTO ChiTietDonHang (MaDonHang, MaSanPham, SoLuong, ThanhTien,  MaMauSac, MaKichThuoc)
    SELECT @MaDonHang, MaSanPham, SoLuong, ThanhTien, MaMauSac, MaKichThuoc
    FROM @ChiTietDonHang;

    -- Có thể thực hiện thêm xử lý khác nếu cần (ví dụ: tính toán tổng tiền đơn hàng, v.v.)
    
END;

-- Function: Tính tổng giá trị đơn hàng
CREATE FUNCTION TinhTongGiaTriDonHang (@MaDonHang INT)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @TongGiaTri DECIMAL(10, 2);
    SELECT @TongGiaTri = SUM(ThanhTien)
    FROM ChiTietDonHang
    WHERE MaDonHang = @MaDonHang;
    RETURN @TongGiaTri;
END;

-- Trigger: Cập nhật số lượng sản phẩm trong kho khi đơn hàng được tạo
CREATE TRIGGER CapNhatSoLuongTonSauDonHang
ON ChiTietDonHang
AFTER INSERT
AS
BEGIN
    DECLARE @MaSanPham INT
	DECLARE @SoLuongMua INT 
	DECLARE @SoLuongTon INT 
	--Trường hợp tạo nhiều đơn hàng cùng lúc
	DECLARE duyetTungPT CURSOR FOR
    SELECT MaSanPham, SoLuong FROM inserted;
    OPEN duyetTungPT;
    FETCH NEXT FROM duyetTungPT INTO @MaSanPham, @SoLuongMua;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @SoLuongTon = SoLuong FROM SanPhamMauSacKichThuoc WHERE MaSanPham = @MaSanPham;
        IF @SoLuongTon < @SoLuongMua
        BEGIN
            PRINT N'Không đủ số lượng';
            ROLLBACK TRAN;
        END
        ELSE
        BEGIN
            UPDATE SanPhamMauSacKichThuoc
            SET SoLuong = SoLuong - @SoLuongMua
            WHERE MaSanPham = @MaSanPham;
        END
        FETCH NEXT FROM duyetTungPT INTO @MaSanPham, @SoLuongMua;
    END
    CLOSE duyetTungPT;
    DEALLOCATE duyetTungPT;
END;

-- Cursor: Duyệt qua danh sách đơn hàng và in thông tin chi tiết
DECLARE @MaDonHang INT, @MaSanPham INT, @SoLuong INT, @ThanhTien DECIMAL(10, 2);
DECLARE conTro CURSOR FOR 
SELECT MaDonHang, MaSanPham, SoLuong, ThanhTien
FROM ChiTietDonHang;

OPEN conTro;
FETCH NEXT FROM conTro INTO @MaDonHang, @MaSanPham, @SoLuong, @ThanhTien;
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'MaDonHang: ' + CAST(@MaDonHang AS NVARCHAR(10)) + 
          ', MaSanPham: ' + CAST(@MaSanPham AS NVARCHAR(10)) + 
          ', SoLuong: ' + CAST(@SoLuong AS NVARCHAR(10)) + 
          ', ThanhTien: ' + CAST(@ThanhTien AS NVARCHAR(10));
    FETCH NEXT FROM conTro INTO @MaDonHang, @MaSanPham, @SoLuong, @ThanhTien;
END;
CLOSE conTro;
DEALLOCATE conTro;

-----------------------------------------------------------------------------------------------------------------------
--1.	Stored Procedure: Thêm phiếu nhập hàng.
CREATE TYPE ChiTietPhieuNhapType AS TABLE
(
    MaSanPham INT,
    MaMauSac INT,
    MaKichThuoc INT,
    SoLuong INT,
    GiaNhap DECIMAL(10, 2)
);

CREATE PROCEDURE ThemPhieuNhap
    @MaNhaCungCap INT,
    @TongTien DECIMAL(10, 2),
    @ChiTietPhieuNhap ChiTietPhieuNhapType READONLY
AS
BEGIN
    DECLARE @MaPhieuNhap INT;

    -- Thêm phiếu nhập vào bảng PhieuNhap
    INSERT INTO PhieuNhap (MaNhaCungCap, NgayNhap, TongTien)
    VALUES (@MaNhaCungCap, GETDATE(), @TongTien);

    -- Lấy MaPhieuNhap vừa insert vào
    SET @MaPhieuNhap = SCOPE_IDENTITY();

    -- Thêm chi tiết phiếu nhập vào bảng ChiTietPhieuNhap từ bảng tạm
    INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSanPham, MaMauSac, MaKichThuoc, SoLuong, GiaNhap)
    SELECT @MaPhieuNhap, MaSanPham, MaMauSac, MaKichThuoc, SoLuong, GiaNhap
    FROM @ChiTietPhieuNhap;

    PRINT N'Phiếu nhập và chi tiết phiếu nhập đã được thêm thành công';
END;

--Tổng tiền tất cả phiếu nhập
CREATE FUNCTION dbo.TinhTongTienTatCaPhieuNhap()
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @TongTienTatCa DECIMAL(10, 2);

    -- Tính tổng tiền tất cả phiếu nhập
    SELECT @TongTienTatCa = SUM(SoLuong * GiaNhap)
    FROM ChiTietPhieuNhap;

    RETURN @TongTienTatCa;
END;

--3.	Trigger: Cập nhật số lượng sản phẩm khi phiếu nhập được thêm.
CREATE TRIGGER trg_AfterInsertChiTietPhieuNhap
ON ChiTietPhieuNhap
AFTER INSERT
AS
BEGIN
    -- Cập nhật số lượng sản phẩm trong bảng SanPhamMauSacKichThuoc
    UPDATE spm
    SET spm.SoLuong = spm.SoLuong + i.SoLuong
    FROM SanPhamMauSacKichThuoc spm
    INNER JOIN inserted i ON spm.MaSanPham = i.MaSanPham
                         AND spm.MaMauSac = i.MaMauSac
                         AND spm.MaKichThuoc = i.MaKichThuoc;
END;

--Thêm SanPhamMauSacKichThuoc khi phiếu nhập được thêm mà bảng bảng SanPhamMauSacKichThuoc chưa có
CREATE TRIGGER trg_AfterInsertChiTietPhieuNhapCreateSP
ON ChiTietPhieuNhap
AFTER INSERT
AS
BEGIN
    -- Kiểm tra và thêm thông tin kết hợp sản phẩm - màu sắc - kích thước vào bảng SanPhamMauSacKichThuoc nếu chưa tồn tại
    INSERT INTO SanPhamMauSacKichThuoc (MaSanPham, MaMauSac, MaKichThuoc, SoLuong)
    SELECT i.MaSanPham, i.MaMauSac, i.MaKichThuoc, i.SoLuong
    FROM inserted i
    WHERE NOT EXISTS (
        SELECT 1 
        FROM SanPhamMauSacKichThuoc spm
        WHERE spm.MaSanPham = i.MaSanPham 
          AND spm.MaMauSac = i.MaMauSac 
          AND spm.MaKichThuoc = i.MaKichThuoc
    );
END;


----BACKUP DATABASE---

CREATE PROCEDURE BackupDatabase
    @DatabaseName NVARCHAR(100), -- Tên cơ sở dữ liệu
    @BackupFilePath NVARCHAR(MAX) -- Đường dẫn file sao lưu
AS
BEGIN
    BEGIN TRY
        -- Thực hiện sao lưu cơ sở dữ liệu
        DECLARE @BackupCommand NVARCHAR(MAX);
        SET @BackupCommand = 'BACKUP DATABASE ' + QUOTENAME(@DatabaseName) + ' TO DISK = @BackupFilePath';
        EXEC sp_executesql @BackupCommand, N'@BackupFilePath NVARCHAR(MAX)', @BackupFilePath;
        PRINT N'Sao lưu thành công!';
    END TRY
    BEGIN CATCH
        PRINT N'Lỗi xảy ra trong quá trình sao lưu: ' + ERROR_MESSAGE();
    END CATCH
END;
GO

---RESTORE DATABASE---

CREATE PROCEDURE RestoreDatabase
    @DatabaseName NVARCHAR(100), -- Tên cơ sở dữ liệu
    @BackupFilePath NVARCHAR(MAX) -- Đường dẫn file sao lưu
AS
BEGIN
    BEGIN TRY
        -- Đặt cơ sở dữ liệu ở chế độ đơn người dùng để ngừng kết nối
        DECLARE @RestoreCommand NVARCHAR(MAX);
        SET @RestoreCommand = 'ALTER DATABASE ' + QUOTENAME(@DatabaseName) + ' SET SINGLE_USER WITH ROLLBACK IMMEDIATE';
        EXEC sp_executesql @RestoreCommand;

        -- Khôi phục cơ sở dữ liệu
        SET @RestoreCommand = 'RESTORE DATABASE ' + QUOTENAME(@DatabaseName) + ' FROM DISK = @BackupFilePath WITH REPLACE';
        EXEC sp_executesql @RestoreCommand, N'@BackupFilePath NVARCHAR(MAX)', @BackupFilePath;

        -- Đặt cơ sở dữ liệu lại chế độ đa người dùng
        SET @RestoreCommand = 'ALTER DATABASE ' + QUOTENAME(@DatabaseName) + ' SET MULTI_USER';
        EXEC sp_executesql @RestoreCommand;

        PRINT 'Khôi phục cơ sở dữ liệu thành công!';
    END TRY
    BEGIN CATCH
        PRINT N'Lỗi xảy ra trong quá trình khôi phục: ' + ERROR_MESSAGE();
    END CATCH
END;
GO