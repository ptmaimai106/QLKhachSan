
use master
go 
create database quanlykhachsan123
go 

use quanlykhachsan123

create table NHANVIEN(
MANHANVIEN varchar (10) primary key,
CHUCVU nvarchar(20),
TENNHANVIEN nvarchar(30),
DIACHI nvarchar (50), 
SODIENTHOAI varchar (10),
)


create table  KHACHHANG (
CMND varchar (10) primary key,
TENKHACHHANG nvarchar(30),
GIOITINH nvarchar(10),
DIACHI nvarchar (50), 
SODIENTHOAI varchar (10),
)



create table LOAIPHONG(
MALOAIPHONG varchar (10) primary key,
TENLOAI nvarchar (20),
DONGIA int,
SONGUOITOIDA int,
)


create table PHONG(
MAPHONG varchar (10) primary key,
MALOAIPHONG varchar (10),
constraint fk_PHONG_LOAIPHONG foreign key (MALOAIPHONG) references LOAIPHONG(MALOAIPHONG),
)

create table LOAIDICHVU(
MALOAIDICHVU varchar (10) primary key,
TENLOAIDICHVU nvarchar(30),
)

create table DICHVU(
MADICHVU varchar (10) primary key,
TENDICHVU nvarchar(30),
MALOAIDICHVU varchar (10),
DONGIA int,
constraint fk_DICHVU_LOAIDICHVU foreign key (MALOAIDICHVU) references LOAIDICHVU(MALOAIDICHVU),
)

create table PHIEUDATPHONG(
MAPHIEUDAT varchar (10) primary key,
MAPHONG varchar (10),
TRANGTHAI nvarchar (20),
NGAYNHAN datetime,
NGAYDI datetime,
MAKHACHHANG varchar (10),
MANHANVIEN varchar (10),

constraint fk_PHIEUDATPHONG_PHONG foreign key (MAPHONG) references PHONG(MAPHONG),
constraint fk_PHIEUDATPHONG_KHACHHANG foreign key (MAKHACHHANG) references KHACHHANG(CMND),
constraint fk_PHIEUDATPHONG_NHANVIEN foreign key (MANHANVIEN) references NHANVIEN(MANHANVIEN),

)

create table PHIEUTHUEPHONG(
MAPHIEUTHUE varchar (10) primary key,
MAPHONG varchar (10),
NGAYTHUE datetime,
NGAYDI datetime,
MAKHACHHANG varchar (10),
MANHANVIEN varchar (10),
MAPHIEUDICHVU varchar (10),
MAPHIEUDAT varchar (10),
constraint fk_PHIEUTHUEPHONG_PHONG foreign key (MAPHONG) references PHONG(MAPHONG),
constraint fk_PHIEUTHUEPHONG_KHACHHANG foreign key (MAKHACHHANG) references KHACHHANG(CMND),
constraint fk_PHIEUTHUEPHONG_NHANVIEN foreign key (MANHANVIEN) references NHANVIEN(MANHANVIEN),
constraint fk_PHIEUTHUEPHONG_PHIEUDATPHONG foreign key (MAPHIEUDAT) references PHIEUDATPHONG(MAPHIEUDAT),

)


create table PHIEUDICHVU(
MAPHIEUDICHVU varchar (10) primary key,
MAPHIEUTHUE varchar (10),
MADICHVU varchar (10),
SOLUONG int,
THANHTIEN int,
constraint fk_PHIEUDICHVU_DICHVU foreign key (MADICHVU) references DICHVU(MADICHVU),
constraint fk_PHIEUDICHVU_PHIEUTHUEPHONG foreign key (MAPHIEUTHUE) references PHIEUTHUEPHONG(MAPHIEUTHUE),

)


alter table PHIEUTHUEPHONG
add constraint fk_PHIEUTHUEPHONG_PHIEUDICHVU foreign key (MAPHIEUDICHVU) references PHIEUDICHVU(MAPHIEUDICHVU);

create table HOADON(
MAHOADON varchar (10) primary key,
MAPHIEUTHUE varchar (10),
NGAYLAP datetime,
MANHANVIEN varchar (10),
TONGTIEN int,
constraint fk_HOADON_PHIEUTHUEPHONG foreign key (MAPHIEUTHUE) references PHIEUTHUEPHONG(MAPHIEUTHUE),
constraint fk_HOADON_NHANVIEN foreign key (MANHANVIEN) references NHANVIEN(MANHANVIEN),

)


--drop database quanlykhachsan1;


--NHÂN VIÊN

