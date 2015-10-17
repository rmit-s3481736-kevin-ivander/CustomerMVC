/*
   Saturday, October 17, 20153:29:30 PM
   User: 
   Server: DESKTOP-GDRRLOJ
   Database: Assignment2
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Booking
	DROP CONSTRAINT FK__Booking__Movie_I__52593CB8
GO
ALTER TABLE dbo.Movies SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Movies', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Movies', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Movies', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Booking
	(
	Booking_ID int NOT NULL,
	Movie_ID int NOT NULL,
	Movie_Title nvarchar(MAX) NULL,
	Movie_Time char(10) NULL,
	Session_Time nchar(10) NULL,
	Price decimal(18, 0) NULL,
	No._of_Ticket int NULL,
	Ticket_Type nchar(50) NULL,
	First_Name nvarchar(MAX) NOT NULL,
	Last_Name nvarchar(MAX) NOT NULL,
	Email nvarchar(MAX) NOT NULL,
	Poster nvarchar(MAX) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Booking SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.Booking)
	 EXEC('INSERT INTO dbo.Tmp_Booking (Booking_ID, Movie_ID, Movie_Title, Movie_Time, Session_Time, Price, No._of_Ticket, Ticket_Type, First_Name, Last_Name, Email, Poster)
		SELECT Booking_ID, Movie_ID, Movie_Title, Movie_Time, Session_Time, Price, No._of_Ticket, Ticket_Type, First_Name, Last_Name, Email, Poster FROM dbo.Booking WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.Booking
GO
EXECUTE sp_rename N'dbo.Tmp_Booking', N'Booking', 'OBJECT' 
GO
ALTER TABLE dbo.Booking ADD CONSTRAINT
	PK_Booking PRIMARY KEY CLUSTERED 
	(
	Booking_ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Booking ADD CONSTRAINT
	FK__Booking__Movie_I__52593CB8 FOREIGN KEY
	(
	Movie_ID
	) REFERENCES dbo.Movies
	(
	Movie_ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Booking', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Booking', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Booking', 'Object', 'CONTROL') as Contr_Per 