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