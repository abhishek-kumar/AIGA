----------------------------------------------------------------------------------------------------
-- We may need to create the database if it's not already there.... 
use master
GO

/* I couldn't find a way to script "IF EXISTS" in a way that works with both SQL 2000 and 2005
   so we just accept that this may error if it doesn't exist.  It causes no problems. */
DROP DATABASE [ArchiveService]
GO

/* Installation directories for 2000 & 2005 are different, so replace MSSQLServerLocation with the
   correct installation path at run-time.  Those are usually:
   2000: C:\Program Files\Microsoft SQL Server\MSSQL\DATA\
   2005: C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\
   */
CREATE DATABASE ArchiveService
ON (    NAME = N'Archive_dat',
	    -- SET THIS FILE LOCATION TO BE ON YOUR PRIMARY DATA ARRAY --
	    FILENAME = N'MSSQLServerLocation\ArchiveService.mdf',
	    SIZE = 100 MB,
	    MAXSIZE = UNLIMITED,
	    FILEGROWTH = 50 MB)
LOG ON( NAME = N'Archive_log',
	    -- MOVE THIS FILE ONTO A SEPERATE HARD DRIVE FOR BEST PERFORMANCE --
	    FILENAME = N'MSSQLServerLocation\ArchiveService_log.ldf',
	    SIZE = 10 MB,
	    MAXSIZE = UNLIMITED,
	    FILEGROWTH = 10%)
GO

-- Simple (not Full) recovery model
exec sp_dboption N'ArchiveService', N'trunc. log', N'true'
GO

----------------------------------------------------------------------------------------------------
USE ArchiveService
GO

-- NOTE: I can't seem to cause the script to just return due to an error finding the database
--  I've tried putting a check for @@ERROR both here and before the GO statement, and neither worked
--  Without it, this file will run fine even if the database isn't present, and thus the tables
--  end up in the system's master database.  (pfb, 14-Apr-05)

----------------------------------------------------------------------------------------------------
--drop all the tables
IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Frame' )
	DROP TABLE Frame
GO
IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'RawStream' )
	DROP TABLE RawStream
GO
IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Stream' )
	DROP TABLE Stream
GO
IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Participant' )
	DROP TABLE Participant
GO
IF EXISTS( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Conference')
	DROP TABLE Conference
GO


----------------------------------------------------------------------------------------------------
CREATE TABLE Conference
(
	conference_id	int identity(1,1)	NOT NULL PRIMARY KEY,
	description		varchar(255)		NOT NULL,
	venue_identifier varchar(255)		NOT NULL,
	start_dttm		datetime			NOT NULL,
	end_dttm		datetime			NULL
)
GO


----------------------------------------------------------------------------------------------------
--create the table to hold the information on a particular participant
CREATE TABLE Participant
(
	participant_id		int Identity(1,1)	NOT NULL PRIMARY KEY,
	conference_id	int					NOT NULL FOREIGN KEY REFERENCES Conference(conference_id)
	  ON DELETE CASCADE   ON UPDATE CASCADE,
	cname			varchar(255)		NOT NULL,
	[name]			varchar(255)		NOT NULL
)
GO


----------------------------------------------------------------------------------------------------
CREATE TABLE Stream
(
	stream_id		int Identity(1,1)	NOT NULL PRIMARY KEY,
	participant_id		int					NOT NULL FOREIGN KEY REFERENCES Participant(participant_id)
	  ON DELETE CASCADE   ON UPDATE CASCADE,
	[name]			varchar(255)			NOT NULL,
	payload_type	varchar(255)			NOT NULL,
	privextns       image               NOT NULL
)
GO


----------------------------------------------------------------------------------------------------
CREATE TABLE RawStream
(
	stream_id	    int         	    NOT NULL FOREIGN KEY REFERENCES Stream(stream_id)
	  ON DELETE CASCADE   ON UPDATE CASCADE,
	data			image				NULL
)
GO


----------------------------------------------------------------------------------------------------
CREATE TABLE Frame
(
	frame_id	int	identity(1,1)	NOT NULL PRIMARY KEY NONCLUSTERED,
	stream_id	int				    NOT NULL FOREIGN KEY REFERENCES Stream(stream_id)
	  ON DELETE CASCADE   ON UPDATE CASCADE,
	raw_start	int			        NOT NULL,
	raw_end		int			        NOT NULL,
	frame_time	bigint			    NOT NULL
)

--we look up frames by time per stream so noncluster the pk
--CREATE UNIQUE CLUSTERED INDEX Sream_Time_Index on Frame( stream_id, frame_time)
--JCB bugfix mark this as unclustered because I was getting a unique constraint violation 
--  when attempting to run archiver in a venue with 10+ concurrent streams
CREATE UNIQUE CLUSTERED INDEX Sream_Time_Index on Frame( stream_id, frame_time)
GO


----------------------------------------------------------------------------------------------------
/*	Scripting of the user name and permissions for LOCAL SERVICE account
*/

DECLARE @serveraccount varchar(58)
select @serveraccount = CONVERT(varchar(50), SERVERPROPERTY('machinename'))
select @serveraccount = N'NT AUTHORITY\LOCAL SERVICE'

--create it if the login does not exist...
IF NOT EXISTS( SELECT * FROM master.dbo.syslogins WHERE loginname = @serveraccount)
	EXEC sp_grantlogin @serveraccount

EXEC sp_defaultdb @serveraccount, N'ArchiveService'

IF NOT EXISTS (SELECT * FROM dbo.sysusers WHERE [name] = @serveraccount AND uid < 16382)
	EXEC sp_grantdbaccess @serveraccount

EXEC sp_addrolemember N'db_datareader', @serveraccount
EXEC sp_addrolemember N'db_datawriter', @serveraccount
GRANT SELECT, UPDATE, INSERT, DELETE ON Conference to [NT AUTHORITY\LOCAL SERVICE]
GRANT SELECT, UPDATE, INSERT, DELETE ON Frame to [NT AUTHORITY\LOCAL SERVICE]
GRANT SELECT, UPDATE, INSERT, DELETE ON Participant to [NT AUTHORITY\LOCAL SERVICE]
GRANT SELECT, UPDATE, INSERT, DELETE ON RawStream to [NT AUTHORITY\LOCAL SERVICE]
GRANT SELECT, UPDATE, INSERT, DELETE ON Stream to [NT AUTHORITY\LOCAL SERVICE]

GO