﻿using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces;

public interface IColorService : IBaseService<Color, ColorRequestModel, ColorResponseModel>
{
}