using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CPT
{
    /// <summary>
    /// It just works ¯\_(ツ)_/¯
    /// https://www.youtube.com/watch?v=YPN0qhSyWy8 
    /// </summary>
    class Table
    {
        private int width, height, thinkness;
        public Table(int width, int height, int thinkness)
        {
            this.width = width;
            this.height = height;
            this.thinkness = thinkness;
        }
        public StackPanel loadTable(StackPanel stackPanel)
        {
            Dataset ds = new Dataset();
            StackPanel StackColumn = stackPanel;
            StackColumn.Height = height;
            StackColumn.Width = width;
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
            Row.Children.Add(addColumn(50, " Change"));
            Row.Children.Add(addVSpacer());

            StackColumn.Children.Add(Row);
            StackColumn.Children.Add(addHSpacer());

            for (int i = 0; i < ds.getGPUSize(); i++)
            {
                Row = addRow();

                Row.Children.Add(addColumn(55, " " + ds.getGPU(i).getRanking()));
                Row.Children.Add(addVSpacer());
                Row.Children.Add(addColumn(220, " " + ds.getGPU(i).getName()));
                Row.Children.Add(addVSpacer());
                Row.Children.Add(addColumn(55, " " + ds.getGPU(i).getMarPercent()));
                Row.Children.Add(addVSpacer());
                Row.Children.Add(addColumn(46, " " + ds.getGPU(i).getAprPercent()));
                Row.Children.Add(addVSpacer());
                Row.Children.Add(addColumn(44, " " + ds.getGPU(i).getMayPercent()));
                Row.Children.Add(addVSpacer());
                Row.Children.Add(addColumn(46, " " + ds.getGPU(i).getJunPercent()));
                Row.Children.Add(addVSpacer());
                Row.Children.Add(addColumn(42, " " + ds.getGPU(i).getJulPercent()));
                Row.Children.Add(addVSpacer());
                Row.Children.Add(addColumn(50, " " + ds.getGPU(i).getChange()));
                Row.Children.Add(addVSpacer());

                StackColumn.Children.Add(Row);
                StackColumn.Children.Add(addHSpacer());
            }
            return StackColumn;
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
            Row.Width = width;
            Row.HorizontalAlignment = HorizontalAlignment.Left;
            Row.VerticalAlignment = VerticalAlignment.Top;
            Row.Orientation = Orientation.Horizontal;
            return Row;
        }
        private Rectangle addHSpacer()
        {
            Rectangle rect = new Rectangle();
            rect.Height = thinkness;
            rect.Width = width;
            rect.Fill = Brushes.White;
            rect.HorizontalAlignment = HorizontalAlignment.Center;
            rect.VerticalAlignment = VerticalAlignment.Center;
            return rect;
        }
        private Rectangle addVSpacer()
        {
            Rectangle rect = new Rectangle();
            rect.Height = 30;
            rect.Width = thinkness;
            rect.Fill = Brushes.White;
            rect.HorizontalAlignment = HorizontalAlignment.Center;
            rect.VerticalAlignment = VerticalAlignment.Center;
            return rect;
        }
    }
}
