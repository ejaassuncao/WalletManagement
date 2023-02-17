CREATE TABLE [dbo].[tb_wallet] (
    [wal_Id]   UNIQUEIDENTIFIER NOT NULL,
    [wal_name] VARCHAR (50)     NOT NULL, 
    [wal_new] VARCHAR(50) NULL, 
    CONSTRAINT [wal_Id] PRIMARY KEY CLUSTERED ([wal_Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'abbreviation:  wal
Description: tables wallet', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tb_wallet';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'PK table', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tb_wallet', @level2type = N'COLUMN', @level2name = N'wal_Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Name wallet', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tb_wallet', @level2type = N'COLUMN', @level2name = N'wal_name';

