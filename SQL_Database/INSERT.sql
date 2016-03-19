USE LabEquipment;
GO

SET IDENTITY_INSERT tblWorker ON
INSERT INTO tblWorker
(Id, LastName, FirstName, Post, PhoneNumber)
VALUES
(1, 'Voloshinovskii', 'Anatolii', 'Head of the laboratory', NULL),
(2, 'Vistovskii', 'Volodymyr', 'Laboratory Worker', NULL),
(3, 'Pushak', 'Igor', 'Laboratory Worker', NULL),
(4, 'Bulyk', 'Levko', 'Master student', '(063)2086866'),
(5, 'Tzumra', 'Volodymyr', 'Master student', NULL)
SET IDENTITY_INSERT tblWorker OFF
GO

SET IDENTITY_INSERT tblEquipment ON
INSERT INTO tblEquipment
(Id, Name, PermanentLocation)
VALUES
(1, 'Sample Rammer', 'Tara"s desck, middle drawer'),
(2, 'Small UV Lamp', 'In drawwer of table in Smoluhovskii"s room'),
(3, 'PH-meter', 'Ë-014 in wardrobe with chemicals'),
(4, 'Magnatic stirrer', 'Ë-014 Desc'),
(5, 'Centrifuge MPW-310', 'Ë-014'),
(6, 'Old Centrifuge', 'Ë-014')
SET IDENTITY_INSERT tblEquipment OFF
GO
