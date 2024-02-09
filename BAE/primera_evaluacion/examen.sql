
--1
select Titulo + ' es una película del año '+ STR(agno,4,0) + ' y del estudio: ' + Estudio as 'Peliculas'
from RecaudacionPeliculas
where agno between 1980 and 1989 and Estudio like '[^A,E,I,O,U]___';

--2
select SUM(Npeliculas) as TotalPeliculas
from CineexhibidoCA
where CA = 'Canarias' and agno in (2005, 2008, 2010, 2014);

--3
select top 3 Titulo
from RecaudacionPeliculas
where agno between 2010 and 2014
order by RecUSA desc;

--4
select DATENAME(MONTH, fecha) as Meses, SUM(LargometrajesExtranjeros) + SUM(LargometrajesNacional) as RecaudacionAcumulada
from DatosRecaudacionSpain
group by DATENAME(MONTH, fecha)
order by SUM(LargometrajesExtranjeros) + SUM(LargometrajesNacional) desc;

--5
select Titulo, SUM(RecUSA)+ SUM(RecResto) as RecaudacionTotal
from RecaudacionPeliculas
where Titulo like '%war%' and agno > 1980
group by Titulo
having SUM(RecUSA)+ SUM(RecResto) > 100
order by SUM(RecUSA)+ SUM(RecResto) desc;

--6
if object_id('datoscine') is not null
	drop table datoscine;
else 
	create table datoscine (
		id int primary key identity,
		titulo varchar(100) not null,
		fechaextreno datetime null,
		recaudacion numeric(14,2) null,
		clasificacion int default 5 null
	);

--7
insert datoscine (titulo, fechaextreno, recaudacion) 
values ('Star Wars: Episode I - The Phantom Menace', '19/5/1999', 1027.01);
set identity_insert datoscine on
insert datoscine (id, titulo, fechaextreno, recaudacion, clasificacion)
values (987, 'Star Wars: Episode II - Attack of the Clones', '16/5/2002', 649.40, null);

--8
update datoscine
set id = 8
where id = 987;

delete from datoscine
where id = 987;

--9
select COUNT(Titulo) as NumerosPeliculas, SUM(RecUSA) + SUM(RecResto) as TotalRecaudacion, agno, Estudio
from RecaudacionPeliculas
group by agno, Estudio
having COUNT(Titulo) > 6
order by agno, Estudio;

--10
select SUM(LargometrajesExtranjeros) + SUM(LargometrajesNacional) as NumeroDeLargometraje,
	   DATENAME(MONTH, fecha) as Mes
from DatosRecaudacionSpain
where DATENAME(MONTH, fecha) like '%r%'
group by DATENAME(MONTH, fecha), DATEPART(MONTH, fecha)
order by DATEPART(MONTH, fecha) asc 

--11
select agno , SUM(Npantallas) as CuantasPantallas, SUM(Nlargometrajes) as CuantosLargometrajes, SUM(EspectPeliculasExtranjeras) as EspectadoresExtranjeros
from ActividadesCineSpain
group by agno
having SUM(RecPeliculasExtranjeras) > 300
order by agno;

--12
select top 1 with ties Estudio, COUNT(Titulo) as CuantasPeliculas
from RecaudacionPeliculas
where Estudio like '___'
group by Estudio
having COUNT(Titulo) < 10
order by COUNT(Titulo) desc;