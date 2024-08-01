using CommunityToolkit.Mvvm.ComponentModel;

namespace PluginWithSettingsPage.Models;

public class Settings : ObservableRecipient
{
    private bool _settings2 = false;
    private string _settings1 = "foobar";

    public string Settings1
    {
        get => _settings1;
        set
        {
            if (value == _settings1) return;
            _settings1 = value;
            OnPropertyChanged();
        }
    }

    public bool Settings2
    {
        get => _settings2;
        set
        {
            if (value == _settings2) return;
            _settings2 = value;
            OnPropertyChanged();
        }
    }
}