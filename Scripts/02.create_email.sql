CREATE TABLE EmailType
(
Guid UNIQUEIDENTIFIER NOT NULL,
Deleted BIT NOT NULL,
CreatedAt DATE NOT NULL,
UpdatedAt DATE NOT NULL,
CreatedBy UNIQUEIDENTIFIER NOT NULL,
UpdatedBy UNIQUEIDENTIFIER NOT NULL,
Name VARCHAR(200) NOT NULL,
CONSTRAINT PK_EmailType_Guid PRIMARY KEY(Guid),
);
CREATE TABLE Errors
(
Guid UNIQUEIDENTIFIER NOT NULL,
Deleted BIT NOT NULL,
CreatedAt DATE NOT NULL,
UpdatedAt DATE NOT NULL,
CreatedBy UNIQUEIDENTIFIER NOT NULL,
UpdatedBy UNIQUEIDENTIFIER NOT NULL,
Message VARCHAR(250) NOT NULL,
StackTrace VARCHAR(MAX) NOT NULL,
CONSTRAINT PK_Errors_Guid PRIMARY KEY(Guid),
);
CREATE TABLE EmailTemplate
(
Guid UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
Deleted BIT NOT NULL DEFAULT 0,
CreatedAt DATE NOT NULL DEFAULT GETDATE(),
UpdatedAt DATE NULL,
CreatedBy UNIQUEIDENTIFIER NOT NULL,
UpdatedBy UNIQUEIDENTIFIER NULL,
Subject VARCHAR(150) NULL,
Template VARCHAR(MAX) NULL,
IdType UNIQUEIDENTIFIER NULL,
CONSTRAINT pk_EmailTemplate_Guid PRIMARY KEY(Guid),
);
CREATE TABLE EmailKeys
(
Guid UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
Deleted BIT NOT NULL DEFAULT 0,
CreatedAt DATE NOT NULL DEFAULT GETDATE(),
UpdatedAt DATE NULL,
CreatedBy UNIQUEIDENTIFIER NOT NULL,
UpdatedBy UNIQUEIDENTIFIER NULL,
[Key] VARCHAR(50) NULL,
FieldNameValue VARCHAR(50) NULL,
IdTemplate UNIQUEIDENTIFIER NULL,
CONSTRAINT pk_EmailKeys_Guid PRIMARY KEY(Guid),
);