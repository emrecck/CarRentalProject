use RentACar
go

create table Users(
	Id int IDENTITY (1,1) NOT NULL PRIMARY KEY,
	FirstName varchar(20) NOT NULL,
	LastName varchar(20) NOT NULL,
	Email nvarchar(100) NOT NULL,
	"Password" varchar(20) NOT NULL, 
)

create table Customers(
	Id int IDENTITY (1,1) NOT NULL PRIMARY KEY,
	UserId int NOT NULL,
	CompanyName varchar(50) NOT NULL,
	CONSTRAINT "FK_User_Customer" FOREIGN KEY(UserId)
	REFERENCES dbo.Users(Id)
)

create table Rentals(
	Id int IDENTITY (1,1) NOT NULL PRIMARY KEY,
	CarId int NOT NULL,
	CustomerId int NOT NULL,
	RentDate DateTime NOT NULL,
	ReturnDate DateTime NULL,
	CONSTRAINT "FK_Rental_Car" FOREIGN KEY(CarID)
	REFERENCES dbo.Cars(Id),
	CONSTRAINT "FK_Rental_Customer" FOREIGN KEY(CustomerId)
	REFERENCES dbo.Customers(Id)
)