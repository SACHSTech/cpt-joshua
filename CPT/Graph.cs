using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CPT
{
    class Graph
    {
        private Grid graph;
        private int width, height, thickness;
        private bool bg;
        public Graph(int width, int height, int thickness, bool bg)
        {
            this.width = width;
            this.height = height;
            this.thickness = thickness;
            this.bg = bg;
        }
        public Grid DrawGraph(Grid grid)
        {
            graph = new Grid();
            graph = grid;
            graph.Width = width;
            graph.Height = height;
            graph.Children.Clear();

            DrawBG();

            return graph;
        }
        private void DrawBG()
        {
            Rectangle rect;

            if (bg)
            {
                rect = new Rectangle();
                rect.Width = width;
                rect.Height = height;
                rect.Fill = Brushes.Black;
                graph.Children.Add(rect);
            }

            rect = new Rectangle();
            rect.Width = width;
            rect.HorizontalAlignment = HorizontalAlignment.Right;
            rect.VerticalAlignment = VerticalAlignment.Bottom;
            rect.Margin = new Thickness(0, 0, 0, 10);
            rect.Height = thickness;
            rect.Fill = Brushes.White;
            graph.Children.Add(rect);

            rect = new Rectangle();
            rect.Width = thickness;
            rect.HorizontalAlignment = HorizontalAlignment.Left;
            rect.VerticalAlignment = VerticalAlignment.Top;
            rect.Margin = new Thickness(0, 0, 0, 0);
            rect.Height = height-10;
            rect.Fill = Brushes.White;
            graph.Children.Add(rect);
        }

        public void AddBar(double value, double barThickness, Brush barColor, double barPosition, string name, double fontSize, double fontXDisplacement, double fontYDisplacement)
        {
            Rectangle rect = new Rectangle();
            rect.Width = barThickness;
            rect.HorizontalAlignment = HorizontalAlignment.Left;
            rect.VerticalAlignment = VerticalAlignment.Bottom;
            rect.Margin = new Thickness(barPosition + thickness, 0, 0, 10 + thickness);
            rect.Height = value;
            rect.Fill = barColor;
            graph.Children.Add(rect);

            TextBlock text = new TextBlock();
            text.Text = name;
            text.FontSize = fontSize;
            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.TextAlignment = TextAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Bottom;
            text.Margin = new Thickness(barPosition + thickness + fontXDisplacement, 0, 0, fontYDisplacement);
            text.Foreground = barColor;
            graph.Children.Add(text);

            text = new TextBlock();
            text.Text = value+"%";
            text.FontSize = fontSize/1.3;
            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.TextAlignment = TextAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Bottom;
            text.Foreground = barColor;
            //text.Margin = new Thickness(-(10 + thickness + (text.Text.Length*fontSize/5)), 0, 0, value + thickness + fontSize / 1.3);
            text.Margin = new Thickness(barPosition + thickness , 0, 0, value + fontSize + thickness);
            graph.Children.Add(text);
        }
        public void ClearBars()
        {
            graph.Children.Clear();
        }
        public void RemoveBar(int barNumber)
        {
            graph.Children.RemoveAt(barNumber);
        }
    }
}
