CREATE TABLE tblUsage
(
	Id INT NOT NULL IDENTITY,
	EquipmentId INT NOT NULL,
	WorkerId INT NOT NULL,
	TakeingDate DATETIME NOT NULL,
	ReturningDate DATETIME NULL

	CONSTRAINT PK_tblUsage_Id PRIMARY KEY (Id),
	CONSTRAINT FK_tblUsage_Id_tblEquipment_Id FOREIGN KEY (EquipmentId) REFERENCES tblEquipment(Id),
	CONSTRAINT FK_tblUsage_Id_tblWorker_Id FOREIGN KEY (WorkerId) REFERENCES tblWorker(Id)
);