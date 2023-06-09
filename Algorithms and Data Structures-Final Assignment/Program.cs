
using System;
using System.Collections.Generic;
//using stackoverflow
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> ingredients = new Dictionary<string, int>()
        {
            { "Ham", 72 },
            { "Bologna", 57 },
            { "Chicken", 17 },
            { "Corned Beef", 53 },
            { "Salami", 40 },
            { "Cheese, American", 104 },
            { "Cheese, Cheddar", 113 },
            { "Cheese, Havarti", 105 },
            { "Mayonnaise", 94 },
            { "Mustard", 10 },
            { "Butter", 102 },
            { "Garlic Aioli", 100 },
            { "Sriracha", 15 },
            { "Dressing, Ranch", 73 },
            { "Dressing, 1000 Island", 59 },
            { "Lettuce", 5 },
            { "Tomato", 4 },
            { "Cucumber", 4 },
            { "Banana Pepper", 10 },
            { "Green Pepper", 3 },
            { "Red Onion", 6 },
            { "Spinach", 7 },
            { "Avocado", 64 }
        };

        Console.Write("Enter your minimum range of calories that you want to make your sandwich: ");
        int minCalories = int.Parse(Console.ReadLine());
        Console.Write("Enter your maximum range of calories that you want to make your sandwich: ");
        int maxCalories = int.Parse(Console.ReadLine());
        Console.Write("Do you want to exclude any ingredients?");
        string[] exclusions = Console.ReadLine().Split(",");
        //this method learned from microsoft.com
        Dictionary<string, int> updatedIngredients = new Dictionary<string, int>(ingredients, StringComparer.OrdinalIgnoreCase);
        List<string> titleExclusions = new List<string>();
        foreach (string exclusion in exclusions)
        {
            string lowercaseExclusion = exclusion.ToLower().Trim();

            //learned from udemy.com's online lessons
            string titleExclusion = char.ToUpper(lowercaseExclusion[0]) + lowercaseExclusion.Substring(1);
            titleExclusions.Add(titleExclusion);
            if (lowercaseExclusion == "bread")
            {
                Console.WriteLine("Sandwiches must include bread.");
            }
            else if (updatedIngredients.ContainsKey(lowercaseExclusion))
            {
                updatedIngredients.Remove(lowercaseExclusion);
            }
        }
        Console.WriteLine($"Excluding:{string.Join(" and ", titleExclusions)}");

        int totalCal = 132; // Initially 132 for 2 slices of bread
        List<string> sandwich = new List<string> { "Adding Bread (66 calories)" };
        bool finished = false;
        while (!finished)
        {
            foreach (KeyValuePair<string, int> ingredient in updatedIngredients)
            {
                if (totalCal + ingredient.Value <= maxCalories)
                {
                    totalCal += ingredient.Value;
                    sandwich.Add($"Adding {ingredient.Key} ({ingredient.Value} calories)");
                }
                if (totalCal >= minCalories)
                {
                    finished = true;
                    break;
                }
            }
        }

        sandwich.Add("Adding Bread (66 calories)");
        Console.WriteLine(string.Join("\n", sandwich));
        Console.WriteLine($"Your sandwich, with {totalCal} calories, is ready. Enjoy!");
    }
}
