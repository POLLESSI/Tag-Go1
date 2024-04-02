CREATE TABLE [dbo].[Chat]
(
	[Chat_Id] INT IDENTITY,
	[NewMessage] NVARCHAR(64) NULL,
	[Author] NVARCHAR(32) NOT NULL,
	[Evenement_Id] INT NULL,
	[Activity_Id] INT NULL,
	[Active] BIT DEFAULT 1

	CONSTRAINT [PK_Chat] PRIMARY KEY ([Chat_Id])
	CONSTRAINT [FK_Chat_Evenement] FOREIGN KEY (Evenement_Id) REFERENCES [Evenement] ([Evenement_Id])
)

GO

CREATE TRIGGER [dbo].[OnDeleteChat]
	ON [dbo].[Chat]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE Chat SET Active = 0
		WHERE Chat_Id = (SELECT Chat_Id FROM deleted)
	END