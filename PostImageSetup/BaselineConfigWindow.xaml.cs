using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace PostImageSetup
{
  /// <summary>
  /// Interaction logic for BaselineConfigWindow.xaml
  /// </summary>
  public partial class BaselineConfigWindow : Window
  {
    private TreeViewItem _treeModel;
    public BaselineConfigWindow(TreeViewItem treeModel)
    {
      InitializeComponent();
      _treeModel = treeModel;
      MainTreeView.Items.Add(_treeModel);
      TreeViewItem treeItem = (TreeViewItem)MainTreeView.Items[0];
      treeItem.ExpandSubtree();
      SizeToContent = SizeToContent.WidthAndHeight;
    }

    private void MainTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
      TreeView treeView = (TreeView)sender;
      MessageBoxResult result = MessageBox.Show("Delete item?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
      if (result == MessageBoxResult.Yes)
      {
        // find the item and remove it
      }
    }
  }
}
