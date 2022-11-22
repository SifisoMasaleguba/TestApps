USE [TestDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/***********************************************************************************************************************************************************************************************************************************
-- Author:			Sifiso
-- Create date:		2022-11-22
-- Description:		Insert Product
************************************************************************************************************************************************************************************************************************************/
CREATE PROCEDURE [dbo].STP_PRODUCT_ADD
(
  @Name VARCHAR(100),
  @Price MONEY,
  @ReleaseDate [DATETIME]
) AS

 BEGIN
	SET NOCOUNT ON

		INSERT INTO  [dbo].[PRODUCT]([Name],[Price],[ReleaseDate])
		VALUES (@Name,@Price,@ReleaseDate)
		

END

GO