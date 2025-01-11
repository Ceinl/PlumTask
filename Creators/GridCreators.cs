using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PlumTask.Creators
{
    internal static class GridCreators
    {
        public static Grid CreateHomeGrid()
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

        /* --------------------- --------------------- --------------------- --------------------- */

        public static Grid CreateProjectGrid()
        {
            Grid grid = new Grid();

            for (int i = 0; i < 3; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < 3; i++)
            {
                StackPanel columnPanel = new StackPanel
                {
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#182533")),
                    Margin = new Thickness(i == 0 ? 0 : 10, 0, i == 2 ? 0 : 10, 0),
                    AllowDrop = true 
                };

                columnPanel.Drop += ColumnPanel_Drop;
                columnPanel.DragOver += ColumnPanel_DragOver;

                Grid.SetColumn(columnPanel, i);
                grid.Children.Add(columnPanel);

                for (int j = 0; j < 2; j++)
                {
                    Button card = new Button
                    {
                        Height = 100,
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2b5278")),
                        Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fdfdfd")),
                        Content = $"Картка {i + 1}.{j + 1}",
                        Margin = new Thickness(10),
                        BorderThickness = new Thickness(0),
                    };

                    card.PreviewMouseMove += Card_PreviewMouseMove;
                    columnPanel.Children.Add(card);
                }
            }

            return grid;
        }

        private static void Card_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Button card = (Button)sender;
                DragDrop.DoDragDrop(card, card, DragDropEffects.Move);
            }
        }

        private static void ColumnPanel_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
        }

        private static void ColumnPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Button)) is Button card)
            {
                StackPanel targetPanel = (StackPanel)sender;
                StackPanel sourcePanel = (StackPanel)card.Parent;

                if (targetPanel != sourcePanel)
                {
                    sourcePanel.Children.Remove(card);
                    targetPanel.Children.Add(card);
                }
            }
        }

        /* --------------------- --------------------- --------------------- --------------------- */









        public static Grid CreateScheduleGrid() 
        {
            return new Grid();
        }


    }
}


