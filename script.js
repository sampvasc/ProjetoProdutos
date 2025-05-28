-- Criando o banco de dados
create database dbProjetoProdutos;
use dbProjetoProdutos;

-- Criando as tabelas do Banco de Dados
create table tbCliente(
IdUser int primary key auto_increment,
Nome varchar(50) not null,
Email varchar(50) not null,
Senha varchar(50) not null
);

create table tbProduto(
IdProd int primary key auto_increment,
Nome varchar(50) not null,
Descricao varchar(50) not null,
Preco decimal(4,2) not null,
Quantidade int not null
);