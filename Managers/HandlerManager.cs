using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Factories;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;

namespace WestCoastEducation.Managers;

public class HandlerManager : PersonnelManager<Handler>
{
    private readonly ApplicationData _data;
    private readonly IHandlerFactory _handlerFactory;

    public HandlerManager(ApplicationData data, IHandlerFactory handlerFactory) : base(data.Handlers, data)
    {
        _data = data;
        _handlerFactory = handlerFactory;
    }

    public void AddNewHandler()
    {
        // get the shared propertys
        var adminPersonalProps = AddNewPersonnel("Handler");
        // get handler specefic propertys
        var handlingCourses = Helper.SelectCourses(_data.Courses).ToArray();

        var handler = _handlerFactory.Create(
        adminPersonalProps.DateOfEmployment,
        adminPersonalProps.OfficeLocation,
        adminPersonalProps.FirstName,
        adminPersonalProps.LastName,
        adminPersonalProps.PhoneNumber,
        adminPersonalProps.Addresses,
        adminPersonalProps.Email,
        adminPersonalProps.SubjectFields,
        adminPersonalProps.TeachingCourses,
        adminPersonalProps.TeacherId,
        handlingCourses
    );
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Record created, press any key to add the new handler to the payrolls...");
        Console.ReadLine();

        Console.Clear();
        Helper.SimulateInsertToDb(handler.FirstName, handler.LastName);

        _data.Handlers.Add(handler);
        DatabaseHandler.SaveList("handlers.json", _data.Handlers);
        Menu.ReturnToMenu();
    }
}
