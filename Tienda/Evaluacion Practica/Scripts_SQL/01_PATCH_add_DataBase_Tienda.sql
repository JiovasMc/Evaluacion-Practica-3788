
IF not EXISTS(SELECT * FROM DBO.SYSDATABASES WHERE NAME = 'dbTienda') 
BEGIN
	CREATE DATABASE dbTienda;
end

