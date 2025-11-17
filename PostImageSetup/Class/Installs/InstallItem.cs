namespace PostImageSetup.Class.Installs
{
  internal class InstallItem
  {
    public string? InstallType { get; set; }
    public string? Name { get; set; }
    public string? FilePath { get; set; }
    public string? Arguments { get; set; }
    public string? Message { get; set; }
    public string? Destination { get; set; }
    public bool? IsLaptop { get; set; }
    public bool? IsDesktop { get; set; }
    public bool? SkipCheck { get; set; }
  }
}
