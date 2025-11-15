public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public string Type { get; set; } = string.Empty;
    public Metadata Metadata { get; set; } = new Metadata();
    public List<Feature> Features { get; set; } = new List<Feature>();
}
public class Metadata
{
    public long Generated { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Api { get; set; } = string.Empty;
    public int Count { get; set; }
    public int Status { get; set; }
}
public class Feature
{
    public string Type { get; set; } = string.Empty;
    public Properties Properties { get; set; } = new Properties();
}

public class Properties
{
    public double? Mag { get; set; }
    public string Place { get; set; } = string.Empty;
}
