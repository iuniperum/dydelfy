using System;
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
    public double dydelf = 0, krokodyl = 0, szop = 0;
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
        private double timer;
        public double _kolumny { get; set; }
        public double _rzedy { get; set; }
        public double _timer { get; set; }
    }
    public plansza_dane plansza_reaktywna { get; } = new();

    private przycisk dodanie(int rodz, bool czy, bool mozna, int ind) {
        przycisk p = new przycisk {_rodzaj = rodz, _uzyty = czy, _czy_mozna = mozna, _indeks = ind};
        return p;
    }

    public void start(object sender, RoutedEventArgs e)
    {
        plansza_reaktywna._kolumny = x;
        plansza_reaktywna._rzedy = y;
        plansza_reaktywna._timer = y + 1;
        
        for (int i = 0; i < x*y; i++) {
            plansza_reaktywna.przyciski.Add(dodanie(0, false, true, i));
        }
        
        Random rnd = new Random();

        for (int i = 0; i < dydelfy; i++) {
            dydelf = rnd.Next(0, plansza_reaktywna.przyciski.Count);
            while (plansza_reaktywna.przyciski[Convert.ToInt32(dydelf)]._czy_mozna == false) {
                dydelf = rnd.Next(0, plansza_reaktywna.przyciski.Count);
            }
            plansza_reaktywna.przyciski[Convert.ToInt32(dydelf)]._rodzaj = 1;
            plansza_reaktywna.przyciski[Convert.ToInt32(dydelf)]._czy_mozna = false;
        }
        
        for (int i = 0; i < krokodyle; i++) {
            krokodyl = rnd.Next(0, plansza_reaktywna.przyciski.Count);
            while (plansza_reaktywna.przyciski[Convert.ToInt32(krokodyl)]._czy_mozna == false) {
                krokodyl = rnd.Next(0, plansza_reaktywna.przyciski.Count);
            }
            plansza_reaktywna.przyciski[Convert.ToInt32(krokodyl)]._rodzaj = 2;
            plansza_reaktywna.przyciski[Convert.ToInt32(krokodyl)]._czy_mozna = false;
        }
        
        for (int i = 0; i < szopy; i++) {
            szop = rnd.Next(0, plansza_reaktywna.przyciski.Count);
            while (plansza_reaktywna.przyciski[Convert.ToInt32(szop)]._czy_mozna == false) {
                szop = rnd.Next(0, plansza_reaktywna.przyciski.Count);
            }
            plansza_reaktywna.przyciski[Convert.ToInt32(szop)]._rodzaj = 3;
            plansza_reaktywna.przyciski[Convert.ToInt32(szop)]._czy_mozna = false;
        }
        
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
        for (int i = 0; i < plansza_reaktywna.przyciski.Count; i++) {
            lista += "/przycisk " + plansza_reaktywna.przyciski[i]._rodzaj;
        }

        przy.InnerLeftContent = lista;
        //gra.Close();
    }
}