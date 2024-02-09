create table FAC_T_Cliente2 (
CodCliente integer identity primary key,
NombreCliente varchar(60),
DatosCliente varchar(60),
FechaAlta datetime ,
FechaNacimiento datetime
);
go

insert into FAC_T_Cliente2 ( NombreCliente,DatosCliente,FechaAlta,FechaNacimiento ) values ('Antonio','C/uno n� 3','01/03/2012','15/04/1970');
insert into FAC_T_Cliente2 ( NombreCliente,DatosCliente,FechaAlta,FechaNacimiento ) values ('Juan','C/la hornera n� 7' ,'22/05/2012','29/06/1982' );
insert into FAC_T_Cliente2 ( NombreCliente,DatosCliente,FechaAlta,FechaNacimiento ) values ('Mar�a','C/el pino n� 7','22/05/2010','15/06/1960');
go

select CodCliente, NombreCliente from Fac_T_Cliente2;

delete from Fac_T_Cliente2 where CodCliente=3;
go

insert into FAC_T_Cliente2 ( NombreCliente,DatosCliente,FechaAlta,FechaNacimiento ) values ('Mar�a','C/el pino n� 7','22/05/2010','15/06/1960');
go

select CodCliente, NombreCliente from Fac_T_Cliente2;
go

delete from Fac_T_Cliente2;
go

insert into FAC_T_Cliente2 ( NombreCliente,DatosCliente,FechaAlta,FechaNacimiento ) values ('Antonio','C/uno n� 3','01/03/2012','15/04/1970');

insert into FAC_T_Cliente2 ( NombreCliente,DatosCliente,FechaAlta,FechaNacimiento ) values ('Juan','C/la hornera n� 7' ,'22/05/2012','29/06/1982');
insert into FAC_T_Cliente2 ( NombreCliente,DatosCliente,FechaAlta,FechaNacimiento ) values ('Mar�a','C/el pino n� 7','22/05/2010','15/06/1960');
go
select CodCliente, NombreCliente from Fac_T_Cliente2;
go

select ident_seed('Fac_T_Cliente2');
--devuelve el valor inicial del generador identity de la tabla.
select ident_incr('FAC_T_Cliente2');
--devuelve el incremento del generador identity de la tabla.
select SCOPE_IDENTITY();
select @@identity;
--devuelven el �ltimo valor generado del anterior insert con
--alguna diferencia en el �mbito
select IDENT_CURRENT( 'FAC_T_Cliente2' );
--devuelve el �ltimo valor generado para la tabla especificada

select ident_seed('FAC_T_Cliente2');
--devuelve el valor inicial del generador identity de la tabla.
select ident_incr('FAC_T_Cliente2');
--devuelve el incremento del generador identity de la tabla.
select SCOPE_IDENTITY();
select @@identity;
--devuelven el �ltimo valor generado del anterior insert con
--alguna diferencia en el �mbito
select IDENT_CURRENT( 'FAC_T_Cliente2' );
--devuelve el �ltimo valor generado para la tabla especificada

select * from FAC_T_Cliente2;

select Id, Titulo, Director, Agno, FechaCompra,precio from Peliculas;
go

select Titulo, Director from Peliculas;
go

select Apellidos, Nombre from Socios;
go

select Id, Titulo, Director, Agno, FechaCompra,precio from Peliculas where 'Francis Ford Coppola' = Director;
go

select Apellidos, Nombre from Socios where 'Juan' = Nombre;
go

select Titulo, Director from Peliculas where '1960' = Agno;
go

use MoviesBasicas;
go

select Director from Peliculas where 'Francis Ford Coppola' <> Director;
go

select Titulo, Director from Peliculas where Agno>'1960';
go

delete from Peliculas where Agno = '1975';
go

delete from Peliculas where Titulo = 'Gandhi';
go

delete from Socios where FechaDeAlta > '31/12/2008';
go

use MoviesBasicas;
go

update Peliculas set FechaCompra = '15/2/2013' where Titulo = 'La Fiera de mi Ni�a';
go

update Peliculas set Director = 'Joseph Leo Mankiewicz' where Director = 'Joseph L. Mankiewicz';
go

update Peliculas set precio = precio + 4 where precio < '4';
go

select Director from Peliculas where Director = NULL;
go

