Build started...
Build succeeded.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No type was specified for the decimal column 'Price' on entity type 'Ingredient'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values using 'HasColumnType()'.
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Ingredient] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [Price] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Ingredient] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [User] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [PassWord] nvarchar(max) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PizzeriaIngredient] (
    [Id] uniqueidentifier NOT NULL,
    [IngredientxId] uniqueidentifier NULL,
    [PizzeriaId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_PizzeriaIngredient] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PizzeriaIngredient_Ingredient_IngredientxId] FOREIGN KEY ([IngredientxId]) REFERENCES [Ingredient] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Pizzeria] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [PizzeriaIngredientId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Pizzeria] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pizzeria_PizzeriaIngredient_PizzeriaIngredientId] FOREIGN KEY ([PizzeriaIngredientId]) REFERENCES [PizzeriaIngredient] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Image] (
    [Id] uniqueidentifier NOT NULL,
    [Url] nvarchar(max) NULL,
    [PizzeriaId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Image] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Image_Pizzeria_PizzeriaId] FOREIGN KEY ([PizzeriaId]) REFERENCES [Pizzeria] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Image_PizzeriaId] ON [Image] ([PizzeriaId]);

GO

CREATE INDEX [IX_Pizzeria_PizzeriaIngredientId] ON [Pizzeria] ([PizzeriaIngredientId]);

GO

CREATE INDEX [IX_PizzeriaIngredient_IngredientxId] ON [PizzeriaIngredient] ([IngredientxId]);

GO

CREATE INDEX [IX_PizzeriaIngredient_PizzeriaId] ON [PizzeriaIngredient] ([PizzeriaId]);

GO

ALTER TABLE [PizzeriaIngredient] ADD CONSTRAINT [FK_PizzeriaIngredient_Pizzeria_PizzeriaId] FOREIGN KEY ([PizzeriaId]) REFERENCES [Pizzeria] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200306120544_InitialCreate', N'3.1.2');

GO


