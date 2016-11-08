using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CheckersGUI
{
    public class SquareView : Label
    {
        public SquareView()
        {
            //Background = Brushes.Transparent;
            Background = Brushes.Red;
            BorderBrush = Brushes.Black;
            BorderThickness = new Thickness(3);
        }
    }
}
