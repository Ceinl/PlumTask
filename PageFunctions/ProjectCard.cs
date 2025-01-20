using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PlumTask.PageFunctions
{
    internal class ProjectCard
    {
        public Button Card;
        public int cardLocation; // 0 - 2

        public ProjectCard(String Content)
        {
            Card = Create(Content);
        }

        public static Button Create(string Content) 
        {
            Button card = new Button
            {
                Height = 100,
                Background = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#2b5278")),
                Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#fdfdfd")),
                Content = Content,
                Margin = new System.Windows.Thickness(10),
                BorderThickness = new System.Windows.Thickness(0),
            };

            card.PreviewMouseMove += Card_PreviewMouseMove;

            return card;
        }

        private static void Card_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) // TODO check for double click
            {
                Button card = (Button)sender;
                DragDrop.DoDragDrop(card, card, DragDropEffects.Move);
            }
        }
    }
}
