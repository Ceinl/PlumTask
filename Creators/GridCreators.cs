using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        public static Grid CreateProjectGrid()
        {
            Grid grid = new Grid();

            // Додаємо 3 стовпці
            for (int i = 0; i < 3; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Створюємо Canvas для кожного стовпця з маргіном
            for (int i = 0; i < 3; i++)
            {
                Canvas canvas = new Canvas();

                // Задаємо заливку в форматі хекса
                canvas.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#182533")); // Колір фону

                // Задаємо маргін для Canvas
                canvas.Margin = new Thickness(i == 0 ? 0 : 10, 0, i == 2 ? 0 : 10, 0); // Маргін тільки між стовпцями

                // Додаємо Canvas в Grid (ставимо його в потрібну колонку)
                Grid.SetColumn(canvas, i);

                // Обробник даблкліка по Canvas
                canvas.MouseWheel += (sender, e) =>
                {
                    CreateCardOnCanvas((Canvas)sender);
                };

                // Додаємо Canvas в Grid
                grid.Children.Add(canvas);
            }

            return grid;
        }

        private static void CreateCardOnCanvas(Canvas canvas)
        {
            // Створюємо нову карточку
            Border card = new Border
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6347")), // Томатний колір (замінити за потреби)
                Width = canvas.ActualWidth * 0.9, // Карточка займає 90% ширини Canvas
                Height = 100, // Висота карточки
                Margin = new Thickness(0),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            // Обчислюємо центр для вирівнювання
            double left = (canvas.ActualWidth - card.Width) / 2;

            // Додаємо карточку на Canvas
            canvas.Children.Add(card);
            Canvas.SetLeft(card, left); // Вирівнюємо по центру
        }







        public static Grid CreateScheduleGrid() 
        {
            return new Grid();
        }


    }
}


