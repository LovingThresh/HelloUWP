using Windows.Foundation;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Hello
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            var foregroundBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 0)
            };

            var gradientStop = new GradientStop
            {
                Offset = 0,
                Color = Windows.UI.Colors.MediumVioletRed
            };
            foregroundBrush.GradientStops.Add(gradientStop);

            gradientStop = new GradientStop
            {
                Offset = 1,
                Color = Windows.UI.Colors.Purple
            };
            foregroundBrush.GradientStops.Add(gradientStop);

            txtblk.Foreground = foregroundBrush;

            var backgroundBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1)
            };
            backgroundBrush.GradientStops.Add(new GradientStop
            {
                Offset = 0,
                Color = Windows.UI.Colors.Blue
            });
            backgroundBrush.GradientStops.Add(new GradientStop
            {
                Offset = 1,
                Color = Windows.UI.Colors.White
            });

            contentGrid.Background = backgroundBrush;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
