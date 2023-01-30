CREATE TABLE PropductSync
(
Guid UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
Deleted BIT NOT NULL DEFAULT 0,
CreatedAt DATE NOT NULL DEFAULT GETDATE(),
UpdatedAt DATE NULL,
CreatedBy UNIQUEIDENTIFIER NOT NULL,
UpdatedBy UNIQUEIDENTIFIER NULL,
ACTUALIZADO NVARCHAR(MAX) NULL,
ACTIVO NVARCHAR(MAX) NULL,
CODIGO NVARCHAR(MAX) NULL,
CBP NVARCHAR(MAX) NULL,
MARCA NVARCHAR(MAX) NULL,
PROVEEDOR NVARCHAR(MAX) NULL,
SUBRUBRO NVARCHAR(MAX) NULL,
VADEMECUM NVARCHAR(MAX) NULL,
ALTA NVARCHAR(MAX) NULL,
TIPO NVARCHAR(MAX) NULL,
LABORATORIO NVARCHAR(MAX) NULL,
CATEGORIA NVARCHAR(MAX) NULL,
LINEA_BAL NVARCHAR(MAX) NULL,
NOMBRE NVARCHAR(MAX) NULL,
DROGA NVARCHAR(MAX) NULL,
ACCION NVARCHAR(MAX) NULL,
DESCRIPCION NVARCHAR(MAX) NULL,
ESPECIE NVARCHAR(MAX) NULL,
VIA_ADMINISTRACION NVARCHAR(MAX) NULL,
PRESENTACION NVARCHAR(MAX) NULL,
RETIRO_LECHE NVARCHAR(MAX) NULL,
RETIRO_CARNE NVARCHAR(MAX) NULL,
FOTO NVARCHAR(MAX) NULL,
DISCONTINUADO NVARCHAR(MAX) NULL,
FALTANTE_INFO NVARCHAR(MAX) NULL,
FALTANTE_FOTO NVARCHAR(MAX) NULL,
OBS NVARCHAR(MAX) NULL,
FECHAREG NVARCHAR(MAX) NULL,
ENLACE NVARCHAR(MAX) NULL,
CONSTRAINT pk_PropductSync_Guid PRIMARY KEY(Guid),
);

CREATE TABLE CustomerSync
(
Guid UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
Deleted BIT NOT NULL DEFAULT 0,
CreatedAt DATE NOT NULL DEFAULT GETDATE(),
UpdatedAt DATE NULL,
CreatedBy UNIQUEIDENTIFIER NOT NULL,
UpdatedBy UNIQUEIDENTIFIER NULL,
CODCTACTE VARCHAR(100) NULL,
RAZON_SOCIAL VARCHAR(100) NULL,
CODDOC VARCHAR(100) NULL,
NRODOC VARCHAR(100) NULL,
CODCONDI VARCHAR(100) NULL,
VENDEDOR VARCHAR(100) NULL,
CREDITO VARCHAR(100) NULL,
DESTINO VARCHAR(100) NULL,
TRANSPORTISTA VARCHAR(100) NULL,
CODLIS VARCHAR(100) NULL,
PRECIOS VARCHAR(100) NULL,
FECHAREG VARCHAR(100) NULL,
DESCDOMICILIO VARCHAR(100) NULL,
CODPRV VARCHAR(100) NULL,
CODPAIS VARCHAR(100) NULL,
CODPOS VARCHAR(100) NULL,
TELEFONO VARCHAR(100) NULL,
CONSTRAINT pk_CustomerSync_Guid PRIMARY KEY(Guid),
);

CREATE TABLE CustomerConditionSync
(
Guid UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
Deleted BIT NOT NULL DEFAULT 0,
CreatedAt DATE NOT NULL DEFAULT GETDATE(),
UpdatedAt DATE NULL,
CreatedBy UNIQUEIDENTIFIER NOT NULL,
UpdatedBy UNIQUEIDENTIFIER NULL,
CODCTACTE VARCHAR(100) NULL,
CODCONDI VARCHAR(100) NULL,
CODLIS VARCHAR(100) NULL,
COLUMNA VARCHAR(100) NULL,
CONSTRAINT pk_CustomerConditionSync_Guid PRIMARY KEY(Guid),
);

CREATE TABLE PriceListSync
(
Guid UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
Deleted BIT NOT NULL DEFAULT 0,
CreatedAt DATE NOT NULL DEFAULT GETDATE(),
UpdatedAt DATE NULL,
CreatedBy UNIQUEIDENTIFIER NOT NULL,
UpdatedBy UNIQUEIDENTIFIER NULL,
CODITM VARCHAR(100) NULL,
DESCRIPCION VARCHAR(100) NULL,
VIGENCIA VARCHAR(100) NULL,
CODLIS VARCHAR(100) NULL,
PRECIO VARCHAR(100) NULL,
PRECIO_A VARCHAR(100) NULL,
PRECIO_B VARCHAR(100) NULL,
PRECIO_C VARCHAR(100) NULL,
PRECIO_D VARCHAR(100) NULL,
PRECIO_E VARCHAR(100) NULL,
PRECIO_F VARCHAR(100) NULL,
PRECIO_G VARCHAR(100) NULL,
PRECIO_H VARCHAR(100) NULL,
PRECIO_I VARCHAR(100) NULL,
PRECIO_J VARCHAR(100) NULL,
PRECIO_K VARCHAR(100) NULL,
PRECIO_L VARCHAR(100) NULL,
PRECIO_M VARCHAR(100) NULL,
PRECIO_N VARCHAR(100) NULL,
PRECIO_O VARCHAR(100) NULL,
PRECIO_NL VARCHAR(100) NULL,
CONSTRAINT pk_PriceListSync_Guid PRIMARY KEY(Guid),
);
