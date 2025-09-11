using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Domain.Interfaces.Repositories;
using SalesDatePrediction.Domain.StoreProceduresEntities;

namespace SalesDatePrediction.Infrastructure.Persistance.Repositories
{
    internal class DataAccessRepository : IDataAccessRepository
    {
        private readonly SalesPredictionDbContext _context;

        public DataAccessRepository(SalesPredictionDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrder(NewOrder newOrder)
        {

            var newOrderIdParam = new SqlParameter
            {
                ParameterName = "@NewOrderId",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            SqlParameter[] parameters =
            [
                new SqlParameter("@EmployeeId", newOrder.Empid),
                new SqlParameter("@ShipperId", newOrder.Shipperid),
                new SqlParameter("@ShipName", newOrder.Shipname),
                new SqlParameter("@ShipAddress", newOrder.Shipaddress),
                new SqlParameter("@ShipCity", newOrder.Shipcity),
                new SqlParameter("@OrderDate", newOrder.Orderdate),
                new SqlParameter("@RequiredDate", newOrder.Requireddate),
                new SqlParameter("@ShippedDate", newOrder.Shippeddate),
                new SqlParameter("@Freight", newOrder.Freight),
                new SqlParameter("@ShipCountry", newOrder.Shipcountry),
                new SqlParameter("@ProductId", newOrder.Productid),
                new SqlParameter("@UnitPrice", newOrder.Unitprice),
                new SqlParameter("@Qty", newOrder.Qty),
                new SqlParameter("@Discount", newOrder.Discount),
                newOrderIdParam
            ];

            var result = await _context.Database.ExecuteSqlRawAsync("EXEC dbo.NewOrder @EmployeeId, @ShipperId, @ShipName, @ShipAddress, @ShipCity, @OrderDate, @RequiredDate, @ShippedDate, @Freight, @ShipCountry, @ProductId, @UnitPrice, @Qty, @Discount, @NewOrderId OUTPUT", parameters);

            return (int)newOrderIdParam.Value;
        }

        public async Task<List<ClientOrder>> GetClientOrders(int id)
        {
            var result = await _context.ClientOrders.FromSqlRaw("EXEC dbo.ClientOrders @CustomerId", new SqlParameter("@CustomerId", id)).ToListAsync();

            return result;
        }

        public async Task<List<SPEmployee>> GetEmployees()
        {
            return await _context.SPEmployees.FromSqlRaw("EXEC dbo.Employees").ToListAsync();
        }

        public async Task<List<SaleDatePrediction>> GetPredictions()
        {
            return await _context.SaleDatePredictions.FromSqlRaw("EXEC dbo.PredictNextOrders").ToListAsync(); 
        }

        public async Task<List<SPProduct>> GetProducts()
        {
            return await _context.SPProducts.FromSqlRaw("EXEC dbo.Products").ToListAsync();
        }

        public async Task<List<SPShipper>> GetShippers()
        {
            return await _context.SPShippers.FromSqlRaw("EXEC dbo.Shippers").ToListAsync();
        }
    }
}
