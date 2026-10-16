using System;
using WestCoastEducation.Factories;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;

namespace WestCoastEducation.Managers;

public class AdminManager : PersonnelManager<Admin>
{
    public AdminManager(
        List<Admin> admins,
        List<Course> courses,
        IDatabase<Admin> database,
        IPersonnelFactory<Admin> personnelFactory)
        : base(admins, courses, database, personnelFactory)
    {
    }

    public void AddNewAdmin()
    {
        AddNewPersonnel("admins.json", "Admin"); // use the new genric method of adding new adminsitrive personell
    }
}
