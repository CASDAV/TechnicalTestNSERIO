CREATE OR ALTER PROCEDURE Shippers
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		s.shipperid,
		s.companyname
	FROM Sales.Shippers s
END;
GO