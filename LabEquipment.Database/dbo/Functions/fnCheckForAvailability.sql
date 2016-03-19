CREATE FUNCTION fnCheckForAvailability(@EquipmentId INT)
RETURNS INT
BEGIN
	DECLARE @WorkerId INT;
	SELECT @WorkerId = WorkerId FROM tblUsage
	WHERE EquipmentId = @EquipmentId AND ReturningDate IS NULL;
	RETURN @WorkerId;
END;