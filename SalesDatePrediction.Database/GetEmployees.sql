CREATE OR ALTER PROCEDURE Employees
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		e.empid,
		CONCAT(e.firstname, ' ', e.lastname) AS FullName
	FROM HR.Employees e
END;
GO