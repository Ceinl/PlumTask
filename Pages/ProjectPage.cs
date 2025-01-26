using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using PlumTask.PageFunctions;
using PlumTask.UI_elements;
using System.Windows.Controls.Primitives;

namespace PlumTask.Pages
{
    internal class ProjectPage
    {

        public static string cardcontent = "new card";

        private static Grid windowGrid;

        public Grid Create()
        {
            windowGrid = new Grid();

            for (int i = 0; i < 3; i++)
            {
                windowGrid.ColumnDefinitions.Add(new ColumnDefinition());
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
                
                columnPanel.MouseLeftButtonDown += ColumnDoubleClickEvent;

                Grid.SetColumn(columnPanel, i);
                windowGrid.Children.Add(columnPanel);


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
                        Tag = i
                    };

                    card.PreviewMouseMove += Card_PreviewMouseMove;
                    columnPanel.Children.Add(card);
                }
            }

            return windowGrid;
        }



        private static void ColumnDoubleClickEvent(object sender, MouseButtonEventArgs e)
        {
            var createCardPopup = new CreateCardPopup(); 

            var popup = new Popup
            {
                Child = createCardPopup,  
                IsOpen = true,
                StaysOpen = false, 
                 PlacementTarget = (UIElement)windowGrid,  
                Placement = PlacementMode.Center,  
                AllowsTransparency = true,  
                HorizontalOffset = 0, 
                VerticalOffset = 0,
                Width = 400,
                Height = 450

            };

            CardManager.AddCard((StackPanel)sender, cardcontent);
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
    }
}
