using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Models;

namespace WestCoastEducation.Managers;

public class AdminManager : PersonnelManager<Admin>
{
    private readonly ApplicationData _data;
    public AdminManager(ApplicationData data) : base(data.Admins) // base refers to the parent class, in this case the PersonnelManager
    {
        _data = data;
    }

    public void AddNewAdmin()
    {
        AddNewPersonnel("admins.json", "Admin"); // use the new genric method of adding new adminsitrive personell
    }
}
