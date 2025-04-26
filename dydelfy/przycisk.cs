using System.ComponentModel;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace dydelfy;

public class przycisk : INotifyPropertyChanged {
    // 0 - pusty,
    // 1 -  dydelf
    // 2 - krokodyl
    // 3 - szop
    private int indeks;
    private int rodzaj;
    private string obrazek;
    private string zwierzak;
    private bool czy_uzyty;
    private bool czy_mozna_zmieniac;
    
    public int _indeks {
        get => indeks;
        set { indeks = value; OnPropertyChanged(); }
    }
    
    public int _rodzaj {
        get => rodzaj;
        set { rodzaj = value; OnPropertyChanged(); }
    }
    public string _obrazek {
        get => obrazek;
        set { obrazek = value; OnPropertyChanged(); }
    }
    public string _zwierzak {
        get => zwierzak;
        set { zwierzak = value; OnPropertyChanged(); }
    }
    public bool _uzyty {
        get => czy_uzyty;
        set { czy_uzyty = value; OnPropertyChanged(); }
    }
    
    public bool _czy_mozna {
        get => czy_mozna_zmieniac;
        set { czy_mozna_zmieniac = value; OnPropertyChanged(); }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}