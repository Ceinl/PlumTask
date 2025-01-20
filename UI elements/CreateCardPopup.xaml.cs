using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PlumTask.UI_elements
{
    /// <summary>
    /// Interaction logic for CreateCardPopup.xaml
    /// </summary>
    public partial class CreateCardPopup : UserControl
    {
        public CreateCardPopup()
        {
            InitializeComponent();
            
        }


        private void Button_Click(object sender, RoutedEventArgs e) // Legacy button to close the popup
        {
            if (Parent is Popup popup)
            {
                popup.IsOpen = false;
            }
        }



    }
}
