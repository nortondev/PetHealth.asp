
/*drop database db_pethealth;*/

create database db_pethealth;
use db_pethealth;

create table tbLogin(
idUsuario int primary key auto_increment,
nomeUsuario varchar(50),
sobrenomeUsuario varchar(50),
cpf varchar(15),
Usuario varchar(50),
Senha varchar(50),
tipo varchar(1)
);

create table tbPlano(
idPlano int primary key auto_increment,
nomePlano varchar(50),
descPlano varchar(150),
valorPlano varchar(10),
fotoPlano varchar(255)
);

insert into tbPlano values (default, "Plano Básico", "Básico", "80.00", "1");
insert into tbPlano values (default, "Plano Plus", "Mais", "189.00", "1");
insert into tbPlano values (default, "Plano Gold", "Ouro", "180.00","1");
insert into tbPlano values (default, "Plano Premium", "Premium", "149.00", "1");

create table tbAnimal(
idAnimal int primary key auto_increment,
Animal varchar(50),
descAnimal varchar(150),
fotoAnimal varchar(255)
);

create table tbSexo(
idSexo int primary key auto_increment,
Sexo varchar(50)
);

insert into tbSexo values (default, "Macho");
insert into tbSexo values (default, "Fêmea");


create table tbCliente(
idCliente int primary key auto_increment,
nomeCliente varchar(50),
sobrenomeCliente varchar(50),
emailCliente varchar(50),
telefoneCliente varchar(14)
);

create table tbPet(
idPet int primary key auto_increment,
nomePet varchar(50),
idAnimal int,
idSexo int,
racaPet varchar(50),
idadePet int,
pesoPet int,
fotoPet varchar(255),
idPlano int,
idCliente int,
foreign key(idAnimal) references tbAnimal(idAnimal),
foreign key(idSexo) references tbSexo(idSexo),
foreign key(idPlano) references tbPlano(idPlano),
foreign key(idCliente) references tbCliente(idCLiente)
);



insert into tbPet values (default, "Raio", "4", "1", "Beta", "1", "13", "1", "1");
delete from tbPet where idPet=12;
 
create view vwPet as
select tbPet.idPet, tbPet.nomePet, tbAnimal.Animal, tbSexo.Sexo, tbPet.racaPet, tbPet.idadePet, tbPet.pesoPet, tbPet.fotoPet, tbPlano.nomePlano, tbCliente.nomeCliente
from tbPet
inner join tbAnimal on tbAnimal.idAnimal = tbPet.idAnimal
inner join tbSexo on tbSexo.idSexo = tbPet.idSexo
inner join tbPlano on tbPlano.idPlano = tbPet.idPlano
inner join tbCliente on tbCliente.idCliente = tbPet.idCliente;

create table tbPagamento(
idPagamento int primary key auto_increment,
numeroCartao int,
nomeCartao varchar(50)
);

insert into tbLogin values (default, 'Camila', 'Martins', '55555555555', 'caamrtns', '12345678', '0');
insert into tbLogin values (default, 'Neymar', 'Júnior', '512.787.970-08', 'ohneymar', '12345', '1');

insert into tbAnimal values (default, 'Ave', 'Birds', '1');
insert into tbAnimal values (default, 'Gato', 'Cat', '1');
insert into tbAnimal values (default, 'Cachorro', 'Dog', '1');
insert into tbAnimal values (default, 'Peixe', 'Passáro', '1');
select * from tbLogin;
select * from tbAnimal;