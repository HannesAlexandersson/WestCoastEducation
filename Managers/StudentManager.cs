using System;
using System.Reflection.Metadata.Ecma335;

namespace WestCoastEducation.Managers;

public class StudentManager
{
    private readonly List<Student> _students;

    public StudentManager(List<Student> students)
    {
        _students = students; // we set the list of students that we get from App when we create the Studentmanager to its own backing field for use in this class
    }

    public void ListStudentData(string prop)
    {
        int counter;
        counter = 0;
        foreach (var student in _students)
        {
            counter++;
            if (prop == "name")
            {
                Console.WriteLine($"\e[0;34m{counter}. \e[0;33m{student.FirstName} {student.LastName} \e[0;37m- \e[0;36mid: {student.StudentId}.\e[0m");
            }
            else if (prop == "email")
            {
                Console.WriteLine($"\e[0;33m{counter}. \e[0;34m{student.StudentId} \e[0;37m- \e[0;36m{student.Email}\e[0m");
            }
            else if (prop == "phone")
            {
                Console.WriteLine($"\e[0;33m{counter}. \e[0;34m{student.StudentId} \e[0;37m- \e[0;36m{student.PhoneNumber}\e[0m");
            }
            else if (prop == "address")
            {
                Console.WriteLine($"\e[0;33m{counter}. \e[0;34m{student.FirstName} {student.LastName} \e[0;37m-");
                foreach (var address in student.Addresses)
                {
                    Console.WriteLine(
                        $" \e[0;36m{address.StreetAddress}, {address.PostalCode} {address.City}\e[0m");
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
        // if user confirm everything we construct the new Student object with all the user-inputted fields
        Student newStudent = new()
        {
            FirstName = personData.FirstName,
            LastName = personData.LastName,
            PhoneNumber = personData.PhoneNumber,
            Email = personData.Email,
            Addresses = personData.Addresses
        };
        // check for if student already exists in list
        if (Helper.CheckForDuplicates(_students, newStudent))
        {
            Console.WriteLine("ERROR!!! Student already exists in the rolls! Press any key to return to menu...");
            Console.ReadLine();
            return;
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
        // add the generated uuid to the student object
        newStudent.StudentId = id;
        Thread.Sleep(550);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Connecting to database...");
        Thread.Sleep(550);
        // add the new student to the students list
        _students.Add(newStudent);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        DatabaseHandler.SaveList("students.json", _students);
        Console.WriteLine($"{personData.FirstName} {personData.LastName} added to the rolls in the database!");
        Menu.ReturnToMenu();

    }

}
