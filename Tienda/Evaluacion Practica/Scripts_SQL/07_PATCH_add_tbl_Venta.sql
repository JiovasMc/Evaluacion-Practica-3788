use dbTienda

if OBJECT_ID(N'Tienda.detalle_venta', 'U')is not NULL begin
	drop table Tienda.detalle_venta
end

if OBJECT_ID(N'Tienda.detalle_venta', 'U')is NULL begin
	create table Tienda.detalle_venta(
	 venta_id int not null FOREIGN KEY REFERENCES Tienda.venta([venta_id]),
	 producto_id int not null FOREIGN KEY REFERENCES Tienda.producto([producto_id]),
	 cantidad int not null,
	 descuento decimal(12, 4) not null,
	 total decimal(12, 4) not null
	)

	SELECT * FROM Tienda.detalle_venta
end 
