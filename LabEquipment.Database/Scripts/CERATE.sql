
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
