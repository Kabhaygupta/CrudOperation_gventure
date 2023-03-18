create database CrudOperation_gventure
use CrudOperation_gventure

Create table Enrollment(
EnrollmentID int not null primary key identity(1,1),
Name varchar(50) ,
Email nvarchar(50) ,
Password nvarchar(30) ,
);
insert into Enrollment values('Abhay Kumar','emailtoakgupta@gmail.com','Abhay@123');
select *from Enrollment


Create table Companies(
C_Id int identity(1,1) primary key,
C_Name varchar(255) unique,
C_Address varchar(255),
);


insert into Companies values('FlipKart','Delhi');
insert into Companies values('Amazone','Delhi');


Create table Products(
P_Id int identity(101,1) primary key,
P_Name varchar(255),
P_Model varchar(20),
P_Price decimal(8,2),
Comp_Id int foreign key references Companies(C_Id)
);



insert into Products values('Laptop','E_series',50000,1) 
insert into Products values('Watch','E123',1500,2) 
insert into Products values('Bat','SP1234',2000,1) 
insert into Products values('Mobile','T635',200000,2) 
insert into Products values('Book','SP456',1005,1) 
insert into Products values('Bag','M1234',1500,2) 

Select *from tbl_Companies
select *From tbl_Products