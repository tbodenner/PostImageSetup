using System.Windows.Media;
using SD = System.Drawing;

namespace PostImageSetup.Model.SiteConfigs.Site
{
  internal class BannerLine
  {
    private Color? _color;
    public string Text { get; set; } = string.Empty;
    public string ColorName { get; set; } = string.Empty;

    public Color Color
    {
      get
      {
        if (_color == null)
        {
          try
          {
            SD.Color sdColor = SD.Color.FromName(ColorName);
            _color = Color.FromArgb(sdColor.A, sdColor.R, sdColor.G, sdColor.B);
          }
          catch
          {
            _color = Colors.White;
          }
        }
        return (Color)_color;
      }
      set
      {
        _color = value;
      }
    }
  }
}