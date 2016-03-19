CREATE PROCEDURE spInsertWorker
	@FirstName NVARCHAR(30), 
	@LastName NVARCHAR(30),
	@Post NVARCHAR(30),
	@PhoneNumber NVARCHAR(12),
	@Id INT OUTPUT
AS
BEGIN
	INSERT INTO tblWorker (FirstName, LastName, Post, PhoneNumber)
	VALUES (@FirstName, @LastName, @Post, @PhoneNumber);
	SET @Id = @@IDENTITY;
END;