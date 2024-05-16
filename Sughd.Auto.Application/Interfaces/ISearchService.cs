using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces;

public interface ISearchService
{
    Task<List<CarResponseModel>> Search(SearchCarRequestModel searchCarRequestModel);
    Task<List<UserInfoForSaleCarResponseModel>> SearchByPhoneNumber(string phoneNumber);
    Task<List<CarMarkaResponsModel>> SearchByMarkaName(string markaName);
}