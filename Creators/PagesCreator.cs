using PlumTask.PageFunctions;
using PlumTask.Pages;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PlumTask.Creators
{
    internal static class PagesCreator
    {
        private static readonly Dictionary<string, Grid> _pages = new(); 
        private static Grid? _contentGrid; 
        private static Grid? _navigationGrid;

        private static void PageFabric()
        {
            CreatePage("Home", GridCreators.CreateHomeGrid()); // Legacy
            CreatePage("Project", GridCreators.CreateProjectGrid()); // Legacy
            CreatePage("Schedule", GridCreators.CreateScheduleGrid()); // Legacy


            ProjectPage projectPage = new ProjectPage();
            CreatePage("2roject", projectPage.Create()); // NEW
            
        }


        public static void InitializePagesComponent(Grid contentGrid, Grid navigationGrid)
        {
            SetContentGrid(contentGrid);
            SetNavigationGrid(navigationGrid);

            PageFabric();
        }

        public static void SetContentGrid(Grid grid)
        {
            _contentGrid = grid;
        }

        public static void SetNavigationGrid(Grid grid)
        {
            _navigationGrid = grid;
        }

        public static void CreatePage(string pageName, Grid grid)
        {
            _pages[pageName] = grid; 
            CreateNavButton(pageName.Substring(0, 1), pageName);
        }

        public static void CreateNavButton(string content, string targetPageKey)
        {
            if (_navigationGrid == null)
            {
                Console.WriteLine("Navigation grid is not set.");
                return;
            }

            int currentRowIndex = _navigationGrid.RowDefinitions.Count;
            _navigationGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            Button navButton = new Button
            {
                Content = content,
                Margin = new Thickness(10),
                Padding = new Thickness(10),
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2b5278")),
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fdfdfd")),
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                BorderThickness = new Thickness(0),
                Cursor = System.Windows.Input.Cursors.Hand,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };

            navButton.Click += (sender, e) => ShowPage(targetPageKey);

            Grid.SetRow(navButton, currentRowIndex);
            _navigationGrid.Children.Add(navButton);
        }

        public static void ShowPage(string pageKey)
        {
            if (_contentGrid == null)
            {
                Console.WriteLine("Content grid is not set.");
                return;
            }

            if (_pages.TryGetValue(pageKey, out Grid? targetGrid))
            {
                _contentGrid.Children.Clear(); 
                _contentGrid.Children.Add(targetGrid);
            }
            else
            {
                MessageBox.Show($"Grid with key '{pageKey}' not found.");
            }
        }
    }
}
