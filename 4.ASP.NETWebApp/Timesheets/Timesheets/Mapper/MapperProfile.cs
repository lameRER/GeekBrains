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
            
            CreateMap<AddInvoiceCommand, Invoice>();
            CreateMap<Invoice, InvoiceDto>();
            
            CreateMap<AddEmployeeCommand, Employee>();
            CreateMap<Employee, EmployeeDto>();
            
            CreateMap<AddTaskCommand, Task>();
            CreateMap<Task, TaskDto>();
        }
    }
}