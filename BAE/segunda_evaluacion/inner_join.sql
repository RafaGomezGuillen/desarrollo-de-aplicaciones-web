-- INNER JOIN
use Discos;
--1.- Cuáles son los dos clientes con más puntuaciones efectuadas (sacándolos todos).
select top 2 with ties Nombre,count(Puntuacion)
from Cliente
	inner join Puntuacion
	on Puntuacion.Idcliente = Cliente.id
group by Nombre
order by count(Puntuacion) desc;
--2.- Media de la puntuación de discos de los intérpretes que comiencen con A y efectuada en sábado
select AVG(Puntuacion.Puntuacion) as MediaPuntuacion, Disco.Titulo
from Disco
	inner join Puntuacion
	on Disco.IdDisco = Puntuacion.iddisco
	inner join Interprete
	on Interprete.IdInterprete = Disco.IdInterprete
where Interprete.Interprete like 'A%' and DATENAME(DW, Fecha) = 'Sábado'
group by Disco.Titulo;
--3.- Clientes (dando su nombre) nacidos antes de 1975 que hayan puntuado a los tipos que contengan 'rock'
select distinct Cliente.Nombre
from Cliente
	inner join Puntuacion
	on Cliente.id = Puntuacion.Idcliente
	inner join Disco
	on Puntuacion.iddisco = Disco.IdDisco
	inner join DiscoTipo
	on DiscoTipo.IdDisco = Disco.IdDisco
	inner join Tipo
	on DiscoTipo.IdTipo = Tipo.IdTipo
where DATEPART(YEAR, Cliente.FechaNacimiento) < 1975 and Tipo.tipo like '%rock%';
--4.- Disco (dando su título) con mayor media de puntuacion que haya sido votado dos o más veces
select top 1 with ties Disco.Titulo, COUNT(Puntuacion) as NumPuntuacion, AVG(Puntuacion) as MediaPuntuacion
from Disco
	inner join Puntuacion
	on Puntuacion.iddisco = Disco.IdDisco
group by Disco.Titulo
having COUNT(Puntuacion) >= 2
order by AVG(Puntuacion) desc;
--5.- Intérprete que más veces haya sido puntuado
select top 1 Interprete, COUNT(Puntuacion) as NumPuntuacion
from Interprete
	inner join Disco
	on Interprete.IdInterprete = Disco.IdInterprete
	inner join Puntuacion
	on Puntuacion.iddisco = Disco.IdDisco
group by Interprete
order by COUNT(Puntuacion) desc;
--6.- Dos intérpretes con más discos
select top 2 with ties Interprete, COUNT(Disco.Titulo) as NumTituloDisco
from Interprete
	inner join Disco
	on Disco.IdInterprete = Interprete.IdInterprete
group by Interprete
order by COUNT(Disco.Titulo) desc;
--7 títulos de los discos que hayan recibido alguna puntuación y el nombre del intérprete 
select Disco.Titulo, Interprete.Interprete
from Interprete
	inner join Disco
	on Disco.IdInterprete = Interprete.IdInterprete
	inner join Puntuacion
	on Puntuacion.iddisco = Disco.IdDisco
group by Disco.Titulo, Interprete.Interprete;
-- SEGUNDA PARTE
--8 Cuál es el disco (dando el título) que tiene más tipos
select top 1 Disco.Titulo, COUNT(tipo) as NumTipo
from Disco
	inner join DiscoTipo
	on Disco.IdDisco = DiscoTipo.IdDisco
	inner join Tipo
	on Tipo.IdTipo = DiscoTipo.IdTipo
group by Disco.Titulo
order by COUNT(tipo) desc;
--9 Media de la puntuación de discos de los interpretes que contengan 'Jackson'
select Disco.Titulo, AVG(Puntuacion.Puntuacion) as MediaPuntuacion
from Interprete
	inner join Disco
	on Interprete.IdInterprete = Disco.IdInterprete
	inner join Puntuacion
	on Puntuacion.iddisco = Disco.IdDisco
where Interprete.Interprete like '%Jackson%'
group by Disco.Titulo;
--10 Disco (dando su título) con mayor media de puntuacion que haya sido votado dos o más veces
select top 1 Disco.Titulo 
from Disco
	inner join Puntuacion
	on Disco.IdDisco = Puntuacion.iddisco
group by Disco.Titulo
having COUNT(Puntuacion) > 2
order by AVG(Puntuacion) desc;
--11 Número de votos realizados por cada cliente (dando su nombre) incluyéndolos todos los clientes. Ordenar por el nº de votos de mayor a menor
select Cliente.Nombre, COUNT(Puntuacion.Puntuacion) as NumVotos
from Cliente
	inner join Puntuacion
	on Puntuacion.Idcliente = Cliente.id
group by Cliente.Nombre
order by COUNT(Puntuacion.Puntuacion) desc;
--12 Tipo (dando su denominación) con más discos
select top 1 Tipo.tipo, COUNT(Disco.Titulo) as NumDiscos
from Disco
	inner join DiscoTipo
	on DiscoTipo.IdDisco = Disco.IdDisco
	inner join Tipo
	on Tipo.IdTipo = DiscoTipo.IdTipo 
