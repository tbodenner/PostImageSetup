using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using Windows.Storage.Search;

namespace PostImageSetup.Model
{
  internal class Installer
  {
    public string Name { get; }
    public string FilePath { get; }
    public string Arguments { get; }
    public string Message { get; }
    public bool IsLaptop { get; }
    public bool IsDesktop { get; }
    public bool SkipCheck { get; }
    public bool IsInstalled { get { return _isInstalled; } set { _isInstalled = value; } }

    private bool _isMsi = false;
    private bool _isExe = false;
    private bool _isInstalled = false;

    private readonly ProcessStartInfo _processStartInfo;

    public event EventHandler? InstallComplete;

    public Installer(string name, string filePath, string arguments, string message,
                     bool isLaptop, bool isDesktop, bool skipCheck)
    {
      Name = name;
      FilePath = filePath;
      Arguments = arguments;
      Message = message;
      IsLaptop = isLaptop;
      IsDesktop = isDesktop;
      SkipCheck = skipCheck;

      GetInstallerFileExtension(FilePath);
      _processStartInfo = new(FilePath, Arguments);
    }

    protected virtual void OnInstallComplete(EventArgs e)
    {
      InstallComplete?.Invoke(this, e);
    }

    private void GetInstallerFileExtension(string filePath)
    {
      // get our path's extension
      string? extension = Path.GetExtension(filePath);
      // set our bools based on the extension
      switch (extension)
      {
        case ".msi":
          _isMsi = true;
          break;
        case ".exe":
          _isExe = true;
          break;
      }
    }

    public void StartInstall()
    {
      // create our list of installed software
      List<string> listInstalled = GetInstalledApplications();
      // check if the program is already installed
      if (IsSoftwareInstalled(Name))
      {
        // software is already installed
        IsInstalled = true;
        // fire our event
        OnInstallComplete(EventArgs.Empty);
      }
      else
      {
        // create our process
        Process? process = new() { StartInfo = _processStartInfo };
        // start the process
        process.Start();
        // check if the program was installed, and return the result
        IsInstalled = IsSoftwareInstalled(Name);
        // fire our event
        OnInstallComplete(EventArgs.Empty);
      }
    }

    private static bool IsSoftwareInstalled(string softwareName)
    {
      // create our list of installed software
      List<string> listInstalled = GetInstalledApplications();
      // return the result of the contains method
      return listInstalled.Contains(softwareName);
    }

    private static List<string> GetInstalledApplications()
    {
      // our key paths
      string[] keyPaths =
        [
          @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall",
          @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"
        ];
      // our return list
      List<string> listOutput = [];
      // get our display names
      foreach (string keyPath in keyPaths)
      {
        listOutput.AddRange(GetInstalledDisplayNames(keyPath));
      }
      // return our list
      return listOutput;
    }

    private static List<string> GetInstalledDisplayNames(string uninstallKeyPath)
    {
      // our return list
      List<string> listOutput = [];
      // get our uninstall root
      RegistryKey? keyUninstallRoot = Registry.LocalMachine.OpenSubKey(uninstallKeyPath);
      // check if our root key, if null return an empty list
      if (keyUninstallRoot == null) { return listOutput; }
      // get all the subkeys for our uninstall root
      string[]? subkeys = keyUninstallRoot?.GetSubKeyNames();
      // check if keys were returned
      if (subkeys != null && subkeys.Length > 0)
      {
        foreach (string key in subkeys)
        {
          // get our display name
          string? displayName = keyUninstallRoot?.OpenSubKey(key)?.GetValue("DisplayName")?.ToString();
          // if the name is not null
          if (displayName != null)
          {
            // add it to our list
            listOutput.Add(displayName);
          }
        }
      }
      // return our list
      return listOutput;
    }
  }
}