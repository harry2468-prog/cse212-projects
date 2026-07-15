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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            
            // Safely parse points. If the field is empty, default to 0.
            var points = string.IsNullOrEmpty(fields[8]) ? 0 : int.Parse(fields[8]);

            // Add or update the player's career points in the dictionary
            if (players.ContainsKey(playerId)) {
                players[playerId] += points;
            } else {
                players[playerId] = points;
            }
        }

        // Convert the dictionary to an array so we can sort it
        var sortedPlayers = players.ToArray();
        
        // Sort the players by their total points (Value) in descending order
        Array.Sort(sortedPlayers, (p1, p2) => p2.Value.CompareTo(p1.Value));

        // Create the top 10 players list and print it out
        var topPlayers = new string[10];
        
        Console.WriteLine("\nTop 10 NBA Career Scorers:");
        Console.WriteLine("--------------------------");
        for (int i = 0; i < 10 && i < sortedPlayers.Length; i++) {
            topPlayers[i] = $"{sortedPlayers[i].Key}: {sortedPlayers[i].Value}";
            Console.WriteLine($"{i + 1}. {sortedPlayers[i].Key} - {sortedPlayers[i].Value} pts");
        }
        Console.WriteLine("--------------------------");
    }
}
