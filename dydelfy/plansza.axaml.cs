using System;
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

    public void odwrocenie(object sender, RoutedEventArgs e) {
        if (sender is Button button) {
            if (_main.plansza_reaktywna.przyciski[Convert.ToInt32(button.Tag)]._uzyty == false) {
                _main.plansza_reaktywna.przyciski[Convert.ToInt32(button.Tag)]._uzyty = true;
            }
        }
    }

    public void zakrycie(object sender, RoutedEventArgs e) {
        if (sender is Button button) {
            if (_main.plansza_reaktywna.przyciski[Convert.ToInt32(button.Tag)]._uzyty == true) {
                _main.plansza_reaktywna.przyciski[Convert.ToInt32(button.Tag)]._uzyty = false;
            }        
        }
    }
}