namespace WestCoastEducation.Factories;

public interface ICourseFactory
{
    Course Create(
        string title,
        int courseLength,
        DateTime startDate,
        DateTime endDate,
        Guid[] teacherIds,
        CourseType courseType);
}