insert into NHANVIEN values('LT1',N'Lễ tân',N'NGUYỄN VĂN MỘT',N'Hà Nội','0357542892')
insert into NHANVIEN values('KT1',N'Kế toán',N'NGUYỄN VĂN HAI',N'Hà Nội','0987654234')
insert into NHANVIEN values('NS1',N'Nhân sự',N'NGUYỄN VĂN BA',N'Hà Nam','0357892345')
insert into NHANVIEN values('KT2',N'Kế toán',N'NGUYỄN THỊ TƯ',N'Hà Nội','0352316789')
insert into NHANVIEN values('LT2',N'Lễ tân',N'NGUYỄN VĂN NĂM',N'Hà Tĩnh','0985156278')
insert into NHANVIEN values('QL1',N'Quản lý',N'NGUYỄN THỊ SÁU',N'Hòa Bình','0989124356')



--LOẠI PHÒNG
insert into LOAIPHONG values ('VIP1', N'Phòng VIP 1',500000,2)
insert into LOAIPHONG values ('VIP2', N'Phòng VIP 2',1000000,3)
insert into LOAIPHONG values ('VIP3', N'Phòng VIP 3',2000000,5)

-- PHÒNG 

insert into PHONG values ('PA01','VIP1')
insert into PHONG values ('PA02','VIP1')
insert into PHONG values ('PA03','VIP1')
insert into PHONG values ('PA04','VIP1')
insert into PHONG values ('PA05','VIP1')
insert into PHONG values ('PA06','VIP1')
insert into PHONG values ('PA07','VIP1')
insert into PHONG values ('PA08','VIP1')
insert into PHONG values ('PA09','VIP1')
insert into PHONG values ('PA10','VIP1')

insert into PHONG values ('PB01','VIP2')
insert into PHONG values ('PB02','VIP2')
insert into PHONG values ('PB03','VIP2')
insert into PHONG values ('PB04','VIP2')
insert into PHONG values ('PB05','VIP2')
insert into PHONG values ('PB06','VIP2')
insert into PHONG values ('PB07','VIP2')
insert into PHONG values ('PB08','VIP2')
insert into PHONG values ('PB09','VIP2')
insert into PHONG values ('PB10','VIP2')

insert into PHONG values ('PC01','VIP3')
insert into PHONG values ('PC02','VIP3')
insert into PHONG values ('PC03','VIP3')
insert into PHONG values ('PC04','VIP3')
insert into PHONG values ('PC05','VIP3')
insert into PHONG values ('PC06','VIP3')
insert into PHONG values ('PC07','VIP3')
insert into PHONG values ('PC08','VIP3')
insert into PHONG values ('PC09','VIP3')
insert into PHONG values ('PC10','VIP3')

--LOẠI DỊCH VỤ

insert into LOAIDICHVU values ('PARTY',N'Dịch vụ tiệc tùng')
insert into LOAIDICHVU values ('RELAX',N'Dịch vụ giải trí')
insert into LOAIDICHVU values ('SPORT',N'Dịch vụ thể thao')
insert into LOAIDICHVU values ('WASH',N'Dịch vụ giặt ủi')
insert into LOAIDICHVU values ('OTHERS',N'Dịch vụ khác')

-- DỊCH VỤ

insert into DICHVU values ('DVPA01',N'Tổ chức tiệc cưới','PARTY', 50000000)
insert into DICHVU values ('DVPA02',N'Tổ chức tiệc sinh nhật','PARTY', 5000000)
insert into DICHVU values ('DVPA03',N'Tổ chức tiệc gặp mặt','PARTY', 10000000)
insert into DICHVU values ('DVRE01',N'KARAOKE','RELAX', 1000000)
insert into DICHVU values ('DVRE02',N'Xem phim','RELAX', 500000)
insert into DICHVU values ('DVRE03',N'Bar Club','RELAX', 3000000)
insert into DICHVU values ('DVSP01',N'Yoga','RELAX', 500000)
insert into DICHVU values ('DVSP02',N'GYM','RELAX', 500000)
insert into DICHVU values ('DVSP03',N'Bơi lội','RELAX', 500000)
insert into DICHVU values ('DVSP04',N'Lướt sóng','RELAX', 1000000)
insert into DICHVU values ('DVSP05',N'Trượt tuyết','RELAX', 1000000)
insert into DICHVU values ('DVWA01',N'Combo giặt + sấy','WASH', 300000)
insert into DICHVU values ('DVOT01',N'Nước suối','OTHERS', 20000)
insert into DICHVU values ('DVOT02',N'Nước ngọt các loại','OTHERS', 30000)
insert into DICHVU values ('DVOT03',N'Cơm trắng','OTHERS', 30000)
insert into DICHVU values ('DVOT04',N'Bữa sáng đặc biệt','OTHERS', 150000)
insert into DICHVU values ('DVOT05',N'Bữa trưa đặc biệt','OTHERS', 300000)
insert into DICHVU values ('DVOT06',N'Bữa tuối đặc biệt','OTHERS', 400000)
insert into DICHVU values ('DVOT07',N'Buffet nướng + lẩu hải sản','OTHERS', 1000000)
insert into DICHVU values ('DVOT08',N'Buffet chay','OTHERS', 500000)
insert into DICHVU values ('DVOT09',N'Các món ăn vặt khác','OTHERS', 50000)
insert into DICHVU values ('DVOT10',N'Thức ăn cho bữa chính đủ món','OTHERS', 100000)

