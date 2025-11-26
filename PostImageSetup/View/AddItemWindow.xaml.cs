using System.Windows;

namespace PostImageSetup
{
  /// <summary>
  /// Interaction logic for AddItemWindow.xaml
  /// </summary>
  public partial class AddItemWindow : Window
  {
    public AddItemWindow(Window owner)
    {
      InitializeComponent();
      // set our owner
      Owner = owner;
      TextBoxAddItem.Focus();
    }

    private void ButtonAdd_Click(object sender, RoutedEventArgs e)
    {
      // set our text
      Text = TextBoxAddItem.Text;
      // set our dialog result
      DialogResult = true;
      // close the window
      Close();
    }

    private void ButtonCancel_Click(object sender, RoutedEventArgs e)
    {
      // set our dialog result
      DialogResult = false;
      // close the window
      Close();
    }

    public string Text { get; private set; } = string.Empty;
  }
}
