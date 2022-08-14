using System.Windows;
using Solitfire.Logic;
using Solitfire.ViewModel;

namespace Solitfire;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private MainViewModel _mainViewModel;

    public App()
    {
        _mainViewModel = new MainViewModel(new Board());
    }
    
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow
        {
            DataContext = _mainViewModel
        };
        MainWindow.Show();
        base.OnStartup(e);
    }
}