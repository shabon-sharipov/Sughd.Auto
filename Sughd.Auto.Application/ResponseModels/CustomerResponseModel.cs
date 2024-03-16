namespace Sughd.Auto.Application.ResponseModels;

public class CustomerResponseModel
{
    public long Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNamber { get; set; }

    //TODO need use enum
    public string Status { get; set; }

    public string DateOfBirthday { get; set; }
}