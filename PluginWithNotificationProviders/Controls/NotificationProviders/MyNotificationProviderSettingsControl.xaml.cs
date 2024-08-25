using System.Windows.Controls;
using PluginWithNotificationProviders.Models;

namespace PluginWithNotificationProviders.Controls.NotificationProviders;

public partial class MyNotificationProviderSettingsControl : UserControl
{
    /// <summary>
    /// 这个属性用来存储提醒提供方设置
    /// </summary>
    public MyNotificationSettings Settings { get; }
    
    // 这里通过构造函数参数传入设置对象，这样设置控件就可以访问到提醒提供方的设置了。
    public MyNotificationProviderSettingsControl(MyNotificationSettings settings)
    {
        // 将设置对象写入到属性中，这样前端就可以访问到这个设置对象，以进行绑定。
        Settings = settings;
        
        InitializeComponent();
    }
}