using System.Text.Json.Serialization;

public class FeatureCollection
{
    // Tells C# to specifically look for the JSON array called "features"
    [JsonPropertyName("features")]
    public Feature[] Features { get; set; }
}

public class Feature
{
    // Tells C# to look for the "properties" object inside each feature
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }
}

public class Properties
{
    // Tells C# to grab the "place" string
    [JsonPropertyName("place")]
    public string Place { get; set; }

    // Tells C# to grab the "mag" number 
    [JsonPropertyName("mag")]
    public double? Mag { get; set; }
}