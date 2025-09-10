CREATE OR ALTER PROCEDURE Products
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		p.productid,
		p.productname
	FROM Production.Products p
END;
GO