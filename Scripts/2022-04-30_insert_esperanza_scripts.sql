-- Pruebas
INSERT INTO DocumentType (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'DNI');
INSERT INTO DocumentType (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'CI');

INSERT INTO Sex (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'FEMENINO');
INSERT INTO Sex (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'MASCULINO');

INSERT INTO Country (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'ARGENTINA');
INSERT INTO Country (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'CHILE');

INSERT INTO City (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name, CountryGuid)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'BUENOS AIRES', NEWID());
INSERT INTO City (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name, CountryGuid)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'MISIONES', NEWID());

INSERT INTO Neighborhood (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name, CityGuid)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'CABALLITO', NEWID());
INSERT INTO Neighborhood (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name, CityGuid)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'LANUS', NEWID());

INSERT INTO UserRole (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'ADMIN');
INSERT INTO UserRole (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'CLIENTE');

INSERT INTO Category (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'CAT1');
INSERT INTO Category (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'CAT2');

INSERT INTO Kind (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'PERRO');
INSERT INTO Kind (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'GATO');

INSERT INTO Line (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'PERRIN');
INSERT INTO Line (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'GATIN');

INSERT INTO OrderStatus (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'PEDIDO');
INSERT INTO OrderStatus (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Name)
VALUES (NEWID(), 0, GETDATE(), GETDATE(), NEWID(), NEWID(), 'VENTA');



-- Eliminación
DELETE FROM DocumentType
DELETE FROM Sex 
DELETE FROM Country
DELETE FROM City
DELETE FROM Neighborhood
DELETE FROM UserRole
DELETE FROM Category
DELETE FROM Kind
DELETE FROM Line
DELETE FROM OrderStatus 

