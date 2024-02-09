use operacionesquirurgicas;
go

--1
if object_id('ver_cantidad_material','P') is not null
	drop procedure ver_cantidad_material;
go
create procedure ver_cantidad_material
	@nombre varchar(100),
	@cantidad_material int output
as
	if exists(select denominaciontipo from intervencion where denominaciontipo = @nombre)
		begin
			select @cantidad_material = SUM(cantidad)
			from intervencion
			inner join materialintervencion
			on materialintervencion.idintervencion = intervencion.idintervencion
			where denominaciontipo = 'Adenoidectomía. Operación de Vegetaciones'
			group by denominaciontipo
		end
	else
		begin
			set @cantidad_material = -1
		end
GO

declare @cantidad_material int;
exec ver_cantidad_material 'Adenoidectomía. Operación de Vegetaciones', @cantidad_material output;
select @cantidad_material as Cantidad;
exec ver_cantidad_material 'No existe', @cantidad_material output;
select @cantidad_material as Cantidad;

--2
if object_id('mod_cadena') is not null
	drop function mod_cadena;
go
create function dbo.mod_cadena
(
	@texto varchar(max)
)
returns varchar(max)
as
	begin
		declare @vocales varchar(100) = 'aiouAIUO'
		declare @consonantes varchar(100) = 'qwrtypsdfghjklñzxcvbnm'
		declare @i int = 1
		declare @char char(1)
		declare @simbolos_no_vocales varchar(max) = ''
		while @i <= LEN(@texto)
		begin
			set @char = SUBSTRING(@texto, @i, 1)

			if @char like '[' + @vocales + ']'
				set @simbolos_no_vocales += UPPER(@char)

			if @char like '[' + @consonantes + ']'
				set @simbolos_no_vocales += LOWER(@char)

			if @char like '[e]'
				set @simbolos_no_vocales += '3'

			if @char = ' '
				set @simbolos_no_vocales += '?'

			set @i += 1
		end
		return @simbolos_no_vocales
	end;
go

select dbo.mod_cadena ('Prueba AsTodo S');
go

--3
IF object_id('TablasOperaciones') IS NOT NULL
	DROP table [TablasOperaciones]
go
create table TablasOperaciones
	( t varchar(100))
go
insert into TablasOperaciones values ('Paciente'),('Operacion'),('Intervencion'),('material')
go
select * from TablasOperaciones;
go

IF object_id('contar_registros') IS NOT NULL 
	drop procedure contar_registros;
go
create procedure contar_registros
as
begin
    declare @campos varchar(100)
	declare @sentencia varchar(max) = '';
    declare cur cursor for
        select t from TablasOperaciones
    open cur
    fetch next from cur into @campos
    while @@FETCH_STATUS = 0
		begin
			set @sentencia = 'select COUNT(*) FROM ' + @campos
			exec(@sentencia)
			fetch next from cur into @campos
		end
    close cur;
    deallocate cur;
end
go

exec contar_registros;
go

--4
if object_id('ver_intervenciones') is not null
 drop function ver_intervenciones;
go
CREATE FUNCTION dbo.ver_intervenciones
	(@nombrematerial varchar(100))
RETURNS TABLE
AS
RETURN
(
	select denominaciontipo
	from material
	inner join materialintervencion
	on materialintervencion.idmaterial = material.idmaterial
	inner join intervencion
	on intervencion.idintervencion = materialintervencion.idintervencion
	where nombrematerial = @nombrematerial
)
go

select denominaciontipo
from dbo.ver_intervenciones('Agujas Quirúrgicas.');
go
--5
IF OBJECT_ID('ver_tabla') IS NOT NULL
    DROP FUNCTION ver_tabla;
GO
CREATE FUNCTION ver_tabla
(
    @input1 int,
	@input2 int
)
RETURNS @tabla_retorno TABLE
(
	campo varchar(100)
)
AS
BEGIN
    IF @input1 = 1 and @input2 = 0
        INSERT INTO @tabla_retorno
        SELECT nombrematerial FROM material;
    ELSE IF @input2 = 1  and @input1 = 0
        INSERT INTO @tabla_retorno
        SELECT denominaciontipo FROM intervencion;
	ELSE IF @input2 = 1 and @input1 = 1
        INSERT INTO @tabla_retorno
        SELECT denominaciontipo FROM intervencion
		UNION ALL
		SELECT nombrematerial FROM material;
    RETURN
END
GO
select campo
from ver_tabla(1,1);
go


--6
if object_id('control_pacientes') is not null
	drop trigger control_pacientes;
go
create trigger control_pacientes
 on Paciente
 for insert
 as
	if (18 <= (select DATEDIFF(YEAR, FechaNacimiento, GETDATE()) from inserted))
		begin
			select 'Transacción realizada.';
			select * from inserted;
		end
	else
		begin
			raiserror ('No se pueden insertar pacientes menores de edad.', 16, 1)
			rollback transaction
		end
go

insert Paciente ( DNIPaciente,Nombre,DatosCliente,FechaNacimiento,Telefono )  values ( '05679312Z','Paciente mayor','Ofra','Ene 30 1984 12:00AM','922304051' );
insert Paciente ( DNIPaciente,Nombre,DatosCliente,FechaNacimiento,Telefono )  values ( '05679341P','Paciente menor','Ofra','Ene 30 2010 12:00AM','922304012' );