select Director from Peliculas where Director = '';
go

create table peliculas2 (
	Id int null,
	Titulo nvarchar(100) not null,
	Director nvarchar(100) not null,
	Agno int null,
	FechaCompra datetime null,
	precio numeric(6,2) null
);
go

insert peliculas2 values (1, 'Cars', 'Rayo MQueen', 46, '24/12/1999', null);
go

create table Socios2 (
	NIFNIE char(9),
	Apellidos varchar(50),
	Nombre varchar(100),
	Direccion varchar(100),
	Telefono char (9),
	FechaDeAlta datetime,
	primary key (Apellidos, nombre)
);
go

insert Socios2 (NIFNIE,Apellidos, Nombre, Direccion,Telefono,FechaDeAlta)  values ('27194787R','P�rez Rodr�guaz','Antonio','C/La mesa n� 153','92262335','06/12/2012');
go

insert Socios2 (NIFNIE,Apellidos, Nombre, Direccion,Telefono,FechaDeAlta)  values ('14562375F','P�rez Rodr�guez','Antonio','C/La silla n� 25','92265212','21/11/2003');
go

drop table peliculas2;
go

create table Peliculas2 (
	Id int identity primary key,
	Titulo nvarchar(100) null,
	Director nvarchar(100) null,
	Agno int null,
	FechaCompra datetime null,
	Precio numeric(6, 2) null
);
go

set dateformat dmy;
insert into Peliculas2 values (1, 'Cars', 'Antonio Di Caprio', 2003, '24/04/2012', 14,2);

insert into Peliculas2 values ('Toy Story', 'Messi', 2012, '22/11/2001', 11);
insert into Peliculas2 values ('Bichos', 'Steve Raro', 2010, '11/01/2022', 10);
insert into Peliculas2 values ('Los Increibles', 'Rodruigo', 2010, '24/04/2001', 9);

use MoviesBasicas;

if (select name from master.sys.sysdatabases where name = 'MoviesBasicas') is null
	select 'no existe';
else 
	select 'existe';

if DB_ID('facturasbasicas') is null
	select 'no existe';
else
	select 'existe';

select Id,convert(varchar,FechaCompra,103) from Peliculas;
go

set language Espa�ol;
select Id,convert(varchar,FechaCompra,100) from Peliculas;
go

create table Personal (
	ID int primary key identity,
	DNI char(9),
	Nombre varchar(100),
	Puesto char(20),
	FechaDeNacimiento datetime,
	NHijos int
);
go

create table Prueba (
	ID int,
	Dato char(20)
);
go

insert Prueba (ID, Dato) values (1, 'elemento1');
insert Prueba (ID, Dato) values (2, 'elemento2');
go

select ID, Dato from Prueba;
go

delete from Prueba where ID = 2;
go

drop table Prueba;
go

select * from Prueba;
go

set dateformat dmy;
go

set identity_insert Personal off;
go

insert Personal (DNI, Nombre, Puesto, FechaDeNacimiento, NHijos) values ('32456789H', 'Mar�a','Jefa','27/3/1975', null);
insert Personal (DNI, Nombre, Puesto, FechaDeNacimiento, NHijos) values ('23456789W','Juan','T�cnico','23/4/1968', null);
insert Personal (DNI, Nombre, Puesto, FechaDeNacimiento, NHijos) values ('45454545J','Ana','Jardinero','21/1/1980', null);
go

set identity_insert Personal on;
go

insert Personal (ID, DNI, Nombre, Puesto, FechaDeNacimiento, NHijos) values (33,'65656546G','Antonio','Jardinero','23/05/1978', null);
go

delete from Personal where DNI = '65656546G';
go

select Precio from Planta where Precio > 20;
go

select CodFamilia from Familia where Familia = 'Cyperaceae';
go

select DescripcionPlanta from Planta where Precio = 12.30;
go

update Planta set Precio = Precio + 1 where Precio < 5;
go

select Familia from Familia where CodFamilia = 5;
go

update Familia set Familia = 'Rosaceae officinalis' where CodFamilia = 5;
go

if DB_ID('JardinBotanicoBasicas') is null
	 create database JardinBotanicoBasicas;
else
	 drop database JardinBotanicoBasicas
	 create database JardinBotanicoBasicas;
go

