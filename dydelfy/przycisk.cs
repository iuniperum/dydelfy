using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace dydelfy;

public class przycisk : INotifyPropertyChanged {
    // 0 - pusty
    // 1 -  dydelf
    // 2 - krokodyl
    // 3 - szop
    public int rodzaj {get; set;}
    public bool czy_odkryty {get; set;}
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}