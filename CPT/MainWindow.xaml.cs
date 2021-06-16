using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CPT
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
        SolidColorBrush moreInf = new SolidColorBrush(Color.FromRgb(99, 186, 236));
        SolidColorBrush buttonHighlight = new SolidColorBrush(Color.FromArgb(40, 0, 0, 0));
        bool clickHold = false;
        private void GPU_More_Info_MouseEnter(object sender, MouseEventArgs e)
        {
            GPU_More_Info.Foreground = Brushes.White;
        }
        private void GPU_More_Info_MouseLeave(object sender, MouseEventArgs e)
        {
            GPU_More_Info.Foreground = moreInf;
        }

        private async void GPU_More_Info_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clickHold = true;
            await Task.Delay(300);
            clickHold = false;
        }

        private void GPU_More_Info_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(clickHold)
            {
                GPU_More_Info_Grid.Visibility = Visibility.Visible;
            }       
        }

        private void CPU_More_Info_MouseEnter(object sender, MouseEventArgs e)
        {
            CPU_More_Info.Foreground = Brushes.White;
        }

        private void CPU_More_Info_MouseLeave(object sender, MouseEventArgs e)
        {
            CPU_More_Info.Foreground = moreInf;
        }

        private void CPU_More_Info_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clicked.Visibility = Visibility.Visible;
        }

        private void CPU_More_Info_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Clicked.Visibility = Visibility.Hidden;
        }

        private void Close_MouseEnter(object sender, MouseEventArgs e)
        {
            Close.Background = buttonHighlight;
        }

        private void Close_MouseLeave(object sender, MouseEventArgs e)
        {
            Close.Background = null;
        }

        private void Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Min_MouseEnter(object sender, MouseEventArgs e)
        {
            Min.Background = buttonHighlight;
        }

        private void Min_MouseLeave(object sender, MouseEventArgs e)
        {
            Min.Background = null;
        }

        private void Min_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GPU_More_Info_Grid.Visibility = Visibility.Hidden;
        }

        private void Load_table_Click(object sender, RoutedEventArgs e)
        {
            Table tb = new Table(580, 3075, 1);
            this.StackColumn = tb.loadTable(this.StackColumn);
        }
    }
}