select @@LANGUAGE;
go

set language Espa�ol;
go

set language us_english;
go

insert into Comida (IdComida, Fecha) values (22, '03/12/2013');
insert into Comida (IdComida, Fecha) values (23, '12/26/2013');
go

set language Espa�ol;
go

insert into Comida (IdComida, Fecha) values (24, '18/03/2013');
insert into Comida (IdComida, Fecha) values (25, '25/07/2013');
go

select IdComida, CONVERT(varchar, Fecha, 103) from Comida;
go

create table TipoPlato2 (
	CodTipoPlato int null,
	TipoPlato varchar(100) null default 'Bebidas b�sicas',
	Agrupa varchar(10) null default 'Bebida'
);
go

insert into TipoPlato2 (CodTipoPlato) values (1);
insert into TipoPlato2 (CodTipoPlato) values (2);
insert into TipoPlato2 (CodTipoPlato, TipoPlato) values (3, 'Hamburguesa');
insert into TipoPlato2 (CodTipoPlato, Agrupa) values (4, 'Cerveza');
go

select * from TipoPlato2;
go

select 'Agrupa: '+Agrupa,'hola '+TipoPlato from TipoPlato2;
go

select Precio - (Precio*5/100) from Plato;
go

select Plato, Precio from plato where CodPlato = 4;
go

update Plato set Precio = Precio + 3 where CodPlato = 4;
go

select Plato, Precio from Plato;
go

select (4+5)*6 as 'hola';
go

select Plato,cast(Precio/10 as numeric(6,2)), Precio from Plato;
go

select Agrupa+' ', 'Su plato'+TipoPlato from TipoPlato2;

--Redondear 4567.345 con 2 decimales
select ROUND(4567.345, 2);
--Truncar 4567.356 con 1 decimal
select ROUND(4567.356, 1);
--Ra�z cuadrada de 625
select SQRT(625);
--Cuadrado de 12
select POWER(12,2);
--Valor absoluto de la diferencia 23-56
select ABS(23-56);
-- Dar el precio del plato redondeado sin decimales.
-- Resultado de dividir el precio entre diez, dando el cociente
-- entero y el resto por separado.
select (FLOOR(ROUND(precio,0)/ 10)) as cociente, ((ROUND(precio,0)% 10)) as resto from plato;

-- Mostrar la fecha actual
select GETDATE();
-- Indicar el nombre del d�a de la semana de hoy
select DATEPART(DW, GETDATE());
-- Indicar el n� del mes de la fecha actual.
select DATEPART(MONTH, GETDATE());
-- Calcular el n�mero de d�as de diferencia entre el 25/12/2010 y la fecha actual.
select DATEDIFF(DAY, '25/12/2010', GETDATE());
-- Dar el n� del a�o actual
select DATEPART(YEAR, GETDATE());
-- Sumar 35 d�as a la fecha actual.
select DATEADD(day, 3, GETDATE());
-- Calcular el n�mero de d�as transcurridos entre la fecha actual y la fecha de cada comida.
select DATEDIFF(day, Fecha, GETDATE()) from Comida;
-- Dar las comidas efectuadas en Domingo.
select IdComida from Comida where DATEPART(DW, Fecha) = 7;
-- Dar el n�mero del mes de cada comida. 
select DATEPART(MONTH, Fecha) as Hola from Comida;

--Sacar los platos ordenados por su nombre.
select CodPlato, Plato from Plato order by Plato 
--Sacar los platos ordenados por su precio de mayor a menor.
select Plato, Precio from Plato order by Precio DESC;
--Sacar los platos ordenados por codtpoplato y precio
select Plato from Plato order by CodPlato, Precio;
--Sacar las comidas con pagado a S y ordenadas por el n�mero del mes.
select Pagado, DATENAME(MONTH, Fecha) from Comida order by DATEPART(MONTH, Fecha);