--KHACHHANG 

insert into KHACHHANG values('212487422',N'Tạ Thị Tú Phi',N'Nữ',N'Hồ Chí Minh','0334994998')
insert into KHACHHANG values('212487423',N'Nguyễn Thị Mai Quyên',N'Nữ',N'Hồ Chí Minh','0334994997')
insert into KHACHHANG values('212487424',N'Trần Thị Lan Vi',N'Nữ',N'Cần Thơ','033499496')
insert into KHACHHANG values('212487425',N'Đỗ Công Trí',N'Nam',N'Long An','0334994995')
insert into KHACHHANG values('212487426',N'Mai Thanh Tùng',N'Nam',N'Vũng Tàu','0334994994')


--PHIEUTHUEPHONG

insert into PHIEUTHUEPHONG values('0001','PA01', 2018-12-22,2018-12-25,'212487422','NV1',NULL,NULL)
insert into PHIEUTHUEPHONG values('0002','PB01',2018-12-24,2018-12-29,'212487423','NV1',NULL,NULL)
insert into PHIEUTHUEPHONG values('0003','PB05',2018-12-25,2019-01-01,'212487424','NV5',NULL,NULL)
insert into PHIEUTHUEPHONG values('0004','PC06',2018-12-29,2019-01-03,'212487425','NV5',NULL,NULL)
insert into PHIEUTHUEPHONG values('0005','PA02',2019-01-01,2019-01-05,'212487426','NV5',NULL,NULL)

--PHIEUDICHVU

insert into PHIEUDICHVU values('0001','0001','DVSP01',2,1000000)
insert into PHIEUDICHVU values('0002','0002','DVSP02',2,1000000)
insert into PHIEUDICHVU values('0003','0003','DVSP03',2,1000000)
insert into PHIEUDICHVU values('0004','0004','DVWA01',1,300000)
insert into PHIEUDICHVU values('0005','0005','DVPA01',1,50000000)

--HOADON


insert into HOADON values('0001','0001',25/12/2018,'NV1',3000000)
insert into HOADON values('0002','0002',29/12/2018,'NV1',4000000)
insert into HOADON values('0003','0003',01/01/2019,'NV5',5000000)
insert into HOADON values('0004','0004',03/01/2019,'NV5',3000000)
insert into HOADON values('0005','0005',05/01/2019,'NV5',60000000)




select kh.CMND as N'Mã khách hàng',kh.TENKHACHHANG as N'Tên khách hàng', ptp.NGAYTHUE as N'Ngày đến', ptp.NGAYDI as N'Ngày đi', hd.TONGTIEN as N'Tổng tiền'
from HOADON hd, KHACHHANG kh,PHIEUTHUEPHONG ptp
where kh.CMND=ptp.MAKHACHHANG and ptp.MAPHIEUTHUE=hd.MAPHIEUTHUE and hd.NGAYLAP between '2018-12-19' and '2019-01-01'



select sum(TONGTIEN) as [Doanh thu] from HOADON where NGAYLAP >='2018-12-19' and NGAYLAP<='2019-01-01'

select dv.TENDICHVU as [Tên dịch vụ], pdv.SOLUONG as [Số lượng], pdv.THANHTIEN as [Tiền vốn]--, SUM(pdv.THANHTIEN)
from PHIEUDICHVU pdv, HOADON hd, DICHVU dv
where dv.MADICHVU=pdv.MADICHVU and hd.MAPHIEUTHUE=pdv.MAPHIEUTHUE  and hd.NGAYLAP between '2018-12-19' and '2019-01-01'--and pdv.THANHTIEN=pdv.THANHTIEN*0.75

select sum(pdv.THANHTIEN) as [Tiền vốn] from PHIEUDICHVU pdv,HOADON hd, DICHVU dv 
where dv.MADICHVU=pdv.MADICHVU and hd.MAPHIEUTHUE=pdv.MAPHIEUTHUE  and hd.NGAYLAP between '2018-12-19' and '2019-01-01'


select THANHTIEN from PHIEUDICHVU
where THANHTIEN=THANHTIEN*0.75
