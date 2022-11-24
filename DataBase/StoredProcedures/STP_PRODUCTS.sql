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
		P.ReleaseDate,
		COUNT(C.ProductId) AS NumerOfComments 
	FROM
		[dbo].[PRODUCT] P WITH (NOLOCK)
		LEFT OUTER JOIN COMMENT C WITH(NOLOCK) ON C.ProductId = P.ProductId
	WHERE 1 = 1	
		AND (P.ProductId  = @ProductId OR ISNULL(@ProductId,-1) = -1)
		AND P.isProductDeleted = 0
		GROUP BY 
				P.ProductId,
				P.[Name],
				P.Price ,
				P.ReleaseDate,
				C.ProductId
END

GO