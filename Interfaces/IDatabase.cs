using System;

namespace WestCoastEducation.Interfaces;

public interface IDatabase<T>
{
    List<T> Read(string fileName);
    void Write(string fileName, List<T> data);
}
