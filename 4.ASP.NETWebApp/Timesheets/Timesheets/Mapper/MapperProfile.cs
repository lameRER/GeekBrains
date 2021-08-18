using AutoMapper;
using Timesheets.DAL.Models;
using Timesheets.Request;
using Timesheets.Responses;

namespace Timesheets.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddCustomerQuery, Customer>();
            CreateMap<GetCustomerByIdQuery, Customer>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}