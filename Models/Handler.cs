namespace WestCoastEducation;

public class Handler : Teacher // Handler inherits from Teachers and can therefore use and access everything in the teacherclass, and the Teacher inherits from Person, so in the end Handlers have everythin Person AND Teachers ahve
{
    public DateTime DateOfEmployment { get; set; }
}
