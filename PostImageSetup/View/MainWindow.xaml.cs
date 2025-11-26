using PostImageSetup.Model;
using PostImageSetup.Model.AppConfig;
using PostImageSetup.Model.SiteConfigs.Baseline;
using PostImageSetup.Model.SiteConfigs.Installs;
using PostImageSetup.Model.SiteConfigs.Site;
using PostImageSetup.ViewModel;
using System.IO;
using System.Windows;
using System.Windows.Media;

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
    private readonly ColoredOutput _coloredOutput = new();

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
      ListViewTest.ItemsSource = _coloredOutput.Output;
      _coloredOutput.OutputUpdated += ColoredOutput_OutputUpdated;
    }

    private void ColoredOutput_OutputUpdated(object? sender, EventArgs e)
    {
      ScrollViewerOutput.ScrollToEnd();
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
        Window window = new BaselineConfigWindow(_baselineConfig.Baseline)
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

    private void ButtonTest_Click(object sender, RoutedEventArgs e)
    {
      StartInstall();
    }

    private void StartInstall()
    {
      Installer installer = new("ECFax Messenger",
                                "Installers\\ECFax Messenger\\ECFax-Messenger-1.5.1.37-Installer.msi",
                                "ALLUSERS=1 /passive /norestart",
                                "ECFax Messenger",
                                true,
                                true,
                                false);
      installer.InstallComplete += Installer_InstallComplete;
      Thread thread = new(new ThreadStart(installer.StartInstall));
      thread.Start();
    }

    private void Installer_InstallComplete(object? sender, EventArgs e)
    {
      MessageBox.Show("Install done!");
    }

    private void ButtonTestLine_Click(object sender, RoutedEventArgs e)
    {
      if (_siteConfig?.Banner != null)
      {
        foreach (BannerLine line in _siteConfig.Banner)
        {
          _coloredOutput.AddLine(line.Color, line.Text);
        }
      }
      _coloredOutput.AddLine(Colors.Blue, "BLUE TEST");
      _coloredOutput.AddLine(Colors.Red, "RED TEST");
      _coloredOutput.AddLine(Colors.White, "WHITE TEST");
    }
  }
}