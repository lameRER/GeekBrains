using System;
using System.Threading;
using System.Windows;

namespace WpfAppTask_1_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int Fibonachi(int value)
        {
            if (value is 0 or 1) return value;

            return Fibonachi(value - 1) + Fibonachi(value - 2); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonStart.IsEnabled = false;
            var thread = new Thread(() =>
            {
                for (int i = 0; i < 30; i++)
                {
                    int sleep =0;
                    var result = Fibonachi(i);
                    TextBlockFibonachi.Dispatcher.Invoke(() =>
                    {
                        sleep = (int)Slider.Value;
                        TextBlockFibonachi.Text = result.ToString();
                    });
                    if(sleep != 0)
                        Thread.Sleep(sleep);
                }
                ButtonStart.Dispatcher.Invoke(() =>
                {
                    ButtonStart.IsEnabled = true;
                });
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Console.WriteLine(Slider.Value);
        }
    }
}
