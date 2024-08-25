using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using ClassIsland.Core.Abstractions.Services;
using ClassIsland.Shared.Interfaces;
using ClassIsland.Shared.Models.Notification;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Hosting;
using PluginWithNotificationProviders.Controls.NotificationProviders;
using PluginWithNotificationProviders.Models;

namespace PluginWithNotificationProviders.Services.NotificationProviders;

public class MyNotificationProvider : INotificationProvider, IHostedService
{
    private INotificationHostService NotificationHostService { get; }
    public ILessonsService LessonsService { get; }
    public string Name { get; set; } = "示例提醒提供方";
    public string Description { get; set; } = "提醒提供方说明";
    public Guid ProviderGuid { get; set; } = new Guid("DD3BC389-BEA9-40B7-912B-C7C37390A101");
    public object? SettingsElement { get; set; }
    public object? IconElement { get; set; } =  new PackIcon()
    {
        Kind = PackIconKind.TextLong,
        Width = 24,
        Height = 24
    };
    
    /// <summary>
    /// 这个属性用来存储提醒的设置。
    /// </summary>
    private MyNotificationSettings Settings { get; }

    public MyNotificationProvider(INotificationHostService notificationHostService,
        ILessonsService lessonsService)
    {
        NotificationHostService = notificationHostService;
        LessonsService = lessonsService;
        NotificationHostService.RegisterNotificationProvider(this);
        
        // 获取这个提醒提供方的设置，并保存到 Settings 属性上备用。
        Settings = NotificationHostService.GetNotificationProviderSettings<MyNotificationSettings>(ProviderGuid);

        // 将刚刚获取到的提醒提供方设置传给提醒设置控件，这样提醒设置控件就可以访问到提醒设置了。
        // 然后将 SettingsElement 属性设置为这个控件对象，这样提醒设置界面就会显示我们自定义的提醒设置控件。
        SettingsElement = new MyNotificationProviderSettingsControl(Settings);
        
        LessonsService.OnBreakingTime += LessonsServiceOnOnBreakingTime;
    }   

    private void LessonsServiceOnOnBreakingTime(object? sender, EventArgs e)
    {
        NotificationHostService.ShowNotification(new NotificationRequest()
        {
            MaskContent = new TextBlock(new Run("Hello world!"))
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            },
            OverlayContent = new TextBlock(new Run(Settings.Message))
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            },
            // 下面两个属性设置了语音播报的内容。
            MaskSpeechContent = "Hello world!",
            OverlaySpeechContent = Settings.Message,
        });
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
    }
}