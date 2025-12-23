
public class HeightCategory
{
    public static void PrintCategory()
    {
        Console.Write("Enter height in cm: ");
        string input = Console.ReadLine();
        int height;
        if (!int.TryParse(input, out height))
        {
            Console.WriteLine("Invalid input. Please enter a numeric value.");
            return;
        }
        if (height < 150)
        {
            Console.WriteLine("Dwarf");
        }
        else if (height >= 150 && height < 165)
        {
            Console.WriteLine("Average");
        }
        else if (height >= 165 && height <= 190)
        {
            Console.WriteLine("Tall");
        }
        else
        {
            Console.WriteLine("Abnormal");
        }
    }
}

