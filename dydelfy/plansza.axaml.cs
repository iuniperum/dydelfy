using System.Collections.ObjectModel;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace dydelfy;

public partial class plansza : Window, INotifyPropertyChanged
{
    public ObservableCollection<przycisk> przyciski { get; } = new ObservableCollection<przycisk>();
    private MainWindow _main;
    public plansza(MainWindow okno) {
        InitializeComponent();
        _main = okno;
        for (int i = 0; i < _main.x*_main.y; i++) {
            przycisk p = new przycisk();
        }
    }
}