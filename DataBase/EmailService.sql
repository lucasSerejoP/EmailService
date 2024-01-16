
USE Master
GO

CREATE DATABASE EmailService
GO
USE EmailService

IF OBJECT_ID('Template', 'U') IS NULL
BEGIN

    CREATE TABLE COMMUNICATION_Template
    (
        Id BIGINT NOT NULL IDENTITY (1,1),
        Html VARCHAR(MAX) NULL,
        ChaveCabecalho VARCHAR(200) NULL,
		ChaveConteudo VARCHAR(200) NOT NULL,
		ChaveBotoes VARCHAR(200) NULL,
		ChaveRodape VARCHAR(200) NULL,
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

    CREATE TABLE EmailConfig
    (
        Id BIGINT NOT NULL IDENTITY (1,1),
        IdTipoSolicitacaoEmail INT NOT NULL,
		EmailOrigem VARCHAR(200) NOT NULL,
		Assunto VARCHAR (50) NOT NULL,
		MensagemDefault VARCHAR(MAX) NOT NULL,
		CabecalhoDefault VARCHAR (200) NULL,
		RodapeDefault VARCHAR (200) NULL,
		BotoesDefault VARCHAR (200) NULL,
		IdTemplate BIGINT NOT NULL,
        PRIMARY KEY (Id),
		CONSTRAINT fk_EmailConfig_Template FOREIGN KEY (IdTemplate) REFERENCES Template (Id)
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
        Id BIGINT NOT NULL IDENTITY (1,1),
		EmailOrigem VARCHAR(200) NOT NULL,
		EmailDestino VARCHAR(200) NOT NULL,
		Assunto VARCHAR (50) NULL,
		Mensagem VARCHAR(MAX) NOT NULL,
		IdTemplate BIGINT NOT NULL,
		IdEmailConfig BIGINT NOT NULL,
		DataCadastro DATETIME NOT NULL,
        DataAtualizacao DATETIME NULL,
		IdStatusFila INT NOT NULL,
        PRIMARY KEY (Id),
		CONSTRAINT fk_ForwardEmail_Template FOREIGN KEY (IdTemplate) REFERENCES Template (Id),
		CONSTRAINT fk_ForwardEmail_EmailConfig FOREIGN KEY (IdEmailConfig) REFERENCES EmailConfig(Id),
    );

    PRINT 'SCRIPT CREATE TABLE ForwardEmail EXECUTADO COM SUCESSO'
END
ELSE
BEGIN
    PRINT 'SCRIPT CREATE TABLE ForwardEmail NAO EXECUTADO'
END;