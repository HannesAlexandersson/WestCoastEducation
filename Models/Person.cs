using WestCoastEducation.Classes;

namespace WestCoastEducation.Models;

public record class Person
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public List<Address> Addresses { get; set; } = [];
    public string? Email { get; set; }
}
