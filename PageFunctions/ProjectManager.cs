using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace PlumTask.PageFunctions
{
    internal class ProjectManager
    {

        private static void CreateCardOnCanvas(Canvas canvas)
        {
            Border card = new Border
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6347")), 
                Width = canvas.ActualWidth * 0.9,
                Height = 100, 
                Margin = new Thickness(0),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            double left = (canvas.ActualWidth - card.Width) / 2;

            canvas.Children.Add(card);
            Canvas.SetLeft(card, left); 
        }

    }
}
