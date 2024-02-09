--4- Cree un disparador para que se ejecute cada vez que una instrucci�n "insert" ingrese datos en "empleados"; 
--el mismo debe verificar que el sueldo del empleado no sea mayor al sueldo m�ximo establecido para la secci�n, 
--si lo es, debe mostrar un mensaje indicando tal situaci�n y deshacer la transacci�n.
if object_id('DIS_verificar_sueldo') is not null
	drop trigger DIS_verificar_sueldo;
go
create trigger DIS_verificar_sueldo
	on empleados
	for insert
	as
		declare @maxSueldo decimal(8,2)
		select @maxSueldo = sueldomaximo from secciones 
										inner join inserted 
										on inserted.codigoseccion = secciones.codigo;
		if (@maxSueldo >= (select sueldo from inserted))
			begin
				select 'Transacci�n realizada';
				select * from inserted;
			end
		else
			begin
				raiserror ('El sueldo introducido debe ser menor al m�ximo', 16, 1)
				rollback transaction
			end
go
--4- Cree un disparador para controlar que no se elimine un art�culo si hay stock. 
--El disparador se  activar� cada vez que se ejecuta un "delete" sobre "articulos", 
--controlando el stock, si se est�  eliminando un art�culo cuyo stock sea mayor a 0, 
--el disparador debe retornar un mensaje de error y  deshacer la transacci�n.
if object_id('DIS_controlar_stock') is not null
	drop trigger DIS_controlar_stock;
go
create trigger DIS_controlar_stock
	on articulos
	for delete
	as
		declare @stock int
		select @stock = stock from articulos;
		if (@stock = (select stock from deleted where stock = 0))
			begin
				select 'Transacci�n realizada';
				select * from deleted;
			end
		else
			begin
				raiserror ('No puedes eleminar un articulo que tenga stock', 16, 1)
				rollback transaction
			end
go
--9- Cree un trigger para evitar que se elimine m�s de 1 art�culo. 
--Note que hay 2 disparadores para el mismo suceso (delete) sobre la misma tabla.
if object_id('DIS_controlar_stock2') is not null
	drop trigger DIS_controlar_stock2;
go
create trigger DIS_controlar_stock2
	on articulos
	for delete
	as
		declare @veces int;
		select @veces = COUNT(*) from deleted;
		if (@veces < 2)
			begin
				select 'Transacci�n realizada';
				select * from deleted;
			end
		else
			begin
				raiserror ('No puedes eliminar m�s de un articulo.', 16, 1)
				rollback transaction
			end
go

select * from articulos;
delete from articulos where codigo > 4;
go

drop table articulos