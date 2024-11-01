use dbTienda
go

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Tienda.getDetalleCompra(
	@venta_id int
)
as

Begin TRY

select p.descripcion, v.cantidad, p.costo_unitario, v.total, p.producto_id 
from Tienda.detalle_venta v
inner join Tienda.producto p on p.producto_id = v.producto_id 
where venta_id = @venta_id 

END TRY
BEGIN CATCH
 Select 'error al general la consulta'
 END CATCH;
GO