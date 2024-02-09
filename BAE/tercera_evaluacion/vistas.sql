--2. Crear una vista basada en esa consulta. (ver_paro_provincia)
create view ver_paro_provincia
as
select CA, Provincia, SUM(TotalParoRegistrado) as TotalParados
from ParoMes
	inner join Municipios
	on Municipios.CodMunicipio = ParoMes.CodMunicipio
	inner join Provincias
	on Provincias.CodProvincia = Municipios.CodProvincia
	inner join ComunidadesAutonomas
	on ComunidadesAutonomas.CodCA = Provincias.CodCA
where MONTH(Fecha) = 1
group by Provincia, CA;
go
--3. Usar la vista sacando todos sus datos.
select *
from ver_paro_provincia;
go
--4. Usar la vista para sacar la suma de parados por Comunidad Aut�noma.
select CA, SUM(TotalParados) as SumaParados
from ver_paro_provincia
group by CA;
go
--5. Crear una vista sobre la tabla ComunidadesAutonomas
create view ver_comunidades_autonomas
as
select CodCA, CA
from ComunidadesAutonomas;
go
--7. Borrar la vista anterior comprobando que existe
if OBJECT_ID('ver_comunidades_autonomas', 'V') is not null
	drop view ver_comunidades_autonomas;
go
--8. Mostrar la estructura de la vista ver_paro_provincia
exec sp_helptext ver_paro_provincia;
go
--9. Crear de nuevo la vista pero encriptada
drop view ver_paro_provincia;
go
create view ver_paro_provincia
with encryption
as
select CA, Provincia, SUM(TotalParoRegistrado) as TotalParados
from ParoMes
	inner join Municipios
	on Municipios.CodMunicipio = ParoMes.CodMunicipio
	inner join Provincias
	on Provincias.CodProvincia = Municipios.CodProvincia
	inner join ComunidadesAutonomas
	on ComunidadesAutonomas.CodCA = Provincias.CodCA
where MONTH(Fecha) = 1
group by Provincia, CA;
go
--10. Comprobar que no se puede ver su estructura
exec sp_helptext ver_paro_provincia;
go
--13. Crear una vista que acceda a las Comunidades aut�nomas solamente
create view mis_comunidades_autonomas
as
select CodCA, CA
from ComunidadesAutonomas;
go
--14. Hacer una inserci�n correcta sobre esa vista
insert into mis_comunidades_autonomas
(CodCA, CA)
values (20, 'Nueva CA');
go
--15. Borrar el registro creado anteriormente, usando tambi�n la vista
delete from mis_comunidades_autonomas
where CodCA = 20;
go
--16. Crear una vista que muestre s�lo las Comunidades aut�nomas que comiencen con C y 
--con la opci�n with check option
create view ca_con_c
as
select CodCA, CA
from ComunidadesAutonomas
where CA like 'C%'
with check option;
go
--17. Probar inserciones y modificaciones que validen el funcionamiento de la opci�n 
--aplicada
insert into ca_con_c
(CodCA, CA)
values (20, 'Canarias 2.0');
go
update ca_con_c
set CA = 'Canarias 3.0'
where CodCA = 20;
go
--18. Modificar la vista anterior filtrando a comunidades aut�nomas que comiencen por A
alter view mis_comunidades_autonomas
as
select CodCA, CA
from ComunidadesAutonomas
where CA like 'A%';
go