using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// <summary>
    /// Interaction logic for Instructions2.xaml
    /// </summary>
    public partial class Instructions2 : Window
    {
        public Instructions2()
        {
            vis.Interval = TimeSpan.FromSeconds(0.5);
            vis.Tick += Vis_Tick;
            InitializeComponent();
        }

        private void Vis_Tick(object sender, EventArgs e)
        {
            mone++;
            if (mone % 2 != 0)
                block.Visibility = Visibility.Visible;
            else
                block.Visibility = Visibility.Hidden;
        }
        private int mone = 0;
        DispatcherTimer vis = new DispatcherTimer();
        private void Window_Activated(object sender, EventArgs e)
        {
            vis.Start();
            DoubleAnimation movecube = new DoubleAnimation();
            movecube.From = 0;
            movecube.To = 1;
            movecube.AutoReverse = true;
            movecube.RepeatBehavior = RepeatBehavior.Forever;
            red.BeginAnimation(TranslateTransform3D.OffsetXProperty, movecube);

            ThicknessAnimation movebutt = new ThicknessAnimation();
            movebutt.AutoReverse = true;
            movebutt.RepeatBehavior = RepeatBehavior.Forever;
            movebutt.To = new Thickness(-90, 132, 693, 311);
            c.BeginAnimation(MarginProperty, movebutt);
            movebutt.To = new Thickness(626, 246, 0, 207);
            r.BeginAnimation(MarginProperty, movebutt);
            movebutt.To = new Thickness(-90, 172, 693, -120);
            q.BeginAnimation(MarginProperty, movebutt);

        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = e.GetPosition(this);
            double x = pt.X;
            double y = pt.Y;
            if (x>=1279 && x<=1356 && y>=708 && y<=751)
            { Nshadow.Opacity = 0;}
            else {  Nshadow.Opacity = 1;}

            if (x >= 1282 && x <= 1350 && y >= 10 && y <= 78)
            { Xshadow.Opacity = 0; }
            else { Xshadow.Opacity = 1; }
           
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point pt = e.GetPosition(this);
            double x = pt.X;
            double y = pt.Y;
            if (x >= 1279 && x <= 1356 && y >= 708 && y <= 751)
            { Instructions1 b = new Instructions1();
                b.Show();
                this.Close();
            }
            

            if (x >= 1282 && x <= 1350 && y >= 10 && y <= 78)
            {
                bridge.turnonfirstscreen = true;
                this.Close(); }
            
        }
    }
}
