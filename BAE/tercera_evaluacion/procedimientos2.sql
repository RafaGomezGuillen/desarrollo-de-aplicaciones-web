--1.- Crear un procedimiento que pase como parámetro el nombre de la tabla a crear, 
--y que valide si existe, dando error si es así; en caso contrario la cree con la siguiente estructura:
--(DNI varchar(9), Nombre varchar(40));
if object_id('crear_tabla','P') is not null
	drop procedure crear_tabla;
go

create procedure crear_tabla
	@nombre_tabla varchar(100)
as
if OBJECT_ID(@nombre_tabla) is null
	begin
		declare @sentencia nvarchar(1000);
		set @sentencia = N'create table ' + @nombre_tabla + N' (Dni varchar(9), Nombre varchar(40))';
		exec sp_executesql @sentencia;
	end
else
	begin
		print 'La tabla ' + @nombre_tabla + ' existe.'
	end
go

exec crear_tabla N'mi_tabla';
go

--2.- Crear un procedimiento que pase como parámetro el nombre de una tabla, 
--que valide si existe, en ese caso hacer un select de la misma, y en caso 
--contrario nos indique que no existe mediante un mensaje de error.
if object_id('ver_tabla','P') is not null
	drop procedure ver_tabla;
go

create procedure ver_tabla
	@nombre_tabla varchar(100)
as
if OBJECT_ID(@nombre_tabla) is not null
	begin
		declare @sentencia nvarchar(1000);
		set @sentencia = N'select * from ' + @nombre_tabla;
		exec sp_executesql @sentencia;
	end
else
	begin
		print 'La tabla ' + @nombre_tabla + ' no existe.'
	end
go

use EmpresasInformaticas;
go
--1.- Crear Procedimiento almacenado al que le pasemos como parámetro el nombre del Mes, 
--que valide si es correcto y que devuelva en un parámetro de salida el nº de facturas del mes indicado 
--y un -1 si el nombre del mes es incorrecto. Dar tres ejemplos de prueba.
create procedure factura_mes
	@mes varchar(20),
	@n_facturas int output
as
if (@mes in ('Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre',
			'Octubre', 'Noviembre', 'Diciembre'))
	begin
		select @n_facturas = COUNT(*) from Factura where DATENAME(MONTH, Fecha) = @mes	
	end
else
	begin
		set @n_facturas = -1;
	end
go

declare @n_facturas as int;
exec factura_mes 'Mayo', @n_facturas output;
select @n_facturas as nFacturas;
go
declare @n_facturas as int;
exec factura_mes 'Marzo', @n_facturas output;
select @n_facturas as nFacturas;
go
declare @n_facturas as int;
exec factura_mes 'Madyo', @n_facturas output;
select @n_facturas as nFacturas;
go
--2.- Hacer un procedimiento almacenado que muestre el día de los N próximos meses a partir de la fecha de hoy, 
--con N entrado como parámetro, con valor por defecto 10.
--Si hoy es 8/6/2013, para N=8 deberá salir en formato fecha:
--Jul  8 2013 11:10AM
--Ago  8 2013 11:10AM
--Sep  8 2013 11:10AM
--Oct  8 2013 11:10AM
--Nov  8 2013 11:10AM
--Dic  8 2013 11:10AM
--Ene  8 2014 11:10AM
--Feb  8 2014 11:10AM
create procedure ver_meses
	@n_meses int = 10
as
declare @contador int;
set @contador = 0;
while (@contador < @n_meses)
	begin
		select DATEADD(MONTH, @contador, GETDATE())
		set @contador = @contador + 1;
	end
go

exec ver_meses 8;
go

--3.- Crear Procedimiento almacenado que actualice la tabla componente, aplicándole un 5% de incremento 
--a los precios de los componentes de un CodTipo pasado como parámetro. Validará que hay componentes del 
--tipo pasado, mostrando un mensaje en el caso de que no existan y el número de componentes modificados 
--en el caso de que sí existan.
create procedure actualizar_componentes
	@cod_tipo int
as
set nocount off
if exists(select clave, descripcion, precio, CodTipo from Componente where CodTipo = @cod_tipo)
	begin
		update Componente
		set precio = precio + precio * 0.05
		where CodTipo = @cod_tipo
		print cast(@@rowcount as varchar) + ' registros';
	end
else
	begin
		print 'No existe '+ @cod_tipo + '.';
	end
go

exec actualizar_componentes 69;
go
--4.- Crear un procedimiento almacenado que le pasemos como parámetro un texto 
--y que devuelva en un parámetro de salida los símbolos que no sean las vocales (con o sin acento).
--Hacer un ejemplo de ejecución.
create procedure buscar_simbolos_no_vocales
    @texto varchar(1000),
    @simbolos_no_vocales varchar(1000) OUTPUT
as
begin
    declare @vocales varchar(10) = 'aeiouáéíóúAEIOUÁÉÍÓÚ'
    declare @i int = 1
    declare @char char(1)
    set @simbolos_no_vocales = ''
    while @i <= LEN(@texto)
    begin
        set @char = SUBSTRING(@texto, @i, 1)

        if @char not like '[' + @vocales + ']'
            set @simbolos_no_vocales += @char

        set @i += 1
    end
end
go

declare @simbolos_no_vocales as varchar(1000);
exec buscar_simbolos_no_vocales 'Hola', @simbolos_no_vocales output;
select @simbolos_no_vocales as Resultado;
go
declare @simbolos_no_vocales as varchar(1000);
exec buscar_simbolos_no_vocales 'Estoy en el TEA ahora mismo profe, hay mucha gente.áéí', @simbolos_no_vocales output;
select @simbolos_no_vocales as Resultado;
go
--5.- Crear procedimiento almacenado que le pasemos un texto como parámetro y devuelva en un 
--parámetro de salida el nº de componentes cuya descripción contenga el texto suministrado. 
--Hacer un ejemplo de ejecución.
create procedure numero_componentes_descripcion
	@texto varchar(1000),
	@n_componentes int output
as
	select @n_componentes = COUNT(*) from Componente where descripcion like '%' + @texto + '%'
go

declare @n_componentes as int;
exec numero_componentes_descripcion 'ANTIVIRUS', @n_componentes output;
select @n_componentes as Resultado;
go
declare @n_componentes as int;
exec numero_componentes_descripcion 'ACER', @n_componentes output;
select @n_componentes as Resultado;
go
declare @n_componentes as int;
exec numero_componentes_descripcion 'CABLE', @n_componentes output;
select @n_componentes as Resultado;
go