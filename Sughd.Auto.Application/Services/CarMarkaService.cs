﻿using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;

namespace Sughd.Auto.Application.Services;

public class CarMarkaService : BaseService<CarMarkaRequestModel, CarMarkaResponsModel>, ICarMarkaService
{
}