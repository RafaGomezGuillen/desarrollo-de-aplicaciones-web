--SUBCONSULTAS
use Paro;
--1.- Municipios de la isla de Tenerife
select Municipios.Municipio
from Islas
	inner join MunicipiosIslas
	on MunicipiosIslas.CISLA = Islas.CISLA
	inner join Municipios
	on Municipios.CodMunicipio = MunicipiosIslas.CodMunicipio
where Islas.ISLA = 'Tenerife';
--2.- Paro en la Industria en la Provincia de Le�n en el mes de febrero de 2013
select SUM(ParoIndustria) as Paro
from Provincias
	inner join Municipios
	on Municipios.CodProvincia = Provincias.CodProvincia
	inner join ParoMes
	on ParoMes.CodMunicipio = Municipios.CodMunicipio
where Provincias.Provincia = 'Le�n' and MONTH(Fecha) = 2 and YEAR(Fecha) = 2013;
--3.- Mostrar las comunidades aut�nomas y el n� de habitantes (padr�n), orden�ndolas 
--de mayor a menor poblaci�n
select CA, SUM(Padron) as NumHabitantes
from ComunidadesAutonomas
	inner join Provincias
	on Provincias.CodCA =ComunidadesAutonomas.CodCA
	inner join Municipios
	on Municipios.CodProvincia = Provincias.CodProvincia
	inner join Padron
	on Padron.CodMunicipio = Municipios.CodMunicipio
group by CA
order by NumHabitantes desc;
--4.- Qu� Comunidad Aut�noma tiene mayor diferencia entre el paro mujeres en la edad 
--25-45 y la de mujeres menores de 25, en enero de 2013.
select top 1 CA, (SUM(ParoMujerEdad25_45) - SUM(ParoMujerEdadMenor25)) as Diferencia
from ComunidadesAutonomas
	inner join Provincias
	on Provincias.CodCA = ComunidadesAutonomas.CodCA
	inner join Municipios
	on Municipios.CodProvincia = Provincias.CodProvincia
	inner join ParoMes
	on ParoMes.CodMunicipio = Municipios.CodMunicipio
where MONTH(Fecha) = 1 and YEAR(Fecha) = 2013
group by CA
order by Diferencia desc;
--5.- Comunidades aut�nomas sin islas
select CA
from ComunidadesAutonomas
where CA != 'Canarias' and CA != 'Balears, Illes'
group by CA;
--6.- Crear una vista que muestre el nombre de la comunidad aut�noma, el de la 
--provincia y el del municipio, junto al total de paro registrado a fecha 1/3/2013 y al 
--padr�n. Usar esta vista para mostrar la divisi�n entre paro registrado y padr�n para 
--todas las Comunidades aut�nomas.
--*7.- Dar los nombres de los municipios de la Comunidad aut�noma con mayor paro en
--agricultura (en febrero de 2013).
select Municipio
from Municipios
	inner join Provincias
	on Provincias.CodProvincia = Municipios.CodProvincia
	inner join ComunidadesAutonomas
	on ComunidadesAutonomas.CodCA = Provincias.CodCA
where CA = (select top 1 CA
			from ComunidadesAutonomas 
				inner join Provincias
				on Provincias.CodCA = ComunidadesAutonomas.CodCA
				inner join Municipios
				on Municipios.CodProvincia = Provincias.CodProvincia
				inner join ParoMes
				on ParoMes.CodMunicipio = Municipios.CodMunicipio
			where MONTH(Fecha) = 2 and YEAR(Fecha) = 2013
			group by CA
			order by SUM(ParoAgricultura) desc);
--*8.- N�mero de municipios con m�s de 200000 habitantes por Comunidad Aut�noma 
--en el padr�n, sacando todas las Comunidades Aut�nomas
select CA, (select COUNT(*)
			from Provincias
				inner join Municipios
				on Municipios.CodProvincia = Provincias.CodProvincia
				inner join Padron
				on Padron.CodMunicipio = Municipios.CodMunicipio
			where Padron > 200000 and Provincias.CodCA = ComunidadesAutonomas.CodCA)
