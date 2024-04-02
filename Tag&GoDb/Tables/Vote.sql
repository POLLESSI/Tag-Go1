CREATE TABLE [dbo].[Vote]
(
	[Vote_Id] INT IDENTITY,
	[Evenement_Id] INT NOT NULL UNIQUE,
	[FunOrNot] BIT NULL,
	[Comment] NVARCHAR(128),
	[Active] BIT DEFAULT 1

	CONSTRAINT [PK_Vote] PRIMARY KEY ([Vote_Id])
	CONSTRAINT [FK_Vote_Evenement] FOREIGN KEY(Evenement_Id) REFERENCES [Evenement] ([Evenement_Id]),
	CONSTRAINT [UK_Evenement] UNIQUE ([Evenement_Id])
)

GO

CREATE TRIGGER [dbo].[OnDeleteVote]
	ON [dbo].[Vote]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE Vote SET Active = 0
		WHERE Vote_Id = (SELECT Vote_Id FROM deleted)
	END