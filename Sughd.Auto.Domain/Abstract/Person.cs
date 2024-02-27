namespace Sughd.Auto.Domain.Abstract;

public class Person : EntityBase
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNamber { get; set; }

    //TODO need use enum
    public string Status { get; set; }

    public string DateOfBirthday { get; set; }
}