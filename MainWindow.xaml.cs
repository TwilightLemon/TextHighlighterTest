using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace TextHighlighterTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var jump = new HighlightTextBlock(true)
            {
                Margin = new Thickness(40, 0, 40, 182),
                VerticalAlignment = VerticalAlignment.Bottom,
                FontSize = 56,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Color.FromArgb(0x5E,255,255,255)),
                HighlightColor = Color.FromArgb(0x66,0xFF,0xFF,0xFF),
                HighlightPos = 0.5,
                HighlightWidth = 0.4,
                Text = "Jump TextBlock",
                TextAlignment = TextAlignment.Left,
                UseAdditive = true
            };
            grid.Children.Add(jump);
            jump.MouseDoubleClick += Jump_MouseDoubleClick;
        }

        private void Jump_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            double durationMs = 3000;
            var jump =(HighlightTextBlock)sender;
            jump.BeginAnimation(HighlightTextBlock.HighlightPosProperty, new DoubleAnimation(-jump.HighlightWidth, 1, TimeSpan.FromMilliseconds(durationMs))
            {
                EasingFunction = new CubicEase()
            });
            var geo=jump.Geometries!;
            double delay = 0, unit = durationMs / geo.Length;
            double p = 8.4, addi=unit - (p-1)*unit/(geo.Length-1);
            foreach(var g in geo)
            {
                var trans = new TranslateTransform();
                g.Transform = trans;
                trans.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation(0, -10, TimeSpan.FromMilliseconds(unit*p))
                {
                    BeginTime = TimeSpan.FromMilliseconds(delay),
                    EasingFunction=new CubicEase()
                });
                delay += addi;
            }
        }
    }
}