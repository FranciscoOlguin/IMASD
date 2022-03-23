CREATE PROCEDURE[EmpleadoUpdate]
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
@PagoNomina MONEY,
@IdEmpleado INT
AS
UPDATE Empleado SET Nombre=@Nombre, ApellidoPaterno=@ApellidoPaterno, ApellidoMaterno=@ApellidoMaterno,IdDepartamento=@IdDepartamento,
Email=@Email, Sexo=@Sexo, Telefono=@Telefono, Celular=@Celular, FechaNacimiento=@FechaNacimiento, IdEstado=@IdEstado,
CodigoPostal=@CodigoPostal, Direccion=@Direccion,PagoNomina=@PagoNomina WHERE IdEmpleado=@IdEmpleado

CREATE PROCEDURE[EmpleadoDelete]
@IdEmpleado int
AS
DELETE FROM Empleado WHERE IdEmpleado=@IdEmpleado

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
CONVERT(DATE,@FechaNacimiento,105),@IdEstado,@CodigoPostal,@Direccion,@PagoNomina)

CREATE PROCEDURE[EmpleadoGetById]
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
