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
	PermanentLocation NVARCHAR(100) NOT NULL

	CONSTRAINT PK_tblEquipment_Id PRIMARY KEY (Id)
);
GO

CREATE TABLE tblWorker
(
	Id INT NOT NULL IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Post NVARCHAR(30) NOT NULL,
	PhoneNumber NVARCHAR(12) NULL

	CONSTRAINT PK_tblWorker_Id PRIMARY KEY (Id),
	CONSTRAINT CK_tblEquipment_PhoneNumber CHECK(PhoneNumber LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
									  		  OR PhoneNumber LIKE 'null')
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
