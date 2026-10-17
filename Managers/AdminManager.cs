using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;

namespace WestCoastEducation.Managers;

public class AdminManager : PersonnelManager<Admin>
{
    private readonly ApplicationData _data;
    private readonly IAdminFactory _adminFactory;
    public AdminManager(ApplicationData data, IAdminFactory adminFactory) : base(data.Admins, data) // base refers to the parent class, in this case the PersonnelManager
    {
        _data = data;
        _adminFactory = adminFactory;
    }

    public void AddNewAdmin()
    {
        var adminPersonalProps = AddNewPersonnel("Admin");

        var admin = _adminFactory.Create(
             adminPersonalProps.DateOfEmployment,
        adminPersonalProps.OfficeLocation,
        adminPersonalProps.FirstName,
        adminPersonalProps.LastName,
        adminPersonalProps.PhoneNumber,
        adminPersonalProps.Addresses,
        adminPersonalProps.Email,
        adminPersonalProps.SubjectFields,
        adminPersonalProps.TeachingCourses,
        adminPersonalProps.TeacherId
        //OBS!!!! TODO: add in the admin specefics propertys when they are added into the admin record!!
        );

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Record created, press any key to add the new admin to the payrolls...");
        Console.ReadLine();

        Console.Clear();
        Helper.SimulateInsertToDb(admin.FirstName, admin.LastName);

        _data.Admins.Add(admin);
        DatabaseHandler.SaveList("admins.json", _data.Admins);
        Menu.ReturnToMenu();
    }
}
