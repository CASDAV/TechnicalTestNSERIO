CREATE OR ALTER PROCEDURE PredictNextOrders
AS
BEGIN
    SET NOCOUNT ON;

    WITH day_gaps AS
    (
        SELECT
            o.custid AS CustomerId,
            DATEDIFF(DAY, LAG(o.orderdate) OVER (PARTITION BY o.custid ORDER BY o.orderdate), o.orderdate) AS gap
        FROM Sales.Orders o
    ),
    avg_days_per_customer AS
    (
        SELECT
            dg.CustomerId,
            AVG(dg.gap) AS AVGDaysBetween
        FROM day_gaps dg
        WHERE dg.gap IS NOT NULL
        GROUP BY dg.CustomerId
    ),
    last_order AS
    (
        SELECT
            o.custid,
            MAX(o.orderdate) AS LastOrder
        FROM Sales.Orders o
        GROUP BY o.custid
    )
    SELECT
        c.companyname AS CustomerName,
        lo.LastOrder AS LastOrderDate,
        DATEADD(DAY, ag.AVGDaysBetween, lo.LastOrder) AS NextPredictedOrder
    FROM last_order lo
    JOIN avg_days_per_customer ag
        ON lo.custid = ag.CustomerId
    JOIN Sales.Customers c
        ON lo.custid = c.custid
    ORDER BY CustomerName ASC;
END;
GO
