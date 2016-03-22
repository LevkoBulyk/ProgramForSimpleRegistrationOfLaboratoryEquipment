CREATE TABLE tblWorker
(
	Id INT NOT NULL IDENTITY,
	ManagerId INT NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Post NVARCHAR(30) NOT NULL,
	PhoneNumber NVARCHAR(12) NULL,
	[Login] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Disabled] BIT NOT NULL

	CONSTRAINT PK_tblWorker_Id PRIMARY KEY (Id),
	CONSTRAINT FK_tblWorker_ManagerId_tblWorker_Id FOREIGN KEY (ManagerId) REFERENCES tblWorker(Id),
	CONSTRAINT CK_tblWorker_PhoneNumber CHECK(PhoneNumber LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
									  		  OR PhoneNumber LIKE 'null'),
	CONSTRAINT UQ_tblWorker_Login UNIQUE([Login])
);