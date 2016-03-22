USE master;
GO

IF EXISTS(SELECT 1 FROM sys.databases WHERE Name = 'LabEquipment')
BEGIN
	DROP DATABASE LabEquipment;
END;
GO

CREATE DATABASE LabEquipment;
GO

USE LabEquipment;
GO

CREATE TABLE tblEquipment
(
	Id INT NOT NULL IDENTITY,
	Name NVARCHAR(100) NOT NULL,
	PermanentLocation NVARCHAR(100) NOT NULL,
	[Disabled] BIT NOT NULL

	CONSTRAINT PK_tblEquipment_Id PRIMARY KEY (Id)
);
GO

CREATE TABLE tblWorker
(
	Id INT NOT NULL IDENTITY,
	ManagerId INT NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Post NVARCHAR(30) NOT NULL,
	PhoneNumber NVARCHAR(12) NULL,
	[Login] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Disabled] BIT NOT NULL

	CONSTRAINT PK_tblWorker_Id PRIMARY KEY (Id),
	CONSTRAINT FK_tblWorker_ManagerId_tblWorker_Id FOREIGN KEY (ManagerId) REFERENCES tblWorker(Id),
	CONSTRAINT CK_tblWorker_PhoneNumber CHECK(PhoneNumber LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
									  		  OR PhoneNumber LIKE 'null'),
	CONSTRAINT UQ_tblWorker_Login UNIQUE([Login])
);
GO

CREATE TABLE tblUsage
(
	Id INT NOT NULL IDENTITY,
	EquipmentId INT NOT NULL,
	WorkerId INT NOT NULL,
	TakeingDate DATETIME NOT NULL,
	ReturningDate DATETIME NULL

	CONSTRAINT PK_tblUsage_Id PRIMARY KEY (Id),
	CONSTRAINT FK_tblUsage_Id_tblEquipment_Id FOREIGN KEY (EquipmentId) REFERENCES tblEquipment(Id),
	CONSTRAINT FK_tblUsage_Id_tblWorker_Id FOREIGN KEY (WorkerId) REFERENCES tblWorker(Id)
);
GO
