using System;
using System.Globalization;
using System.Reflection.Metadata;

////class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("Enter a date in format 'dd/mm/yyyy': ");

//        //try
//        //{
//            DateTime userDate = ReadDateFromUser();
//            Console.WriteLine($"You entered a valid date:{userDate.ToString("dd/MM/yyyy")}");
//        //}
//        //catch (FormatException)
//        //{
//        //    Console.WriteLine("Invalid date format. PLease enter the date in the format 'dd/mm/yyyy'.");

//        //}
//        //catch (Exception ex)
//        //{
//        //    Console.WriteLine($"An unexpected error occurred:{ex.Message}");

//        //}
//    }
//    //static DateTime ReadDateFromUser()
//    {
//        //string input = Console.ReadLine();

//        if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
//        {
//            return result;
//        }
//        else
//        {
//            throw new FormatException("The provided date format is invalid.");
//        }
//    }
//}




//class Myayuuuuuuu
//{
//    static void Main(string[] args)
//    {
//        Console.Write("Enter the number to find it's square root: ");

//        try
//        {
//            double number = ReadNumFromUser();
//            double squareRoot = Math.Sqrt(number);
//            Console.WriteLine($"The square root of {number} is {squareRoot}");
//        }
//        catch (ArgumentOutOfRangeException)
//        {
//            Console.WriteLine($"ENTER THE POSSITIVE NUMBER!!!!!!");
//        }
//        catch (FormatException)
//        {
//            Console.WriteLine($"PLEASE ENTER THE NUMERIC VALUE@!!!!!!!");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"An unexpected error! {ex.Message}");
//        }
//    }
//    static double ReadNumFromUser()
//    {
//        string input = Console.ReadLine();

//        if (double.TryParse(input, out double number))
//        {
//            if (number < 0)
//            {
//                throw new ArgumentOutOfRangeException("number", "Cannot find the square root of negative number.");
//            }
//            return number;
//        }
//        else
//        {
//            throw new FormatException("Input is not valid number.");
//        }
//    }

//}

//class Smoothie
//{
//    private static readonly Dictionary<string, double> IngredientPrices = new Dictionary<string, double>
//    {
//        { "Strawberries", 1.50 },
//        { "Banana", 0.50 },
//        { "Mango", 2.50 },
//        { "Blueberries", 1.00 },
//        { "Raspberries", 1.00 },
//        { "Apple", 1.75 },
//        { "Pineapple", 3.50 }
//    };

//    public List<string> Ingredients { get; }

//    public Smoothie(List<string> ingredients)
//    {
//        Ingredients = ingredients;
//    }

//    public double GetCost()
//    {
//        return Ingredients.Sum(ingredient => IngredientPrices[ingredient]);
//    }

//    public double GetPrice()
//    {
//        return Math.Round(GetCost() * 2.5, 2);
//    }

//    public string GetName()
//    {
//        var sortedIngredients = Ingredients
//            .Select(ingredient => ingredient.Replace("berries", "berry"))
//            .OrderBy(ingredient => ingredient)
//            .ToList();

//        string name = string.Join(" ", sortedIngredients);
//        return sortedIngredients.Count > 1 ? $"{name} Fusion" : $"{name} Smoothie";
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        var smoothie = new Smoothie(new List<string> { "Strawberries", "Banana" });

//        Console.WriteLine($"Cost: £{smoothie.GetCost():0.00}");
//        Console.WriteLine($"Price: £{smoothie.GetPrice():0.00}");
//        Console.WriteLine($"Name: {smoothie.GetName()}");
//    }
//}


public interface ITestpaper
{
    string Subject { get; }
    string[] MarkScheme {  get; }
    string PassMark { get; }
}

public interface IStudent
{
    string[] TestsTaken { get; }
    void TakeTest(ITestpaper paper, string[] answers);
}


public class TestPaper : ITestpaper
{
    public string Subject { get; private set; }
    public string[] MarkScheme { get; private set; }
    public string PassMark { get; private set; }

    public TestPaper(string subject, string[] markScheme, string passMark)
    {
        Subject = subject;
        MarkScheme = markScheme;
        PassMark = passMark;
    }
}

public class Student : IStudent
{
    private List<string> _testsTaken = new List<string>();

    public string[] TestsTaken
    {
        get => _testsTaken.Count > 0 ? _testsTaken.ToArray() : new string[] { "No tests taken" };
    }

    public void TakeTest(ITestpaper paper, string[] answers)
    {
        int correctAnswers = 0;

        for (int i = 0; i < paper.MarkScheme.Length; i++)
        {
            if (i < answers.Length && answers[i] == paper.MarkScheme[i])
            {
                correctAnswers++;
            }

        }

        int score = (correctAnswers * 100) / paper.MarkScheme.Length;
        int passMark = int.Parse(paper.PassMark.TrimEnd('%'));

        string result = score >= passMark ? $"{paper.Subject}: Passed!!!({score}%)" : $"{paper.Subject}: Failed!!!({score}%)";

        _testsTaken.Add(result);

    } 
}

class Programmmmmmmmmmm
{
    static void Main()
    {
        TestPaper paper1 = new TestPaper("Maths", new string[] { "1A", "2C", "3D", "4A", "5A" }, "50%");
        TestPaper paper2 = new TestPaper("Chemistry", new string[] { "1C", "2D", "3B", "4C" }, "75%");
        TestPaper paper3 = new TestPaper("Computing", new string[] { "1D", "2C", "3C", "4B", "5D" }, "60%");

        Student student1 = new Student();
        Student student2 = new Student();

        Console.WriteLine(string.Join(", ", student1.TestsTaken));

        student1.TakeTest(paper1, new string[] { "1A", "2C", "3D", "4A", "5A" });
        Console.WriteLine(string.Join(", ", student1.TestsTaken));

        student2.TakeTest(paper2, new string[] { "1C", "2D", "3B" });
        Console.WriteLine(string.Join(", ", student2.TestsTaken));
    }
}
