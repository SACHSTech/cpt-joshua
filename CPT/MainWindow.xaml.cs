﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CPT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dataset ds;
        public MainWindow()
        {
            InitializeComponent();
            ds = new Dataset();
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
                if(this.StackColumn.Height <= 282)
                {
                    Table tb = new Table(580, 3075, 1);
                    this.StackColumn = tb.loadTable(this.StackColumn, ds);
                }
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
            Table tb = new Table(580, 3075, 1);
            this.StackColumn = tb.loadTable(this.StackColumn, ds);
        }

        private void Sort_March_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Sort sort = new Sort();
            sort.SortDoubles(ds.gpus, 0, ds.gpus.Count - 1, "getMarPercent");
            Table tb = new Table(580, 3075, 1);
            this.StackColumn = tb.loadTable(this.StackColumn, ds);
        }

        private void Load_Table_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ds = new Dataset();
            Table tb = new Table(580, 3075, 1);
            this.StackColumn = tb.loadTable(this.StackColumn, ds);
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
            Table tb = new Table(580, 3075, 1);
            this.StackColumn = tb.loadTable(this.StackColumn, ds);
        }
        private void GPU_Graph_Loaded(object sender, RoutedEventArgs e)
        {
            Graph gr = new Graph(241, 134, 1, false);
            this.GPU_Graph = gr.DrawGraph(this.GPU_Graph, ds);

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
    }
}
