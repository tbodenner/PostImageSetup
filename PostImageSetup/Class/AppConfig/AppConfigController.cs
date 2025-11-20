using System.IO;
using System.Text.Json;
using Windows.ApplicationModel.VoiceCommands;

namespace PostImageSetup.Class.AppConfig
{
  internal class AppConfigController
  {
    // our config file
    private readonly string _configFilePath;
    // write our file using indentation
    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    // our config data from the json file
    private AppConfig? _appConfig;

    public AppConfigController(string configFilePath)
    {
      _configFilePath = configFilePath;
      // read our json
      ReadAppConfigJson();
    }

    private void ReadAppConfigJson()
    {
      // read our config file
      string configData = File.ReadAllText(_configFilePath);
      // get our json value from the config file
      _appConfig = JsonSerializer.Deserialize<AppConfig>(configData);
    }

    public void WriteAppConfigJson()
    {
      // get our json string from our object
      string jsonString = JsonSerializer.Serialize(_appConfig, _jsonOptions);
      // write our config to file
      File.WriteAllText(_configFilePath, jsonString);
    }

    public string? RootFolder
    {
      get
      {
        // check if our app config is null
        if (_appConfig == null)
        {
          // if null, return an empty string
          return string.Empty;
        }
        else
        {
          // otherwise, return our value
          return _appConfig.RootFolder;
        }
      }
      set
      {
        // check if our app config is not null
        if (_appConfig != null)
        {
          // set our value
          _appConfig.RootFolder = value;
        }
      }
    }
  }
}
