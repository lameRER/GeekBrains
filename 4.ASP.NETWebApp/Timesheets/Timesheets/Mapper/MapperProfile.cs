using AutoMapper;
using Timesheets.DAL.Models;
using Timesheets.Responses;

namespace Timesheets.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerDto>();
        }
    }
}