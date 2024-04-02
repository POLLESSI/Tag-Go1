CREATE TABLE [dbo].[NUser]
(
	[NUser_Id] UNIQUEIDENTIFIER DEFAULT NEWID(),
	[Email] NVARCHAR(64) NOT NULL,
	[Pwd] BINARY(64) NULL,
	[SecurityStamp] UNIQUEIDENTIFIER NULL,
	[Person_Id] INT NOT NULL,
	[Role_Id] INT NOT NULL DEFAULT 3,
	[Avatar_Id] INT NULL UNIQUE,
	[Point] INT NULL DEFAULT 0,
	[Active] BIT DEFAULT 1

	CONSTRAINT [CK_NUser_Email] CHECK (Email like '__%@__%_%'),
	CONSTRAINT [PK_NUser] PRIMARY KEY ([NUser_Id]),
	CONSTRAINT [FK_NUser_Person] FOREIGN KEY (Person_Id) REFERENCES [Person] ([Person_Id]),
	CONSTRAINT [FK_NUser_Avatar] FOREIGN KEY (Avatar_Id) REFERENCES [Avatar] ([Avatar_Id]),
	CONSTRAINT [UK_Avatar_Id] UNIQUE ([Avatar_Id])
)

GO

CREATE TRIGGER [dbo].[OnDeleteNUser]
	ON [dbo].[NUser]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE NUser SET Active = 0
		WHERE NUser_Id = (SELECT NUser_Id FROM deleted)
	END