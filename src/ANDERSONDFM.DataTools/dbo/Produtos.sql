CREATE TABLE [dbo].[Produtos]
(
    [Id] [int] NOT NULL,
	[Nome] [varchar](150) NOT NULL,
	[DataInclusao] [datetime2](7) NOT NULL,
	[UsuarioInclusao] [varchar](50) NOT NULL,
    CONSTRAINT [PK_GrauParentesco] PRIMARY KEY CLUSTERED ([Id] ASC)
)
