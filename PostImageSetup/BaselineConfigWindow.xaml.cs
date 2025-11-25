using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PostImageSetup
{
  /// <summary>
  /// Interaction logic for BaselineConfigWindow.xaml
  /// </summary>
  public partial class BaselineConfigWindow : Window
  {
    private readonly Dictionary<string, ObservableCollection<string>>? _baseline;
    private readonly Dictionary<string, ListView>? _dictListViews = [];
    private readonly Dictionary<string, Button>? _dictRemoveButtons = [];
    private readonly Dictionary<string, Button>? _dictAddButtons = [];

    public BaselineConfigWindow(Dictionary<string, ObservableCollection<string>>? baseline)
    {
      InitializeComponent();
      _baseline = baseline;
      CreateBaselineListViews();
      SizeToContent = SizeToContent.WidthAndHeight;
    }

    private void CreateBaselineListViews()
    {
      // check if our baseline is null
      if (_baseline == null) { return; }
      // count the number of keys
      int keyCount = 0;
      // create our groupbox and listview from our baseline data
      foreach (string key in _baseline.Keys)
      {
        // create the grid for our group box
        Grid grid = new();
        grid.ColumnDefinitions.Add(new());
        grid.RowDefinitions.Add(new());
        grid.RowDefinitions.Add(new());

        // create the stack panel for our buttons
        StackPanel panel = new() { Orientation = Orientation.Horizontal };
        Grid.SetColumn(panel, 0);
        Grid.SetRow(panel, 0);
        grid.Children.Add(panel);

        // create the add button
        Button buttonAdd = new() { Content="Add", Width=120, Height=20};
        panel.Children.Add(buttonAdd);
        _dictAddButtons?.Add(key, buttonAdd);
        buttonAdd.Click += ButtonAdd_Click;
        // create the remove button
        Button buttonRemove = new() { Content = "Remove", Width = 120, Height = 20 };
        panel.Children.Add(buttonRemove);
        _dictRemoveButtons?.Add(key, buttonRemove); // add our remove button to a dictionary so we can access it later
        buttonRemove.Click += ButtonRemove_Click;
        // create the remove group button
        Button buttonRemoveGroup = new() { Content = "Remove Group", Width = 120, Height = 20 };
        panel.Children.Add(buttonRemoveGroup);

        // create our list view
        ListView listView = new() { ItemsSource = _baseline[key] };
        Grid.SetColumn(listView, 0);
        Grid.SetRow(listView, 1);
        grid.Children.Add(listView);
        _dictListViews?.Add(key, listView); // add our list view to a dictionary so we can access it later

        // create the group box and our grid to the group box
        GroupBox groupBox = new() { Header = key, Content = grid };

        // add out groups boxes based on the count
        if (keyCount % 2 == 0)
        {
          // add to even stack panel
          BaselineStackPanelEven.Children.Add(groupBox);
        }
        else
        {
          // add to odd stack panel
          BaselineStackPanelOdd.Children.Add(groupBox);
        }

        // update our count
        keyCount++;
      }
    }

    private void ButtonAdd_Click(object sender, RoutedEventArgs e)
    {
      AddItemWindow window = new AddItemWindow(this);
      bool? dialogResult = window.ShowDialog();
      if (dialogResult == true)
      {
        // make sure our sender is a button
        if (sender is Button button)
        {
          // the key of the current button
          string currentKey = string.Empty;
          // check if our dictionary is null
          if (_dictAddButtons == null) { return; }
          // look for our button in our dictionary
          foreach (string key in _dictAddButtons.Keys)
          {
            // if our dictionary button matches our sending button
            if (_dictAddButtons[key] == button)
            {
              // set our key
              currentKey = key;
              // and stop the loop
              break;
            }
          }
          // check if we found a key
          if (currentKey != string.Empty)
          {
            // check if our text is not empty
            if (window.Text != string.Empty)
            {
              // add our string to our dictionary's list
              _baseline?[currentKey].Add(window.Text);
            }
          }
        }
      }
    }

    private void ButtonRemove_Click(object sender, RoutedEventArgs e)
    {
      // make sure our sender is a button
      if (sender is Button button)
      {
        // the key of the current button
        string currentKey = string.Empty;
        // check if our dictionary is null
        if (_dictRemoveButtons == null) { return; }
        // look for our button in our dictionary
        foreach (string key in _dictRemoveButtons.Keys)
        {
          // if our dictionary button matches our sending button
          if (_dictRemoveButtons[key] == button)
          {
            // set our key
            currentKey = key;
            // and stop the loop
            break;
          }
        }
        // check if we found a key
        if (currentKey != string.Empty)
        {
          // check if our dictionary is not null
          if (_dictListViews != null)
          {
            // get our list view
            ListView listView = _dictListViews[currentKey];
            // get the number of items in our list view
            int count = listView.SelectedItems.Count;
            // create an array to store our list view's data
            string[] listArray = new string[count];
            // copy the contents of the list view into the array
            listView.SelectedItems.CopyTo(listArray, 0);
            // loop through our array
            foreach (string item in listArray)
            {
              // and remove each item in our array from the dictionary's list
              _baseline?[currentKey].Remove(item);
            }
          }
        }
      }
    }
  }
}
