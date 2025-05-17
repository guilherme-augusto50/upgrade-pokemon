using static System.Net.Mime.MediaTypeNames;
using System.Text.Json.Serialization;

public class Pokemon
{
    public string name { get; set; }
    public double weight { get; set; }
    public double height { get; set; }
    public List<TypeSlot> types { get; set; }
    public Sprites sprites { get; set; }
}

public class TypeSlot
{
    public int slot { get; set; }
    public Type type { get; set; }
}

public class Type
{
    public string name { get; set; }
}

public class Sprites
{
    public Other other { get; set; }
}

public class Other
{
    [JsonPropertyName("official-artwork")]
    public OfficialArtwork officialArtwork { get; set; }
}

public class OfficialArtwork
{
    public string front_default { get; set; }
}