using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CheckersGUI
{
    public class PieceView : Label
    {
        public PieceView()
        {
            Init();
        }
        
        private void Init()
        {
            Width = 50;
            Height = 50;
            Background = Brushes.Transparent;
        }

        public void SetImagePath(string path)
        {
            ImageBrush imgBrush = new ImageBrush(new BitmapImage(new Uri(path, UriKind.Relative)));
            imgBrush.Stretch = Stretch.Uniform;
            Background = imgBrush;
        }

        public static PieceView FromPath(string path)
        {
            PieceView pieceView = new PieceView();
            pieceView.SetImagePath(path);
            return pieceView;
        }
    }
}