from ComunidadesAutonomas;
--*9.- Municipios con m�s parados en Servicios entre los habitantes del padr�n en 
--febrero de 2013 que la media nacional de la misma divisi�n
select distinct Municipio
from ParoMes
	inner join Municipios
	on Municipios.CodMunicipio = ParoMes.CodMunicipio
	inner join Padron
	on Padron.CodMunicipio = Municipios.CodMunicipio
where Municipio in (select Municipio
					from ParoMes
						inner join Municipios
						on Municipios.CodMunicipio = ParoMes.CodMunicipio
						inner join Padron
						on Padron.CodMunicipio = Municipios.CodMunicipio
					where MONTH(Fecha) = 2 and YEAR(Fecha) = 2013
					group by Municipio
					having SUM(ParoServicios) > AVG(TotalParoRegistrado));
--10.- Indicar para cada Comunidad Aut�noma el n� de habitantes por municipio 
--(padr�n dividido entre n�mero de municipios), orden�ndolas de menor a mayor
select CA, (select (SUM(Padron) / COUNT(Municipio)) as NumHabiPorMuni 
			from Municipios
			inner join Padron
			on Padron.CodMunicipio = Municipios.CodMunicipio
			inner join Provincias
			on Provincias.CodProvincia = Municipios.CodProvincia
			where Provincias.CodCA = CA2.CodCA) as Content
from ComunidadesAutonomas as CA2
order by Content;
--*11.- Diferencia por Comunidad Aut�noma entre el n� de parados en marzo de 2013 y 
--en enero de 2013
select CA , (select SUM(TotalParoRegistrado) 
			from ComunidadesAutonomas
				inner join Provincias
				on Provincias.CodCA = ComunidadesAutonomas.CodCA
				inner join Municipios
				on Municipios.CodProvincia = Provincias.CodProvincia
				inner join ParoMes
				on ParoMes.CodMunicipio = Municipios.CodMunicipio
			where MONTH(Fecha) = 3 and YEAR(Fecha) = 2013 and Provincias.CodCA = CA2.CodCA) 
		-	(select SUM(TotalParoRegistrado)
			from ComunidadesAutonomas
				inner join Provincias
				on Provincias.CodCA = ComunidadesAutonomas.CodCA
				inner join Municipios
				on Municipios.CodProvincia = Provincias.CodProvincia
				inner join ParoMes
				on ParoMes.CodMunicipio = Municipios.CodMunicipio
			where MONTH(Fecha) = 1 and YEAR(Fecha) = 2013 and Provincias.CodCA = CA2.CodCA) as Diferencia
from ComunidadesAutonomas as CA2;
--*12.- Municipio con m�s habitantes de cada Comunidad Aut�noma
select CA, (select top 1 Municipio
			from Provincias
				inner join Municipios
				on Municipios.CodProvincia = Provincias.CodProvincia
				inner join Padron
				on Padron.CodMunicipio = Municipios.CodMunicipio
			where Provincias.CodCA = CA2.CodCA
			order by Padron desc) as Municipio
from ComunidadesAutonomas as CA2;

use AudienciasTV;
--1.- Cadena con mayor audiencia (en la tabla Audiencia) el 15/5/2013 en el Periodo 'Noche1 (20.30 a 24.00)'
select top 1 Cadena
from Cadena
	inner join Audiencia
	on Audiencia.IdCadena = Cadena.idCadena
	inner join Periodo
	on Periodo.id = Audiencia.idPeriodo
where Fecha = '15/5/2013' and Periodo = 'Noche1 (20.30 a 24.00)'
group by Cadena
order by SUM(Valor) desc;
--2.- Programa de TELECINCO con m�s espectadores los jueves (en audienciaprograma)
select top 1 Programa
from Programa
	inner join AudienciaPrograma
	on AudienciaPrograma.IdPrograma = Programa.IdPrograma
	inner join Cadena
	on Cadena.idCadena = AudienciaPrograma.IdCadena
where Cadena = 'TELECINCO' and DATENAME(DW, FechaHora) = 'Jueves'
order by Espectadores desc;
--(*) 3.- �Cu�ntos programas tiene telecinco entre los cinco primeros del d�a 8/5/2013 
--teniendo en cuenta el share (en audienciaprograma)?
select COUNT(*) as nProgramas
from Cadena
	inner join (select top 5 Cadena.idCadena
				from Programa
					inner join AudienciaPrograma
					on AudienciaPrograma.IdPrograma = Programa.IdPrograma
					inner join Cadena
					on Cadena.idCadena = AudienciaPrograma.IdCadena
				where DAY(FechaHora) = 8
				order by Share desc) as subconsulta
	on Cadena.idCadena = subconsulta.idCadena
