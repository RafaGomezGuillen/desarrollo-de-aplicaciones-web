--1
select Nombre
from Equipo
	inner join EquipoCampeonato
	on EquipoCampeonato.idequipo = Equipo.IdEquipo
	inner join Campeonato
	on Campeonato.Id = EquipoCampeonato.idcampeonato
where DATEPART(MONTH, Inicio) = 5
group by Nombre
having COUNT(Campeonato) > 3;
-- Federaciones con clubs de equipos participantes en pruebas de más de 10 días
																															from Campeonato)
select Federacion
from Federacion as F2
where Federacion in (select Federacion
					from Federacion
						inner join Club
						on Club.IdFederacion = Federacion.Id
						inner join Equipo
						on Equipo.IdClub = Club.idClub
						inner join EquipoCampeonato
						on EquipoCampeonato.idequipo = Equipo.IdEquipo
						inner join Campeonato
						on Campeonato.Id = EquipoCampeonato.idcampeonato
					where ABS(DATEPART(DAY, Fin) - DATEPART(DAY, Inicio)) < 10 and DATEPART(MONTH, Fin) - DATEPART(MONTH, Inicio) = 1 and F2.Id = Club.IdFederacion
					group by Federacion)
group by Federacion;
--3
select Campeonato, SUM(Nparticipantes) as TotalParticipantes
from EquipoCampeonato
	right join Campeonato
	on Campeonato.Id = EquipoCampeonato.idcampeonato
group by Campeonato;
--4
select Federacion, SUM(NCiclistas) as TotalNCiclistas
from Federacion
	inner join Club
	on Club.IdFederacion = Federacion.Id
	inner join Equipo
	on Equipo.IdClub = Club.idClub
group by Federacion
having SUM(NCiclistas) > 3000
order by SUM(NCiclistas) desc;
--5
select Organizador, SUM(Nparticipantes) as TotalParticipantes, COUNT(Nombre) as TotalEquipos,
	   COUNT(Campeonato) as NCampeonato
from Organizador
	left join Campeonato
	on Campeonato.IdOrganizador = Organizador.Id
	left join EquipoCampeonato
	on EquipoCampeonato.idcampeonato = Campeonato.Id
	left join Equipo
	on Equipo.IdEquipo = EquipoCampeonato.idequipo
group by Organizador;

--6
select Tipo
from TipoEquipo
	left join Equipo
	on Equipo.IdTipo = TipoEquipo.IdTipo
group by Tipo
having COUNT(Nombre) < 3;
-- Cauntos equipos tiene cada club en mas de 6 competiciones. 
select Club, COUNT(Nombre), COUNT(Campeonato) 
from Club
	inner join Equipo
	on Equipo.IdClub = Club.idClub
	inner join EquipoCampeonato
	on EquipoCampeonato.idequipo = Equipo.IdEquipo
	inner join Campeonato
	on Campeonato.Id = EquipoCampeonato.idcampeonato
where nombre in (select nombre
				from Club
					inner join Equipo
					on Equipo.IdClub = Club.idClub
					inner join EquipoCampeonato
					on EquipoCampeonato.idequipo = Equipo.IdEquipo
					inner join Campeonato
					on Campeonato.Id = EquipoCampeonato.idcampeonato
				group by Nombre
				having COUNT(Campeonato) > 6)
group by Club
--8
select distinct nombre
from Equipo
	inner join EquipoCampeonato
	on Equipo.IdEquipo = EquipoCampeonato.idequipo
	inner join Campeonato
	on Campeonato.Id = EquipoCampeonato.idcampeonato
where Premios < 30000 and Premios < 5000;