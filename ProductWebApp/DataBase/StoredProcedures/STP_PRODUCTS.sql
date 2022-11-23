USE [TestDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/***********************************************************************************************************************************************************************************************************************************
-- Author:			Sifiso
-- Create date:		2022-11-22
-- Description:		Return Product
************************************************************************************************************************************************************************************************************************************/
CREATE PROCEDURE [dbo].STP_PRODUCTS
(
  @ProductId INT = NULL
) AS

 BEGIN
	SET NOCOUNT ON

	SELECT
	    P.ProductId,
		P.[Name],
		P.Price ,
		P.ReleaseDate
	FROM
		[dbo].[PRODUCT] P WITH (ROWLOCK)
	WHERE 1 = 1	
		AND (P.ProductId  = @ProductId OR ISNULL(@ProductId,-1) = -1)
		AND P.isProductDeleted = 0

END

GO