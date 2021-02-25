create database RentACar
go

use RentACar
go


create table "Brands"(
	"Id" "int" IDENTITY (1,1) NOT NULL PRIMARY KEY,
	"Name" nvarchar(20) NOT NULL
)
go

create table "Colors"(
	"Id" "int" IDENTITY (1,1) NOT NULL PRIMARY KEY,
	"Name" nvarchar(20) NOT NULL
)
go
create table "Cars"(
	"Id" "int" IDENTITY (1,1) NOT NULL ,
	"BrandId" "int" NOT NULL,
	"ColorId" "int" NOT NULL,
	"ModelYear" "int" NOT NULL,
	"DailyPrice" "int" NOT NULL,
	"Description" nvarchar(100) NOT NULL,
	CONSTRAINT "PK_Cars" PRIMARY KEY CLUSTERED
	(
		"Id"
	),
	CONSTRAINT "FK_Brand_Car" FOREIGN KEY
	(
		"BrandId"
	) REFERENCES "dbo"."Brands"
	(
		"Id"	
	),
	CONSTRAINT "FK_Color_Car" FOREIGN KEY(ColorID)
	REFERENCES "dbo"."Colors"(Id)
)

