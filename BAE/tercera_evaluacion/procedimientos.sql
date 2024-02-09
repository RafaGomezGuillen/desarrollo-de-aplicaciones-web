-- eliminación de la tabla "libros" si existe;
-- creación de la tabla "libros" con: codigo, titulo, autor, editorial, precio, cantidad;
-- ingreso de algunos registros.
create procedure crear_datos
as
if object_id('libros','U') is not null
drop table libros;
create table libros(
	titulo varchar(40),
	autor varchar(30),
	editorial varchar(15),
	precio float,
	cantidad integer
);
insert into libros 
	(titulo,autor,editorial,precio,cantidad)
values
	('El aleph','Borges','Emece',25.50,100),
	('Alicia en el pais de las maravillas','Lewis Carroll','Atlantida',10,200),
	('Crimen y castigo','Fi�dor Dostoievski','Ed. uno',10.25,2),
	('Diez negritos','Agatha Christie','E. uno', 6.50,3),
	('Cien a�os de soledad','Gabriel Garc�a M�rquez','Ed. siempre',10.20,7),
	('Los Pilares de la Tierra','Ken Follett','Ed. siempre',16.40,2),
	('El viejo y el mar','Ernest Hemingway','Ed. Santillana',6.50,4);
go

if object_id('crear_datos','P') is not null
drop procedure crear_datos;
go

exec crear_datos;
go

--verificar que existe el procedimiento creado recientemente.
exec sp_help crear_datos;
go

if object_id('libros_menos_10','P') is not null
drop procedure libros_menos_10;
go

--Necesitamos un procedimiento almacenado que muestre los libros de los cuales hay menos de 10. 
create procedure libros_menos_10
as
select titulo
from libros
where cantidad < 10;
go

exec libros_menos_10;
go

--Cree un procedimiento almacenado llamado "pa_empleados_sueldo" que seleccione los nombres, apellidos y sueldos de los empleados que tengan un sueldo superior o igual al enviado como parámetro.
if object_id('pa_empleados_sueldo') is not null
	drop procedure pa_empleados_sueldo;
go

create procedure pa_empleados_sueldo
	@sueldo decimal(6,2)
as
	select nombre, apellido, sueldo
	from empleados
	where @sueldo <= sueldo;
go

exec pa_empleados_sueldo 400;
exec pa_empleados_sueldo 500;

--Cree un procedimiento almacenado llamado "pa_empleados_actualizar_sueldo" que actualice los sueldos iguales al enviado como primer parámetro con el valor enviado como segundo parámetro.
if object_id('pa_empleados_actualizar_sueldo') is not null
	drop procedure pa_empleados_actualizar_sueldo;
go

create procedure pa_empleados_actualizar_sueldo
	@sueldo_original decimal(6,2),
	@sueldo_modificado decimal(6,2)
as
	update empleados
	set sueldo = @sueldo_modificado
	where sueldo = @sueldo_original;
go

exec pa_empleados_actualizar_sueldo 300,350;

exec pa_empleados_actualizar_sueldo @sueldo_original = 350, @sueldo_modificado = 400; 


--Cree un procedimiento llamado "pa_sueldototal" que reciba el documento de un empleado y muestre su nombre, apellido y el sueldo total (resultado de la suma del sueldo y salario por hijo, que es de $200 si el sueldo es menor a $500 y $100, si el sueldo es mayor o igual a $500). Coloque como valor por defecto para el parámetro el patrón "%".
if object_id('pa_sueldototal') is not null
	drop procedure pa_sueldototal;
go

create procedure pa_sueldototal
	@input_documento varchar(8) = '%'
as
if exists (
	select nombre, apellido, sueldo
	from empleados
	where documento like @input_documento and sueldo < 500
)
	begin
		update empleados
		set sueldo = sueldo + 200
		where documento like @input_documento and sueldo < 500
	end
else if exists (
	select nombre, apellido, sueldo
	from empleados
	where documento like @input_documento and sueldo >= 500
)
	begin
		update empleados
		set sueldo = sueldo + 100
		where documento like @input_documento and sueldo >= 500
	end
go

exec pa_sueldototal '22333333';
exec pa_sueldototal '22444444';
exec pa_sueldototal '22666666';
exec pa_sueldototal;


--4- Cree un procedimiento almacenado llamado "pa_seccion" al cual le enviamos el nombre de una sección y que nos retorne el promedio de sueldos de todos los empleados de esa sección y el valor mayor de sueldo (de esa sección).
if object_id('pa_seccion') is not null
	drop procedure pa_seccion;
go
create procedure pa_seccion
	@nombre_seccion varchar(20),
	@promedio_sueldos decimal(6,2) output,
	@max_sueldo decimal(6,2) output
as
	select @promedio_sueldos = AVG(sueldo) from empleados where seccion = @nombre_seccion
	select @max_sueldo = MAX(sueldo) from empleados where seccion = @nombre_seccion;
go
--5
declare @promedio_sueldos as decimal (6,2);
declare @max_sueldo as decimal(6,2);
exec pa_seccion 'Secretaria', @promedio_sueldos output, @max_sueldo output;
select @promedio_sueldos as PromedioSueldos, @max_sueldo as Maxsueldo;
exec pa_seccion 'Contaduria', @promedio_sueldos output, @max_sueldo output;
select @promedio_sueldos as PromedioSueldos, @max_sueldo as Maxsueldo;
go

--7- Elimine el procedimiento almacenado "pa_sueldototal", si existe y cree un procedimiento con ese nombre que reciba el documento de un empleado y retorne el sueldo total (en un parámetro de salida), resultado de la suma del sueldo y salario por hijo, que es $200 si el sueldo es menor a $500 y $100 si es mayor o igual.
if object_id('pa_sueldototal') is not null
	drop procedure pa_sueldototal;
go

create procedure pa_sueldototal
    @documento char(8),
    @sueldoTotal decimal(6,2) output
as
begin
    declare @sueldo decimal(6,2), @cantidadHijos int
    select @sueldo = sueldo, @cantidadHijos = cantidadhijos from empleados where documento = @documento
    
    if @sueldo < 500
        set @sueldoTotal = @sueldo + @cantidadHijos * 200
    else
        set @sueldoTotal = @sueldo + @cantidadHijos * 100
end
go

declare @sueldoTotal as decimal(6,2);
exec pa_sueldototal null, @sueldoTotal output;
select @sueldoTotal as SueldoTotal;
go



	


