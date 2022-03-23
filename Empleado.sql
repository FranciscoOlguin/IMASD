CREATE DATABASE BDNOMINA2022

CREATE TABLE Empleado(
IdEmpleado INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(50),
ApellidoPaterno VARCHAR(50),
ApellidoMaterno VARCHAR(50),
IdDepartamento INT,
FOREIGN KEY (IdDepartamento) REFERENCES Departamento (IdDepartamento),
Email  VARCHAR(254) UNIQUE,
Sexo CHAR(2),
Telefono VARCHAR(20),
Celular VARCHAR(20),
FechaNacimiento DATE,
IdEstado INT,
FOREIGN KEY (IdEstado) REFERENCES Estado (IdEstado),
CodigoPostal VARCHAR(6),
Direccion VARCHAR(50),
PagoNomina MONEY
)

CREATE TABLE Estado(
IdEstado INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(50)
)

CREATE TABLE Departamento(
IdDepartamento INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR (50)
)

drop table Empleado

truncate table Empleado

INSERT INTO [dbo].[Departamento]
           ([Nombre])
     VALUES
           ('Recursos Humanos'),('Finanzas'),('Marketing'),('Comercial'),('Compras'),('Logistica y operaciones')

INSERT INTO [dbo].[Estado]
           ([Nombre])
     VALUES
           ('Estado de Mexico'),('Jalisco'),('Michoacán')
GO

INSERT INTO [dbo].[Empleado]
           ([Nombre]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno]
		   ,[IdDepartamento]
           ,[Email]
           ,[Sexo]
           ,[Telefono]
           ,[Celular]
           ,[FechaNacimiento]
		   ,[IdEstado]
           ,[CodigoPostal]
           ,[Direccion]
           ,[PagoNomina])
     VALUES
           ('Francisco','Olguin','Carranza',1,'francisco@gmail.com','2',5583187481,5538405050,'1999-01-20',1,'54900','Temoaya 3 barrio la comcepcion',8550)



CREATE PROCEDURE[EmpleadoGetAll]
AS 
SELECT
Empleado.IdEmpleado,
Empleado.Nombre,
Empleado.ApellidoPaterno,
Empleado.ApellidoMaterno,
Departamento.IdDepartamento,
Departamento.Nombre as NDep,
Empleado.Email,
Empleado.Sexo,
Empleado.Telefono,
Empleado.Celular,
Empleado.Fechanacimiento,
Estado.IdEstado,
Estado.Nombre AS NEst,
Empleado.CodigoPostal,
Empleado.Direccion,
Empleado.PagoNomina
FROM Empleado
INNER JOIN	Departamento ON Empleado.IdDepartamento = Departamento.IdDepartamento 
INNER JOIN Estado ON Empleado.IdEstado = Estado.IdEstado

CREATE PROCEDURE[EmpleadoAdd]'Carolina','Carranza','Olguin',1,'Carolina@gmail.com','M','5583180520','5051951956','01/01/1980',1,'54900','El partidor',5000
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@IdDepartamento INT,
@Email  VARCHAR(254),
@Sexo CHAR(2),
@Telefono VARCHAR(20),
@Celular VARCHAR(20),
@FechaNacimiento VARCHAR(50),
@IdEstado INT,
@CodigoPostal VARCHAR(6),
@Direccion VARCHAR(50),
@PagoNomina MONEY
AS
INSERT INTO [dbo].[Empleado]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[IdDepartamento],
[Email],[Sexo],[Telefono],[Celular],[FechaNacimiento],[IdEstado],[CodigoPostal],[Direccion],[PagoNomina])
VALUES (@Nombre,@ApellidoPaterno,@Apellidomaterno,@IdDepartamento,@Email,@Sexo,@Telefono,@Celular,
@FechaNacimiento=CONVERT(DATE,@FechaNacimiento,105),@IdEstado,@CodigoPostal,@Direccion,@PagoNomina)

CREATE PROCEDURE[EmpleadoGetById]2
@IdEmpleado INT
AS
SELECT
Empleado.IdEmpleado,
Empleado.Nombre,
Empleado.ApellidoPaterno,
Empleado.ApellidoMaterno,
Departamento.IdDepartamento,
Departamento.Nombre as NDep,
Empleado.Email,
Empleado.Sexo,
Empleado.Telefono,
Empleado.Celular,
Empleado.Fechanacimiento,
Estado.IdEstado,
Estado.Nombre AS NEst,
Empleado.CodigoPostal,
Empleado.Direccion,
Empleado.PagoNomina
FROM Empleado
INNER JOIN	Departamento ON Empleado.IdDepartamento = Departamento.IdDepartamento 
INNER JOIN Estado ON Empleado.IdEstado = Estado.IdEstado
WHERE IdEmpleado = @IdEmpleado


CREATE PROCEDURE[EstadoGetAll]
AS
SELECT 
IdEstado,
Nombre
FROM Estado

CREATE PROCEDURE[DepartamentoGetAll]
AS
SELECT 
IdDepartamento,
Nombre
FROM Departamento

