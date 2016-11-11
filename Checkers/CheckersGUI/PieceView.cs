using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CheckersGUI
{
    /// <summary>
    /// This represents the view for a Checkers Piece.
    /// </summary>
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
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(path);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = myStream;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();
            ImageBrush imgBrush = new ImageBrush(image);
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
