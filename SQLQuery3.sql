use RentACar
go

create table CarImages(
	Id int IDENTITY (1,1) NOT NULL PRIMARY KEY,
	CarId int NOT NULL,
	ImagePath nvarchar(250) NOT NULL,
	"Date" DateTime NOT NULL DEFAULT GETDATE(),
	CONSTRAINT "FK_Car_CarImage" FOREIGN KEY(CarId)
	REFERENCES dbo.Cars(Id)
)