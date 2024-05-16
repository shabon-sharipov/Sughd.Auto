using AutoMapper;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class SearchService(
    ICarRepository carRepository,
    IUserRepository userRepository,
    ICarMarkaRepository markaRepository,
    IMapper mapper) : ISearchService
{
    public async Task<List<CarResponseModel>> Search(SearchCarRequestModel searchCarRequestModel)
    {
        var result = await carRepository.Search(searchCarRequestModel);

        return mapper.Map<List<CarResponseModel>>(result);
    }

    public async Task<List<UserInfoForSaleCarResponseModel>> SearchByPhoneNumber(string phoneNumber)
    {
        return await userRepository.SearchByPhoneNumber(phoneNumber);
    }

    public async Task<List<CarMarkaResponsModel>> SearchByMarkaName(string markaName)
    {
        var test = await markaRepository.SearchByMarkaName(markaName);

        return mapper.Map<List<CarMarkaResponsModel>>(test);
    }
}