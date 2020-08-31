use master
go

create database [GeoTema]
go

use [GeoTema]
go

create table [UserTable](
[ID] int identity(1,1) primary key not null,
[Username] varchar(16) unique not null,
[Password] varchar(32) COLLATE SQL_Latin1_General_CP437_BIN not null,
[Type] tinyint not null)
go

insert into dbo.[UserTable] values ('Admin', 'Passw0rd1',3)
go

create table [GeoTable](
[ID] int identity(1,1) primary key not null,
[PostalCode] int not null,
[City] varchar(32) unique not null,
[Population] int not null,
[Temperature] float not null
)
go

create table [CountryTable](
[ID] int identity(1,1) primary key not null,
[Country] varchar(40) unique not null,
[Continent] varchar(40) not null,
[SecondaryContinent] varchar(40) null,
[Birthrate] float not null
)
go

create table [RankTable](
[ID] int identity(1,1) primary key not null,
[Country] varchar(40) unique foreign key references [CountryTable]([Country]) not null,
[Rank] int unique not null)
go

CREATE VIEW vw_combined
as select 
[CountryTable].[ID],
[CountryTable].[Country],
[CountryTable].[Continent],
[CountryTable].[SecondaryContinent],
[RankTable].[Rank],
[CountryTable].[Birthrate]
from CountryTable
inner join [RankTable] ON CountryTable.Country = RankTable.[Country]
go

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'admin')
CREATE LOGIN [admin] WITH PASSWORD = 'Passw0rd'
GO
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'admin')
BEGIN
    CREATE USER [admin] FOR LOGIN [admin]
    EXEC sp_addrolemember N'db_owner', N'admin'
END;
GO