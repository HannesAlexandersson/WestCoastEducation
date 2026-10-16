using System;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;

namespace WestCoastEducation.Classes;
// a class that tells the DI services how to obtains the required lists needed to create the managers
public class ApplicationData
{
    public List<Course> Courses { get; } = [];
    public List<Teacher> Teachers { get; } = [];
    public List<Student> Students { get; } = [];
    public List<Handler> Handlers { get; } = [];
    public List<AdminPersonel> Admins { get; } = [];

    public ApplicationData(IService<Course> courseService)
    {
        Courses = courseService.GetList();
    }
}
