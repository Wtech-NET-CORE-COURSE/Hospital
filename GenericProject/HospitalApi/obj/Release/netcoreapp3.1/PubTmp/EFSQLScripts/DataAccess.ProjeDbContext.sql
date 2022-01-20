IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211130072816_ProjeMigration')
BEGIN
    CREATE TABLE [Hospital] (
        [Hospital_Id] int NOT NULL IDENTITY,
        [Hospital_Name] nvarchar(max) NULL,
        [Hospital_Adress] nvarchar(max) NULL,
        [NumberOfDoctors] int NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Hospital] PRIMARY KEY ([Hospital_Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211130072816_ProjeMigration')
BEGIN
    CREATE TABLE [Poliklinik] (
        [Poliklinik_Id] int NOT NULL IDENTITY,
        [Poliklinik_Name] nvarchar(max) NULL,
        [NumberOfDoctors] int NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Poliklinik] PRIMARY KEY ([Poliklinik_Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211130072816_ProjeMigration')
BEGIN
    CREATE TABLE [Patient] (
        [Patient_Id] int NOT NULL IDENTITY,
        [Patient_Name] nvarchar(max) NULL,
        [Patient_Condition] nvarchar(max) NOT NULL,
        [Hospital_Id] int NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Patient] PRIMARY KEY ([Patient_Id]),
        CONSTRAINT [FK_Patient_Hospital_Hospital_Id] FOREIGN KEY ([Hospital_Id]) REFERENCES [Hospital] ([Hospital_Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211130072816_ProjeMigration')
BEGIN
    CREATE TABLE [Doctor] (
        [Doctor_Id] int NOT NULL IDENTITY,
        [Doctor_Name] nvarchar(max) NULL,
        [Hospital_Id] int NULL,
        [Poliklinik_Id] int NULL,
        [IsActıve] bit NOT NULL,
        CONSTRAINT [PK_Doctor] PRIMARY KEY ([Doctor_Id]),
        CONSTRAINT [FK_Doctor_Hospital_Hospital_Id] FOREIGN KEY ([Hospital_Id]) REFERENCES [Hospital] ([Hospital_Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Doctor_Poliklinik_Poliklinik_Id] FOREIGN KEY ([Poliklinik_Id]) REFERENCES [Poliklinik] ([Poliklinik_Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211130072816_ProjeMigration')
BEGIN
    CREATE TABLE [Date] (
        [Date_Id] int NOT NULL IDENTITY,
        [Date_Tarih] datetime2 NOT NULL,
        [Doctor_Id] int NULL,
        [Patient_Id] int NULL,
        CONSTRAINT [PK_Date] PRIMARY KEY ([Date_Id]),
        CONSTRAINT [FK_Date_Doctor_Doctor_Id] FOREIGN KEY ([Doctor_Id]) REFERENCES [Doctor] ([Doctor_Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Date_Patient_Patient_Id] FOREIGN KEY ([Patient_Id]) REFERENCES [Patient] ([Patient_Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211130072816_ProjeMigration')
BEGIN
    CREATE TABLE [Prescription] (
        [Prescriptions_Id] int NOT NULL IDENTITY,
        [Medicine_Name] nvarchar(max) NOT NULL,
        [Doctor_Id] int NULL,
        [Patient_Id] int NULL,
        CONSTRAINT [PK_Prescription] PRIMARY KEY ([Prescriptions_Id]),
        CONSTRAINT [FK_Prescription_Doctor_Doctor_Id] FOREIGN KEY ([Doctor_Id]) REFERENCES [Doctor] ([Doctor_Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Prescription_Patient_Patient_Id] FOREIGN KEY ([Patient_Id]) REFERENCES [Patient] ([Patient_Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211130072816_ProjeMigration')
BEGIN
    CREATE INDEX [IX_Date_Doctor_Id] ON [Date] ([Doctor_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211130072816_ProjeMigration')
BEGIN
    CREATE INDEX [IX_Date_Patient_Id] ON [Date] ([Patient_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211130072816_ProjeMigration')
BEGIN
    CREATE INDEX [IX_Doctor_Hospital_Id] ON [Doctor] ([Hospital_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211130072816_ProjeMigration')
BEGIN
    CREATE INDEX [IX_Doctor_Poliklinik_Id] ON [Doctor] ([Poliklinik_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211130072816_ProjeMigration')
BEGIN
    CREATE INDEX [IX_Patient_Hospital_Id] ON [Patient] ([Hospital_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211130072816_ProjeMigration')
BEGIN
    CREATE INDEX [IX_Prescription_Doctor_Id] ON [Prescription] ([Doctor_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211130072816_ProjeMigration')
BEGIN
    CREATE INDEX [IX_Prescription_Patient_Id] ON [Prescription] ([Patient_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211130072816_ProjeMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211130072816_ProjeMigration', N'5.0.11');
END;
GO

COMMIT;
GO

