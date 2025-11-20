using PostImageSetup.Class;
using PostImageSetup.Class.AppConfig;
using PostImageSetup.Class.SiteConfigs.Baseline;
using PostImageSetup.Class.SiteConfigs.Installs;
using PostImageSetup.Class.SiteConfigs.Site;
using System.Windows;

namespace PostImageSetup
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private readonly SiteConfig? _siteConfig;
    private readonly InstallConfig? _installConfig;
    private readonly BaselineConfig? _baselineConfig;

    public MainWindow()
    {
      InitializeComponent();
      AppConfigController acc = new();
      _siteConfig = JsonConfigReader.ReadConfig();
      _installConfig = JsonConfigReader.ReadInstalls();
      _baselineConfig = JsonConfigReader.ReadBaseline();
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
      Window window = new BaselineConfigWindow
      {
        Owner = this,
        WindowStyle = WindowStyle.ToolWindow
      };
      window.ShowDialog();
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