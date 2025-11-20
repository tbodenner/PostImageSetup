using PostImageSetup.Class.SiteConfigs.Baseline;
using PostImageSetup.Class.SiteConfigs.Installs;
using PostImageSetup.Class.SiteConfigs.Site;
using System.IO;
using System.Text.Json;

namespace PostImageSetup.Class
{
  internal static class JsonConfigReader
  {
    private static readonly string TESTFilePath = "C:\\Users\\OITPREBODENT\\OneDrive - Department of Veterans Affairs\\Desktop\\GitHub\\Install-PostImageSetup";

    private static string? GetJsonText(string jsonFilePath)
    {
      if (File.Exists(jsonFilePath))
      {
        return File.ReadAllText(jsonFilePath);
      }
      else
      {
        return null;
      }
    }

    public static SiteConfig? ReadConfig()
    {
      string? jsonText = GetJsonText("config.json");
      if (jsonText == null)
      {
        return null;
      }
      else
      {
        return JsonSerializer.Deserialize<SiteConfig>(jsonText);
      }
    }

    public static InstallConfig? ReadInstalls()
    {
      string? jsonText = GetJsonText("installs.json");
      if (jsonText == null)
      {
        return null;
      }
      else
      {
        return new(JsonSerializer.Deserialize<InstallItem[]>(jsonText));
      }
    }

    public static BaselineConfig? ReadBaseline()
    {
      string? jsonText = GetJsonText("baseline.json");
      if (jsonText == null)
      {
        return null;
      }
      else
      {
        return new(JsonSerializer.Deserialize<Dictionary<string, string[]>>(jsonText));
      }
    }
  }
}
