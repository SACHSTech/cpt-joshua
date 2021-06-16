using System;
using System.Collections.Generic;
using System.Data;
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

        // It just works ¯\_(ツ)_/¯
        // https://www.youtube.com/watch?v=YPN0qhSyWy8 
        #region Table Maker
        private void Load_table_Click(object sender, RoutedEventArgs e)
        {
            Dataset ds = new Dataset();
            StackPanel StackColumn = this.StackColumn;
            StackPanel Row;

            Row = addRow();

            Row.Children.Add(addColumn(55, " Ranking"));
            Row.Children.Add(addVSpacer());
            Row.Children.Add(addColumn(220, " Name"));
            Row.Children.Add(addVSpacer());
            Row.Children.Add(addColumn(55, " March %"));
            Row.Children.Add(addVSpacer());
            Row.Children.Add(addColumn(46, " April %"));
            Row.Children.Add(addVSpacer());
            Row.Children.Add(addColumn(44, " May %"));
            Row.Children.Add(addVSpacer());
            Row.Children.Add(addColumn(46, " June %"));
            Row.Children.Add(addVSpacer());
            Row.Children.Add(addColumn(42, " July %"));
            Row.Children.Add(addVSpacer());
            Row.Children.Add(addColumn(60, " August %"));
            Row.Children.Add(addVSpacer());
            Row.Children.Add(addColumn(50, " Change"));
            Row.Children.Add(addVSpacer());

            StackColumn.Children.Add(Row);
            StackColumn.Children.Add(addHSpacer());

            for (int i=0;i<ds.getGPUSize();i++)
            {
                Row = addRow();

                Row.Children.Add(addColumn(55, " "+ds.getGPU(i).getRanking()));
                Row.Children.Add(addVSpacer());
                Row.Children.Add(addColumn(220, " "+ds.getGPU(i).getName()));
                Row.Children.Add(addVSpacer());
                Row.Children.Add(addColumn(55, " "+ds.getGPU(i).getMarPercent()));
                Row.Children.Add(addVSpacer());

                StackColumn.Children.Add(Row);
                StackColumn.Children.Add(addHSpacer());
            }
            this.StackColumn = StackColumn;
        }
        private Grid addColumn(int Width, String Text)
        {
            Grid grid = new Grid();
            TextBlock label = new TextBlock();
            grid.Height = 30;
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.VerticalAlignment = VerticalAlignment.Top;
            grid.Width = Width;
            label.Text = Text;
            label.TextAlignment = TextAlignment.Left;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.Foreground = Brushes.White;
            grid.Children.Add(label);
            return grid;
        }
        private StackPanel addRow()
        {
            StackPanel Row = new StackPanel();
            Row.Height = 30;
            Row.Width = 760;
            Row.HorizontalAlignment = HorizontalAlignment.Left;
            Row.VerticalAlignment = VerticalAlignment.Top;
            Row.Orientation = Orientation.Horizontal;
            return Row;
        }
        private Rectangle addHSpacer()
        {
            Rectangle rect = new Rectangle();
            rect.Height = 1;
            rect.Width = 780;
            rect.Fill = Brushes.White;
            rect.HorizontalAlignment = HorizontalAlignment.Center;
            rect.VerticalAlignment = VerticalAlignment.Center;
            return rect;
        }
        private Rectangle addVSpacer()
        {
            Rectangle rect = new Rectangle();
            rect.Height = 30;
            rect.Width = 1;
            rect.Fill = Brushes.White;
            rect.HorizontalAlignment = HorizontalAlignment.Center;
            rect.VerticalAlignment = VerticalAlignment.Center;
            return rect;
        }
        #endregion Table Maker
    }
}