--Sacar los platos con nombre comenzando por A o C.
select Plato from Plato where SUBSTRING(Plato,1,1) = 'A' or SUBSTRING(Plato,1,1) = 'C';
--Sacar los platos con nombre que no comiencen ni por A ni por C.
select Plato from Plato where (SUBSTRING(Plato,1,1) <> 'A') and (SUBSTRING(Plato,1,1) <> 'C'); 
--Sacar los platos con precio entre 10 y 20 (incluyendo ambos valores)
select Plato, Precio from Plato where (Precio >= 10) and (Precio  <= 20);
--Sacar los platos con codtpoplato menor que 3 o con precio menor que 60
select CodPlato, Precio, Plato from Plato where (CodPlato < 3) or (Precio < 60);
--Sacar las comidas con pagado a S y del d�a 17
select Pagado, Fecha, IdComida from Comida where (Pagado = 'S') and (DATEPART(DAY, Fecha) = 17);

-- Sacar los platos con nombre comenzando por las letras entre A y C.
select Plato from Plato where SUBSTRING(Plato,1,1) between 'A' and 'C';  
--Sacar los platos con precio entre 10 y 20 (incluyendo ambos valores)
select Plato, Precio from Plato where Precio between 10 and 20;
--Sacar las comidas entre los d�as 17 y 20.
select IdComida, Fecha from Comida where DATEPART(day,Fecha) between 17 and 20;

--Sacar los platos con nombre comenzando por las vocales.
select Plato from Plato where SUBSTRING(Plato,1,1) in ('A', 'E', 'I', '0', 'U');
--Sacar los platos con precio 6, 9 ,11 o 16.
select Plato, Precio from Plato where Precio in (6, 9, 11, 16);
--Sacar los tpo plato que comienzan con A, B o C
select CodTipoPlato from Plato where SUBSTRING(Plato, 1, 1) in ('A', 'B', 'C');
--Sacar las comidas con d�a de la semana en su fecia Lunes, Jueves o s�bado
select IdComida, Fecha from Comida where DATENAME(WEEKDAY, Fecha) in ('Lunes', 'Jueves', 'Sabado');

--Sacar los platos con nombre comenzando por A iasta F.
select Plato from Plato where Plato like '[A-F]%';
--Sacar los tpo de plato con Carnes en el campo TipoPlato.
select TipoPlato from TipoPlato where TipoPlato like '%Carnes%';
--Sacar los platos que contengan "ca" en el campo Plato.
select Plato from Plato where Plato like '%ca%';
--Sacar las comidas en las mesas que tengan un 1 o un 2 en el tercer car�cter.
select CodMesa from Comida where CodMesa like '__1' or CodMesa like '__2';
--Sacar los platos que contengan Lenguado o Salm�n en el campo Plato.
select Plato from Plato where Plato like 'Lenguado%' or Plato like 'Salm�n%';
--Sacar los platos que no tengan m�nimo en el campo plato.
select Plato from Plato where Plato like '%[^m�nimo]%';
--Sacar los platos cuyo campo plato terminen con C�sar.
select Plato from Plato where Plato like '%C�sar';

--Cuántos programas diferentes tene cada cadena con algún share >20
select Cadena, COUNT(Distinct Programa)
from Datosprogramas
where Share > 20
group by Cadena;
--Media de espectadores que han visto programas punteros en la sexta
--los lunes, por hora de comienzo
select AVG(Espectadores) as MediaEspectadores, DATEPART(HOUR, FechaHora) as HoraPunta
from Datosprogramas
where Cadena = 'LA SEXTA' and DATENAME(DW, FechaHora) = 'Lunes'
group by DATEPART(hour, FechaHora);

--Suma de audiencia de programas para cada cadena en
--martes y para las cadenas con tres o menos programas.
select SUM(Espectadores) as Audiencia, Cadena, COUNT(DISTINCT Programa) as NumeroProgramas
from Datosprogramas
where DATENAME(DW, FechaHora) = 'Martes'
group by Cadena
having COUNT(DISTINCT Programa) <= 3;
--Mostrar las cadenas con media de share mayor que 10 en el
--horario de las 10, 11 y 12 de la mañana.
select Cadena, AVG(Share) as MediaShare
from Datosprogramas
where DATEPART(HOUR, FechaHora) in (10, 11, 12)
group by Cadena
having AVG(Share) > 10;

