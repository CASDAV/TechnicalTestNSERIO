using AutoMapper;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Domain.Interfaces.Repositories;
using SalesDatePrediction.Domain.StoreProceduresEntities;

namespace SalesDatePrediction.Application.Services
{
    public class ApplicationServices
    {
        private readonly IDataAccessRepository _repository;

        private readonly IMapper _mapper;

        public ApplicationServices(IDataAccessRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ClientOrderDTO>> GetClientOrders(int id)
        {
            return _mapper.Map<List<ClientOrderDTO>>(await _repository.GetClientOrders(id)); 
        }

        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            return _mapper.Map<List<EmployeeDTO>>(await _repository.GetEmployees());
        }

        public async Task<int> CreateOrder(NewOrderDTO newOrder)
        {
            return await _repository.CreateOrder(_mapper.Map<NewOrder>(newOrder));
        } 

        public async Task<List<ProductDTO>> GetProducts()
        {
            return _mapper.Map<List<ProductDTO>>(await _repository.GetProducts());
        }

        public async Task<List<ShipperDTO>> GetShippers()
        {
            return _mapper.Map<List<ShipperDTO>>(await _repository.GetShippers());
        }

        public async Task<List<SaleDatePredictionDTO>> GetPredictions()
        {
            return _mapper.Map<List<SaleDatePredictionDTO>>(await _repository.GetPredictions());
        }
    }
}
