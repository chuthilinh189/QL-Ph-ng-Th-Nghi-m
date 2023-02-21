USE [QuanLyPhongThiNghiem]
GO

--------------------------------------------------------------

CREATE TRIGGER [dbo].[tgDeletePhongThiNghiem]
ON [dbo].[PhongThiNghiem]
INSTEAD OF DELETE
-- Trigger xóa PTN: 
-- Xóa chi tiết đăng ký thuộc Phòng trước
-- Xóa Phòng sau
AS
BEGIN
	DELETE FROM dbo.ChiTietDangKi WHERE MaPTN IN (SELECT MaPhong FROM deleted)
	DELETE FROM dbo.PhongThiNghiem WHERE MaPhong IN (SELECT MaPhong FROM deleted)
END
GO

--------------------------------------------------------------

CREATE TRIGGER [dbo].[tgDeleteChiTietDangKi]
ON [dbo].[ChiTietDangKi]
INSTEAD OF DELETE
-- Trigger xóa ChiTietDangKy: 
-- Xóa chi tiết sử dụng của ChiTietDangKy trước
-- Xóa ChiTietDangKy sau
AS
BEGIN
	DELETE FROM dbo.ChiTietSuDung WHERE MaCTDK IN (SELECT MaCTDK FROM deleted)
	DELETE FROM dbo.ChiTietDangKi WHERE MaCTDK IN (SELECT MaCTDK FROM deleted)

END
GO

--------------------------------------------------------------

CREATE TRIGGER [dbo].[tgDeleteBaiThiNghiem]
ON [dbo].[BaiThiNghiem]
INSTEAD OF DELETE
-- Trigger xóa Bài thí nghiệm: 
-- Xóa chi tiết trang thiết bị cần dùng trước
-- Xóa bài thí nghiệm sau
AS
BEGIN

	DELETE FROM dbo.ChiTietTTBCanDung  WHERE MaBTN IN (SELECT MaBTN FROM deleted)
	DELETE FROM dbo.BaiThiNghiem WHERE MaBTN IN (SELECT MaBTN FROM deleted)

END
GO

--------------------------------------------------------------

CREATE TRIGGER [dbo].[tgInsertChiTietSuDung]
ON [dbo].[ChiTietSuDung]
INSTEAD OF INSERT
-- Trigger thêm Chi tiết sử dụng:
-- Nếu Ca sử dụng đang ở tình trạng Chưa thực hiện thì sửa thành tình trạng Đã thực hiện
-- Sau đó thêm Chi tiết sử dụng
AS
BEGIN
	DECLARE 
		@MaChiTietSD	varchar(20),
		@MaCTDK			varchar(20),
		@MaTTB			varchar(20)

	SELECT @MaChiTietSD = MaChiTietSD FROM inserted
	SELECT @MaCTDK = MaCTDK FROM inserted
	SELECT @MaTTB = MaTTB FROM inserted
	
	UPDATE dbo.ChiTietDangKi
	SET	TinhTrang = N'Đã thực hiện'
	WHERE MaCTDK = @MaCTDK

	INSERT INTO dbo.ChiTietSuDung(MaChiTietSD, MaCTDK, MaTTB)
	VALUES (@MaChiTietSD, @MaCTDK, @MaTTB)

END
GO