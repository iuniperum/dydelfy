using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Avalonia.ReactiveUI;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ReactiveUI;

namespace dydelfy;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private plansza gra;
    public double x = 0, y = 0;
    public double dydelfy = 0, krokodyle = 0, szopy = 0;
    public double czas = 0;
    public ObservableCollection<przycisk> przyciski { get; } = new ObservableCollection<przycisk>();
    public MainWindow() {
        InitializeComponent();
        DataContext = this;
    }

    public void start(object sender, RoutedEventArgs e) {
        gra = new plansza(this);
        gra.Show();
    }
    
    public void ustawienia(object sender, RoutedEventArgs e) {
        ustawienia ust = new ustawienia(this);
        ust.Show();
    }
    
    public void koniec(object sender, RoutedEventArgs e) {
        test.InnerRightContent = x;
        test.InnerLeftContent = y;
        //gra.Close();
    }
}