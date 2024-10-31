use dbTienda

if OBJECT_ID(N'Tienda.catalogs', 'U') is not NULL begin
	drop table Tienda.catalogs
end

if OBJECT_ID(N'Tienda.catalogs', 'U')is NULL begin
	create table Tienda.catalogs(
	 [catalogo_id] varchar(30) primary key not null,
	 [descripcion] varchar(500) not null,
	 [isvisible] int not null,

	)
end 


if OBJECT_ID(N'Tienda.catalogs', 'U') is not NULL begin
insert into Tienda.catalogs values('TT:01', 'Estatus Cliente', 1)
	insert into Tienda.catalogs values('TT:01:01', 'ACTIVO', 1)
	insert into Tienda.catalogs values('TT:01:02', 'INACTIVO', 1)
	insert into Tienda.catalogs values('TT:02', 'Estatus Producto', 1)
	insert into Tienda.catalogs values('TT:02:01', 'ACTIVO', 1)
	insert into Tienda.catalogs values('TT:02:02', 'INACTIVO', 1)
	insert into Tienda.catalogs values('TT:03', 'Estatus Venta', 1)
	insert into Tienda.catalogs values('TT:03:01', 'PAGADA', 1)
	insert into Tienda.catalogs values('TT:03:02', 'PENDIENTE', 1)
end