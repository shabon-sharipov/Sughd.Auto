using AutoMapper;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Automapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        MapCustomers();
    }

    private void MapCustomers()
    {
        CreateMap<CustomerRequestModel, Customer>();
        CreateMap<Customer, CustomerResponseModel>();
    }
}