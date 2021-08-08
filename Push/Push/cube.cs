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
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Timers;
using System.Windows.Navigation;

namespace Push
{
    public class Cube
    {
        public DoubleAnimation Move = new DoubleAnimation();
        public TranslateTransform3D position;
        public Model3DGroup CubeGame;
        public string color;
        public Cube(int X,int Z,int Y,string colorC, Model3DGroup cube)
        {
            //createcube
            CubeGame = cube;
            position = new TranslateTransform3D(X, Y, Z);
            CubeGame.Transform = position;
            ((ImageBrush)((DiffuseMaterial)((GeometryModel3D)cube.Children[0]).Material).Brush).ImageSource
                    = new BitmapImage(new Uri("..\\..\\Images\\"+colorC+".jpg", UriKind.Relative));
            Move.Duration = TimeSpan.FromSeconds(0.5);
            color = colorC;
        }
        public void MoveX(double to,double from,double tm)
        {
            UpDate(from, to, tm);
            position.BeginAnimation(TranslateTransform3D.OffsetXProperty, Move);
        }
        public void MoveZ(double to,double from,double tm)
        {
            UpDate(from, to, tm);
            position.BeginAnimation(TranslateTransform3D.OffsetZProperty, Move);
        }
        public void MoveY(double to,double from,double tm)
        {
            UpDate(from,to,tm);
            position.BeginAnimation(TranslateTransform3D.OffsetYProperty, Move);
        }
        public void UpDate(double from,double to,double tm)
        {
            Move.Duration = TimeSpan.FromSeconds(tm);
            Move.To = to;
            Move.From = from;
        }

        public string Getcolor() { return color;}

    }
}