--Sacar los países con datos, ordenado por el nombre del país.
select pais from DatosTuristas group by pais order by pais;
--Sacar los países que hayan tenido algún dato de visitas de 
--mujeres De 25 a 44 años de más de 30000.
select pais 
from DatosTuristas
where sexo = 'Mujeres' and grupoedad = 'De 25 a 44 años' and turistas > 30000
group by pais;
--Contar cuántos datos hay por grupo de edad.
select grupoedad, COUNT(*)
from DatosTuristas 
group by grupoedad;
--Dar los 3 países con más turistas en el periodo de 2013.
select top 3 SUM(turistas), pais
from DatosTuristas
where periodo = 2013
group by pais
order by SUM(turistas) desc;

--Mostrar la media de turistas por pais para aquellos países
--con media mayor de 25000 en 2012
select AVG(turistas) as MediaTuristas, pais
from DatosTuristas
where periodo = 2012
group by pais
having AVG(turistas) > 25000
order by AVG(turistas);
--Mostrar los dos países con mayor suma de turistas en 2013,
--que tengan datos >23000.
select top 2 pais, SUM(turistas) as SumaTuristas
from DatosTuristas
where periodo = 2013
group by pais
having turistas > 23000
order by SUM(turistas) desc;

create database Facturas;

if object_id('FAC_T_Articulo') is not null
drop table FAC_T_Articulo; 

use Facturas;
create table FAC_T_Articulo (
	CodArticulo int primary key,
	NombreArticulo varchar(50) unique,
	TipoArticulo varchar(50),
	PrecioActual numeric(10,2)
);

if object_id('FAC_T_Cliente') is not null
drop table FAC_T_Cliente; 

create table FAC_T_Cliente(
	CodCliente int primary key,
	NombreCliente varchar(60) not null,
	DatosCliente varchar(60) default 'Desconocida',
	Municipio varchar(50),
	FechaAlta datetime default getdate(),
	FechaNacimiento datetime null
);

insert FAC_T_Articulo ( CodArticulo,NombreArticulo,TipoArticulo,PrecioActual )  
values ( 205,'Sierra circular especial','Herramienta el�ctrica', 158.50 );

insert FAC_T_Cliente ( CodCliente,NombreCliente,DatosCliente,Municipio,FechaNacimiento )  
values ( 45,'Laura Gonz�lez Gonz�lez','C/La Marina n� 3','S/C Tenerife', '25/09/1990');

update FAC_T_Articulo
set PrecioActual = PrecioActual + PrecioActual * 0.1
where PrecioActual <= 5

select PrecioActual
from FAC_T_Articulo
where PrecioActual <= 5

select Municipio, DatosCliente, NombreCliente, FechaNacimiento
from FAC_T_Cliente
where NombreCliente = 'Laura Gonz�lez Gonz�lez';

set dateformat dmy;
update FAC_T_Cliente
set Datoscliente = 'C/Esmeralda n� 7', FechaNacimiento = '29/09/1990'
where NombreCliente = 'Laura Gonz�lez Gonz�lez';

select *
from FAC_T_Articulo
where PrecioActual < 1;

delete 
from FAC_T_Articulo
where PrecioActual < 1;

select NombreArticulo, PrecioActual
from FAC_T_Articulo;

select NombreCliente, DatosCliente, convert(varchar,FechaNacimiento,103) as DiaMesAnio, DATEDIFF(YEAR, FechaNacimiento, GETDATE()) as NumeroAnio 
from FAC_T_Cliente
where DATEPART(MONTH, FechaNacimiento) = 6
order by DATEDIFF(YEAR, FechaNacimiento, GETDATE()) asc;

select CodArticulo, NombreArticulo, PrecioActual
from FAC_T_Articulo
where PrecioActual between 10 and 50
order by PrecioActual desc;

select NombreCliente, DATENAME(MONTH, FechaAlta) as MES
from FAC_T_Cliente
where DATENAME(MONTH, FechaAlta) in ('enero', 'marzo', 'abril', 'junio');

select NombreArticulo
from FAC_T_Articulo
where NombreArticulo like '%[1-9]%'

select NombreCliente + ' -- ' + str(CodCliente,2,0) as 'datos cliente', DATEPART(YEAR, FechaAlta) as Anio
from FAC_T_Cliente

select NombreCliente
from FAC_T_Cliente
where FechaAlta is not null and DATENAME(MONTH, FechaAlta) = 'mayo';

select *
from FAC_T_Articulo
where PrecioActual > 2 and NombreArticulo like '%destornillador%';