group by tipo.tipo
order by NumDiscos desc;
--13 Cuántos discos tiene cada intérprete (por su nombre) dando todos los intérpretes, ordenado por nº de discos de mayor a menor
select Interprete.Interprete, COUNT(Disco.Titulo) as NumDiscos
from Disco
	inner join Interprete
	on Interprete.IdInterprete = Disco.IdInterprete
group by Interprete.Interprete
order by NumDiscos desc;


use EmpresasInformaticas;
--1.- Artículo que más unidades en total se ha vendido sin considerar los de tipos que contengan
--'ALMACENAMIENTO' ni los de 'VARIOS'
select top 1 Componente.clave, Cantidad
from TipoComponente
	inner join Componente
	on Componente.CodTipo = TipoComponente.CodTipo
	inner join FacturaComponente
	on FacturaComponente.CodComponente = Componente.clave
where TipoComponente.Tipo != 'VARIOS' and TipoComponente.Tipo not like '%ALMACENAMIENTO%'
order by Cantidad desc;
--2.- Tienda con mayores ventas en importe
select top 1 Tienda.NombreTienda, SUM(FacturaComponente.PrecioAplicado) as Ventas
from Tienda
	inner join Factura
	on Factura.idTienda = Tienda.IdTienda
	inner join FacturaComponente
	on FacturaComponente.NFactura = Factura.NFactura
group by Tienda.NombreTienda
order by Ventas desc;
--3.- Tienda con mayor número de facturas realizadas (sacar todas las que coincidan)
select top 1 with ties Tienda.NombreTienda, COUNT(Factura.NFactura) as NumFacturas
from Tienda
	inner join Factura
	on Factura.idTienda = Tienda.IdTienda
group by Tienda.NombreTienda
order by NumFacturas desc;
--4.- Artículos vendidos, dando su nombre, indicando el nº de veces que referencia esté a NULL
select Componente.clave, COUNT(Componente.clave) as nVeces
from Componente
	inner join FacturaComponente
	on FacturaComponente.CodComponente = Componente.clave
where Referencia is null
group by Componente.clave;
--5.- Importe de las facturas de las tiendas de Localidad 'La Laguna'
select SUM(PrecioAplicado) as Importe
from Tienda
	inner join Factura
	on Factura.idTienda = Tienda.IdTienda
	inner join FacturaComponente
	on FacturaComponente.NFactura = Factura.NFactura
where Tienda.Localidad = 'La Laguna';
--6.- Nº de componentes vendidos por tipo de los tipos que contengan 'impresora'
select COUNT(Componente.clave) as nComponente
from Componente
	inner join TipoComponente
	on TipoComponente.CodTipo = Componente.CodTipo
where TipoComponente.Tipo like '%impresora%'
group by Tipo;
--7.- Nº de la Factura con más unidades vendidas (sacando todas las coincidentes) de las tiendas que
--contengan 'CRUZ' en la localidad.
select top 1 with ties FacturaComponente.NFactura, COUNT(FacturaComponente.Cantidad) as nCantidad
from Tienda
	inner join Factura
	on Factura.idTienda = Tienda.IdTienda
	inner join FacturaComponente
	on FacturaComponente.NFactura = Factura.NFactura
where Tienda.Localidad like '%CRUZ%'
group by FacturaComponente.NFactura
order by nCantidad desc;
--8.- Importe por Tipo de Componente, dando el nombre del tipo de componente y sacándolos todos.
select TipoComponente.Tipo, SUM(FacturaComponente.PrecioAplicado) as Importe
from TipoComponente
	inner join Componente
	on Componente.CodTipo = TipoComponente.CodTipo
	inner join FacturaComponente
	on FacturaComponente.CodComponente = Componente.clave
group by TipoComponente.Tipo;
--9.-Total de ventas (en importe) del mes de mayo
select SUM(FacturaComponente.PrecioAplicado) as Importe
from Factura
	inner join FacturaComponente
	on FacturaComponente.NFactura = Factura.NFactura
where MONTH(Fecha) = 5;
--10.- Tienda con la factura en la que se vendieron más artículos.
select top 1 NombreTienda
from Tienda
	inner join Factura
	on Factura.idTienda = Tienda.IdTienda
	inner join FacturaComponente
	on FacturaComponente.NFactura = Factura.NFactura
group by NombreTienda
order by COUNT(FacturaComponente.NFactura) desc; 
--11.- Tipos de componente no vendidos
select Tipo
from TipoComponente
	inner join Componente
	on Componente.CodTipo = TipoComponente.CodTipo
	inner join FacturaComponente
	on FacturaComponente.CodComponente = Componente.clave
where Referencia is null
group by Tipo;
--12.- Especificar las facturas con más de 2 artículos, indicando el nombre de la tienda.select NombreTienda, COUNT(Componente.clave) as nArticulosfrom Tienda	inner join Factura	on Factura.idTienda = Tienda.IdTienda	inner join FacturaComponente	on FacturaComponente.NFactura = Factura.NFactura	inner join Componente	on Componente.clave = FacturaComponente.CodComponentegroup by FacturaComponente.NFactura, NombreTiendahaving COUNT(Componente.clave) > 2order by FacturaComponente.NFactura desc;