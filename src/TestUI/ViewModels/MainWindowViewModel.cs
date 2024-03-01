using System.Collections.ObjectModel;

namespace MyApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
    public ObservableCollection<string> MyItems { get; }
#pragma warning restore CA1822 // Mark members as static

    public MainWindowViewModel()
    {
        MyItems = new ObservableCollection<string>
        {
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
            "Ten"
        };
    }
}