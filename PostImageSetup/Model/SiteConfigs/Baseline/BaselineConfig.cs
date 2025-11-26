using System.Collections.ObjectModel;

namespace PostImageSetup.Model.SiteConfigs.Baseline
{
  internal class BaselineConfig
  {
    private readonly Dictionary<string, ObservableCollection<string>>? _baseline = [];

    public BaselineConfig(Dictionary<string, string[]>? inputDict)
    {
      if (inputDict != null)
      {
        foreach (string key in inputDict.Keys)
        {
          _baseline.Add(key, [.. inputDict[key]]);
        }
      }
    }

    public Dictionary<string, ObservableCollection<string>>? Baseline { get { return _baseline; } }
  }
}