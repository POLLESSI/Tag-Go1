CREATE TABLE [dbo].[Person]
(
	[Person_Id] INT IDENTITY,
	[Lastname] NVARCHAR(32) NOT NULL,
	[Firstname] NVARCHAR(32) NOT NULL,
	[Email] NVARCHAR(64) NOT NULL,
	[Address_Street] NVARCHAR(64) NOT NULL,
	[Address_Nbr] NVARCHAR(8) NOT NULL, 
	[PostalCode] NVARCHAR(8) NOT NULL,
	[Address_City] NVARCHAR(64) NOT NULL,
	[Address_Country] NVARCHAR(64) NULL,
	[Telephone] NVARCHAR(16) NULL,
	[Gsm] NVARCHAR(16) NULL,
	[Active] BIT DEFAULT 1

	CONSTRAINT PK_Person PRIMARY KEY ([Person_Id])
)

GO

CREATE TRIGGER [dbo].[OnDeletePerson]
	ON [dbo].[Person]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE Person SET Active = 0
		WHERE Person_Id = (SELECT Person_Id FROM deleted)
	END