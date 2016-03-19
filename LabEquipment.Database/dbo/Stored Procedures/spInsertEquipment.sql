CREATE PROCEDURE spInsertEquipment
	@Name NVARCHAR(100),
	@PermanentLocation NVARCHAR(100),
	@Id INT OUTPUT
AS
BEGIN
	INSERT INTO tblEquipment
	(Name, PermanentLocation) VALUES (@Name, @PermanentLocation)
	SET @Id =@@IDENTITY;
END;