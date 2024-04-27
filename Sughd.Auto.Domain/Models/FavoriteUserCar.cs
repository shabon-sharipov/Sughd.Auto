using Sughd.Auto.Domain.Abstract;
using Sughd.Auto.Domain.AuthModel;

namespace Sughd.Auto.Domain.Models;

public class FavoriteUserCar : EntityBase
{
    public long UserId { get; set; }
    public virtual User User { get; set; }

    public long CarId { get; set; }
}