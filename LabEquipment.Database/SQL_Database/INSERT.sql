USE LabEquipment;
GO

SET IDENTITY_INSERT tblWorker ON
INSERT INTO tblWorker
(Id, ManagerId, LastName, FirstName, Post, PhoneNumber, [Login], [Password], [Disabled])
VALUES
(1, 1, 'Волошиновський', 'Анатолій', 'Керівник лабораторії', NULL, 'Волошиновський', 'c33367701511b4f6020ec61ded352059', 0),
(2, 1, 'Вістовський', 'Володимир', 'С.Н.С.', '(065)1236584', 'Володимир', 'c33367701511b4f6020ec61ded352059', 0),
(3, 1, 'Пашук', 'Ігор', 'С.Н.С.', NULL, 'Ігор', 'c33367701511b4f6020ec61ded352059', 0),
(4, 3, 'Кость', 'Любмир', 'Студент магістр', '(050)0505056', 'Любко', 'c33367701511b4f6020ec61ded352059', 0),
(5, 2, 'Савка', 'Іванна', 'Студент магістр', NULL, 'Іванка', 'c33367701511b4f6020ec61ded352059', 0),
(6, 1, 'Цюмра', 'Володимир', 'Студент магістр', '(654)3210987', 'VolBog', 'c33367701511b4f6020ec61ded352059', 0),
(7, 1, 'Булик', 'Лев-Іван', 'Студент магістр', '(098)4845528', 'Левко', 'c33367701511b4f6020ec61ded352059', 0)
SET IDENTITY_INSERT tblWorker OFF
GO

SET IDENTITY_INSERT tblEquipment ON
INSERT INTO tblEquipment
(Id, Name, PermanentLocation, [Disabled])
VALUES
(1, 'Sample Rammer', 'Середня шухляда Тарасового стола', 0),
(2, 'Small UV Lamp', 'У столі в кімнаті Смолуховського', 0),
(3, 'PH-метр', 'Л-014 в шафі з хімікатами', 0),
(4, 'Магнітна мішалка', 'Л-014 на столі', 0),
(5, 'Центрифуга MPW-310', 'Л-014', 0),
(6, 'Відкрита центрифуга', 'Л-014', 0),
(7, 'Скальпель', 'Л-014 шафа біля входу', 0)
SET IDENTITY_INSERT tblEquipment OFF
GO
