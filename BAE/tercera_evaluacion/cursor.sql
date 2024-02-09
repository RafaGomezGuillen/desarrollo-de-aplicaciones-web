-- Todos:
-- Rojo, Amarillo, Verde, Azul
IF object_id('valores_concatenados') IS NOT NULL 
	drop procedure valores_concatenados;
go
create procedure valores_concatenados
as
begin
    declare @nombre varchar(10)
	declare @sentencia varchar(1000) = '';
    declare cur cursor for
        select Nombre from Colores
    open cur
    fetch next from cur into @nombre
    while @@FETCH_STATUS = 0
    begin
		set @sentencia += @nombre + ', ';
        fetch next from cur into @nombre
    end
    close cur;
    deallocate cur;
	select @sentencia as Todos;
end
go
exec valores_concatenados;
go


--Donde se almacenan en ventas, las ventas realizadas por un vendedor (cod), en un mes determinado (mes) y con un importe (importe).

--Se pide realizar un procedimiento almacenado que contenga un cursor y que muestre las ventas acumuladas de un determinado vendedor, algo parecido a lo que se muestra a continuación: (en este caso para el vendedor de cod = 2)
IF object_id('ventas_acumuludas') IS NOT NULL 
	drop procedure ventas_acumuludas;
go
create procedure ventas_acumuludas
	@venderdor char(5)
as
begin
    declare @mes char(2)
	declare @importe decimal(8,2)
	declare @cod char(5)
	declare @nombre_mes varchar(10)
	declare @suma decimal(8,2) = 0;
    declare cur cursor for
		select Ventas.cod, mes, importe, nombre from Ventas inner join meses on meses.cod = Ventas.mes	
    open cur
    fetch next from cur into @cod, @mes, @importe, @nombre_mes
    while @@FETCH_STATUS = 0
    begin
		if @cod = @venderdor
			begin
				set @suma += @importe;
				print @nombre_mes + ' Importe ' + cast(@importe as varchar(100)) + ' Acumulado ' 
				+ cast(@suma as varchar(100))
			end
        fetch next from cur into @cod, @mes, @importe, @nombre_mes
    end
    close cur;
    deallocate cur;
end
go
exec ventas_acumuludas '00001';
go
exec ventas_acumuludas '00002';
go