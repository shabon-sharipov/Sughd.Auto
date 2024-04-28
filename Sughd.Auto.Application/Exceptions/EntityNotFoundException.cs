namespace Sughd.Auto.Application.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string errorMassage) : base(errorMassage)
    {
        
    }
}