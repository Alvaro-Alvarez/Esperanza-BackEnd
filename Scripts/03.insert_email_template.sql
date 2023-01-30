--NUEVA CONFIGURACIÓN DE E-MAIL
INSERT INTO Emailtype (guid, name, deleted, createdat, updatedat, createdby, updatedby) 
VALUES (NEWID(), 'OrderPlaced', 0, GETDATE(), GETDATE(), NEWID(), NEWID());

INSERT INTO EmailTemplate (Guid, Subject, IdType, CreatedAt, UpdatedAt, Deleted, CreatedBy, UpdatedBy, Template) 
VALUES (NEWID(), 'Esperanza - Pedido realizado!', (SELECT TOP 1 Guid FROM Emailtype WHERE Name = 'OrderPlaced'), GETDATE(), GETDATE(), 0, NEWID(), NEWID(), '<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
</head>
<body>
    <div>
        <div style="background: linear-gradient(to right, #FCA746, #FCA746);
                font-size: 40px;
                color: #ffffff;
                padding-left: 20px;
                font-weight: bold;
                height: 70px;">
            <span>Pedido realizado con éxito!</span>
        </div>
        <div style="text-align: center; font-size: 24px; font-weight: bold;">
            XXXXX, tu pedido fue realizado exitosamente.
        </div>
        <br>
        Información del pedido
        <br>
        <br>
        <span style="font-weight: bold;">Nombre de producto:</span>  Comida de gato
        <br>
        <span style="font-weight: bold;">Cantidad:</span>  2
        <br>
        <span style="font-weight: bold;">Precio unitario:</span>  100$
        <br>
        <span style="font-weight: bold;">Sub total:</span>  200$
        <br><br>
        <div style="background: linear-gradient(to right, #FCA746, #FCA746);
                font-size: 15px;
                color: white;
                padding-left: 20px;
                height: 70px;
                text-align: center;">
        </div>
    </div>
</body>
</html>');

-- INSERT INTO EmailKeys (Id, Key, FieldNameValue, IdTemplate, CreatedAt, UpdatedAt, Deleted, CreatedBy, UpdatedBy) 
-- VALUES (gen_random_uuid(), '{{Password}}', 'password', (SELECT Id FROM EmailTemplate ORDER BY CreatedAt DESC LIMIT 1), current_timestamp, current_timestamp, false, null, null);
-- INSERT INTO EmailKeys (Id, Key, FieldNameValue, IdTemplate, CreatedAt, UpdatedAt, Deleted, CreatedBy, UpdatedBy) 
-- VALUES (gen_random_uuid(), '{{Email}}', 'User.Email', (SELECT Id FROM EmailTemplate ORDER BY CreatedAt DESC LIMIT 1), current_timestamp, current_timestamp, false, null, null);
-- INSERT INTO EmailKeys (Id, Key, FieldNameValue, IdTemplate, CreatedAt, UpdatedAt, Deleted, CreatedBy, UpdatedBy) 
-- VALUES (gen_random_uuid(), '{{Name}}', 'User.Name', (SELECT Id FROM EmailTemplate ORDER BY CreatedAt DESC LIMIT 1), current_timestamp, current_timestamp, false, null, null);
