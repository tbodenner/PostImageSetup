using PostImageSetup.Class;
using PostImageSetup.Class.AppConfig;
using PostImageSetup.Class.SiteConfigs.Baseline;
using PostImageSetup.Class.SiteConfigs.Installs;
using PostImageSetup.Class.SiteConfigs.Site;
using System.Windows;
using System.IO;

namespace PostImageSetup
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private static readonly string _appConfigJsonFilename = ".\\appconfig.json";
    private readonly AppConfigController _appConfigController;
    private readonly SiteConfig? _siteConfig;
    private readonly InstallConfig? _installConfig;
    private readonly BaselineConfig? _baselineConfig;

    public MainWindow()
    {
      InitializeComponent();
      // check if the config file exists, or create it if it is missing
      CheckAppConfigFileExists();
      // read our config file
      _appConfigController = new(_appConfigJsonFilename);
      // read our other config files
      _siteConfig = JsonConfigReader.ReadConfig(_appConfigController.RootFolder);
      _installConfig = JsonConfigReader.ReadInstalls(_appConfigController.RootFolder);
      _baselineConfig = JsonConfigReader.ReadBaseline(_appConfigController.RootFolder);
    }

    private static void CheckAppConfigFileExists()
    {
      // check if the config file exits
      if (!File.Exists(_appConfigJsonFilename))
      {
        // if it doesn't exist, create the file and write the config structure
        string text = $"{{{Environment.NewLine}  \"RootFolder\": \"\"{Environment.NewLine}}}";
        File.WriteAllText(_appConfigJsonFilename, text);
      }
    }

    private void InstallConfigButton_Click(object sender, RoutedEventArgs e)
    {
      Window window = new InstallConfigWindow
      {
        Owner = this,
        WindowStyle = WindowStyle.ToolWindow
      };
      window.ShowDialog();
    }
    private void BaselineConfigButton_Click(object sender, RoutedEventArgs e)
    {
      if (_baselineConfig != null)
      {
        Window window = new BaselineConfigWindow(_baselineConfig.TreeModel)
        {
          Owner = this,
          WindowStyle = WindowStyle.ToolWindow
        };
        window.ShowDialog();
      }
    }
    private void SiteConfigButton_Click(object sender, RoutedEventArgs e)
    {
      Window window = new SiteConfigWindow
      {
        Owner = this,
        WindowStyle = WindowStyle.ToolWindow
      };
      window.ShowDialog();
    }
  }
}