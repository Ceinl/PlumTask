using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace PlumTask
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Створення домашнього Grid
            Grid homeGrid = Creators.GridCreators.CreateHomeGrid();

            // Додавання його до ContentGrid
            ContentGrid.Children.Add(homeGrid); // додавання до ContentGrid

            // Ініціалізація сторінок
            Creators.PagesCreator.InitializePagesComponent(ContentGrid, NavigationGrid);
        }


        public MainWindow GetMainWindow() 
        {
            return this;
        }

    }
}
 