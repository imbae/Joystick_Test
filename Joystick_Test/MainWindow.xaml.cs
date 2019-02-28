using System.Windows;

namespace Joystick_Test
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel viewModel = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.ThreadDispose();
        }
    }
}
