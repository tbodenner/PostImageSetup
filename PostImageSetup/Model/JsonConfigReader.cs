using PostImageSetup.Model.SiteConfigs.Baseline;
using PostImageSetup.Model.SiteConfigs.Installs;
using PostImageSetup.Model.SiteConfigs.Site;
using System.IO;
using System.Text.Json;

namespace PostImageSetup.Model
{
  internal static class JsonConfigReader
  {
    private static string? GetJsonText(string? rootPath, string? jsonFilename)
    {
      if (rootPath == null || jsonFilename == null) { return null; }
      string jsonFilePath = Path.Join(rootPath, jsonFilename);
      if (File.Exists(jsonFilePath))
      {
        return File.ReadAllText(jsonFilePath);
      }
      else
      {
        return null;
      }
    }

    public static SiteConfig? ReadConfig(string? rootPath)
    {
      if (rootPath == null) { return null; }
      string? jsonText = GetJsonText(rootPath, "config.json");
      if (jsonText == null)
      {
        return null;
      }
      else
      {
        return JsonSerializer.Deserialize<SiteConfig>(jsonText);
      }
    }

    public static InstallConfig? ReadInstalls(string? rootPath)
    {
      if (rootPath == null) { return null; }
      string? jsonText = GetJsonText(rootPath, "installs.json");
      if (jsonText == null)
      {
        return null;
      }
      else
      {
        return new(JsonSerializer.Deserialize<WorkItem[]>(jsonText));
      }
    }

    public static BaselineConfig? ReadBaseline(string? rootPath)
    {
      if (rootPath == null) { return null; }
      string? jsonText = GetJsonText(rootPath, "baseline.json");
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
