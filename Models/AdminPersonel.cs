namespace WestCoastEducation.Models;

public record class AdminPersonel : Teacher
{
    public DateTime DateOfEmployment { get; set; }
}
