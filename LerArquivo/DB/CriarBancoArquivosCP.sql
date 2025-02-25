--create database ArquivosCP;
use ArquivosCP;

IF Not EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_SCHEMA = 'ArquivosCP' 
           AND TABLE_NAME = 'Arquivo')
BEGIN
    PRINT 'A tabela Arquivo existe'
    create table Arquivo 
        (
            Id int not null IDENTITY(1,1),
            PastaEntrada varchar(255) not null,
            PastaProcessamento varchar(255) not null,
            MascaraEntrada varchar(100) not null,
            CodigoParceiro Varchar(100) not null,
            Ativo bit not null
        );
    PRINT 'Tabela Arquivo criada'
END

IF Not EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_SCHEMA = 'ArquivosCP' 
           AND TABLE_NAME = 'EstruturaArquivo')
BEGIN
    PRINT 'A tabela EstruturaArquivo existe'
    create table EstruturaArquivo
        
    PRINT 'Tabela EstruturaArquivo criada'
END
