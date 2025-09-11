using SalesDatePrediction.Domain.StoreProceduresEntities;

namespace SalesDatePrediction.Domain.Interfaces.Repositories
{
    public interface IDataAccessRepository
    {
        public Task<List<SaleDatePrediction>> GetPredictions();
        public Task<List<ClientOrder>> GetClientOrders(int id);
        public Task<List<SPEmployee>> GetEmployees();
        public Task<List<SPShipper>> GetShippers();
        public Task<List<SPProduct>> GetProducts();
        public Task<int> CreateOrder(NewOrder newOrder);
    }
}
