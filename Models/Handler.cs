namespace WestCoastEducation.Models;


public record class Handler : AdminPersonel // Handler inherits from ADminPersonel that inherits from Teachers and can therefore use and access everything in the teacherclass, and the Teacher inherits from Person, so in the end Handlers have everythin Person AND Teachers AND ADMINperosnell ahve

{
    public Course[] HandlingCourses { get; set; } = [];
}
