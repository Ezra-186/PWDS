public static class UniqueLetters
{
    public static void Run()
    {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True because its an empty string
    }

    /// <summary>Determine if there are any duplicate letters in the text provided</summary>
    /// <param name="text">Text to check for duplicate letters</param>
    /// <returns>true if all letters are unique, otherwise false</returns>
    private static bool AreUniqueLetters(string text)
    {
        // Use a set so each letter is stored at most once
        var seenLetters = new HashSet<char>();

        // Look at each character in the string one time
        foreach (var letter in text)
        {
            // If the set already has this letter, we found a duplicate
            if (seenLetters.Contains(letter))
                return false;

            // Otherwise remember this letter for later checks
            seenLetters.Add(letter);
        }

        // We finished the loop without finding duplicates, so all letters are unique
        return true;
    }
}