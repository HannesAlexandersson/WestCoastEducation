using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Models;

namespace WestCoastEducation.Interfaces;

public interface IHandlerFactory
{
        Handler Create(
        DateTime dateOfEmployment,
        string officeLocation,
                string firstName,
        string lastName,
        string phoneNumber,
        List<Address> addresses,
        string? email,
        FieldOfKnowledge[] subjectFields,
        Course[] teachingCourses,
        Guid teacherId,
        Course[] handlingCourses
            );
}
