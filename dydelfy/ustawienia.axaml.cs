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

    public void zatwierdz(object sender, RoutedEventArgs e) {
        _main.x = Convert.ToDouble(plansza_x.Text);
        _main.y = Convert.ToDouble(plansza_y.Text);
        _main.dydelfy = Convert.ToDouble(dydelfy.Text);
        _main.krokodyle = Convert.ToDouble(krokodyle.Text);
        _main.szopy = Convert.ToDouble(szopy.Text);
        _main.czas = Convert.ToInt32(czas.Text);
        this.Close();
    }
}