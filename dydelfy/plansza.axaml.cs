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
    public int znalezione_dydelfy = 0;
    private MainWindow _main;
    public plansza(MainWindow okno) {
        InitializeComponent();
        _main = okno;
        DataContext = _main;
    }

    public void odwrocenie(object sender, RoutedEventArgs e) {
        if (sender is Button button) {
            var index = Convert.ToInt32(button.Tag);
            var nacisniety = _main.plansza_reaktywna.przyciski[index];
            if (nacisniety._uzyty == false) {
                nacisniety._uzyty = true;
                nacisniety._obrazek = nacisniety._zwierzak;


                if (nacisniety._rodzaj == 1) {
                    znalezione_dydelfy += 1;
                    wynik.Text = znalezione_dydelfy.ToString();
                    if (znalezione_dydelfy == _main.dydelfy) {
                        wynik.Text = "Znaleziono wszystkie dydelfy!";
                        this.Close();
                        _main.reset();
                    }
                }
                else if (nacisniety._rodzaj == 2)
                {
                    _main.dwie_sekundy();
                }
                else if (nacisniety._rodzaj == 3)
                {
                    double odleglosc = _main.plansza_reaktywna._kolumny;
                    if (index - odleglosc - 1 >= 0) {
                        zakrycie(index - odleglosc - 1);
                    }

                    if (index - odleglosc >= 0) {
                        zakrycie(index - odleglosc);
                    }

                    if (index - odleglosc + 1 >= 0) {
                        zakrycie(index - odleglosc + 1);
                    }

                    if (index - 1 >= 0) {
                        zakrycie(index - 1);
                    }

                    if (index + 1 < _main.plansza_reaktywna.przyciski.Count) {
                        zakrycie(index + 1);
                    }

                    if (index + odleglosc - 1 < _main.plansza_reaktywna.przyciski.Count) {
                        zakrycie(index + odleglosc - 1);
                    }

                    if (index + odleglosc < _main.plansza_reaktywna.przyciski.Count) {
                        zakrycie(index + odleglosc);
                    }

                    if (index + odleglosc + 1 < _main.plansza_reaktywna.przyciski.Count) {
                        zakrycie(index + odleglosc + 1);
                    }
                }
            }
            else {
                zakrycie(index);
            }
        }
    }

    public void zakrycie(double s) {
        Console.WriteLine("zakrycie");
        var nacisniety = _main.plansza_reaktywna.przyciski[Convert.ToInt32(s)];
        if (nacisniety._uzyty == true) {
            nacisniety._uzyty = false;
            nacisniety._obrazek = "\ud83d\uddd1\ufe0f";
        }
    }
}