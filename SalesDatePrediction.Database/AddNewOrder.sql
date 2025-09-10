CREATE OR ALTER PROCEDURE NewOrder
    @EmployeeId INT,
    @ShipperId INT,
    @ShipName NVARCHAR(40),
    @ShipAddress NVARCHAR(60),
    @ShipCity NVARCHAR(15),
    @OrderDate DATETIME,
    @RequiredDate DATETIME,
    @ShippedDate DATETIME,
    @Freight MONEY,
    @ShipCountry NVARCHAR(15),
    @ProductId INT,
    @UnitPrice MONEY,
    @Qty SMALLINT,
    @Discount NUMERIC(4,3)
AS
BEGIN
    DECLARE @NewOrderId INT;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Sales.Orders 
            (empid, shipperid, shipname, shipaddress, shipcity, orderdate, requireddate, shippeddate, freight, shipcountry)
        VALUES 
            (@EmployeeId, @ShipperId, @ShipName, @ShipAddress, @ShipCity, @OrderDate, @RequiredDate, @ShippedDate, @Freight, @ShipCountry);

        SET @NewOrderId = SCOPE_IDENTITY();

        INSERT INTO Sales.OrderDetails 
            (orderid, productid, unitprice, qty, discount)
        VALUES 
            (@NewOrderId, @ProductId, @UnitPrice, @Qty, @Discount);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
