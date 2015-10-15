/*
   Thursday, October 15, 20154:08:32 PM
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
CREATE TABLE dbo.Booking
	(
	Booking_ID int NOT NULL,
	Movie_ID int NOT NULL,
	Movie_Title nvarchar(MAX) NOT NULL,
	Movie_Time time(7) NOT NULL,
	Session_Time datetime2(7) NOT NULL,
	Price decimal(18, 0) NULL,
	Poster nvarchar(MAX) NOT NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Booking SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Booking', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Booking', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Booking', 'Object', 'CONTROL') as Contr_Per 