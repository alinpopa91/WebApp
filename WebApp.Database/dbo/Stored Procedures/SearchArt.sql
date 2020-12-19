-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchArt]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(150), @Category int, @PriceMin decimal, @PriceMax decimal, @Size nchar(1), @Original nvarchar(10), @Signed bit, @Page int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM ArtDirectory
	WHERE Name LIKE (CASE WHEN @Name IS NOT NULL THEN @Name ELSE Name END) AND
	Category = (CASE WHEN @Category <> 0 THEN @Category ELSE @Category END) AND
	Price >= (CASE WHEN @PriceMin IS NOT NULL THEN @PriceMin ELSE Price END) AND
	Price <= (CASE WHEN @PriceMax IS NOT NULL THEN @PriceMax ELSE Price END) AND
	Size LIKE (CASE WHEN @Size <> '' THEN @Size ELSE Size END) AND
	Original =  (CASE WHEN @Original IS NOT NULL THEN @Original ELSE Original END) AND
	Signed = (CASE WHEN @Signed IS NOT NULL THEN @Signed ELSE Signed END)
	ORDER BY ID
	OFFSET @Page ROWS FETCH NEXT 6 ROWS ONLY
END