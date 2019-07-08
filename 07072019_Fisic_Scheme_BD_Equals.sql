/* 07072019_Logic_Scheme_BD_Equals: */

CREATE DATABASE equals;
USE equals;

CREATE TABLE UflaCard (
    Identificador BigInt PRIMARY KEY AUTO_INCREMENT,
    TipoRegistro varchar(1),
    Estabelecimento varchar(10),
    DataProcessamento varchar(8),
    PeriodoInicial varchar(8),
    PeriodoFinal varchar(8),
    Sequencia varchar(7),
    EmpresaAdquirente varchar(8),
    NomeArquivo varchar(255),
    LinhaArquivo varchar(50),
    DataHoraInclusao DateTime,
	Situacao tinyint default 1
);

CREATE TABLE FagammonCard (
    Identificador BigInt PRIMARY KEY AUTO_INCREMENT,
    TipoRegistro varchar(1),
    DataProcessamento varchar(10),
    Estabelecimento varchar(8),
    EmpresaAdquirente varchar(12),
    Sequencia varchar(7),
    NomeArquivo varchar(255),
    LinhaArquivo varchar(36),
    DataHoraInclusao DateTime,
	Situacao tinyint default 1
);