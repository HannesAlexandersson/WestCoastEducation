using System;

namespace WestCoastEducation.Managers;

public class HandlerManager : PersonnelManager<Handler>
{
    private readonly List<Handler> _handlers;

    public HandlerManager(List<Handler> handlers) : base(handlers)
    {
        _handlers = handlers;
    }

    public void AddNewHandler()
    {
        AddNewPersonnel("handlers.json", "Handler"); // use the new genric method of adding new adminsitrive personell
    }
}
