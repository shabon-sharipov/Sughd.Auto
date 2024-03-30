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
        MapWorker();
        MapCar();
        MapModel();
        MapMarka();
    }

    private void MapCustomers()
    {
        CreateMap<CustomerRequestModel, Customer>();
        CreateMap<Customer, CustomerResponseModel>();
    }

    private void MapWorker()
    {
        CreateMap<WorkerRequestModel, Worker>();
        CreateMap<Worker, WorkerResponseModel>();
    }

    private void MapCar()
    {
        CreateMap<CarRequestModel, Car>();
        CreateMap<Car, CarResponseModel>();
    }

    private void MapModel()
    {
        CreateMap<CarModelRequestModel, Model>();
        CreateMap<Model, CarModelResponseModel>();
    }
    
    private void MapMarka()
    {
        CreateMap<CarMarkaRequestModel, Marka>();
        CreateMap<Marka, CarMarkaResponsModel>();
    }
}