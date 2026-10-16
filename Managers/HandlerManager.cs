using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Models;

namespace WestCoastEducation.Managers;

public class HandlerManager : PersonnelManager<Handler>
{
    private readonly ApplicationData _data;
    public HandlerManager(ApplicationData data) : base(data.Handlers)
    {
        _data = data;
    }

    public void AddNewHandler()
    {
        AddNewPersonnel("handlers.json", "Handler"); // use the new genric method of adding new adminsitrive personell
    }
}
