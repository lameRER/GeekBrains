using AutoMapper;
using Timesheets.DAL.Models;
using Timesheets.Service.Request;
using Timesheets.Service.Responses;

namespace Timesheets.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddCustomerCommand, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<AddContractCommand, Contract>();
            CreateMap<Contract, ContractDto>();
            
            CreateMap<AddInvoiceCommand, Invoice>();
            CreateMap<Invoice, InvoiceDto>();
            
            CreateMap<AddEmployeeCommand, Employee>();
            CreateMap<Employee, EmployeeDto>();
            
            CreateMap<AddTaskCommand, Task>();
            CreateMap<Task, TaskDto>();
        }
    }
}