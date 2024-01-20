
USE Master
GO

CREATE DATABASE EmailService
GO
USE EmailService

IF OBJECT_ID('Template', 'U') IS NULL
BEGIN

    CREATE TABLE Template
    (
        Id BIGINT NOT NULL IDENTITY(1,1),
        Html VARCHAR(MAX) NULL,
        HeaderField VARCHAR(200) NULL,
        ContentField VARCHAR(200) NOT NULL,
        ButtonsField VARCHAR(200) NULL,
        FooterField VARCHAR(200) NULL,
        PRIMARY KEY (Id)
    );

    PRINT 'SCRIPT CREATE TABLE Template EXECUTADO COM SUCESSO'
END
ELSE
BEGIN
    PRINT 'SCRIPT CREATE TABLE Template NAO EXECUTADO'
END;

IF OBJECT_ID('ConfigEmail', 'U') IS NULL
BEGIN

    CREATE TABLE ConfigEmail
    (
        Id BIGINT NOT NULL IDENTITY (1,1),
		SourceEmail VARCHAR(200) NOT NULL,
		[Subject] VARCHAR (50) NOT NULL,
		DefaultMessage VARCHAR(MAX) NOT NULL,
		DefaultHeader VARCHAR (200) NULL,
		DefaultFooter VARCHAR (200) NULL,
		DefaultButtons VARCHAR (200) NULL,
		TemplateId BIGINT NOT NULL,
        CreatedDate DATETIME NOT NULL,
        LastModifiedDate DATETIME NULL,
        PRIMARY KEY (Id),
		CONSTRAINT fk_EmailConfig_Template FOREIGN KEY (TemplateId) REFERENCES Template (Id)
    );

    PRINT 'SCRIPT CREATE TABLE ConfigEmail EXECUTADO COM SUCESSO'
END
ELSE
BEGIN
    PRINT 'SCRIPT CREATE TABLE ConfigEmail NAO EXECUTADO'
END;

IF OBJECT_ID('ForwardEmail', 'U') IS NULL
BEGIN

    CREATE TABLE ForwardEmail
    (
        Id BIGINT NOT NULL IDENTITY(1,1),
        SourceEmail VARCHAR(200) NOT NULL,
        DestinationEmail VARCHAR(200) NOT NULL,
        [Subject] VARCHAR(50) NULL,
        [Message] VARCHAR(MAX) NOT NULL,
        TemplateId BIGINT NOT NULL,
        ConfigEmailId BIGINT NOT NULL,
        CreatedDate DATETIME NOT NULL,
        LastModifiedDate DATETIME NULL,
        PRIMARY KEY (Id),
        CONSTRAINT fk_EmailMessage_Template FOREIGN KEY (TemplateId) REFERENCES Template (Id),
        CONSTRAINT fk_EmailMessage_EmailConfig FOREIGN KEY (ConfigEmailId) REFERENCES ConfigEmail (Id)
    );

    PRINT 'SCRIPT CREATE TABLE ForwardEmail EXECUTADO COM SUCESSO'
END
ELSE
BEGIN
    PRINT 'SCRIPT CREATE TABLE ForwardEmail NAO EXECUTADO'
END;