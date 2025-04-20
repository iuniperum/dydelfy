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
    public string lista = "";
    public MainWindow() {
        InitializeComponent();
        DataContext = this;
    }
    public class plansza_dane : ReactiveObject {
        public ObservableCollection<przycisk> przyciski { get; } = new();
        private double kolumny;
        private double rzedy;
        public double _kolumny { get; set; }
        public double _rzedy { get; set; }
    }
    public plansza_dane plansza_reaktywna { get; } = new();

    private przycisk dodanie(int rodz, bool czy) {
        przycisk p = new przycisk {_rodzaj = rodz, _czy = czy};
        return p;
    }

    public void start(object sender, RoutedEventArgs e)
    {
        plansza_reaktywna._kolumny = x;
        plansza_reaktywna._rzedy = y;
        for (int i = 0; i < x*y; i++) {
            plansza_reaktywna.przyciski.Add(dodanie(1, true));
        }
        gra = new plansza(this);
        gra.Show();
    }
    
    public void nacisniecie_przycisku(object sender, RoutedEventArgs e) {}
    
    public void ustawienia(object sender, RoutedEventArgs e) {
        ustawienia ust = new ustawienia(this);
        ust.Show();
    }
    
    public void koniec(object sender, RoutedEventArgs e) {
        test.InnerRightContent = x;
        test.InnerLeftContent = y;
        for (int i = 0; i < plansza_reaktywna.przyciski.Count; i++) {
            lista += "/przycisk " + plansza_reaktywna.przyciski[i]._rodzaj;
        }

        przy.InnerLeftContent = lista;
        //gra.Close();
    }
}