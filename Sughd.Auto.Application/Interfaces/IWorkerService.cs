using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;

namespace Sughd.Auto.Application.Interfaces;

public interface IWorkerService : IBaseService<WorkerRequestModel, WorkerResponseModel>
{
}