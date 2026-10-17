using System;
using WestCoastEducation.Classes;

using WestCoastEducation.Interfaces;
using WestCoastEducation.Menus;
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
        adminPersonalProps.TeachingCourses // this is not actually courses that the handler teaches but courses the handler is handling. it doesnt make any sence to me have the admin personall teach classes, but again the assignment says tha these types should have EVERYTHING the teachers have so my solution is to only ask for one set of courses and use that for what courses the educational leader/handler have responsibilty for
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
