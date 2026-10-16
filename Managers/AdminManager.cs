using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;

namespace WestCoastEducation.Managers;

public class AdminManager : PersonnelManager<Admin>
{
    private readonly ApplicationData _data;
    // private readonly IAdminFactory _adminFactory;
    public AdminManager(ApplicationData data) : base(data.Admins, data) // base refers to the parent class, in this case the PersonnelManager
    {
        _data = data;
    }

    public void AddNewAdmin()
    {
        AddNewPersonnel("admins.json", "Admin"); // use the new genric method of adding new adminsitrive personell
    }
}
