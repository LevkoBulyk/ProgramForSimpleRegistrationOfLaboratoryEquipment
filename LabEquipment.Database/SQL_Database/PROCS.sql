USE LabEquipment;
GO

-- Function that checks for debts of worker.
IF EXISTS(SELECT 1 FROM sys.objects WHERE type IN ('FN', 'IF', 'TF') AND Name = 'fnCheckForViolator')
BEGIN
	DROP FUNCTION fnCheckForViolator;
END;
GO

CREATE FUNCTION fnCheckForViolator(@WorkerId INT)
RETURNS INT
BEGIN
	DECLARE @EquipmentId INT;
	SELECT @EquipmentId = EquipmentId FROM tblUsage
	WHERE WorkerId = @WorkerId AND ReturningDate IS NULL;
	RETURN @EquipmentId;
END;
GO

-- Function that checks if particular piece of equipment is not taken.
IF EXISTS(SELECT 1 FROM sys.objects WHERE type IN ('FN', 'IF', 'TF') AND Name = 'fnCheckForAvailability')
BEGIN
	DROP FUNCTION fnCheckForAvailability;
END;
GO

CREATE FUNCTION fnCheckForAvailability(@EquipmentId INT)
RETURNS INT
BEGIN
	DECLARE @WorkerId INT;
	SELECT @WorkerId = WorkerId FROM tblUsage
	WHERE EquipmentId = @EquipmentId AND ReturningDate IS NULL;
	RETURN @WorkerId;
END;
GO

-- Procedure, that inserts new record about act of taking.
IF EXISTS(SELECT 1 FROM sys.procedures WHERE Name = 'spInsertNewUsage')
BEGIN
	DROP PROCEDURE spInsertNewUsage;
END;
GO

CREATE PROCEDURE spInsertNewUsage
	@EquipmentId INT,
	@WorkerId INT,
	@UsageId INT OUTPUT
AS
BEGIN
	IF dbo.fnCheckForViolator(@WorkerId) IS NOT NULL
	BEGIN
		RAISERROR('This worker can not take equipment, because he/she has debts.', 16, 1);
		RETURN -1;
	END;
	IF dbo.fnCheckForAvailability(@EquipmentId) IS NOT NULL
	BEGIN
		RAISERROR('This equipment is taken by someone already.', 16, 1);
		RETURN -2;
	END;
	INSERT INTO tblUsage
	(EquipmentID, WorkerId, TakeingDate)
	VALUES
	(@EquipmentId, @WorkerId, GETDATE());
	SET @UsageId = @@IDENTITY;
END;
GO
/*
IF EXISTS(SELECT 1 FROM sys.procedures WHERE Name = 'spInsertEquipment')
BEGIN
	DROP PROCEDURE spInsertEquipment;
END;
GO

CREATE PROCEDURE spInsertEquipment
	@Name NVARCHAR(100),
	@PermanentLocation NVARCHAR(100),
	@Id INT OUTPUT
AS
BEGIN
	INSERT INTO tblEquipment
	(Name, PermanentLocation, [Disabled]) VALUES (@Name, @PermanentLocation, 0)
	SET @Id =@@IDENTITY;
END;
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE Name = 'spInsertWorker')
BEGIN
	DROP PROCEDURE spInsertWorker;
END;
GO

CREATE PROCEDURE spInsertWorker
	@FirstName NVARCHAR(30), 
	@LastName NVARCHAR(30),
	@Post NVARCHAR(30),
	@PhoneNumber NVARCHAR(12),
	@Id INT OUTPUT
AS
BEGIN
	INSERT INTO tblWorker (ManagerId, FirstName, LastName, Post, PhoneNumber, [Login], [Password], [Disabled])
	VALUES (@ManagerId, @FirstName, @LastName, @Post, @PhoneNumber, @Login, @Password, @Disabled);
	SET @Id = @@IDENTITY;
END;
GO
*/

SELECT Id, EquipmentId, WorkerId, TakeingDate, ReturningDate FROM tblUsage WHERE ReturningDate IS NULL;


DECLARE @UsageId INT;
EXEC spInsertNewUsage 1, 5, @UsageId;
