using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using PostImageSetup.Class.SiteConfigs.Site;
using PostImageSetup.Class.SiteConfigs.Installs;
using PostImageSetup.Class.SiteConfigs.Baseline;

namespace PostImageSetup.Class
{
  internal class JsonConfigReader
  {
    private static readonly string TESTFilePath = "C:\\Users\\OITPREBODENT\\OneDrive - Department of Veterans Affairs\\Desktop\\GitHub\\Install-PostImageSetup";
    public void ReadConfig()
    {
      string configPath = Path.Join(TESTFilePath, "config.json");
      string jsonFile = File.ReadAllText(configPath);
      SiteConfig? testConfig = JsonSerializer.Deserialize<SiteConfig>(jsonFile);
    }
    public void ReadInstalls()
    {
      string configPath = Path.Join(TESTFilePath, "installs.json");
      string jsonFile = File.ReadAllText(configPath);
      InstallConfig? testConfig = new(JsonSerializer.Deserialize<InstallItem[]>(jsonFile));
    }
    public void ReadBaseline()
    {
      string configPath = Path.Join(TESTFilePath, "baseline.json");
      string jsonFile = File.ReadAllText(configPath);
      BaselineConfig? testConfig = new(JsonSerializer.Deserialize<Dictionary<string,string[]>>(jsonFile));
    }
  }
}
