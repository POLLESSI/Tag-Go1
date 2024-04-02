CREATE TABLE [dbo].[Evenement]
(
	[Evenement_Id] INT IDENTITY,
	[EvenementDate] DATE NOT NULL,
	[EvenementName] NVARCHAR(32) NOT NULL,
	[EvenementDescription] NVARCHAR(256) NOT NULL,
	[PosLat] DECIMAL(8, 6) NOT NULL,
	[PosLong] DECIMAL(9, 6) NOT NULL,
	[Positif] BIT DEFAULT 1,
	[Organisateur_Id] INT NULL UNIQUE,
	[Icon_Id] INT NULL, 
	[Recompense_Id] INT NULL,
	[Bonus_Id] INT NULL,
	[MediaItem_Id] INT NULL,
	[Active] BIT DEFAULT 1

	CONSTRAINT [PK_Evenement] PRIMARY KEY ([Evenement_Id]),
	CONSTRAINT [FK_Evenement_Organisateur] FOREIGN KEY (Organisateur_Id) REFERENCES [Organisateur] ([Organisateur_Id]),
	CONSTRAINT [FK_Evenement_Icon] FOREIGN KEY (Icon_Id) REFERENCES [Icon] ([Icon_Id]),
	CONSTRAINT [FK_Evenement_Recompense] FOREIGN KEY (Recompense_Id) REFERENCES [Recompense] ([Recompense_Id]),
	CONSTRAINT [FK_Evenement_Bonus] FOREIGN KEY (Bonus_Id) REFERENCES [Bonus] ([Bonus_Id]),
	CONSTRAINT [FK_Evenement_MediaItem] FOREIGN KEY (MediaItem_Id) REFERENCES [MediaItem] ([MediaItem_Id]),
	CONSTRAINT [UK_Otganisateur] UNIQUE ([Organisateur_Id])
)

GO

CREATE TRIGGER [dbo].[OnDeleteEvenement]
	ON [dbo].[Evenement]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE Evenement SET Active = 0
		WHERE Evenement_Id = (SELECT Evenement_Id FROM deleted)
	END