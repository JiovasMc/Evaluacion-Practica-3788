use dbTienda

if OBJECT_ID(N'Tienda.venta', 'U')is not NULL begin
	drop table Tienda.venta
end

if OBJECT_ID(N'Tienda.venta', 'U')is NULL begin
	create table Tienda.venta(
	 venta_id int identity(1,1) primary key not null,
	 fecha datetime not null,
	 cliente_id INT not null FOREIGN KEY REFERENCES Tienda.cliente([cliente_id]),
	 estatus varchar(30) not null FOREIGN KEY REFERENCES Tienda.catalogs([catalogo_id])
	)

	SELECT * FROM Tienda.venta
end 
