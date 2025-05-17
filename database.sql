create database usuarios_db
character set utf8mb4
collate utf8mb4_unicode_ci;

use usuarios_db;
create table if not exists usuarios(	
id int auto_increment primary key,
nome varchar(255) not null,
email varchar(255) not null,
senha varchar(255) not null
);
SELECT * FROM usuarios_db.usuarios;