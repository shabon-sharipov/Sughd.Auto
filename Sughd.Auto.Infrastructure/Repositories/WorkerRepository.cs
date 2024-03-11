using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class WorkerRepository : Repository<Worker>, IWorkerRepository
{
    public WorkerRepository(EFContext context) : base(context)
    {
    }
}