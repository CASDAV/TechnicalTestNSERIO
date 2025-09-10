CREATE OR ALTER PROCEDURE ClientOrders
	@CustomerId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		o.orderid,
		o.requireddate,
		o.shippeddate,
		o.shipname,
		o.shipaddress,
		o.shipcity
	FROM Sales.Orders o
	WHERE o.custid = @CustomerId
END;
GO