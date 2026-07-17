using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
{
    HashSet<string> seenWords = new HashSet<string>();
    List<string> pairs = new List<string>();

    // Pre-allocate a character array so we don't recreate it 1,000,000 times
    char[] revChars = new char[2];

    foreach (string word in words)
    {
        // Manually flip the characters using our array
        revChars[0] = word[1];
        revChars[1] = word[0];
        
        // Create the reversed string instantly
        string reversed = new string(revChars);

        // If the HashSet contains the reversed word, we found a pair!
        if (seenWords.Contains(reversed))
        {
            // As long as the word isn't a palindrome (like "aa"), add it to the pairs
            if (word != reversed)
            {
                pairs.Add($"{word} & {reversed}");
            }
        }
        else
        {
            // Otherwise, just remember we've seen this word
            seenWords.Add(word);
        }
    }

    return pairs.ToArray();
}
    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>A dictionary summarizing the degree counts</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            
            // Ensure there are enough columns to avoid index errors
            if (fields.Length > 3)
            {
                // Extract the 4th column (index 3) and trim any extra spaces
                string degree = fields[3].Trim();

                // Add to dictionary or increment existing count
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Clean the words: ignore spaces and convert to lowercase
        string clean1 = word1.ToLower().Replace(" ", "");
        string clean2 = word2.ToLower().Replace(" ", "");

        // If lengths are different after cleaning, they cannot be anagrams
        if (clean1.Length != clean2.Length)
        {
            return false;
        }

        // Dictionary to count letter frequencies
        var letterCounts = new Dictionary<char, int>();

        // Count the letters in the first word
        for (int i = 0; i < clean1.Length; i++)
        {
            char letter = clean1[i];

            if (letterCounts.ContainsKey(letter))
            {
                letterCounts[letter]++;
            }
            else
            {
                letterCounts[letter] = 1;
            }
        }

        // Decrement counts and verify matches with the second word
        for (int i = 0; i < clean2.Length; i++)
        {
            char letter = clean2[i];

            // If the letter is missing or we ran out of counts for it, it's not an anagram
            if (!letterCounts.ContainsKey(letter) || letterCounts[letter] == 0)
            {
                return false;
            }

            letterCounts[letter]--;
        }

        // If all checks passed, the words are anagrams
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
{
    // 1. Fetch the JSON data from the USGS API
    const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
    using var client = new HttpClient();
    
    // Perform synchronous HTTP GET to fetch the data
    string json = client.GetStringAsync(uri).Result;

    // 2. Deserialize the JSON into the FeatureCollection objects you made
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

    // 3. Loop through the properties and format the output strings
    var result = new List<string>();
    
    if (featureCollection?.Features != null)
    {
        foreach (var feature in featureCollection.Features)
        {
            string place = feature.Properties.Place;
            double? mag = feature.Properties.Mag;

            // Add the formatted string to our result list
            result.Add($"{place} - Mag {mag}");
        }
    }

    return result.ToArray();
}
}
