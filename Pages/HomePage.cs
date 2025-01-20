using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace PlumTask.Pages
{
    internal class HomePage : Pages
    {
        public static Grid Create()
        {
            Grid grid = new Grid();

            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            TextBlock textBlock = new TextBlock();
            textBlock.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFD, 0xFD, 0xFD));
            textBlock.FontSize = 16;
            textBlock.FontWeight = FontWeights.Bold;

            Grid.SetRow(textBlock, 1);
            Grid.SetColumn(textBlock, 1);
            grid.Children.Add(textBlock);

            return grid;
        }
    }
}
