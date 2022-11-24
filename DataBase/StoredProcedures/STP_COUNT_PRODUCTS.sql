USE [TestDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/***********************************************************************************************************************************************************************************************************************************
-- Author:			Sifiso
-- Create date:		2022-11-24
-- Description:		Return Total number of Products
-- EXAMPLE : EXEC [dbo].[STP_COUNT_PRODUCTS]
************************************************************************************************************************************************************************************************************************************/
CREATE PROCEDURE [dbo].[STP_COUNT_PRODUCTS]

 
 AS

 BEGIN
	SET NOCOUNT ON

	SELECT	   
		COUNT(P.ProductId) AS TotalNumberOfProduct 
	FROM
		[dbo].[PRODUCT] P WITH (NOLOCK)
	WHERE 1 = 1		
		AND P.isProductDeleted = 0

END

GO


