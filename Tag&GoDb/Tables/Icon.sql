CREATE TABLE [dbo].[Icon]
(
	[Icon_Id] INT IDENTITY,
	[IconName] NVARCHAR(32) NOT NULL,
	[IconDescription] NVARCHAR(128) NOT NULL,
	[IconUrl] NVARCHAR(2048) NOT NULL,
	[Active] BIT DEFAULT 1

	CONSTRAINT PK_Icon PRIMARY KEY ([Icon_Id])
)

GO

CREATE TRIGGER [dbo].[OnDeleteIcon]
	ON [dbo].[Icon]
	INSTEAD OF DELETE
	AS 
	BEGIN
		UPDATE Icon SET Active = 0
		WHERE Icon_Id = (SELECT Icon_Id FROM deleted)
	END