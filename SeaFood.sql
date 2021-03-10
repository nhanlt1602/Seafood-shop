create database Seafood
go
 
use Seafood
go 
-- Create table
create table Users(
userId			int				identity(1,1) primary key not null,
userName		varchar(40)		not null,
password		varchar(30)		not null,
roleId			int				not null,
fullName		nvarchar(50)	not null,
phoneNumber		varchar(15)		null,
address			nvarchar(50)	null,
status			int				not null
)

create table Role(
roleId			int				identity(1,1) primary key not null,
roleName		varchar(50)		not null,
)


create table Product(
proId			int				identity(1,1) primary key not null,
proTypeId		int				not null,
proName			nvarchar(50)	not null,
proQuantity		int				not null,
proPrice		float			not null,
imgUrl			varchar(100)	not null,
status			int				not null
)




create table Category(
proTypeId		int				identity(1,1) primary key not null,
proTypeName		nvarchar(50)	not null,
)


create table Orders (
orderId			int				identity(1,1) primary key not null,
userId			int		not null,	
fullName		nvarchar(50)	not null,
orderTotal		float			not null,
status			int				not null
)


create table OrderDetail(
orderItemId		int				identity(1,1) primary key not null,
proId			int		not null,
orderId			int				not null,
orderItemQuantity	int			not null,
orderItemPrice	float			not null,
status			int				not null
)



--Create relationshop with table

ALTER TABLE Product ADD CONSTRAINT a1
FOREIGN KEY (proTypeId) references Category(proTypeId)

ALTER TABLE Users ADD CONSTRAINT a2
FOREIGN KEY (roleId) references Role(roleId)

ALTER TABLE Orders ADD CONSTRAINT a4
FOREIGN KEY (userId) references Users(userId)

ALTER TABLE OrderDetail ADD CONSTRAINT a3
FOREIGN KEY (orderId) references Orders(orderId)

ALTER TABLE OrderDetail ADD CONSTRAINT a5
FOREIGN KEY (proId) references Product(proId)

Insert into Category(proTypeId, proTypeName)
values ('1', 'Thun'),
		('2', 'Luoi'),
		('3', 'Mong'),
		('4', 'Xin'),
		('5', 'Phi')


Insert into Role(roleId,roleName)
values	('1','Admin'),
		('2','User'),



