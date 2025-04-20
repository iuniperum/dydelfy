using System.Collections.ObjectModel;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;

namespace dydelfy;

public partial class plansza : Window, INotifyPropertyChanged
{
    private MainWindow _main;
    public plansza(MainWindow okno) {
        InitializeComponent();
        _main = okno;
        DataContext = _main;
    }
}