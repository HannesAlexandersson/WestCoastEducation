using System;
using WestCoastEducation.Models;

namespace WestCoastEducation.Interfaces;

public interface ICourseFactory
{// we say that whenever anyone uses the interface they must implement the 'Create' method 
    Course Create(
            string title,
            int courseLength,
            DateTime startDate,
            DateTime endDate,
            Guid[] teacherIds,
            CourseType courseType);
}
