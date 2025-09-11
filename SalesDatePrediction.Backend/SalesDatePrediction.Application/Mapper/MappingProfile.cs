using AutoMapper;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Domain.StoreProceduresEntities;

namespace SalesDatePrediction.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientOrder, ClientOrderDTO>();
            CreateMap<SPEmployee, EmployeeDTO>();
            CreateMap<NewOrderDTO, NewOrder>();
            CreateMap<SaleDatePrediction, SaleDatePredictionDTO>();
            CreateMap<SPProduct, ProductDTO>();
            CreateMap<SPShipper, ShipperDTO>();
        }
    }
}
