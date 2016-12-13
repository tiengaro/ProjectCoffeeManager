use master
if exists (select * from sys.databases where name = 'QLCafe')
drop database QLCafe
create database QLCafe
go
use QLCafe
create table LoaiSanPham
(
	MaLoaiSanPham int identity(1,1),
	TenLoaiSanPham nvarchar(50),
	primary key(MaLoaiSanPham)
)
go
create table SanPham
(
	MaSanPham int identity(1,1),
	TenSanPham nvarchar(50),
	GiaBan float,
	MaLoaiSanPham int,
	primary key(MaSanPham)
)
go
create table HoaDon
(
	MaHD int identity(1,1),
	NgayLap date,
	primary key(MaHD)
)
go
create table ChiTietHoaDon
(
	MaCTHD int identity(1,1),
	MaSanPham int,
	MaHD int,
	SoLuong int,
	ThanhTien float,
	primary key(MaCTHD)
) 
go
alter table SanPham add  foreign key(MaLoaiSanPham) references LoaiSanPham(MaLoaiSanPham)
go
alter table ChiTietHoaDon add  foreign key(MaSanPham) references SanPham(MaSanPham)
go
alter table ChiTietHoaDon add  foreign key(MaHD) references HoaDon(MaHD)
go
insert into LoaiSanPham(TenLoaiSanPham) values(N'Cà phê')
insert into LoaiSanPham(TenLoaiSanPham) values(N'Ca cao')
insert into LoaiSanPham(TenLoaiSanPham) values(N'Trà')
insert into LoaiSanPham(TenLoaiSanPham) values(N'Sữa')
insert into LoaiSanPham(TenLoaiSanPham) values(N'Nước chanh các loại')
insert into LoaiSanPham(TenLoaiSanPham) values(N'Thực đơn')
go
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Cà phê đen',1,29000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Cà phê đá',1,31000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Cà phê sữa nóng',1,33000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Cà phê sữa đá',1,35000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Cà phê rum',1,45000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Cà phê kem (Ly kem dừa)',1,48000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Cà phê Baileys',1,47000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Cà phê sữa Baileys',1,50000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Ca cao nóng',2,41000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Cacao đá',2,43000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Cacao sữa nóng',2,45000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Cacao sữa đá',2,47000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Chocolate nóng',2,39000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Chocolate đá',2,41000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Chocolate sữa nóng',2,41000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Chocolate sữa đá',2,44000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Bạc xỉu nóng',2,37000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Bạc xỉu đá',2,40000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Lipton nóng',3,35000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Lipton đá',3,39000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Lipton sữa nóng',3,38000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Lipton sữa đá',3,40000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Lipton mật ong',3,40000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Lipton xí mụi',3,42000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Lipton hương trái cây',3,40000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Lipton hương trái cây - sữa',3,40000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Lipton Chanh dây',3,40000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Trà gừng nóng',3,36000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Trà gừng đá',3,37000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Trà hoa cúc nóng',3,35000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Trà hoa cúc đá',3,37000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'La hán quả nóng',3,34000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'La hán quả đá',3,36000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'La hán sữa đá',3,39000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Sữa đặc nóng',4,35000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Sữa tươi nóng',4,35000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Sữa tươi đá',4,37000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Sữa tươi không đá',4,44000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Sữa tươi sirô (dâu, bạc hà, chanh, ...)',4,40000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Sữa tươi cà phê đá',4,40000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Sữa tươi cà phê không đá',4,44000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Sữa tươi cacao đá',4,47000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Sữa chanh',4,39000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Sữa tắc',4,39000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Sam dứa sữa',4,42000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Sữa lắc trái cây (dâu, chuối, sa-pô-chê)',4,48000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Frappuchino Caramel',4,50000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Frappuchino Vani',4,50000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Sữa lắc sirô',4,45000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Chanh tươi nóng',5,35000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Chanh tươi đá',5,38000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Chanh tươi xí muội',5,34000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Chanh tuyết',5,36000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Chanh muối nóng',5,36000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Chanh muối đá',5,38000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Chanh muối xí muội',5,38000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Xí mụi nóng',5,37000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Xí mụi đá',5,38000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Tắc đá',5,38000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Tắc xí muội',5,40000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Dừa tươi',5,42000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Mơ ngâm',5,43000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Sấu ngâm - ly',5,43000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Đá me',5,41000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Trái cây dữa với sữa, sirô, đá',5,45000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Bánh ướt nem chua, giò lụa',6,41000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Cơm tấm sườn nướng',6,43000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Cơm tấm sườn non nướng',6,49000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Cơm chiên chà bông giòn',6,49000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Xúc xích nướng',6,35000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Thịt nướng xiên que',6,41000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Ba rọi cuộn xiên que',6,41000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Bánh mì ốp la xúc xích',6,41000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Bánh mì cá hộp',6,41000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Bánh mì thập cẩm',6,43000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Hủ tiếu/ Mì bò viên',6,45000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Mì gói giò lụa, xúc xích',6,45000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Mì hoành thánh',6,46000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Há cảo hấp',6,41000)
insert into SanPham(TenSanPham,MaLoaiSanPham,GiaBan) values(N'Salad cá ngừ',6,51000)