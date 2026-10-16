using System;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;
using WestCoastEducation.Storage;

namespace WestCoastEducation.Services;

public class StudentServices : IService<Student>
{
    public List<Student> GetList()
    {
        var db = new DataBase<Student>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/students.json");
        var courses = db.Read(path);
        return courses;
    }
}
