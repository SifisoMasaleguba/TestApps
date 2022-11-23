USE [TestDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/***********************************************************************************************************************************************************************************************************************************
-- Author:			Sifiso
-- Create date:		2022-11-22
-- Description:		Return Comment
************************************************************************************************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[STP_COMMENT]
(
  @ProductId INT = NULL
) AS

 BEGIN
	SET NOCOUNT ON

	SELECT
	   C.ProductId,
	   C.Comment,
	   C.Email,
	   DateOfComment
	FROM
		 [dbo].[COMMENT] C WITH (ROWLOCK)
	WHERE 1 = 1	
		AND C.ProductId  = @ProductId

END

GO