where Cadena = 'TELECINCO';
--4.- �Qu� d�a de la semana tiene m�s espectadores considerando los datos de AudienciaPrograma?
select top 1 DATENAME(DW, FechaHora) as DiaSemana
from AudienciaPrograma
group by DATENAME(DW, FechaHora)
order by SUM(Espectadores) desc;
--5.- Cinco programas con media m�s alta de espectadores (en audienciaprograma)que aparezcan dos o
--m�s veces.
select top 5 Programa
from AudienciaPrograma
	inner join Programa
	on Programa.IdPrograma = AudienciaPrograma.IdPrograma
group by Programa
having COUNT(Programa) > 2
order by AVG(Espectadores) desc;
--(*) 6.- Cu�l fue la audiencia (en la tabla audiencia) en el periodo que comienza por Noche2 de la 
--cadena con el programa m�s visto en n�mero de espectadores (de la tabla audienciaPrograma) el d�a 
--9/5/2013.
select Valor
from Periodo
	inner join Audiencia
	on Audiencia.idPeriodo = Periodo.Id
	inner join Cadena
	on Cadena.idCadena = Audiencia.IdCadena
where Periodo = 'Noche2 (24.00 a 02.30)' and Fecha = '9/5/2013' and Cadena = (select top 1 Cadena
																				from Programa
																					inner join AudienciaPrograma
																					on AudienciaPrograma.IdPrograma = Programa.IdPrograma
																					inner join Cadena
																					on Cadena.idCadena = AudienciaPrograma.IdCadena
																				where DAY(FechaHora) = 9 and MONTH(FechaHora) = 5 and YEAR(FechaHora) = 2013
																				order by Espectadores desc);
--7.- Total de espectadores acumulados seg�n la tabla audienciaprograma de cada Operador, dando 
--todos los operadores e incluyendo titularidad.
select Operador, Titularidad ,SUM(Espectadores) as TotalEspectadores
from Titularidad
	left join Operador
	on Operador.IdTitularidad = Titularidad.id
	left join Cadena
	on Cadena.idOperador = Operador.id
	left join AudienciaPrograma
	on AudienciaPrograma.IdCadena = Cadena.idCadena
group by Operador, Titularidad;
--(*) 8.- �En qu� periodo, cadena y fecha est� el valor m�ximo de audiencia (tabla audiencia), de una 
--cadena que tenga al menos tres programas en audienciaprograma en el mismo d�a.
select top 1 Periodo
from Periodo
	inner join Audiencia
	on Audiencia.idPeriodo = Periodo.Id
	inner join Cadena
	on Cadena.idCadena = Audiencia.IdCadena
where Cadena in (select distinct Cadena
				from Cadena
					inner join AudienciaPrograma
					on AudienciaPrograma.IdCadena = Cadena.idCadena
					inner join Programa
					on Programa.IdPrograma = AudienciaPrograma.IdPrograma
				group by Cadena, DAY(FechaHora)
				having COUNT(Programa) > 3)
group by Periodo
order by MAX(Valor) desc;
--9.- �En qu� hora (sin minutos) hay mayor media de espectadores seg�n audienciaprograma?
select top 1 DATEPART(HOUR, FechaHora) as hEspectadores
from AudienciaPrograma
group by DATEPART(HOUR, FechaHora)
order by AVG(Espectadores) desc;
--(*) 10.- Para cada fecha indicar qué Empresa es la n� uno de audiencia en el periodo 'Total d�a' (tabla 
--audiencia).
select distinct Fecha, (select top 1 Operador
						from Operador
							inner join Cadena
							on Cadena.idOperador = Operador.id
							inner join Audiencia
							on Audiencia.IdCadena = Cadena.idCadena
							inner join Periodo
							on Periodo.Id = Audiencia.idPeriodo
						where Periodo = 'Total día' and A2.Fecha = Audiencia.Fecha
						order by Valor desc) as Empresa
