using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using ReactiveUI;
using Avalonia.Media.Imaging;
using SkiaSharp;
using System.IO;
using Avalonia.Threading;

namespace dydelfy;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private plansza gra;
    public double x = 0, y = 0;
    public double dydelfy = 0, krokodyle = 0, szopy = 0;
    public double dydelf = 0, krokodyl = 0, szop = 0;
    public string lista = "";
    public int czas = 0;
    public MainWindow() {
        InitializeComponent();
        DataContext = this;
    }
    public class plansza_dane : ReactiveObject {
        public ObservableCollection<przycisk> przyciski { get; } = new();
        private double kolumny;
        public double _kolumny { get; set; }
        
        private double rzedy;
        public double _rzedy { get; set; }
        
        private double timer;
        public double _timer { get; set; }
        
        private int pozostaly_czas;
        public int _pozostaly_czas {
            get => pozostaly_czas;
            set => this.RaiseAndSetIfChanged(ref pozostaly_czas, value);
        }
        
        private int pozostaly_czas_krokodyl;
        public int _pozostaly_czas_krokodyl {
            get => pozostaly_czas_krokodyl;
            set => this.RaiseAndSetIfChanged(ref pozostaly_czas, value);
        }
        
        public DispatcherTimer odliczanie;
        public DispatcherTimer odliczanie_krokodyle;
    }
    public plansza_dane plansza_reaktywna { get; } = new();

    public void StartCountdown(int seconds) {
        plansza_reaktywna._pozostaly_czas = seconds;

        plansza_reaktywna.odliczanie = new DispatcherTimer {
            Interval = TimeSpan.FromSeconds(1)
        };

        plansza_reaktywna.odliczanie.Tick += (sender, e) => {
            plansza_reaktywna._pozostaly_czas--;

            if (plansza_reaktywna._pozostaly_czas <= 0) {
                plansza_reaktywna.odliczanie.Stop();
                Console.WriteLine("KONIEC");
                gra.Close();
            }
        };

        plansza_reaktywna.odliczanie.Start();
    }
    public void dwie_sekundy() {
        plansza_reaktywna._pozostaly_czas_krokodyl = 2;

        plansza_reaktywna.odliczanie_krokodyle = new DispatcherTimer {
            Interval = TimeSpan.FromSeconds(1)
        };

        plansza_reaktywna.odliczanie_krokodyle.Tick += (sender, e) => {
            plansza_reaktywna._pozostaly_czas_krokodyl--;

            if (plansza_reaktywna._pozostaly_czas_krokodyl <= 0) {
                plansza_reaktywna.odliczanie_krokodyle.Stop();
                Console.WriteLine("KONIEC");
                gra.wynik.Text = "za późno!";
                gra.Close();
            }
        };

        plansza_reaktywna.odliczanie_krokodyle.Start();
    }

    private przycisk dodanie(int rodz, bool czy, bool mozna, int ind, string ob) {
        przycisk p = new przycisk {_rodzaj = rodz, _uzyty = czy, _czy_mozna = mozna, _indeks = ind, _obrazek = ob};
        return p;
    }
    
    public void start(object sender, RoutedEventArgs e) {
        plansza_reaktywna._kolumny = x;
        plansza_reaktywna._rzedy = y;
        plansza_reaktywna._timer = y + 1;
        
        for (int i = 0; i < x*y; i++) {
            plansza_reaktywna.przyciski.Add(dodanie(0, false, true, i, "\ud83d\uddd1\ufe0f"));
        }
        
        Random rnd = new Random();

        for (int i = 0; i < dydelfy; i++) {
            dydelf = rnd.Next(0, plansza_reaktywna.przyciski.Count);
            while (plansza_reaktywna.przyciski[Convert.ToInt32(dydelf)]._czy_mozna == false) {
                dydelf = rnd.Next(0, plansza_reaktywna.przyciski.Count);
            }
            plansza_reaktywna.przyciski[Convert.ToInt32(dydelf)]._rodzaj = 1;
            plansza_reaktywna.przyciski[Convert.ToInt32(dydelf)]._zwierzak = "\ud83e\udda1";
            plansza_reaktywna.przyciski[Convert.ToInt32(dydelf)]._czy_mozna = false;
        }
        
        for (int i = 0; i < krokodyle; i++) {
            krokodyl = rnd.Next(0, plansza_reaktywna.przyciski.Count);
            while (plansza_reaktywna.przyciski[Convert.ToInt32(krokodyl)]._czy_mozna == false) {
                krokodyl = rnd.Next(0, plansza_reaktywna.przyciski.Count);
            }
            plansza_reaktywna.przyciski[Convert.ToInt32(krokodyl)]._rodzaj = 2;
            plansza_reaktywna.przyciski[Convert.ToInt32(krokodyl)]._zwierzak = "\ud83d\udc0a";
            plansza_reaktywna.przyciski[Convert.ToInt32(krokodyl)]._czy_mozna = false;
        }
        
        for (int i = 0; i < szopy; i++) {
            szop = rnd.Next(0, plansza_reaktywna.przyciski.Count);
            while (plansza_reaktywna.przyciski[Convert.ToInt32(szop)]._czy_mozna == false) {
                szop = rnd.Next(0, plansza_reaktywna.przyciski.Count);
            }
            plansza_reaktywna.przyciski[Convert.ToInt32(szop)]._rodzaj = 3;
            plansza_reaktywna.przyciski[Convert.ToInt32(szop)]._zwierzak = "\ud83e\udd9d";
            plansza_reaktywna.przyciski[Convert.ToInt32(szop)]._czy_mozna = false;
        }
        
        gra = new plansza(this);
        gra.Show();
        StartCountdown(czas);
    }
    
    public void ustawienia(object sender, RoutedEventArgs e) {
        ustawienia ust = new ustawienia(this);
        ust.Show();
    }

    public void koniec(object sender, RoutedEventArgs e) {
        gra.Close();
    } 
}