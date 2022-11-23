USE [TestDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/***********************************************************************************************************************************************************************************************************************************
-- Author:			Sifiso
-- Create date:		2022-11-22
-- Description:		Insert Comment
************************************************************************************************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].STP_COMMENT_ADD
(
  @ProductId INT,
  @Comment  varchar (500) ,
  @Email  nvarchar(256)
) AS

 BEGIN
	SET NOCOUNT ON

	INSERT INTO [dbo].[COMMENT]([ProductId],[Comment],[Email],[DateOfComment])
	VALUES (@ProductId,@Comment,@Email,GETDATE())

END

GO