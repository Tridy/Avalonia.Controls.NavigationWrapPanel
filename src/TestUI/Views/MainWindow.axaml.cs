using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.LogicalTree;

namespace MyApp.Views;

public partial class MainWindow : Window
{
    private ItemsControl? _itemsControl;

    public MainWindow()
    {
        InitializeComponent();
        this.Opened += MainWindow_Opened;
    }

    private void MainWindow_Opened(object? sender, System.EventArgs e)
    {
        if (_itemsControl == null)
        {
            _itemsControl = this.FindLogicalDescendantOfType<ItemsControl>();
        }

        if (_itemsControl?.Items != null && _itemsControl.Items.Count > 0)
        {
            Control? firstItem = _itemsControl.ItemContainerGenerator.ContainerFromIndex(0);
            ContentPresenter? contentPresenter = firstItem as ContentPresenter;
            contentPresenter?.Child?.Focus();
        }
    }
}