from Audiencia as A2;
--11.- �Cu�ntos programas diferentes tiene cada empresa, d�ndolas todas, en AudienciaPrograma?
select Operador, COUNT(Programa) as Programas
from Programa
	inner join AudienciaPrograma
	on AudienciaPrograma.IdPrograma = Programa.IdPrograma
	inner join Cadena
	on Cadena.idCadena = AudienciaPrograma.IdCadena
	inner join Operador
	on Operador.id = Cadena.idOperador
group by Operador;
--12.- Para qu� d�a del mes hay m�s de 4 cadenas distintas en audienciaprograma
select DATEPART(DAY, FechaHora) as Dia
from AudienciaPrograma
	inner join Cadena
	on Cadena.idCadena = AudienciaPrograma.IdCadena
group by DAY(FechaHora)
having COUNT(distinct Cadena) > 4;

use Restaurante;
--1.- Contar cuántos platos se han servido por Tipo de Plato (la descripción 
--del Tipo de plato).
select COUNT(Plato) as nPlatos
from Plato
	inner join TipoPlato
	on TipoPlato.CodTipoPlato = Plato.CodTipoPlato
group by TipoPlato;
--2.- Contar las comidas servidas en las mesas, sacando todas las mesas.
select Mesa.CodMesa ,COUNT(Servido) as nComidaServida
from Mesa
	inner join Comida
	on Comida.CodMesa = Mesa.CodMesa
	inner join DetalleComida
	on DetalleComida.IdComida = Comida.IdComida
where Servido = 'S'
group by Mesa.CodMesa;
--3.- Dar la mesa y la fecha de la comida que más platos consumió del tipo 
--de plato carnes, sacándolas todas si hay más de una.
select top 1 Mesa.CodMesa, Fecha, COUNT(TipoPlato) as nPlatos
from TipoPlato
	inner join Plato
	on Plato.CodTipoPlato = TipoPlato.CodTipoPlato
	inner join DetalleComida
	on DetalleComida.CodPlato = Plato.CodPlato
	inner join Comida
	on Comida.IdComida = DetalleComida.IdComida
	inner join Mesa
	on Mesa.CodMesa = Comida.CodMesa
where TipoPlato = 'Carnes'
group by Mesa.CodMesa, Fecha
order by nPlatos desc;
--4.- Comidas pagadas (dando mesa y fecha) que han consumido algo de 
--bebidas.
select Mesa.CodMesa, Fecha, COUNT(Pagado) as nPlatos
from TipoPlato
	inner join Plato
	on Plato.CodTipoPlato = TipoPlato.CodTipoPlato
	inner join DetalleComida
	on DetalleComida.CodPlato = Plato.CodPlato
	inner join Comida
	on Comida.IdComida = DetalleComida.IdComida
	inner join Mesa
	on Mesa.CodMesa = Comida.CodMesa
where Agrupa = 'Bebida'
group by Mesa.CodMesa, Fecha
having COUNT(Agrupa) > 0
order by nPlatos desc;
--5.- Importe total de las comidas pagadas de las mesas que comienzan con A.
select SUM(PrecioPlato) as importeTotal
from Mesa
	inner join Comida
	on Comida.CodMesa = Mesa.CodMesa
	inner join DetalleComida
	on DetalleComida.IdComida = Comida.IdComida
where Pagado = 'S' and Mesa.CodMesa like 'A%';
--6.- Día de la semana con mayor facturación.
select top 1 DATENAME(DW, Fecha) as DiaSemana
from Comida
	inner join DetalleComida
	on DetalleComida.IdComida = Comida.IdComida
group by DATENAME(DW, Fecha)
order by SUM(PrecioPlato) desc;
--7.- Tipo de plato (dando la descripción del tipo de plato) que no sea bebida 
--y que menos veces se ha pedido.
select top 1 TipoPlato
from TipoPlato
	inner join Plato
	on Plato.CodTipoPlato = TipoPlato.CodTipoPlato
	inner join DetalleComida
	on DetalleComida.CodPlato = Plato.CodPlato
where Agrupa != 'Bebida'
group by TipoPlato
order by COUNT(Servido) asc;
--8.- Para cada plato, dando su nombre y sacándolos todos, indicar el nº de 
--comidas en las que ha aparecido.
select Plato, COUNT(Comida.IdComida) as nComidas
from Plato
	left join DetalleComida
	on DetalleComida.CodPlato = Plato.CodPlato
	left join Comida
	on Comida.IdComida = DetalleComida.IdComida
