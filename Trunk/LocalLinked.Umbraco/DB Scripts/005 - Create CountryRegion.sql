CREATE TABLE [dbo].[CountryRegion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryCode] [nchar](2) NOT NULL,
	[RegionName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_CountryRegion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CountryRegion]  WITH CHECK ADD  CONSTRAINT [FK_CountryRegion_Country] FOREIGN KEY([CountryCode])
REFERENCES [dbo].[Country] ([Code])
GO

ALTER TABLE [dbo].[CountryRegion] CHECK CONSTRAINT [FK_CountryRegion_Country]
GO