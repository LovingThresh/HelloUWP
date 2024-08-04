using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace StackPanelWithScrolling
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            IEnumerable<PropertyInfo> properties = typeof(Windows.UI.Colors).GetTypeInfo().DeclaredProperties;

            foreach (var property in properties)
            {
                Windows.UI.Color clr = (Windows.UI.Color)property.GetValue(null);
                TextBlock txtblk = new TextBlock();
                txtblk.Foreground = new SolidColorBrush(clr);
                txtblk.Text = String.Format("{0} \x2014 {1:X2}-{2:X2}-{3:X2}-{4:X2}", property.Name, clr.A, clr.R, clr.G, clr.B);
                StackPanel.Children.Add(txtblk);
            }
        }
    }
}