group by Plato;
--(*) 9.- Dar las comidas pendientes de pagar (dando mesa y fecha) con todos
--sus platos servidos. 
select distinct Mesa.CodMesa, Fecha
from Mesa
	inner join Comida
	on Comida.CodMesa = Mesa.CodMesa
	inner join DetalleComida
	on DetalleComida.IdComida = Comida.IdComida
	inner join Plato
	on Plato.CodPlato = DetalleComida.CodPlato
where Pagado = 'N' and Plato in (select Plato
								from Plato 
									inner join DetalleComida
									on DetalleComida.CodPlato = Plato.CodPlato
								where Servido = 'N')
--(*) 10.- Comidas (dando mesa y fecha) que sólo han consumido bebidas.
select distinct Mesa.CodMesa, Fecha
from TipoPlato
	inner join Plato
	on Plato.CodTipoPlato = TipoPlato.CodTipoPlato
	inner join DetalleComida
	on DetalleComida.CodPlato = Plato.CodPlato
	inner join Comida
	on Comida.IdComida = DetalleComida.IdComida
	inner join Mesa
	on Mesa.CodMesa = Comida.CodMesa
where Comida.IdComida in (select Comida.IdComida
							from Comida
								inner join DetalleComida
								on DetalleComida.IdComida = Comida.IdComida
								inner join Plato
								on Plato.CodPlato = DetalleComida.CodPlato
								inner join TipoPlato
								on TipoPlato.CodTipoPlato = Plato.CodTipoPlato
							where Agrupa = 'Bebida')
--11.- Calcular el plato con mayor diferencia entre lo que se cobró y el precio
--actual (de la tabla Plato).
select top 1 Plato
from Plato
	inner join DetalleComida
	on DetalleComida.CodPlato = Plato.CodPlato
group by Plato
order by SUM(PrecioPlato - Precio) desc;
--12.- Sacar la estadística por días, incluyendo nº platos (incluyendo 
--bebidas), el nº de comidas realizadas y el importe de los platos (incluyendo 
--bebidas)
select DATEPART(DAY, Fecha), COUNT(Plato) as nPlatos, COUNT(Comida.IdComida) as nComidas, SUM(PrecioPlato) as importe
from TipoPlato
	inner join Plato
	on Plato.CodTipoPlato = TipoPlato.CodTipoPlato
	inner join DetalleComida
	on DetalleComida.CodPlato = Plato.CodPlato
	inner join Comida
	on Comida.IdComida = DetalleComida.IdComida
group by DATEPART(DAY, Fecha);

use Restaurante;
--1. Dar el plato más caro de cada comida.
select C2.IdComida, (select top 1 Plato
					from Plato
						inner join DetalleComida
						on DetalleComida.CodPlato = Plato.CodPlato
					where DetalleComida.IdComida = C2.IdComida
					order by Precio desc)
from Comida as C2
--2. Para cada comida dar el número de platos servidos y el número de platos no servidos.
select C2.IdComida, (select COUNT(Plato)
					from Plato
						inner join DetalleComida
						on DetalleComida.CodPlato = Plato.CodPlato
					where Servido = 'S' and DetalleComida.IdComida = C2.IdComida),
					(select COUNT(Plato)
					from Plato
						inner join DetalleComida
						on DetalleComida.CodPlato = Plato.CodPlato
					where Servido = 'N' and DetalleComida.IdComida = C2.IdComida)
from Comida as C2
--3. Dar el plato más caro de cada tipo de plato.
select TipoPlato,   (select top 1 Plato
					from Plato
					where Plato.CodTipoPlato = T2.CodTipoPlato
					order by Precio desc)
from TipoPlato as T2
--4. Dar el plato más caro del tipo de plato con más platos que no sean bebidas.
select top 1 with ties TipoPlato, (select top 1 Plato
								   from Plato 
								   where Plato.CodTipoPlato = T2.CodTipoPlato
								   order by Precio desc)
from TipoPlato as T2
	inner join Plato
	on t2.CodTipoPlato = Plato.CodTipoPlato
