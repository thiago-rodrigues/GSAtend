# GSAtend
Projeto Processo Seletivo GrupoSym

# Dependências

	01. [.NetCore 5.0](https://dotnet.microsoft.com/download/dotnet-core)
	02. [Dapper 2.0.35] (https://dapper-tutorial.net/)
	03. [Sirb.Validation 1.0.2] (https://www.nuget.org/packages/Sirb.Validation)

# Script Criação do BD e Tabelas

```
Script:

create database GSAtend

create table Paciente(
	CPF varchar(14) not null primary key,
	Nome Varchar(100) not null,
	DataNascimento datetime not null,
	Sexo varchar(20) not null)

create table Atendimento (
	Id integer not null primary key identity,
	DataAtendimento datetime,
	Descricao varchar(100),
	CPF varchar (14) not null,
	foreign key (CPF) references Paciente (CPF))

```

# App.config


