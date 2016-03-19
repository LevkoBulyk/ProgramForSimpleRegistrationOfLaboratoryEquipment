CREATE FUNCTION fnCheckForViolator(@WorkerId INT)
RETURNS INT
BEGIN
	DECLARE @EquipmentId INT;
	SELECT @EquipmentId = EquipmentId FROM tblUsage
	WHERE WorkerId = @WorkerId AND ReturningDate IS NULL;
	RETURN @EquipmentId;
END;