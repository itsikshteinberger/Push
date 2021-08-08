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
    /// Interaction logic for Instructions1.xaml
    /// </summary>
    public partial class Instructions1 : Window
    {
        public Instructions1()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            DoubleAnimation roat = new DoubleAnimation();
            roat.Duration = TimeSpan.FromSeconds(3);
            roat.From = 1;
            roat.To = 361;
            roat.RepeatBehavior = RepeatBehavior.Forever;
            ro1.BeginAnimation(AxisAngleRotation3D.AngleProperty, roat);
        }



       

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        { Point pt = e.GetPosition(this);
            double x = pt.X;
            double y = pt.Y;
            if (x >= 1279 && x <= 1356 && y >= 708 && y <= 751)
            {
                Instructions2 b = new Instructions2();
                b.Show();
                this.Close();
            }


            if (x >= 1282 && x <= 1350 && y >= 10 && y <= 78)
            {
                bridge.turnonfirstscreen = true;
                this.Close();}

        }

        private void Window_MouseMove_1(object sender, MouseEventArgs e)
        {
 Point pt = e.GetPosition(this);
            double x = pt.X;
            double y = pt.Y;
            if (x >= 1279 && x <= 1356 && y >= 708 && y <= 751)
            { Nshadow.Opacity = 0; }
            else { Nshadow.Opacity = 1; }

            if (x >= 1282 && x <= 1350 && y >= 10 && y <= 78)
            { Xshadow.Opacity = 0; }
            else { Xshadow.Opacity = 1; }
        }
    }
}
