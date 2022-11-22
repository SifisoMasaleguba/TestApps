USE [TestDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/***********************************************************************************************************************************************************************************************************************************
-- Author:			Sifiso
-- Create date:		2022-11-22
-- Description:		Update Product
************************************************************************************************************************************************************************************************************************************/
CREATE PROCEDURE [dbo].STP_PRODUCT_DELETE
(
  @ProductId INT 
) AS

 BEGIN
	SET NOCOUNT ON

	UPDATE P
	SET
	   P.isProductDeleted = 1
	FROM
		[dbo].[PRODUCT] P WITH (ROWLOCK)
	WHERE 1 = 1	
		AND P.ProductId  = @ProductId
   /*
    DELETE P    	
    FROM    
    	[dbo].[PRODUCT] P WITH (ROWLOCK)
	WHERE 1 = 1	
		AND P.ProductId  = @ProductId
	*/
END

GO