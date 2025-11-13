// Basketball.cs
/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using System.Linq;
using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        // Map from player id to the total points scored in all seasons
        var players = new Dictionary<string, int>();

        // Open the CSV file and set it up as a comma separated reader
        using var reader = new TextFieldParser("../../../basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");

        reader.ReadFields(); // Skip the header row

        // Read each season row and add that season points into the map
        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!; // All columns in this line
            var playerId = fields[0];          // Column 0 is the player id
            var points = int.Parse(fields[8]); // Column 8 is the points for that season

            // Add this season to the running total for that player
            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;   // Player already seen, add to existing total
            }
            else
            {
                players[playerId] = points;    // First time we see this player, start their total
            }
        }

        // Turn the map into an array so we can sort it
        var topPlayers = players.ToArray();

        // Sort by total points in descending order
        Array.Sort(topPlayers, (p1, p2) => p2.Value - p1.Value);

        // Print a blank line, then show the top 10 players and their totals
        Console.WriteLine();
        for (var i = 0; i < 10 && i < topPlayers.Length; ++i)
        {
            Console.WriteLine(topPlayers[i]);  // Writes "[playerId, totalPoints]"
        }
    }
}
