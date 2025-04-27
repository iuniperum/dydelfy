using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace dydelfy;

public partial class ustawienia : Window
{
    private double x, y, dydelf, krokody, szop, sekundy;
    private MainWindow _main;
    public ustawienia(MainWindow okno) {
        InitializeComponent();
        _main = okno;
    }

    public double wczytanie(double bot, double top, TextBox box) {
        x = Convert.ToDouble(plansza_x.Text);
        if (x < bot || x > top) {
            komunikat.Text = "podaj poprawne wartości!";
            _main.czy_dobre_wartosci = false;
        }
        else {
            _main.czy_dobre_wartosci = true;
        }
        return x;
    }

    public void zatwierdz(object sender, RoutedEventArgs e) {
        _main.x = wczytanie(1, 10, plansza_x);
        _main.y = wczytanie(1, 10, plansza_y);
        _main.dydelfy = wczytanie(1, 6, dydelfy);
        _main.krokodyle = wczytanie(0, 1, krokodyle);
        _main.szopy = wczytanie(3, 8, szopy);
        _main.czas = Convert.ToInt32(czas.Text);
        if (_main.czy_dobre_wartosci) {
            komunikat.Text = " ";
            _main.komunikat.Text = " ";
            this.Close();
        }
    }
}