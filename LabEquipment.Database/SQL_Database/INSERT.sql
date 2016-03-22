USE LabEquipment;
GO

SET IDENTITY_INSERT tblWorker ON
INSERT INTO tblWorker
(Id, ManagerId, LastName, FirstName, Post, PhoneNumber, [Login], [Password], [Disabled])
VALUES
(1, 1, '��������������', '�������', '������� ���������', NULL, '��������������', 'c33367701511b4f6020ec61ded352059', 0),
(2, 1, '³���������', '���������', '�.�.�.', '(065)1236584', '���������', 'c33367701511b4f6020ec61ded352059', 0),
(3, 1, '�����', '����', '�.�.�.', NULL, '����', 'c33367701511b4f6020ec61ded352059', 0),
(4, 3, '�����', '������', '������� ������', '(050)0505056', '�����', 'c33367701511b4f6020ec61ded352059', 0),
(5, 2, '�����', '������', '������� ������', NULL, '������', 'c33367701511b4f6020ec61ded352059', 0),
(6, 1, '�����', '���������', '������� ������', '(654)3210987', 'VolBog', 'c33367701511b4f6020ec61ded352059', 0),
(7, 1, '�����', '���-����', '������� ������', '(098)4845528', '�����', 'c33367701511b4f6020ec61ded352059', 0)
SET IDENTITY_INSERT tblWorker OFF
GO

SET IDENTITY_INSERT tblEquipment ON
INSERT INTO tblEquipment
(Id, Name, PermanentLocation, [Disabled])
VALUES
(1, 'Sample Rammer', '������� ������� ���������� �����', 0),
(2, 'Small UV Lamp', '� ���� � ����� ��������������', 0),
(3, 'PH-����', '�-014 � ���� � ���������', 0),
(4, '������� ������', '�-014 �� ����', 0),
(5, '���������� MPW-310', '�-014', 0),
(6, '³������ ����������', '�-014', 0),
(7, '���������', '�-014 ���� ��� �����', 0)
SET IDENTITY_INSERT tblEquipment OFF
GO
