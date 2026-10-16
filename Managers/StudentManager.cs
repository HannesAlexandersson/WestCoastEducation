using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Models;

namespace WestCoastEducation.Managers;

public class StudentManager
{
    private readonly ApplicationData _data;

    public StudentManager(ApplicationData data)
    {
        _data = data;
    }

    public void ListStudentData(string prop)
    {
        int counter;
        counter = 0;
        foreach (var student in _data.Students)
        {
            counter++;
            if (prop == "name")
            {
                Console.WriteLine($"{counter}. {student.FirstName} {student.LastName} - id: {student.StudentId}.");
            }
            else if (prop == "email")
            {
                Console.WriteLine($"{counter}. {student.StudentId} - {student.Email}");
            }
            else if (prop == "phone")
            {
                Console.WriteLine($"{counter}. {student.StudentId} - {student.PhoneNumber}");
            }
            else if (prop == "address")
            {
                Console.WriteLine($"{counter}. {student.FirstName} {student.LastName} -");
                foreach (var address in student.Addresses)
                {
                    Console.WriteLine(
                        $" {address.StreetAddress}, {address.PostalCode} {address.City}");
                }
            }
        }
    }

    public void AddNewStudent()
    {
        Person personData = Helper.PromptForPerson("student");
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("please make sure that all info is correct before proceeding...");
        Console.ReadKey();
        bool allFieldsCorrect = false;
        while (!allFieldsCorrect)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();

            personData.FirstName = Helper.ValidateStringInput("Firstname", personData.FirstName);
            Console.Clear();

            personData.LastName = Helper.ValidateStringInput("Lastname", personData.LastName);
            Console.Clear();

            personData.Addresses[0].StreetAddress =
                Helper.ValidateStringInput("Address", personData.Addresses[0].StreetAddress);
            Console.Clear();

            personData.Addresses[0].PostalCode =
                Helper.ValidateIntInput("Postal code", personData.Addresses[0].PostalCode);
            Console.Clear();

            personData.Addresses[0].City =
                Helper.ValidateStringInput("City", personData.Addresses[0].City);
            Console.Clear();

            personData.PhoneNumber =
                Helper.ValidateStringInput("Phonenumber", personData.PhoneNumber);
            Console.Clear();

            personData.Email =
                Helper.ValidateStringInput("Email", personData.Email ?? ""); // its allowed for a person to not have an email, so leave it empty if they dont have one
            Console.Clear();

            Console.WriteLine("NEW STUDENT FIELDS:");
            Console.WriteLine($"{personData.FirstName} {personData.LastName}");
            Console.WriteLine($"{personData.Addresses[0].StreetAddress} {personData.Addresses[0].PostalCode} {personData.Addresses[0].City}");
            Console.WriteLine(personData.PhoneNumber);
            Console.WriteLine(personData.Email);

            allFieldsCorrect = Helper.ConfirmInput();
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Press any key to generate a studentId for the student");
        Console.ReadKey();
        Guid id = Helper.GenerateGuid();
        Console.WriteLine($" StudentId created: {id}. Press any key to add the new student into the database...");
        Console.ReadKey();
        Thread.Sleep(550);
        Console.WriteLine("Please wait while the system adds the student to the database...");
        Thread.Sleep(550);
        // construct the new Student object with all the user inputted fields
        Student newStudent = new()
        {
            StudentId = id,
            FirstName = personData.FirstName,
            LastName = personData.LastName,
            PhoneNumber = personData.PhoneNumber,
            Email = personData.Email,
            Addresses = personData.Addresses
        };
        Thread.Sleep(550);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Connecting to database...");
        Thread.Sleep(550);
        // add the new student to the students list
        _data.Students.Add(newStudent);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        DatabaseHandler.SaveList("students.json", _data.Students);
        Console.WriteLine($"{personData.FirstName} {personData.LastName} added to the rolls in the database!");
        Menu.ReturnToMenu();

    }

}
