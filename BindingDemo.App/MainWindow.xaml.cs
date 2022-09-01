using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BindingDemo.App;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private string _name;

    public string FirstName
    {
        get => _name;
        set
        {
            if (value == _name)
            {
                return;
            }

            _name = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }

    public MainWindow()
    {
        InitializeComponent();
    }

    private void ButtonExport_OnClick(object sender, RoutedEventArgs e)
    {
        FirstNameModel.Export(FirstName);
    }

    private void ButtonImport_OnClick(object sender, RoutedEventArgs e)
    {
        FirstName = FirstNameModel.Import();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
