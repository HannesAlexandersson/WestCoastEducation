using Microsoft.Extensions.DependencyInjection;
using WestCoastEducation.Factories;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Managers;
using WestCoastEducation.Models;
using WestCoastEducation.Storage;

namespace WestCoastEducation.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWestCoastEducation(this IServiceCollection services)
    {
        services.AddSingleton<IDataFilePathProvider>(
            _ => new DataFilePathProvider(Path.Combine(Environment.CurrentDirectory, "Data")));
        services.AddSingleton(typeof(IDatabase<>), typeof(DataBase<>));

        services.AddSingleton<List<Student>>(provider =>
            provider.GetRequiredService<IDatabase<Student>>().Read("students.json"));
        services.AddSingleton<List<Teacher>>(provider =>
            provider.GetRequiredService<IDatabase<Teacher>>().Read("teachers.json"));
        services.AddSingleton<List<Course>>(provider =>
            provider.GetRequiredService<IDatabase<Course>>().Read("courses.json"));
        services.AddSingleton<List<Admin>>(provider =>
            provider.GetRequiredService<IDatabase<Admin>>().Read("admins.json"));
        services.AddSingleton<List<Handler>>(provider =>
            provider.GetRequiredService<IDatabase<Handler>>().Read("handlers.json"));

        services.AddSingleton<IStudentFactory, StudentFactory>();
        services.AddSingleton<ITeacherFactory, TeacherFactory>();
        services.AddSingleton<ICourseFactory, CourseFactory>();
        services.AddSingleton(typeof(IPersonnelFactory<>), typeof(PersonnelFactory<>));

        services.AddSingleton<StudentManager>();
        services.AddSingleton<TeacherManager>();
        services.AddSingleton<AdminManager>();
        services.AddSingleton<HandlerManager>();
        services.AddSingleton<CourseManager>();
        services.AddSingleton<Menu>();
        services.AddSingleton<App>();

        return services;
    }
}
