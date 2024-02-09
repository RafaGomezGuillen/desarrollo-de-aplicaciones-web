--1.- Crear una funci�n que devuelva cu�ntos libros hay de precio mayor que el que suministremos como par�metro.
if OBJECT_ID('precio_libros_por_encima') is not null
	drop function precio_libros_por_encima;
go

create function precio_libros_por_encima 
	(@valor decimal(5,2))
	returns int
as
	begin
		declare @resultado int
		select @resultado = COUNT(*) from libros where precio > @valor
		return @resultado
	end;
go

select dbo.precio_libros_por_encima(40);
go

--2- Crear una funci�n escalar que tenga como par�metros el DNI y la letra del NIF 
--y nos valide si es correcta o no. Usar la funci�n con los datos 
--de una tabla que contenga nombre, apellidos, fechanacimiento, dni y la letra del nif.
if OBJECT_ID('es_dni_correcto') is not null
	drop function es_dni_correcto;
go

create function es_dni_correcto
	(@dni char(8),
	@nif char(1))
	returns varchar(15)
as
	begin 
		declare @resultado varchar(15)
			if SUBSTRING('TRWAGMYFPDXBNJZSQVHLCKE', @dni % 23 + 1, 1) = @nif
				begin
					set @resultado = 'Correcto'
				end
			else
				begin
					set @resultado = 'Incorrecto'
				end
		return @resultado
	end;
go

select nombre, apellidos, fechanacimiento, dni, letra, dbo.es_dni_correcto(dni, letra) as Comprobacion
from personas;
go

--3.- Crear una funci�n que nos devuelva los a�os de diferencia 
--respecto al actual a partir de la fecha pasada como par�metro.
if OBJECT_ID('anios_de_diferencia') is not null
	drop function anios_de_diferencia;
go

create function anios_de_diferencia
	(@anio char(8))
	returns int
as
	begin 
		declare @resultado int
			set @resultado = DATEDIFF(YEAR, @anio, GETDATE())
		return @resultado
	end;
go

select nombre, apellidos, fechanacimiento, dni, letra, dbo.anios_de_diferencia(YEAR(fechanacimiento)) as Diferencia
from personas;
go

--4.- Crear funci�n que dada fecha como cadena de caracteres devuelva 
--que no es correcta o en caso contrario el nombre del mes.
if OBJECT_ID('comprobar_fecha') is not null
	drop function comprobar_fecha;
go

create function comprobar_fecha
	(@fecha varchar(50))
	returns varchar(50)
as
	begin 
		declare @resultado varchar(50)
			if CAST(SUBSTRING(@fecha, 4, 2) as int) >= 1 and CAST(SUBSTRING(@fecha, 4, 2) as int) <= 12
				begin
					set @resultado = DATENAME(MONTH, @fecha)
				end
			else
				begin
					set @resultado = @fecha + ' no es correcta'
				end
		return @resultado
	end;
go

select dbo.comprobar_fecha('11/12/2022') as Fecha;
go
select dbo.comprobar_fecha('11/13/2022') as Fecha;
go
select dbo.comprobar_fecha('11/00/2022') as Fecha;
go

--5.- Crear una funci�n de tabla que devuelva los libros de precio mayor 
--que el que suministremos como par�metro.
if OBJECT_ID('precio_libros_por_encima_2') is not null
	drop function precio_libros_por_encima_2;
go

create function precio_libros_por_encima_2
	(@valor decimal(5,2))
	returns table
as
	return (
		select COUNT(*) as nPorEncimaPrecioMayor
		from libros
		where precio > @valor
	)
go

select * from dbo.precio_libros_por_encima_2(30);
go

--6.- Funci�n que devuelva el m�ximo precio de la tabla libros
if OBJECT_ID('max_precio_libros') is not null
	drop function max_precio_libros;
go

create function max_precio_libros
	()
	returns table
as
	return (
		select MAX(precio) as PrecioMaximo
		from libros
	)
go

select * from dbo.max_precio_libros();
go

--7.- Funci�n que devuelva una tabla con el nombre y dni de las personas de dos tablas (personal y alumnado),
-- pasando como par�metro: personal (saca s�lo los de la tabla personal; 
--alumnado (saca s�lo los de la tabla alumnado; ambos (saca los de ambas tablas).
IF OBJECT_ID('ver_tabla') IS NOT NULL
    DROP FUNCTION ver_tabla;
GO

CREATE FUNCTION ver_tabla
(
    @nombre_tabla VARCHAR(100)
)
RETURNS @tabla_retorno TABLE
(
    nombre varchar(100),
	apellidos varchar(100)
)
AS
BEGIN
    IF @nombre_tabla = 'personal'
        INSERT INTO @tabla_retorno
        SELECT * FROM personal;
    ELSE IF @nombre_tabla = 'alumnado'
        INSERT INTO @tabla_retorno
        SELECT * FROM alumnado;
    ELSE IF @nombre_tabla = 'ambos'
        INSERT INTO @tabla_retorno
        SELECT * FROM personal
        UNION ALL
        SELECT * FROM alumnado;
    RETURN;
END;
GO

select * from dbo.ver_tabla('personal');
go
select * from dbo.ver_tabla('alumnado');
go
select * from dbo.ver_tabla('ambos');
go

--8.- Funci�n que devuelva el n� de d�as del mes de una fecha pasada como par�metro.
if OBJECT_ID('numero_dias_mes') is not null
	drop function numero_dias_mes;
go

create function numero_dias_mes
    (@fecha date)
	returns int
as
	begin
		declare @anio int, @mes int

		select @anio = YEAR(@fecha), @mes = MONTH(@fecha)

		return DAY(EOMONTH(DATEFROMPARTS(@anio, @mes, 1)))
	end
go

select dbo.numero_dias_mes('11/05/2022') as Fecha;

--9.- Crear funci�n que valide si una cadena de caracteres es un DNI correcto. 
--Que contenga 8 d�gitos y una letra y la letra se corresponda con la correcta. 
--Probarlo con la tabla personas.
if OBJECT_ID('comprobar_dni') is not null
	drop function comprobar_dni;
go

create function comprobar_dni
	(@dni varchar(9))
	returns varchar(50)
as
	begin
		declare @resultado varchar(50)
		declare @dni_numerico int
		declare @dni_letra char(1)
			IF LEN(@dni) = 9 and @dni like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][A-Z]'
				begin
					set @dni_numerico = CAST(SUBSTRING(@dni, 1, 8) as int)
					set @dni_letra = UPPER(SUBSTRING(@dni, 9, 1))
					if SUBSTRING('TRWAGMYFPDXBNJZSQVHLCKE', @dni_numerico % 23 + 1, 1) = @dni_letra
						begin
							set @resultado = 'correcto.'
						end
					else
						begin
							set @resultado = 'incorrecto.'
						end
				end
			else
				begin
					set @resultado = 'incorrecto.'
				end
		return @resultado
	end
go


select nombre, apellidos, fechanacimiento, dni, letra,dbo.comprobar_dni(dni + letra)
from personas