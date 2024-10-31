if EXISTS(SELECT * FROM DBO.SYSDATABASES WHERE NAME = 'dbTienda') begin
	USE [dbTienda]
	IF NOT EXISTS (SELECT * FROM sys.schemas where name = 'Tienda')
	begin
	   EXEC ('CREATE SCHEMA [Tienda] AUTHORIZATION [dbo]')
	end          
end