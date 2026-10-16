namespace WestCoastEducation.Factories;

public class CourseFactory : ICourseFactory
{
    public Course Create(
        string title,
        int courseLength,
        DateTime startDate,
        DateTime endDate,
        Guid[] teacherIds,
        CourseType courseType)
    {
        return new Course
        {
            CourseId = Guid.NewGuid(),
            Title = title,
            CourseLength = courseLength,
            StartDate = startDate,
            EndDate = endDate,
            CoursePersonnelIds = teacherIds,
            CourseType = courseType
        };
    }
}
