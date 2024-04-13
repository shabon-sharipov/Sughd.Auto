using AutoMapper;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Automapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        MapCar();
        MapModel();
        MapMarka();
    }
   
    private void MapCar()
    {
        CreateMap<CarRequestModel, Car>();
        CreateMap<Car, CarResponseModel>()
            .ForMember(c 
                => c.UserName, o 
                => o.MapFrom(c => c.User.UserName));
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