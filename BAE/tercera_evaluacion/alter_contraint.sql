--2.- Crear las Foreign Key correspondientes al esquema siguiente:
alter table ALQ_Alquiler
add constraint FK_ALQ_Alquiler
foreign key (DNICliente)
references ALQ_Cliente (DNICliente);
go

alter table ALQ_Alquiler
add constraint FK_ALQ_Alquiler2
foreign key (Matricula)
references ALQ_Coche (Matricula);
go

alter table ALQ_Coche
add constraint FK_ALQ_Coche
foreign key (codTipo)
references ALQ_tipoCoche (CodTipo);
go
--7.- Ver la informaci�n de las restricciones activas en la tabla alq_alquiler
sp_helpconstraint ALQ_Alquiler;
go
--9.- Deshabilitar la FK de alquiler relacionada con coche.
alter table ALQ_Alquiler
nocheck constraint FK_ALQ_Alquiler2;
go
--11.- Habilitar la restricci�n.
alter table ALQ_Alquiler
check constraint FK_ALQ_Alquiler2;
go
--13.- Borrar la restricci�n.
alter table ALQ_Alquiler
drop constraint FK_ALQ_Alquiler2;
go
--15.- �C�mo podemos hacer para crear de nuevo la restricci�n? Borrar al final los datos descuadrados
alter table ALQ_Alquiler
with nocheck
add constraint FK_ALQ_Alquiler2
foreign key (Matricula)
references ALQ_Coche (Matricula);
go

alter table ALQ_Alquiler
check constraint FK_ALQ_Alquiler2;
go
--16.- Crear la restricci�n activando borrados y actualizaciones en cascada.
alter table ALQ_Alquiler
drop constraint FK_ALQ_Alquiler2;
go

alter table ALQ_Alquiler
with nocheck
add constraint FK_ALQ_Alquiler2
foreign key (Matricula)
references ALQ_Coche (Matricula)
on update cascade
on delete cascade;
go
--19.- C�mo modificar�amos la creaci�n de las tablas para colocarle las foreign key y evitar que puedan colocarse valores null en los campos correspondientes a las mismas. Crear de nuevo la BD con ese cambio.
create table ALQ_tipoCoche
(CodTipo integer primary key not null,
 DescripcionTipo varchar(100),
 PrecioDia numeric(10,2));

create table ALQ_Coche
(Matricula  varchar(10) primary key,
 DescripcionEstado  varchar(100),
 codTipo integer not null,
 CONSTRAINT fk_coche_tipocoche
 FOREIGN KEY (codTipo)
 REFERENCES ALQ_tipoCoche (CodTipo)
 ON DELETE CASCADE
 ON UPDATE CASCADE
);

create table ALQ_Cliente
(DNICliente varchar(9) primary key not null,
 Apellidos varchar(50),
 Nombre varchar(100),
 DatosCliente varchar(100),
 FechaNacimiento datetime,
 FechaCarnet datetime
);

Create table ALQ_Alquiler
(DNICliente varchar(9) not null,
 Matricula varchar(10) not null,
 FechaInicio datetime not null,
 FechaFinal datetime,
 PrecioDiaEfectuado numeric(10,2),
 primary key (DNICliente, Matricula,FechaInicio),
 CONSTRAINT fk_alquiler_cliente
 FOREIGN KEY (DNICliente)
 REFERENCES ALQ_Cliente (DNICliente)
 ON DELETE CASCADE
 ON UPDATE CASCADE,
 CONSTRAINT fk_alquiler_coche
 FOREIGN KEY (Matricula)
 REFERENCES ALQ_Coche (Matricula)
 ON DELETE CASCADE
 ON UPDATE CASCADE
);