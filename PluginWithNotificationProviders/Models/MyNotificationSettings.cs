using CommunityToolkit.Mvvm.ComponentModel;

namespace PluginWithNotificationProviders.Models;

public class MyNotificationSettings : ObservableRecipient
{
    private string _message = "";

    /// <summary>
    /// 要显示的文本
    /// </summary>
    public string Message
    {
        get => _message;
        set
        {
            if (value == _message) return;
            _message = value;
            OnPropertyChanged();
        }
    }
}