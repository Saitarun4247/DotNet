using System;
using System.Text;
using System.Collections.Generic;

public class SolutionDefault
{
    public static void Main()
    {
        string word1 = Console.ReadLine();
        string word2 = Console.ReadLine();

        HashSet<char> secondWordChars = new HashSet<char>();
        foreach (char c in word2.ToLower())
        {
            secondWordChars.Add(c);
        }

        StringBuilder filtered = new StringBuilder();

        foreach (char c in word1)
        {
            char lower = char.ToLower(c);

            bool isVowel = "aeiou".Contains(lower);

            if (isVowel || !secondWordChars.Contains(lower))
            {
                filtered.Append(c);
            }
        }

        StringBuilder result = new StringBuilder();
        char prev = '\0';

        foreach (char c in filtered.ToString())
        {
            char lower = char.ToLower(c);

            if (lower != prev)
            {
                result.Append(c);
                prev = lower;
            }
        }

        Console.WriteLine(result.ToString());
    }
}
