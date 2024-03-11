using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class CustomerService : BaseService<Customer, CustomerRequestModel, CustomerResponseModel>, ICustomerService
{
    public CustomerService()
    {
    }
}