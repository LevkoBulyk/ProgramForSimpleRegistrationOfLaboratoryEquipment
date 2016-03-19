CREATE PROCEDURE spWrittingAboutTaking
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