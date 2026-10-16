namespace WestCoastEducation.Factories;

public interface IPersonnelFactory<T> where T : AdminPersonel
{
    T Create(Teacher teacher, DateTime dateOfEmployment);
}
