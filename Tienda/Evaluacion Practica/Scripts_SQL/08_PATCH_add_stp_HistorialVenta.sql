use dbTienda
go

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Tienda.historailVentas(
	@nombre int,
	@clave int,
	@estatus varchar(500)
)
as

Begin TRY

select c.clave, c.nombre, c.mail, format(v.fecha, 'dd/MM/yyyy') [Fecha],  dv.Total, v.venta_id 
from (select venta_id, sum(total) [Total]
		from Tienda.detalle_venta group by venta_id ) dv
inner join Tienda.venta v on v.venta_id = dv.venta_id 
inner join Tienda.cliente c on c.cliente_id = v.cliente_id 
inner join Tienda.catalogs ct on c.estatus = ct.catalogo_id 
where @nombre in (0, c.cliente_id) and @clave in (0, c.cliente_id) and  @estatus in ('0', ct.catalogo_id)

END TRY
BEGIN CATCH
 Select 'error al general la consulta'
 END CATCH;
GO