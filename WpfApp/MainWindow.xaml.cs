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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hallo!!");
        }

        private void MainCanvas_Initialized(object sender, EventArgs e)
        {
            Canvas canvas = (Canvas)sender;

            for(int y = 0; y < 32; y++)
            {
                for(int x = 0; x < 32; x++)
                {
                    Rectangle rect;
                    rect = new Rectangle();
                    rect.Fill = new SolidColorBrush(Colors.White);
                    rect.Width = 19;
                    rect.Height = 19;
                    rect.MouseDown += Rectangle_MouseDown;
                    rect.MouseMove += Rectangle_MouseMove;
                    Canvas.SetLeft(rect, x * 20);
                    Canvas.SetTop(rect, y * 20);
                    canvas.Children.Add(rect);
                }
            }
        }

        private void Rectangle_MouseDown(object sender,MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                rect.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            }
        }

        private void MenuItem_NameSave_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Delete_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_End_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Slider_Zoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MainCanvas == null) return;

            Matrix matrix = new Matrix();
            matrix.Scale(Slider_Zoom.Value * 0.01, Slider_Zoom.Value * 0.01);
            matrixTransform.Matrix = matrix;

            ZoomLabel.Content = Slider_Zoom.Value + "%";

            MainCanvas.Width = 640 * Slider_Zoom.Value * 0.01;
            MainCanvas.Height = 640 * Slider_Zoom.Value * 0.01;
        }

        private void MenuItem_ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            int index = Slider_Zoom.Ticks.IndexOf(Slider_Zoom.Value);
            index--;

            if (index < 0) return;

            Slider_Zoom.Value = Slider_Zoom.Ticks[index];
        }

        private void MenuItem_ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            int index = Slider_Zoom.Ticks.IndexOf(Slider_Zoom.Value);
            index++;

            if (Slider_Zoom.Ticks.Count <= index) return;

            Slider_Zoom.Value = Slider_Zoom.Ticks[index];
        }
    }
}
