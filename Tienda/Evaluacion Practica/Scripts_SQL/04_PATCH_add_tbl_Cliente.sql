use dbTienda

if OBJECT_ID(N'Tienda.cliente', 'U')is not NULL begin
	drop table Tienda.cliente
end

if OBJECT_ID(N'Tienda.cliente', 'U')is NULL begin
	create table Tienda.cliente(
	 cliente_id int identity(1,1) primary key not null,
	 nombre varchar(500) not null,
	 clave varchar(10) not null,
	 mail varchar(1000) not null,
	 estatus varchar(30) not null FOREIGN KEY REFERENCES Tienda.catalogs([catalogo_id])
	)
end 

if OBJECT_ID(N'Tienda.cliente', 'U') is not NULL begin
declare @i int = 1
    
	while @i <=10 begin
		insert into Tienda.cliente
		values('CLIENTE ' + CONVERT(varchar, @i) , 'CLIE' + CONVERT(varchar, @i), 'cliente' + CONVERT(varchar, @i) + '@clie.com', 'TT:01:01')
		set @i = @i + 1
	end
	 UPDATE Tienda.cliente SET ESTATUS = 'TT:01:02' WHERE CLIENTE_ID IN (3,7,10);
	select * from Tienda.cliente
end

--select * from Tienda.cliente