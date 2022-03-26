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
                for (int i = 0; i < 20; i++)
                {
                    var result = Fibonachi(i);
                    TextBlockFibonachi.Dispatcher.Invoke(() =>
                    {
                        TextBlockFibonachi.Text = result.ToString();
                    });
                    Thread.Sleep(1000);
                }
                ButtonStart.Dispatcher.Invoke(() =>
                {
                    ButtonStart.IsEnabled = true;
                });
            });
            thread.Start();
        }
    }
}
