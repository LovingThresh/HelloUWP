using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace RainbowEight
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private double _txtblkBaseSize;

        public MainPage()
        {
            this.InitializeComponent();
            Loaded += OnPageLoaded;
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            _txtblkBaseSize = txtblk.ActualHeight;
            CompositionTarget.Rendering += OnCompositionTargetRendering;
        }

        private void OnCompositionTargetRendering(object sender, object e)
        {
            txtblk.FontSize = this.ActualHeight / _txtblkBaseSize;
            if (!(e is RenderingEventArgs renderingArgs)) return;
            var t = (0.25 * renderingArgs.RenderingTime.TotalSeconds) % 1;

            for (var index = 0; index < gradientBrush.GradientStops.Count; index++)
            {
                gradientBrush.GradientStops[index].Offset = index / 7.0 - t;
            }
        }
    }
}
