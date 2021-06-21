using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System;
using System.Timers;

namespace CPT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dataset ds = new Dataset();
        private Table tb;
        public MainWindow()
        {
            InitializeComponent();
            ds.loadGPU();
            ds.loadCPU();
        }
        private SolidColorBrush moreInf = new SolidColorBrush(Color.FromRgb(99, 186, 236));
        private SolidColorBrush buttonHighlight = new SolidColorBrush(Color.FromArgb(40, 0, 0, 0));
        private bool clickHold = false;
        private double gpu_removed = 0;
        private double cpu_removed = 0;
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

        private async void CPU_More_Info_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clickHold = true;
            await Task.Delay(300);
            clickHold = false;
        }

        private void CPU_More_Info_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (clickHold)
            {
                CPU_More_Info_Grid.Visibility = Visibility.Visible;
            }
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

        private void Load_Table_MouseEnter(object sender, MouseEventArgs e)
        {
            Load_Table_Highlight.Visibility = Visibility.Visible;
        }

        private void Load_Table_MouseLeave(object sender, MouseEventArgs e)
        {
            Load_Table_Highlight.Visibility = Visibility.Hidden;
        }

        private void Sort_Name_MouseEnter(object sender, MouseEventArgs e)
        {
            Sort_Name_Highlight.Visibility = Visibility.Visible;
        }

        private void Sort_Name_MouseLeave(object sender, MouseEventArgs e)
        {
            Sort_Name_Highlight.Visibility = Visibility.Hidden;
        }

        private void Sort_March_MouseEnter(object sender, MouseEventArgs e)
        {
            Sort_March_Highlight.Visibility = Visibility.Visible;
        }

        private void Sort_March_MouseLeave(object sender, MouseEventArgs e)
        {
            Sort_March_Highlight.Visibility = Visibility.Hidden;
        }

        private void Sort_Name_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Sort sort = new Sort();
            sort.SortStrings(ds.gpus, 0, ds.gpus.Count - 1, "");
            tb = new Table(580, 3075 - gpu_removed, 1);
            this.StackColumn = tb.loadGPUTable(this.StackColumn, ds);
        }

        private void Sort_March_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Sort sort = new Sort();
            sort.SortDoubles(ds.gpus, 0, ds.gpus.Count - 1, "getMarPercent");
            tb = new Table(580, 3075 - gpu_removed, 1);
            this.StackColumn = tb.loadGPUTable(this.StackColumn, ds);
        }

        private void Load_Table_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Sort sort = new Sort();
            sort.SortDoubles(ds.gpus, 0, ds.gpus.Count - 1, "getRanking");
            tb = new Table(580, 3075 - gpu_removed, 1);
            this.StackColumn = tb.loadGPUTable(this.StackColumn, ds);
        }

        private void Sort_April_MouseEnter(object sender, MouseEventArgs e)
        {
            Sort_April_Highlight.Visibility = Visibility.Visible;
        }

        private void Sort_April_MouseLeave(object sender, MouseEventArgs e)
        {
            Sort_April_Highlight.Visibility = Visibility.Hidden;
        }

        private void Sort_April_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Sort sort = new Sort();
            sort.SortDoubles(ds.gpus, 0, ds.gpus.Count - 1, "getAprPercent");
            tb = new Table(580, 3075 - gpu_removed, 1);
            this.StackColumn = tb.loadGPUTable(this.StackColumn, ds);
        }
        private void Sort_May_MouseEnter(object sender, MouseEventArgs e)
        {
            Sort_May_Highlight.Visibility = Visibility.Visible;
        }
        private void Sort_May_MouseLeave(object sender, MouseEventArgs e)
        {
            Sort_May_Highlight.Visibility = Visibility.Hidden;
        }

        private void Sort_May_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Sort sort = new Sort();
            sort.SortDoubles(ds.gpus, 0, ds.gpus.Count - 1, "getMayPercent");
            tb = new Table(580, 3075 - gpu_removed, 1);
            this.StackColumn = tb.loadGPUTable(this.StackColumn, ds);
        }
        private void Sort_June_MouseEnter(object sender, MouseEventArgs e)
        {
            Sort_June_Highlight.Visibility = Visibility.Visible;
        }

        private void Sort_June_MouseLeave(object sender, MouseEventArgs e)
        {
            Sort_June_Highlight.Visibility = Visibility.Hidden;
        }

        private void Sort_June_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Sort sort = new Sort();
            sort.SortDoubles(ds.gpus, 0, ds.gpus.Count - 1, "getJunPercent");
            tb = new Table(580, 3075 - gpu_removed, 1);
            this.StackColumn = tb.loadGPUTable(this.StackColumn, ds);
        }
        private void Sort_July_MouseEnter(object sender, MouseEventArgs e)
        {
            Sort_July_Highlight.Visibility = Visibility.Visible;
        }

        private void Sort_July_MouseLeave(object sender, MouseEventArgs e)
        {
            Sort_July_Highlight.Visibility = Visibility.Hidden;
        }

        private void Sort_July_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Sort sort = new Sort();
            sort.SortDoubles(ds.gpus, 0, ds.gpus.Count - 1, "getJulPercent");
            tb = new Table(580, 3075 - gpu_removed, 1);
            this.StackColumn = tb.loadGPUTable(this.StackColumn, ds);
        }
        private void Sort_Change_MouseEnter(object sender, MouseEventArgs e)
        {
            Sort_Change_Highlight.Visibility = Visibility.Visible;
        }

        private void Sort_Change_MouseLeave(object sender, MouseEventArgs e)
        {
            Sort_Change_Highlight.Visibility = Visibility.Hidden;
        }

        private void Sort_Change_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {   
            Sort sort = new Sort();
            sort.SortDoubles(ds.gpus, 0, ds.gpus.Count - 1, "getChange");
            tb = new Table(580, 3075 - gpu_removed, 1);
            this.StackColumn = tb.loadGPUTable(this.StackColumn, ds);
        }
        private void GPU_Graph_Loaded(object sender, RoutedEventArgs e)
        {
            Graph gr = new Graph(241, 134, 1, false);
            this.GPU_Graph = gr.DrawGraph(this.GPU_Graph);

            double nvidiaPercent = 0.00, amdPercent = 0.00, intelPercent = 0.00, otherPercent = 0.00;

            foreach (GPU gpu in ds.gpus)
            {
                string gpuMfg = gpu.getName().Substring(0, 3);
                switch (gpuMfg)
                {
                    case "NVI":
                        nvidiaPercent += gpu.getJulPercent();
                        break;
                    case "AMD":
                        amdPercent += gpu.getJulPercent();
                        break;
                    case "Int":
                        intelPercent += gpu.getJulPercent();
                        break;
                    case "Oth":
                        otherPercent += gpu.getJulPercent();
                        break;
                }
            }

            /*for(int i = 0; i < ds.gpus.Count; i++)
            {
                string gpuMfg = ds.getGPU(i).getName().Substring(0, 3);
                switch (gpuMfg)
                {
                    case "NVI":
                        nvidiaPercent += ds.getGPU(i).getJulPercent();
                        break;
                    case "AMD":
                        amdPercent += ds.getGPU(i).getJulPercent();
                        break;
                    case "Int":
                        intelPercent += ds.getGPU(i).getJulPercent();
                        break;
                    case "Oth":
                        otherPercent += ds.getGPU(i).getJulPercent();
                        break;
                }
            }*/
            gr.AddBar(otherPercent, 30, new SolidColorBrush(Color.FromRgb(0xF9, 0xE0, 0x7F)), 20, "Other", 12, 0, -5);
            gr.AddBar(nvidiaPercent, 30, new SolidColorBrush(Color.FromRgb(0x98, 0xb3, 0x54)), 70, "Nvidia", 12, -2, -5);
            gr.AddBar(intelPercent, 30, new SolidColorBrush(Color.FromRgb(0x00, 0xBC, 0xB4)), 120, "Intel", 12, 4, -5);
            gr.AddBar(amdPercent, 30, new SolidColorBrush(Color.FromRgb(0xD4, 0x6C, 0x4E)), 170, "AMD", 12, 1.5, -5);
        }

        private void GPU_More_Info_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            tb = new Table(580, 3075, 1);
            this.StackColumn = tb.loadGPUTable(this.StackColumn, ds);
        }

        private async void Back_MouseEnter(object sender, MouseEventArgs e)
        {
            // Back_Highlight.Visibility = Visibility.Visible;
            Back_Highlight.Width = 0;
            Back_Highlight.Visibility = Visibility.Visible;
            while (Back_Highlight.Width < 20)
            {
                Back_Highlight.Width += 4;
                await Task.Delay(10);
            }
        }

        private async void Back_MouseLeave(object sender, MouseEventArgs e)
        {
            //Back_Highlight.Visibility = Visibility.Hidden;
            while (Back_Highlight.Width > 0)
            {
                Back_Highlight.Width -= 4;
                await Task.Delay(10);
            }
            Back_Highlight.Visibility = Visibility.Hidden;
        }

        private async void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clickHold = true;
            await Task.Delay(300);
            clickHold = false;
        }

        private void Back_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (clickHold)
            {
                GPU_More_Info_Grid.Visibility = Visibility.Hidden;
            }
        }

        private async void Search_bar_TextChanged(object sender, TextChangedEventArgs e)
        {
            gpu_removed = 0;
            if (Search_bar.Text != "")
            {
                Search_label.Visibility = Visibility.Hidden;
                ds.loadGPU();

                for (int t = 0; t < 10; t++)
                {
                    for (int i = 0; i < ds.getGPUSize(); i++)
                    {
                        if (!ds.getGPU(i).getRanking().ToString().Contains(Search_bar.Text) && ds.getGPU(i).getName().IndexOf(Search_bar.Text, 0, StringComparison.CurrentCultureIgnoreCase) == -1 && !ds.getGPU(i).getMarPercent().ToString().Contains(Search_bar.Text) && !ds.getGPU(i).getAprPercent().ToString().Contains(Search_bar.Text) && !ds.getGPU(i).getMayPercent().ToString().Contains(Search_bar.Text) && !ds.getGPU(i).getJunPercent().ToString().Contains(Search_bar.Text) && !ds.getGPU(i).getJulPercent().ToString().Contains(Search_bar.Text) && !ds.getGPU(i).getChange().ToString().Contains(Search_bar.Text))
                        {
                            ds.removeGPU(ds.getGPU(i));
                            gpu_removed += 30;
                        }
                    }
                }
            }
            else
            {
                Search_label.Visibility = Visibility.Visible;
                ds.loadGPU();
            }

            await Task.Delay(300);
            tb = new Table(580, 3075- gpu_removed, 1);
            this.StackColumn = tb.loadGPUTable(this.StackColumn, ds);
        }

        private void CPU_Graph_Loaded(object sender, RoutedEventArgs e)
        {
            Graph gr2 = new Graph(241, 134, 1, false);
            this.CPU_Graph = gr2.DrawGraph(this.CPU_Graph);

            double other = 0.00, eight = 0.00, six = 0.00, four = 0.00, two = 0.00;
            foreach (CPU cpu in ds.cpus)
            {
                switch (cpu.Cores)
                {
                    case 8: 
                        eight = cpu.Jul;
                        break;
                    case 6:
                        six = cpu.Jul;
                        break;
                    case 4:
                        four = cpu.Jul;
                        break;
                    case 2:
                        two = cpu.Jul;
                        break;
                }
            }
            other = Math.Round(100 - (eight + six + four + two), 2);
            gr2.AddBar(other, 20, new SolidColorBrush(Color.FromRgb(0xEE, 0xE7, 0xDF)), 20, "Other", 12, -4, -5);
            gr2.AddBar(eight, 20, new SolidColorBrush(Color.FromRgb(0x4D, 0x85, 0x81)), 60, "8 core", 12, -6, -5);
            gr2.AddBar(six, 20, new SolidColorBrush(Color.FromRgb(0xDB, 0xCB, 0xBE)), 100, "6 core", 12, -6, -5);
            gr2.AddBar(four, 20, new SolidColorBrush(Color.FromRgb(0xB0, 0x98, 0x8E)), 140, "4 core", 12, -6, -5);
            gr2.AddBar(two, 20, new SolidColorBrush(Color.FromRgb(0xAB, 0xDE, 0xD7)), 180, "2 core", 12, -6, -5);
        }

        private void CPU_Back_MouseEnter(object sender, MouseEventArgs e)
        {
            CPU_Back_Highlight.Visibility = Visibility.Visible;
        }

        private void CPU_Back_MouseLeave(object sender, MouseEventArgs e)
        {
            CPU_Back_Highlight.Visibility = Visibility.Hidden;
        }

        private async void CPU_Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clickHold = true;
            await Task.Delay(300);
            clickHold = false;
        }

        private void CPU_Back_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (clickHold)
            {
                CPU_More_Info_Grid.Visibility = Visibility.Hidden;
            }
        }

        private void CPU_More_Info_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            tb = new Table(466, 1550, 1);
            this.CPU_StackColumn = tb.loadCPUTable(this.CPU_StackColumn, ds);
        }

        private async void CPU_Search_bar_TextChanged(object sender, TextChangedEventArgs e)
        {
            cpu_removed = 0;
            if (CPU_Search_bar.Text != "")
            {
                CPU_Search_label.Visibility = Visibility.Hidden;
                ds.loadCPU();

                for (int t = 0; t < 10; t++)
                {
                    for (int i = 0; i < ds.getCPUSize(); i++)
                    {
                        if (!ds.getCPU(i).Ranking.ToString().Contains(CPU_Search_bar.Text) && !ds.getCPU(i).Cores.ToString().Contains(CPU_Search_bar.Text) && ds.getCPU(i).OS.IndexOf(CPU_Search_bar.Text, 0, StringComparison.CurrentCultureIgnoreCase) == -1 && !ds.getCPU(i).Mar.ToString().Contains(CPU_Search_bar.Text) && !ds.getCPU(i).Apr.ToString().Contains(CPU_Search_bar.Text) && !ds.getCPU(i).May.ToString().Contains(CPU_Search_bar.Text) && !ds.getCPU(i).Jun.ToString().Contains(CPU_Search_bar.Text) && !ds.getCPU(i).Jul.ToString().Contains(CPU_Search_bar.Text) && !ds.getCPU(i).Change.ToString().Contains(CPU_Search_bar.Text))
                        {
                            ds.removeCPU(ds.getCPU(i));
                            cpu_removed += 30;
                        }
                    }
                }
            }
            else
            {
                CPU_Search_label.Visibility = Visibility.Visible;
                ds.loadCPU();
            }

            await Task.Delay(300);
            tb = new Table(466, 1550 - cpu_removed, 1);
            this.CPU_StackColumn = tb.loadCPUTable(this.CPU_StackColumn, ds);
        }
    }
}
