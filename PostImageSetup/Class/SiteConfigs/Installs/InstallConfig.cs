namespace PostImageSetup.Class.SiteConfigs.Installs
{
  internal class InstallConfig
  {
    public InstallConfig(WorkItem[]? inputArray)
    {
      WorkItems = inputArray;
    }
    public WorkItem[]? WorkItems { get; set; }
  }
}
