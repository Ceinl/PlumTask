using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PlumTask.PageFunctions
{
    internal class CardManager
    {
        public static List<ProjectCard> Cards = new List<ProjectCard>();


        public static void AddCard(StackPanel columnPanel, string content)
        {
            ProjectCard card = new ProjectCard(content);
            Cards.Add(card);
            columnPanel.Children.Add(card.Card);
        }


        public void RemoveCard(ProjectCard card)
        {
            Cards.Remove(card);
        }

        private void addChildren(StackPanel columnPanel) {             
            foreach (ProjectCard card in Cards)
            {
               
            }
        }
    }
}
