create database Vehiculos

use Vehiculos

drop table Usuarios
create table Usuarios(

Id_usuario int identity(100,1) primary key,
Email nvarchar(50)not null unique,
Clave nvarchar(30)not null,
Nombre nvarchar(50)not null,
Apellido nvarchar(50)not null,
Tipo nvarchar(50)not null
)

select * from Usuarios
SELECT u.Email, u.Clave, u.nombre, u.Apellido, u.Tipo from Usuarios u

insert into Usuarios (Email, Clave, Nombre, Apellido, Tipo) values ('Andry@uh.ac.cr', '123', 'Andry', 'Sandi', 'Usuario')
insert into Usuarios (Email, Clave, Nombre, Apellido, Tipo) values ('Marce@uh.ac.cr', '456', 'Marce', 'Herrera', 'Usuario')

drop table Placa
create table Placa(

Id_placa int identity(1,1) primary key,
Num_placa nvarchar(6)not null unique,
Id_Usuario int,
Monto money default 0

SELECT p.Id_placa, p.Num_placa, p.Id_Usuario, p.Monto from Placa p

constraint fk_IdUsuario foreign key(Id_Usuario) references Usuarios(Id_usuario)
)

insert into Placa (Num_placa, Id_Usuario, Monto) values ('BKC105', 100, 50500)
insert into Placa (Num_placa, Id_Usuario, Monto) values ('HJK345', 101, 78900)

select * from Placa

--Procedimientos almacenados Vehiculos

--CONSULTAR

create procedure ConsultaPlacas
as 
	begin
		select * from Placa
end
	exec ConsultaPlacas

--BORRAR

alter procedure BorrarPlacas
@idPlaca nvarchar(50)
as 
	begin
		delete Placa where Id_placa = @idPlaca
end
	exec BorrarPlacas '4'
	exec ConsultaPlacas

--INGRESAR

create procedure IngresarPlacas 
@Num_placa nvarchar(6),
@Id_Usuario int,
@Monto money = 0
as
	begin
		insert into Placa (Num_placa, Id_Usuario, Monto) values (@Num_placa, @Id_Usuario, @Monto)
end
	exec IngresarPlacas 'KLKM045', 101, 88900
	exec ConsultaUsuarios

exec ConsultaPlacas

--Procedimientos almacenados Vehiculos

--CONSULTAR

create procedure ConsultaUsuarios
as 
	begin
		select * from Usuarios
end
	exec ConsultaUsuarios

--BORRAR

create procedure BorrarUsuarios
@email nvarchar(50)
as 
	begin
		delete Usuarios where Email = @email
end
	exec BorrarUsuarios 'Erick@uh.ac.cr'
	exec ConsultaUsuarios

--INGRESAR

alter procedure IngresarUsuarios  
@email nvarchar(50),
@clave nvarchar(30),
@nombre nvarchar(50),
@apellido nvarchar(50),
@tipo nvarchar(50)= 'Usuario'
as
	begin
		insert into Usuarios(Email, Clave, Nombre, Apellido, Tipo) values(@email, @clave, @nombre, @apellido, @tipo)
end
	exec IngresarUsuarios 'Erick@uh.ac.cr', '456', 'Erick', 'Baltodano'
	exec ConsultaUsuarios

--VALIDAR

create procedure ValidarUsuario
@email nvarchar(50),
@clave nvarchar(10),
as
	begin
		select * from Usuarios where Email=@email and Clave=@clave
end
	exec ValidarUsuario 'Andry@uh.ac.cr', '123'

--ACTUALIZAR

create procedure actualizarUsuarios 
	@email nvarchar (50),
	@clave nvarchar (30),
	@nombre nvarchar(50),
	@apellido nvarchar(50),
	@Tipo nvarchar(50)
	 as
	  begin
	   update Usuarios set email = @email, clave = @clave, nombre = @nombre, apellido = @apellido, tipo = @tipo
	  end

exec consultaUsuarios