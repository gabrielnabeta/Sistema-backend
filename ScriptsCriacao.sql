--criar banco de dados
CREATE DATABASE Backend;
--usar banco de dados
USE Backend;
--criar tabelas
CREATE TABLE usuario (
	id INT NOT NULL AUTO_INCREMENT,
	nome VARCHAR(50) NOT NULL,
	sobrenome VARCHAR(150) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	email VARCHAR(50) NOT NULL,
	senha VARCHAR(30) NOT NULL,
	genero VARCHAR(20) NOT NULL,
	PRIMARY KEY (id),
);
--criar tabelas
CREATE TABLE endereco (
	id INT NOT NULL AUTO_INCREMENT,
	rua VARCHAR(200) NOT NULL,
    numero VARCHAR(30) NOT NULL,
    bairro VARCHAR(50) NOT NULL,
    cidade VARCHAR(250) NOT NULL,
    complemento VARCHAR(150) NULL,
    cep VARCHAR(9) NOT NULL,
    estado VARCHAR(2) NOT NULL,
    PRIMARY KEY (id),
);
--alterar tabela 
ALTER TABLE endereco ADD usuario_id INT NOT NULL;
--adicionar chave estrangeira 
ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

--inserir usuario
INSERT INTO usuario
(nome, sobrenome, telefone, email, genero, senha) 
VALUES ('Gabriel', 'Luis', '(18) 99658-5824', 'gabrielnabeta@gmail.com', 'Masculino', 'teste123');

INSERT INTO usuario
(nome, sobrenome, telefone, email, genero, senha) 
VALUES ('Angelina', 'Luisa', '(18) 34521-6924', 'angelina@gmail.com', 'Feminino', 'teste321');

--selecionar todos os usuarios 
SELECT * FROM usuario;
--exemplo para selecionar somente um usuario
SELECT * FROM usuario WHERE email = 'gabrielnabeta@gmail.com'

--alterar usuario
UPDATE usuario SET email = 'angelina1@gmail.com' WHERE id = 2;

--deletar usuario
DELETE FROM usuario WHERE id = 2;
--deletar mais de um usuario
DELETE FROM usuario WHERE id IN = (2,3);
--ou
DELETE FROM usuario WHERE id > 2;



