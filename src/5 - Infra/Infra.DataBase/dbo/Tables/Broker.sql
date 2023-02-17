CREATE TABLE [dbo].[Broker] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [bkr_nomefantasia]  NVARCHAR (60)    NULL,
    [bkr_razaosocial]   NVARCHAR (60)    NULL,
    [bkr_cnpj]          NVARCHAR (15)    NULL,
    [DCreated]          DATETIME2 (7)    NOT NULL,
    [LastUpdate]        DATETIME2 (7)    NOT NULL,
    [CIdUserCreated]    NVARCHAR (MAX)   NULL,
    [CIdUserLastUpdate] NVARCHAR (MAX)   NULL,
    [Enabled]           TINYINT          NOT NULL,
    CONSTRAINT [bkr_id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

