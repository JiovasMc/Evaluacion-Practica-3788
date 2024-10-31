use dbTienda

if OBJECT_ID(N'Tienda.producto', 'U')is not NULL begin
	drop table Tienda.producto
end

if OBJECT_ID(N'Tienda.producto', 'U')is NULL begin
	create table Tienda.producto(
	 producto_id int identity(1,1) primary key not null,
	 descripcion varchar(500) not null,
	 costo_unitario decimal(12,4) not null,
	 estatus varchar(30) not null FOREIGN KEY REFERENCES Tienda.catalogs([catalogo_id])
	)
end 

if OBJECT_ID(N'Tienda.producto', 'U') is not NULL begin
declare @i int = 1
    
	while @i <=15 begin
		insert into Tienda.producto
		values('PRODUCTO ' + CONVERT(varchar, @i) , (SELECT ROUND(((9999 - 1) * RAND() + 1), 2)) , 'TT:02:01')
		set @i = @i + 1
	end
	 UPDATE Tienda.producto SET ESTATUS = 'TT:02:02' WHERE producto_id IN (5,11,13);
	select * from Tienda.producto
end




