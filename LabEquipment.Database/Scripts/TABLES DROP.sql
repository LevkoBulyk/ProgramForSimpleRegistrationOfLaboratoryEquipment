
USE LabEquipment;
GO

IF EXISTS(SELECT 1 FROM sys.tables WHERE Name = 'tblUsage')
	DROP TABLE tblUsage;
GO

IF EXISTS(SELECT 1 FROM sys.tables WHERE Name = 'tblEquipment')
	DROP TABLE tblEquipment;
GO

IF EXISTS(SELECT 1 FROM sys.tables WHERE Name = 'tblWorker')
	DROP TABLE tblWorker;
GO
