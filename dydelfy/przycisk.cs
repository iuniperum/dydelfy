using System.ComponentModel;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace dydelfy;

public class przycisk : ReactiveObject {
    // 0 - pusty,
    // 1 -  dydelf
    // 2 - krokodyl
    // 3 - szop
    private int rodzaj;
    private bool czy_uzyty;
    
    public int _rodzaj {
        get => rodzaj;
        set { rodzaj = value; OnPropertyChanged(); }
    }
    public bool _czy {
        get => czy_uzyty;
        set { czy_uzyty = value; OnPropertyChanged(); }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}