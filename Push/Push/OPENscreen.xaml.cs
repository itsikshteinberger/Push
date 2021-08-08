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
    /// Interaction logic for OPENscreen.xaml
    /// </summary>
    public partial class OPENscreen : Window
    {
        
       
        public OPENscreen()
        {
            dooranimation.Completed += Dooranimation_Completed;
            InitializeComponent();
            
        }

        

       
        ThicknessAnimation dooranimation = new ThicknessAnimation(); MainWindow a = new MainWindow();
        private void play_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (bridge.turnonfirstscreen)
            {
                dooranimation.Duration = TimeSpan.FromSeconds(3);
                dooranimation.To = new Thickness(-688, 0, 296, 0);
                leftdoor.BeginAnimation(MarginProperty, dooranimation);
                dooranimation.To = new Thickness(307.2, 0, -709, 0);
                bridge.turnonfirstscreen = false;
                rightdoor.BeginAnimation(MarginProperty, dooranimation);
            }
            
            
        }

        private void Dooranimation_Completed(object sender, EventArgs e)
        {


           
            a.Show();
            this.Close();
        }

        private void about_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (bridge.turnonfirstscreen)
            {
                bridge.turnonfirstscreen = false;
                about a = new about();
                a.Show();
            }
        }

        private void instructions_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (bridge.turnonfirstscreen)
            {
                Instructions1 a = new Instructions1();
                a.Show();
                bridge.turnonfirstscreen = false;
            }
        }

        private void exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (bridge.turnonfirstscreen)
            {
                this.Close();
            }
        }
        private static DoubleAnimation anim = new DoubleAnimation();
        private static double OrigFontSize, MaxFontSize;


        public  void Grow_Up(TextBlock tb)
        {
           
            //אירוע זה מגדיל את התווית הנבחרת כאשר העכבר עליו
            OrigFontSize = tb.FontSize;
            MaxFontSize = OrigFontSize + 5;

            anim.From = tb.FontSize;
            anim.To = MaxFontSize;
            anim.Duration = TimeSpan.FromSeconds(.5);
            tb.BeginAnimation(TextBlock.FontSizeProperty, anim);
        }
public  void Grow_Down(TextBlock tb)
        {//אירוע זה מקטין את התווית הנבחרת כאשר העכבר עזב אותו
            anim.From = tb.FontSize;
            anim.To = OrigFontSize;
            anim.Duration = TimeSpan.FromSeconds(.5);
            tb.BeginAnimation(TextBlock.FontSizeProperty, anim);
        }
        private void textblockmousedown(object sender, MouseEventArgs e)
        {
           
            Grow_Up((TextBlock)sender);
        }

        private void textblockmouseleave(object sender, MouseEventArgs e)
        {
            Grow_Down((TextBlock)sender);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
