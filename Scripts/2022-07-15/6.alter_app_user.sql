ALTER TABLE AppUser ADD BasClientCode VARCHAR(100) NULL;

ALTER TABLE [Product] ADD BasProductCode VARCHAR(100) NULL;

ALTER TABLE AppUser ADD CanCCM BIT NULL;
ALTER TABLE AppUser ADD CanCCB BIT NULL;