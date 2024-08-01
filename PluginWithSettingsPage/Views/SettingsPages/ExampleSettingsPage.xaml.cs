using ClassIsland.Core.Abstractions.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassIsland.Core.Attributes;

namespace PluginWithSettingsPage.Views.SettingsPages;

/// <summary>
/// ExampleSettingsPage.xaml 的交互逻辑
/// </summary>
[SettingsPageInfo("examples.exampleSettingsPage", "示例设置页面")]
public partial class ExampleSettingsPage : SettingsPageBase
{
    public Plugin Plugin { get; }

    public ExampleSettingsPage(Plugin plugin)
    {
        Plugin = plugin;
        InitializeComponent();
        DataContext = this;
    }
}