select NombreCliente, FechaAlta
from FAC_T_Cliente
where DATENAME(MONTH, FechaAlta) in ('enero', 'marzo', 'mayo');

select NombreCliente, CodCliente, DATEDIFF(MONTH, FechaAlta, GETDATE()) as 'meses de antig�edad'
from FAC_T_Cliente
order by NombreCliente;

select NombreCliente, DATENAME(DW, FechaAlta) as DiaSemanaDeAlta
from FAC_T_Cliente
order by FechaAlta asc; 

EXEC sp_columns @Table_name = 'FAC_T_Cliente'; 

select COUNT(NombreCliente) as ContarClientes
from FAC_T_Cliente;

select COUNT(FechaNacimiento) as FechaNacimiento
from FAC_T_Cliente
where FechaNacimiento is not null;

select AVG(PrecioActual) as MediaPrecioArticulos
from FAC_T_Articulo
where TipoArticulo like  '%Herramienta%';

select TipoArticulo
from FAC_T_Articulo
group by TipoArticulo
order by TipoArticulo;

select TipoArticulo, COUNT(NombreArticulo) as CuantosArticulos
from FAC_T_Articulo
group by TipoArticulo
order by COUNT(NombreArticulo) desc;

select TipoArticulo, AVG(PrecioActual) as MediaPrecio
from FAC_T_Articulo
group by TipoArticulo
having COUNT(TipoArticulo) > 2;


select TOP 2 Municipio, COUNT(NombreCliente) as Clientes
from FAC_T_Cliente
group by Municipio
order by COUNT(NombreCliente) desc;

select TipoArticulo, MAX(PrecioActual) as PrecioMasAlto
from FAC_T_Articulo
group by TipoArticulo
order by MAX(PrecioActual) desc;

select Municipio, COUNT(*) - COUNT(FechaNacimiento) as ClientesConFecha, COUNT(FechaNacimiento) as ClientesSinFecha
from FAC_T_Cliente
group by Municipio; 

select DATENAME(MONTH, FechaNacimiento) as Mes, COUNT(NombreCliente) as CuantosClientes
from FAC_T_Cliente
where DATENAME(MONTH, FechaNacimiento) is not null
group by DATENAME(MONTH, FechaNacimiento), MONTH(FechaNacimiento)
order by MONTH(FechaNacimiento) asc;

--1
select nombre, faltas, beca 
from alumnos
where faltas > 15 and beca is not null;

update alumnos
set beca = beca - (beca * 0.10)
where faltas > 15 and beca is not null;

select nombre, faltas, beca 
from alumnos
where faltas > 15 and beca is not null;

--2 
select nombre, localidad, curso, nivel
from alumnos
where nombre like '%ez%' and localidad like '%ca'
order by nivel asc, curso asc;

--3
select UPPER(nombre) as NombreMayuscula, str(curso,1,0)+ '� de la ESO' as CursoESO
from alumnos
where curso <= 3 and nivel = 'ESO'
order by curso asc;

--4 
select COUNT(nombre) as AlumnosMatriculados
from alumnos;

--5
select COUNT(nombre) as CuantosAlumnosHay, curso, nivel, COUNT(beca) as CuantosTienenBeca
from alumnos
group by curso, nivel
order by curso asc, nivel asc;

--6
select curso, nivel, SUM(beca) as TotalBeca
from alumnos
group by curso, nivel
having AVG(beca) > 200;

--7
select top 2 DATENAME(MONTH, fecha_nac) as Mes
from alumnos
group by DATENAME(MONTH, fecha_nac)
order by COUNT(MONTH(fecha_nac)) desc;

--8
select nombre, DATEDIFF(YEAR, fecha_nac, GETDATE()) as Edad, 
	   DATENAME(DW, fecha_nac) as DiaSemanaNacimiento
from alumnos
where beca is null;

--9 
select nombre, curso, DATEDIFF(YEAR, fecha_nac, GETDATE()) as Edad
from alumnos
where DATEDIFF(YEAR, fecha_nac, GETDATE()) between 15 and 17

--10
select top 1 curso, COUNT(nombre) as NumeroMatriculado
from alumnos
group by curso;

create database PrestamoLibros;

