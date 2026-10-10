using System;

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

}
