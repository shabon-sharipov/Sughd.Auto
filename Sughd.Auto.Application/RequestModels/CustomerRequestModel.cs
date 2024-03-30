namespace Sughd.Auto.Application.RequestModels;

public class CustomerRequestModel
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNamber { get; set; } = string.Empty;

    //TODO need use enum
    public string Status { get; set; } = string.Empty;

    public string DateOfBirthday { get; set; } = string.Empty;
}