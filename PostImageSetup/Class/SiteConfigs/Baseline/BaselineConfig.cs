using System.Windows.Controls;

namespace PostImageSetup.Class.SiteConfigs.Baseline
{
  internal class BaselineConfig
  {
    private readonly Dictionary<string, List<string>> _baseline = [];
    private readonly TreeViewItem _treeModel = new() { Header = "Baseline" };

    public BaselineConfig(Dictionary<string, string[]>? inputDict)
    {
      if (inputDict != null)
      {
        foreach (string key in inputDict.Keys)
        {
          _baseline.Add(key, [.. inputDict[key]]);
        }
      }
      BuildTreeModel();
    }

    private void BuildTreeModel()
    {
      foreach (string key in _baseline.Keys)
      {
        _treeModel.Items.Add(new TreeViewItem() { Header = key, ItemsSource = _baseline[key] });
      }
    }

    public Dictionary<string, List<string>>? Baseline { get { return _baseline; } }
    public TreeViewItem TreeModel { get { return _treeModel; } }
  }
}