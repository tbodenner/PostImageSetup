namespace PostImageSetup.Class.SiteConfigs.Site
{
  internal class SiteConfig
  {
    public BannerLine[]? Banner { get; set; }
    public char? MapDriveLetter { get; set; }
    public string? MapDriveFolder { get; set; }
    public string? InstallFolder { get; set; }
    public string? TempFolder { get; set; }
    public string? SystemFolder { get; set; }
    public string? JsonFileName { get; set; }
    public string? BaselineFileName { get; set; }
    public int? AssetTagMinLength { get; set; }
    public int? AssetTagMaxLength { get; set; }
    public int? RebootTimeout { get; set; }
    public string? DellAssetExePath { get; set; }
    public string? DellDesktopBiosPath { get; set; }
    public string? DellLaptopBiosPath { get; set; }
    public string? HpAssetExePath { get; set; }
    public string? HpDesktopBiosPath { get; set; }
    public string? HpLaptopBiosPath { get; set; }
    public string? LenovoAssetExePath { get; set; }
    public string? LenovoBiosToolPath { get; set; }
    public string? LenovoDesktopBiosPath { get; set; }
    public string? LenovoLaptopBiosPath { get; set; }
    public string? LenovoModel21H2 { get; set; }
    public string? LenovoModel21H2JsonFileName { get; set; }
    public string? LenovoModel21H2BiosTargetVersion { get; set; }
    public string? DesktopOU { get; set; }
    public string? LaptopOU { get; set; }
  }
}
