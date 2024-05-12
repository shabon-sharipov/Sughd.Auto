﻿using AutoMapper;
using Sughd.Auto.Application.AuthServices.ResponseModels;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.AuthModel;
using Sughd.Auto.Domain.Models;
using UserResponseModel = Sughd.Auto.Application.AuthServices.ResponseModels.UserResponseModel;

namespace Sughd.Auto.Application.Automapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        MapCar();
        MapModel();
        MapMarka();
        MapRole();
        UserMap();
    }

    private void UserMap()
    {
        CreateMap<User, UserResponseModel>();
        CreateMap<UserUpdateRequestModel, User>();
    }
    
    private void MapCar()
    {
        CreateMap<CarRequestModel, Car>();
        CreateMap<Car, CarResponseModel>()
            .ForMember(cr
                => cr.MarkaName, c
                => c.MapFrom(c => c.Marka.Name))
            .ForMember(cr
                => cr.ModelName, c
                => c.MapFrom(c => c.Model.Name));
    }

    private void MapModel()
    {
        CreateMap<CarModelRequestModel, Model>();
        CreateMap<Model, CarModelResponseModel>()
            .ForMember(
                c
                => c.MarkaName, o
                => o.MapFrom(c => c.Marka.Name));
    }
    
    private void MapMarka()
    {
        CreateMap<CarMarkaRequestModel, Marka>();
        CreateMap<Marka, CarMarkaResponsModel>();
    }

    private void MapRole()
    {
        CreateMap<Role, RoleResponseModel>();
    }
}