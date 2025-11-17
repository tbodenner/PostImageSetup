namespace PostImageSetup.Class.Installs
{
  internal class InstallConfig
  {
    public InstallConfig(InstallItem[]? inputArray)
    {
      Installs = inputArray;
    }
    public InstallItem[]? Installs { get; set; }
  }
}