where Agrupa != 'Bebida'
group by TipoPlato, t2.CodTipoPlato
order by COUNT(Plato) desc;
--5. Dar los platos servidos de la comida más barata.
select distinct Plato
from Plato
	inner join DetalleComida 
	on DetalleComida.CodPlato = Plato.CodPlato
	inner join Comida 
	on Comida.IdComida = DetalleComida.IdComida
	inner join (select top 1 Comida.IdComida
				FROM Comida
					inner join DetalleComida 
					ON DetalleComida.IdComida = Comida.IdComida
				group by Comida.IdComida
				order by SUM(PrecioPlato) asc
) as ComidaBarata on ComidaBarata.IdComida = Comida.IdComida
where Servido = 'S';
--6. Dar los tipos de platos servidos de la comida más cara.
select distinct TipoPlato
from TipoPlato
	inner join Plato
	on Plato.CodTipoPlato = TipoPlato.CodTipoPlato
	inner join DetalleComida
	on DetalleComida.CodPlato = Plato.CodPlato
	
	inner join (select top 1 Comida.IdComida
				FROM Comida
					inner join DetalleComida 
					on DetalleComida.IdComida = Comida.IdComida
				group by Comida.IdComida
				order by SUM(PrecioPlato) desc
) as ComidaCara on ComidaCara.IdComida = DetalleComida.IdComida
where Servido = 'S';
--7. Dar las comidas pendientes de pagar (dando mesa y fecha) con todos sus platos servidos.
select Comida.IdComida, Mesa.CodMesa, Fecha, (select COUNT(*)
												from Plato
													inner join DetalleComida
													on DetalleComida.CodPlato = Plato.CodPlato
												where Servido = 'S' and DetalleComida.IdComida = Comida.IdComida)
												as PlatosServidos
from Mesa
	inner join Comida
	on Comida.CodMesa = Mesa.CodMesa
where Pagado = 'N';
--8. Comidas (dando mesa y fecha) que sólo han consumido bebidas
select Mesa.CodMesa, Comida.Fecha
from Mesa
	inner join Comida 
	on Comida.CodMesa = Mesa.CodMesa
where Comida.IdComida in (select Comida.IdComida
							from Comida
								inner join DetalleComida 
								on DetalleComida.IdComida = Comida.IdComida
								inner join Plato 
								on Plato.CodPlato = DetalleComida.CodPlato
								inner join TipoPlato 
								on TipoPlato.CodTipoPlato = Plato.CodTipoPlato
							where Agrupa = 'Bebida');
--9. Mostrar los platos de las Comidas que han servido más de 5 bebidas.
select distinct Plato
from Plato
	inner join DetalleComida
	on DetalleComida.CodPlato = Plato.CodPlato
	inner join Comida
	on Comida.IdComida = DetalleComida.IdComida
where Comida.IdComida in (select Comida.IdComida
							from Comida
								inner join DetalleComida
								on DetalleComida.IdComida = Comida.IdComida
								inner join Plato
								on Plato.CodPlato = DetalleComida.CodPlato
								inner join TipoPlato
								on TipoPlato.CodTipoPlato = Plato.CodTipoPlato
							where Agrupa = 'Bebida' and Servido = 'S'
							group by Comida.IdComida
							having COUNT(Agrupa) > 5)
--10. Comidas (dando mesa y fecha) que han servido más bebidas que platos.
select Mesa.CodMesa, Comida.Fecha
from Mesa
	inner join Comida 
	on Comida.CodMesa = Mesa.CodMesa
where (select COUNT(Agrupa)
		from TipoPlato
			inner join Plato
			on Plato.CodTipoPlato = TipoPlato.CodTipoPlato
			inner join DetalleComida
			on DetalleComida.CodPlato = Plato.CodPlato
		where Agrupa = 'Bebida' and Servido = 'S' and DetalleComida.IdComida = Comida.IdComida) >
		(select COUNT(Agrupa)
		from TipoPlato
			inner join Plato
			on Plato.CodTipoPlato = TipoPlato.CodTipoPlato
			inner join DetalleComida
			on DetalleComida.CodPlato = Plato.CodPlato
		where Agrupa = 'Plato' and Servido = 'S' and DetalleComida.IdComida = Comida.IdComida)