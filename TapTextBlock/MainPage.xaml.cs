using System;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace TapTextBlock
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public sealed partial class MainPage : Page
    {
        private readonly Random _rand = new Random();
        private readonly byte[] _rgb = new byte[3];

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Txtblk_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            _rand.NextBytes(_rgb);
            var clr = Color.FromArgb(255, _rgb[0], _rgb[1], _rgb[2]);
            txtblk.Foreground = new SolidColorBrush(clr);
        }
    }
}
