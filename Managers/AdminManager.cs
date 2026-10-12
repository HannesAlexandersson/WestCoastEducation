using System;
using WestCoastEducation.Models;

namespace WestCoastEducation.Managers;

public class AdminManager : PersonnelManager<Admin>
{
    private readonly List<Admin> _admins;

    public AdminManager(List<Admin> admins) : base(admins) // base refers to the parent class, in this case the PersonnelManager
    {
        _admins = admins;
    }

    public void AddNewAdmin()
    {
        AddNewPersonnel("admins.json", "Admin"); // use the new genric method of adding new adminsitrive personell
    }
}