use PrestamoLibros;
if object_id ('libros') is not null drop table libros;
 create table libros(
 codigo int identity,
 titulo varchar(40) not null,
 autor varchar(20) default 'Desconocido',
 editorial varchar(20),
 precio decimal(6,2),
 cantidad int default 0,
 primary key (codigo)
);

insert into libros (titulo,autor,editorial,precio) values('El aleph','Borges','Emece',25);
insert into libros values('Java en 10 minutos','Mario Molina','Siglo XXI',50.40,100);
insert into libros (titulo,autor,editorial,precio,cantidad) values('Alicia en el pais de las maravillas','Lewis Carroll','Emece',15,50);
go

use PrestamoLibros;

-- Mostrar las 3 primeras letras de todos los ttulos.
select LEFT(titulo, 3) from libros;
-- Mostrar el precio como cadena de caracteres.
select str(precio,7,3)from libros;
-- Mostrar la cadena con el ttulo, un gui�n, el autor un gui�n y el precio.
select titulo +' - '+autor +' - '+str(precio,7,3)+' euros ' as column1 from libros;
-- Mostrar las seis �ltmas letras del ttulo y del autor.
select RIGHT(titulo, 6), RIGHT(autor, 6) from libros;
select SUBSTRING(titulo, len(titulo)- 5, 6), SUBSTRING(autor, len(autor) - 5, 6) from libros;
-- Mostrar el nombre del autor en may�scula.
select UPPER(autor) from libros;
-- Indicar el n�mero de letras del autor y del ttulo.
select LEN(autor), LEN(titulo) from libros;
-- Mostrar los caracteres del 4 al 10 del autor
select SUBSTRING(autor, 4, 7) from libros;
-- Cambiar arroba por el car�cter arroba y punto por el car�cter
-- punto en el texto correoarrobahotmailpuntocom 
select REPLACE('correoarrobahotmailpuntocom', 'arroba', '@');
select REPLACE('correoarrobahotmailpuntocom', 'punto', '.');
select REPLACE (REPLACE('correoarrobahotmailpuntocom', 'arroba', '@'), 'punto', '.');

--1
create table Paises (
	idPais int primary key identity,
	pais varchar(50) not null,
	codPais char(3) not null
);

--2 
set identity_insert Paises on;
insert into Paises (idPais, pais, codPais) values (1, 'Italia', '001');

select *
from Paises;

set identity_insert Paises off;
insert into Paises (pais, codPais) values ('Alemanio', '002');

insert into Paises (pais, codPais) values (null, '002');

--3
update PuntuacionBasicas
set Fecha = DATEADD(MONTH,1,Fecha)
where Plataforma = 'PC';

--4
delete from Paises
where idPais > 1

select * 
from Paises;

--5
select COUNT(Juego) as CuantosJuegosHay, Plataforma, Tipo
from Juegos
where Plataforma = 'PS3' and Tipo = 'Acci�n'
group by Plataforma, Tipo;

--6
select top 2 Nombre, FechaNacimiento
from Cliente
where Email like '%.ca' and DATEPART(MONTH, FechaNacimiento) = 5
order by FechaNacimiento desc;

--7
select top 3 COUNT(distinct Juego) as Juegos, Desarrollador, Tipo
from Juegos
where Desarrollador like 'B%' and Tipo = 'Acci�n'
group by Desarrollador, Tipo
order by COUNT(distinct Juego) desc;

--8
select COUNT(Nombre) as NumeroDeClientes, DATENAME(DW, FechaRegistro) as DiaDeLaSemana
from Cliente
group by DATEPART(DW, FechaRegistro), DATENAME(DW, FechaRegistro)
order by DATEPART(DW, FechaRegistro) asc;

--9
select Plataforma, COUNT(Puntuacion) as NumeroPuntaciones, 
	   SUM(Puntuacion) as SumaPuntuacion, COUNT(distinct Juego) as NumeroJuegosDistintos
from PuntuacionBasicas
group by Plataforma
having COUNT(Puntuacion) > 6
order by SUM(Puntuacion) desc;

--10
select UPPER(NombreCliente) as NombreCliente,
	   COUNT(Puntuacion) as NumeroPuntuaciones, AVG(Puntuacion) as Media
from PuntuacionBasicas
group by NombreCliente
having AVG(Puntuacion) > 5 and COUNT(Puntuacion) > 1
order by AVG(Puntuacion) desc;