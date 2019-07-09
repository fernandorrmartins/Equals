/* 07072019_Logic_Scheme_BD_Equals: */

CREATE DATABASE equals;
USE equals;

CREATE TABLE Arquivo (
    Identificador BigInt PRIMARY KEY AUTO_INCREMENT,
    TipoRegistro varchar(1),
    Estabelecimento varchar(15),
    DataProcessamento varchar(15),
    PeriodoInicial varchar(15),
    PeriodoFinal varchar(15),
    Sequencia varchar(15),
    EmpresaAdquirente varchar(15),
    NomeArquivo varchar(255),
    LinhaArquivo varchar(50),
    DataHoraInclusao DateTime,
    Situacao TinyInt default 1
);