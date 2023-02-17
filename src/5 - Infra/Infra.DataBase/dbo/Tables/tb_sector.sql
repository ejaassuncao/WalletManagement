CREATE TABLE [dbo].[tb_sector] (
    [sct_Id]            UNIQUEIDENTIFIER NOT NULL,
    [sct_name]          NVARCHAR (60)    NOT NULL,
    [sct_DCreated]      DATETIME2 (7)    NOT NULL,
    [LastUpdate]        DATETIME2 (7)    NOT NULL,
    [CIdUserCreated]    NVARCHAR (MAX)   NULL,
    [CIdUserLastUpdate] NVARCHAR (MAX)   NULL,
    [Enabled]           TINYINT          NOT NULL,
    CONSTRAINT [sct_id] PRIMARY KEY CLUSTERED ([sct_Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'abbreviation: sct
Description: table sector', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tb_sector';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'pk table', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tb_sector', @level2type = N'COLUMN', @level2name = N'sct_Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'sector name', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tb_sector', @level2type = N'COLUMN', @level2name = N'sct_name';

