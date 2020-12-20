-- =============================================
-- Author:		Alin Popa
-- Create date: 10.12.2020
-- Description:	Paginated search engine
-- =============================================
-- EXEC [dbo].[SearchArt] @Name = 'Satul', @Category = 0, @PriceMin = 10, @PriceMax = 150, @Size = 'M', @Original = 'ORIGINAL', @Signed = 1, @Page = 1
CREATE PROCEDURE [dbo].[SearchArt]
	@Name nvarchar(150) = '', 
	@Category int = 0, 
	@PriceMin decimal = 0, 
	@PriceMax decimal = 0, 
	@Size nchar(1) = '', 
	@Original nvarchar(10) = '', 
	@Signed bit = null, 
	@Page int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM ArtDirectory
	WHERE Name LIKE (CASE WHEN @Name <> '' THEN '%' + @Name + '%' ELSE Name END) AND
	Category = (CASE WHEN @Category <> 0 THEN @Category ELSE Category END) AND
	Price >= (CASE WHEN @PriceMin <> 0 THEN @PriceMin ELSE Price END) AND
	Price <= (CASE WHEN @PriceMax <> 0 THEN @PriceMax ELSE Price END) AND
	Size LIKE (CASE WHEN @Size <> '' THEN @Size ELSE Size END) AND
	Original =  (CASE WHEN @Original <> '' THEN @Original ELSE Original END) AND
	Signed = (CASE WHEN @Signed IS NOT NULL THEN @Signed ELSE Signed END)
	ORDER BY ID OFFSET 6 * (@Page - 1) ROWS
  FETCH NEXT 6 ROWS ONLY;
END