using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Checkers.Model;

namespace CheckersGUI
{
    /// <summary>
    /// Interaction logic for TypeMenu.xaml
    /// </summary>
    public partial class TypeMenu : Window
    {
        private List<Player> _m=new List<Player> { new GUIHumanPlayer(), new GUIHumanPlayer() };
        public List<Player> m
        {
            get { return _m; }
            set { _m = value; }
        }
        public TypeMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            m = new List<Player> { new GUIHumanPlayer(), new GUIHumanPlayer() };
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            m = new List<Player> { new GUIHumanPlayer(), new NewAIPlayer() };
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            m = new List<Player> { new NewAIPlayer(), new NewAIPlayer() };
            this.Close();
        }
    }
}
