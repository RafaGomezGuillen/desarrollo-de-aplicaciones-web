--2. Crear una tabla con la estructura siguiente:
--a. clave primaria DNI 
alter table empleados
alter column DNI varchar(8) primary key;
go
--3. Crear las sentencias para que valide lo siguiente:
--b. no nulo apellidos --
alter table empleados
alter column apellidos varchar(30) not null;
go
--c. no nulo nombre --
alter table empleados
alter column nombre varchar(30) not null;
go
--d. valor �nico apellidos y nombre
alter table empleados
add constraint uq_apellidosnombre
	unique(apellidos, nombre);
go
--e. validar que fechanacimiento sea menor que la fecha actual
alter table empleados
add constraint ck_fecha
	check(fechanacimiento <= getdate());
go
--f. validar que cantidad de hijos no sea negativa ni mayor que 20
alter table empleados
add constraint ck_hijos
	check (cantidadhijos >= 0 and cantidadhijos < 20);
go
--g. validar que secci�n no est� vac�o
alter table empleados
add constraint ck_seccionnovacio
	check (rtrim(seccion) != '');
go
--4. Ver los �ndices que tiene.
sp_helpindex empleados;
go
--5. A�adir �ndice por fecha de nacimiento
create nonclustered index ix_fechanaciminento
on empleados(fechanacimiento);
go
--6. A�adir �ndice por sueldo
create nonclustered index ix_sueldo
on empleados(sueldo);
go
--7. Modificar lo siguiente en la tabla
--a. A�adir campo direcci�n varchar(100)
alter table empleados
add direccion varchar(30);
go
--b. Cambiar a no nulo seccion
alter table empleados
alter column seccion varchar(20) not null;
go
--c. Validar que sueldo sean >0 y <1000
alter table empleados
add constraint ck_sueldo
	check (sueldo > 0 and sueldo < 1000);
go