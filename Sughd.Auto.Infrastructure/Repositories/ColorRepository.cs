using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class ColorRepository : Repository<Color>, IColorRepository
{
    public ColorRepository(EFContext context) : base(context)
    {
    }
}