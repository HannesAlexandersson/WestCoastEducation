using System;
using System.ComponentModel.DataAnnotations;

namespace WestCoastEducation;

public class Helper
{
    public static string PromptUserForStringInput(string prompt)
    {
        bool incorrect = true;
        string userInput = "";
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.CursorVisible = true;
        while (incorrect)
        {
            Console.WriteLine(prompt);
            Console.ForegroundColor = ConsoleColor.Green;
            userInput = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please try again, type with the letter keys...");
                Console.ResetColor();
            }
            else
            {
                incorrect = false;
            }
        }
        return userInput;
    }
    public static int PromptUserForIntInput(string prompt)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.CursorVisible = true;
        while (true)
        {
            Console.WriteLine(prompt);
            Console.ForegroundColor = ConsoleColor.Green;
            var userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please try again, ONLY use numbers...");
                Console.ResetColor();
            }
            else if (int.TryParse(userInput, out int result))
            {
                return result;
            }
        }
    }

    public static DateTime PromptUserForDateInput(string prompt)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.CursorVisible = true;

        while (true)
        {
            Console.WriteLine($"{prompt} (yyyy-MM-dd)");
            Console.ForegroundColor = ConsoleColor.Green;
            var userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input cannot be empty, please try again.");
                Console.ResetColor();
            }
            else if (DateTime.TryParseExact(
                         userInput,
                         "yyyy-MM-dd",
                         System.Globalization.CultureInfo.InvariantCulture,
                         System.Globalization.DateTimeStyles.None,
                         out DateTime result))
            {
                return result;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid date. Use the format yyyy-MM-dd, e.g. 2026-10-10.");
                Console.ResetColor();
            }
        }
    }

    public static void CheckInput()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid selection. Please try again.");
        Console.ResetColor();
        Console.ReadKey();
    }

    public static Guid GenerateGuid()
    {
        Guid newGuid = Guid.NewGuid();
        return newGuid;
    }

    public static string ValidateStringInput(string nameOfInput, string input)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{nameOfInput}: {input}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"If {nameOfInput} is correct, press 'Y'. To change the {nameOfInput} press 'N' ");
            Console.ForegroundColor = ConsoleColor.Green;
            var userInput = Console.ReadLine()?.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please press a key");
                Console.ResetColor();
            }
            else if (userInput != "n" && userInput != "y")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please only answer with 'Y' or 'N'");
                Console.ResetColor();
                continue;
            }
            else if (userInput == "y")
            {
                return input;
            }
            else if (userInput == "n")
            {
                return PromptUserForStringInput($"Enter the {nameOfInput}");

            }
        }
    }
    public static int ValidateIntInput(string nameOfInput, int input)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{nameOfInput}: {input}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"If {nameOfInput} is correct, press 'Y'. To change the {nameOfInput} press 'N' ");
            Console.ForegroundColor = ConsoleColor.Green;
            var userInput = Console.ReadLine()?.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please press a key");
                Console.ResetColor();
            }
            else if (userInput != "n" && userInput != "y")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please only answer with 'Y' or 'N'");
                Console.ResetColor();
                continue;
            }
            else if (userInput == "y")
            {
                return input;
            }
            else if (userInput == "n")
            {
                return PromptUserForIntInput($"Enter the {nameOfInput}");
            }
        }
    }
    public static DateTime ValidateDateInput(string nameOfInput, DateTime input)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{nameOfInput}: {input:yyyy-MM-dd}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"If {nameOfInput} is correct, press 'Y'. To change the {nameOfInput} press 'N'");

            Console.ForegroundColor = ConsoleColor.Green;
            var userInput = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input, please press a key");
                Console.ResetColor();
            }
            else if (userInput != "n" && userInput != "y")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please only answer with 'Y' or 'N'");
                Console.ResetColor();
                continue;
            }
            else if (userInput == "y")
            {
                return input;
            }
            else if (userInput == "n")
            {
                return PromptUserForDateInput($"Enter the {nameOfInput}");
            }
        }
    }

    public static void Terminate()
    {
        Environment.Exit(0);
    }

    public static bool ConfirmInput()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Is all fields correct? Y/N");
            Console.ForegroundColor = ConsoleColor.Green;
            var userCheck = Console.ReadLine()?.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(userCheck))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input value! Please answer with Y for yes or N for no!");
                Console.ResetColor();
                continue;
            }
            else if (userCheck != "y" && userCheck != "n")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please only answer with 'Y' or 'N'");
                Console.ResetColor();
                continue;
            }
            else if (userCheck == "y")
            {
                return true;
            }
            else if (userCheck == "n")
            {
                return false;
            }
        }
    }

    public static Person PromptForPerson(string nameOfObject)
    {
        string firstName = PromptUserForStringInput($"Enter {nameOfObject} firstname: ");
        string lastName = PromptUserForStringInput($"Enter {nameOfObject} lastname: ");
        string email = PromptUserForStringInput($"Enter {nameOfObject} email: ");
        string phone = PromptUserForStringInput($"Enter {nameOfObject} phonenumber: ");
        string address = PromptUserForStringInput($"Enter {nameOfObject} address: ");
        int pCode = PromptUserForIntInput($"Enter {nameOfObject} postal code: ");
        string city = PromptUserForStringInput($"Enter what city the {nameOfObject} lives in: ");

        return new Person
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phone,
            Addresses =
            [
                new Address
            {
                StreetAddress = address,
                PostalCode = pCode,
                City = city
            }
            ]
        };
    }

    public static Teacher PromptForTeacher()
    {
        FieldOfKnowledge[] subjectFields = PromptForSubjectFields();

        List<Course> teachingCourses = SelectCourses();

        return new Teacher
        {
            SubjectFields = subjectFields,
            TeachingCourses = teachingCourses.ToArray()
        };
    }

    public static FieldOfKnowledge[] PromptForSubjectFields()
    {
        List<FieldOfKnowledge> subjectFields = [];

        bool addMore = true;

        while (addMore)
        {
            string subject = PromptUserForStringInput(
                "Enter a subject field for the teacher: ");

            subjectFields.Add(new FieldOfKnowledge
            {
                NameOfSubject = subject
            });

            addMore = ConfirmInput();
        }

        return subjectFields.ToArray();
    }

    public static Guid SelectTeacher(List<Teacher> teachers)
    {

        for (int i = 0; i < teachers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {teachers[i].FirstName} {teachers[i].LastName}");
        }

        while (true)
        {
            Console.Write("\nSelect a teacher by number: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int selection) &&
                selection >= 1 &&
                selection <= teachers.Count)
            {
                return teachers[selection - 1].TeacherId;
            }

            Console.WriteLine("Invalid selection. Please try again.");
        }
    }

    public static List<Course> SelectCourses()
    {
        var courses = DatabaseHandler.GetList<Course>("courses.json");
        List<Course> selectedCourses = [];

        for (int i = 0; i < courses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {courses[i].Title}");
        }

        bool selectMore = true;

        while (selectMore)
        {
            Console.Write("\nSelect a course by number: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int selection) &&
                selection >= 1 &&
                selection <= courses.Count)
            {
                Course selectedCourse = courses[selection - 1];

                if (!selectedCourses.Contains(selectedCourse))
                {
                    selectedCourses.Add(selectedCourse);
                    Console.WriteLine($"{selectedCourse.Title} added.");
                }
                else
                {
                    Console.WriteLine("Course already selected.");
                }

                selectMore = ConfirmInput();
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

        return selectedCourses;
    }
}
