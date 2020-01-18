USE MASTER;
GO

/*
    CREATE DATABASE
    CREATE DB LOGIN
    CREATE DATABASE USER FOR THE DB LOGIN AND ASSIGN THE READ ROLE
*/

CREATE LOGIN db_model_generator_user WITH PASSWORD = 'DbModelGen123#';
GO

IF DB_ID (N'DbModelSample') IS NOT NULL
    DROP DATABASE DbModelSample;

CREATE DATABASE DbModelSample
    COLLATE Latin1_General_100_CS_AS_SC;

GO

USE DbModelSample;
GO

CREATE USER db_model_generator_user FOR LOGIN db_model_generator_user;

ALTER ROLE db_datareader ADD MEMBER db_model_generator_user;
GO

/*
    CREATE SCHEMA
*/

CREATE TABLE ApplicationUser (
    UserID INT IDENTITY(1, 1) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(100) NOT NULL,
    PasswordSalt NVARCHAR(100) NOT NULL,
    Active BIT NOT NULL,
    CONSTRAINT PK_User PRIMARY KEY (UserID),
    CONSTRAINT UC_UserEmail UNIQUE (Email)
)

CREATE TABLE Comment (
    CommentID INT IDENTITY(1,1) NOT NULL,
    UserID INT NOT NULL,
    Date DATETIME2 NOT NULL,
    Text NVARCHAR(MAX),
    CONSTRAINT PK_Comment PRIMARY KEY (CommentID),
    CONSTRAINT FK_Comment_ApplicationUser FOREIGN KEY (UserID) REFERENCES ApplicationUser(UserID)
)