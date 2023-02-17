CREATE TABLE [dbo].[Company] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [cny_name]          NVARCHAR (60)    NULL,
    [cny_cnpj]          NVARCHAR (15)    NULL,
    [SectorId]          UNIQUEIDENTIFIER NULL,
    [DCreated]          DATETIME2 (7)    NOT NULL,
    [LastUpdate]        DATETIME2 (7)    NOT NULL,
    [CIdUserCreated]    NVARCHAR (MAX)   NULL,
    [CIdUserLastUpdate] NVARCHAR (MAX)   NULL,
    [Enabled]           TINYINT          NOT NULL,
    CONSTRAINT [cny_id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_cny_sct] FOREIGN KEY ([SectorId]) REFERENCES [dbo].[tb_sector] ([sct_Id])
);










GO





GO


