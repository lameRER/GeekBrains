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
            CreateMap<AddCustomerInsert, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<AddContractInsert, Contract>();
            CreateMap<Contract, ContractDto>();
            
            CreateMap<AddInvoiceInsert, Invoice>();
            CreateMap<Invoice, InvoiceDto>();
            
            CreateMap<AddEmployeeInsert, Employee>();
            CreateMap<Employee, EmployeeDto>();
            
            CreateMap<AddTaskInsert, Task>();
            CreateMap<Task, TaskDto>();
        }
    }
}