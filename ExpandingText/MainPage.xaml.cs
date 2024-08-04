using System;
using System.Collections.Generic;
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

namespace ExpandingText
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, object e)
        {
            if (!(e is RenderingEventArgs renderArgs)) return;
            var t = (0.25 * renderArgs.RenderingTime.TotalSeconds) % 1;
            var scale = t < 0.5 ? 2 * t : 2 * (1 - t);
            txtblk.FontSize = 1 + scale * 143;

            var gray = (byte)(255 * t);
            gridBrush.Color = Color.FromArgb(255, gray, gray, gray);

            gray = (byte)(255 - gray);
            txtblkBrush.Color = Color.FromArgb(255, gray, gray, gray);
        }
    }
}
