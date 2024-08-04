using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace RountedEvents0
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private readonly Random _rand = new Random();
        private readonly byte[] _rgb = new byte[3];

        public MainPage()
        {
            this.InitializeComponent();
        }

        private Brush GetRandomBrush()
        {
            _rand.NextBytes(_rgb);
            var clr = Color.FromArgb(255, _rgb[0], _rgb[1], _rgb[2]);
            return new SolidColorBrush(clr);
        }

        private void Txtblk_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var txtblk = sender as TextBlock;
            Debug.Assert(txtblk != null, nameof(txtblk) + " != null");
            txtblk.Foreground = GetRandomBrush();
        }

        protected override void OnTapped(TappedRoutedEventArgs e)
        {
            contentGrid.Background = GetRandomBrush();
            base.OnTapped(e);
        }
    }
}