use ANIMABD
go


-- Inserts para la tabla TIPO_CLIENTE
INSERT INTO TIPO_CLIENTE (NOM_TIPOCLI) VALUES 
('PERSONA NATURAL'),
('EMPRESA')
go

INSERT INTO ESPECIALIDAD (NOM_ESPECIALIDAD) VALUES
('MASCOTAS'),('ANIMALES EXOTICOS')
GO


-- Inserts para la tabla CLIENTE
INSERT INTO CLIENTE (COD_CLIENTE, NOMBRES_COMPLETOS, DNIRUC, DIRECCION, CORREO, TIPOCLI, ELIMINADO)
VALUES 
('CLI00001', 'Juan Pérez', '12345678901', 'Calle 123', 'juan@email.com', 1,'No'),
('CLI00002', 'Empresa XYZ', '98765432109', 'Av. Principal', 'info@empresa.com', 2,'No'),
('CLI00003', 'Ana Rodríguez', '45678901234', 'Avenida Central', 'ana@email.com', 1,'No'),
('CLI00004', 'Compañía ABC', '56789012345', 'Calle Secundaria', 'info@compania.com', 2,'No'),
('CLI00005', 'Carlos Gómez', '34567890123', 'Calle 456', 'carlos@email.com', 1,'No'),
('CLI00006', 'Empresa DEF', '89012345678', 'Carrera Principal', 'info@empresa-def.com', 2,'No'),
('CLI00007', 'Luisa Martínez', '67890123456', 'Avenida Secundaria', 'luisa@email.com', 1,'No'),
('CLI00008', 'Otra Empresa', '01234567890', 'Carrera 789', 'otra@empresa.com', 2,'No'),
('CLI00009', 'Pedro Sánchez', '23456789012', 'Calle Principal', 'pedro@email.com', 1,'No'),
('CLI00010', 'Empresa GHI', '90123456789', 'Calle 789', 'info@empresa-ghi.com', 2,'No')
GO

select * from CLIENTE
go

select * from TIPO_CLIENTE
go



-- Insertar animales
INSERT INTO ANIMALES (NOM_ANIMAL) VALUES ('Perro'),('Gato')
GO
-- Puedes agregar más animales según sea necesario

-- Insertar tipos de producto
INSERT INTO TIPO_PRODUCTO (NOM_TIPO) VALUES ('Comida Balanceada'),('Vitaminas')
GO
-- Puedes agregar más tipos según sea necesario

-- Insertar productos
INSERT INTO PRODUCTOS (CODIGO, DESCRIPCION,PRECIO, STOCK, ANIMAL, TIPOCOMI,ELIMINADO)
VALUES ('PR00001', 'Comida Premium para Perros',25, 100, 1, 1, 'No'),
	   ('PR00002', 'Vitaminas para Gatos',50, 50, 2, 2, 'No')
GO
-- Puedes agregar más productos según sea necesario

INSERT INTO TIPO_VENTA(NOMBRE_TVEN) VALUES('Factura'),('Boleta')
GO

-- Agregar columna 'FOTO' a la tabla 'PRODUCTOS'
/*ALTER TABLE PRODUCTOS
ADD FOTOPRO varchar(255);*/

-- Modificar la columna 'FOTO' para ser nula
/*ALTER TABLE PRODUCTOS
ALTER COLUMN fotopro varchar(255) NULL;*/


select *from dbo.ANIMALES
go

SELECT * FROM CLIENTE
GO
SELECT * FROM EMPLEADOS
GO
SELECT * FROM CONSULTORES
GO
select * from PRODUCTOS
go

select * from dbo.TIPO_PRODUCTO

delete from PRODUCTOS where codigo = 'PR00003'
go


