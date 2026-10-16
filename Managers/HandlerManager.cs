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
        AddNewPersonnel("handlers.json", "Handler"); // use the new genric method of adding new adminsitrive personell
    }
}
