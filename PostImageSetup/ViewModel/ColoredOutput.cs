using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace PostImageSetup.ViewModel
{
  class ColoredOutput
  {
    public event EventHandler? OutputUpdated;

    public ObservableCollection<TextBlock> Output { get; } = [];

    public void AddLine(Color textColor, string text)
    {
      // create our foreground color
      SolidColorBrush foreground = new(textColor);
      // create our background color
      SolidColorBrush background = new(Colors.Black);
      // create our label and add it to our collection
      Output.Add(new()
      {
        FontFamily = new("Consolas"),
        Text = text,
        Foreground = foreground,
        Background = background,
        Padding = new(2,0,0,0),
        Margin = new(0)
      });
      OnOutputUpdated(EventArgs.Empty);
    }

    protected virtual void OnOutputUpdated(EventArgs e)
    {
      OutputUpdated?.Invoke(this, e);
    }
  }
}