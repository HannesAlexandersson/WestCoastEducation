using System;
using WestCoastEducation.Factories;
using WestCoastEducation.Interfaces;

namespace WestCoastEducation.Managers;

public class HandlerManager : PersonnelManager<Handler>
{
    public HandlerManager(
        List<Handler> handlers,
        List<Course> courses,
        IDatabase<Handler> database,
        IPersonnelFactory<Handler> personnelFactory)
        : base(handlers, courses, database, personnelFactory)
    {
    }

    public void AddNewHandler()
    {
        AddNewPersonnel("handlers.json", "Handler"); // use the new genric method of adding new adminsitrive personell
    }
}
