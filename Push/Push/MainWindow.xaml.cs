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
using System.IO;

namespace Push
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Model3DGroup[] levels;
        public string[] imageslevel;
        public MainWindow()
        {
            to11.Completed += To11_Completed;
            to21.Completed += To21_Completed;
            CloseAnim1.Completed += CloseAnim1_Completed;
            openanim1.Completed += Openanim1_Completed;
            camanim1.Completed += Camanim1_Completed;
            InitializeComponent();
            InitializeLeves();
        }

        private void To11_Completed(object sender, EventArgs e)
        {
            bridge.currentscreen = 1;
            screen1(Visibility.Visible);
            updateanim(openanim1, new Thickness(-703, 0, 309, 0), new Thickness(-1585, 0, 1191, 0), openanim2, new Thickness(297, 0, -691, 0), new Thickness(1292, 0, -1686, 0));
        }

        private void To21_Completed(object sender, EventArgs e)
        {
            bridge.currentscreen = 2;
            screen1(Visibility.Hidden);
            updateanim(openanim1, new Thickness(-703, 0, 309, 0), new Thickness(-1585, 0, 1191, 0), openanim2, new Thickness(297, 0, -691, 0), new Thickness(1292, 0, -1686, 0));
        }

        private void Openanim1_Completed(object sender, EventArgs e)
        {
            TurnOn = true;
        }

        ThicknessAnimation openanim1 = new ThicknessAnimation();
        ThicknessAnimation openanim2 = new ThicknessAnimation();
        ThicknessAnimation to21 = new ThicknessAnimation();
        ThicknessAnimation to22 = new ThicknessAnimation();
        ThicknessAnimation to11 = new ThicknessAnimation();
        ThicknessAnimation to12 = new ThicknessAnimation();
        private bool again = true;
        about a = new about();
        Instructions1 b = new Instructions1();
        ThicknessAnimation dooranimation1 = new ThicknessAnimation(); // לא חשוב
        ThicknessAnimation dooranimation2 = new ThicknessAnimation(); // לא חשוב
        private int levelNumber = 0, camroatate = 0;
        private ThicknessAnimation CloseAnim1 = new ThicknessAnimation();
        private ThicknessAnimation CloseAnim2 = new ThicknessAnimation();
        private bool TurnOn = true,activeagain=true;
        private bool finish = true;
        DoubleAnimation camanim1 = new DoubleAnimation();
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if ( finish &&TurnOn&&bridge.currentscreen==2)
            {
                if (e.Key == Key.Q)
                { updateanim(to11, leftdoor.Margin, new Thickness(-703, 0, 309, 0), to12, rightdoor.Margin, new Thickness(297, 0, -691, 0)); }
                TurnOn = false;

                if (e.Key == Key.Left)
                {
                    camroatate -= 30;
                    levelNumber--;
                }
                if (e.Key == Key.Right)
                {
                    camroatate += 30;
                    levelNumber++;
                }
                if (levelNumber == 12)
                    levelNumber = 0;
                if (levelNumber == -1)
                    levelNumber = 11;

                camanim1.To = camroatate;
                ro1.BeginAnimation(AxisAngleRotation3D.AngleProperty, camanim1);
                paintbackround(levelNumber);

                if (e.Key == Key.Enter && levelNumber != 0)
                {
                    if (levelNumber == 11)
                    {
                        Random randLev = new Random();
                        levelNumber = randLev.Next(10) + 1;
                    }
                    finish = false;
                    updateanim(CloseAnim1, leftdoor.Margin, new Thickness(-703, 0, 309, 0), CloseAnim2, rightdoor.Margin, new Thickness(297, 0, -691, 0));
                }
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (activeagain)
            {
                //dooranimation1.To = new Thickness(297, 0, -691, 0);
                //dooranimation2.To = new Thickness(-703, 0, 309, 0);
                activeagain = false;
                if (TurnOn)
                {
                    TurnOn = true;
                    if (bridge.currentscreen==2)
                    {
                        TurnOn = false;
                        screen1(Visibility.Hidden);
                        updateanim(openanim1,new Thickness(-703, 0, 309, 0), new Thickness(-1585, 0, 1191, 0), openanim2, new Thickness(297, 0, -691, 0) ,new Thickness( 1292, 0, -1686, 0));
                    }
                    levelNumber = bridge.currentlevel;
                    ro1.Angle = bridge.currentlevel * 30;
                    camroatate = bridge.currentlevel * 30;
                    paintbackround(levelNumber);
                    DoubleAnimation op = new DoubleAnimation();
                    op.From = 1;
                    op.To = 0;
                    op.RepeatBehavior = RepeatBehavior.Forever;
                    op.AutoReverse = true;
                    op.Duration = TimeSpan.FromSeconds(1.5);
                    Instruction.BeginAnimation(SolidColorBrush.OpacityProperty, op);
                    finish = true;
                    
                    
                }
            }
        }

        private void CloseAnim1_Completed(object sender, EventArgs e)
        {
            
            if (!bridge.isfirst2&&again)
            {
                again = false;
                GamePush gp = new GamePush(levelNumber);
                gp.Show();
                this.Close();
            }
            else
            {
                if (dark.Opacity == 0)
                {
                    DoubleAnimation dark_anim = new DoubleAnimation();
                    dark_anim.To = 1;
                    dark_anim.Completed += Dark_anim_Completed;
                    dark.BeginAnimation(OpacityProperty, dark_anim);
                }
            }
        }

        private void updateanim(ThicknessAnimation anim1,Thickness from1,Thickness to1, ThicknessAnimation anim2, Thickness from2,Thickness to2)
        {
            TurnOn = false;
            anim1.Duration = TimeSpan.FromSeconds(3);
            anim2.Duration = TimeSpan.FromSeconds(3);
            anim1.From = from1;
            anim2.From = from2;
            anim1.To = to1;
            anim2.To = to2;
            leftdoor.BeginAnimation(MarginProperty, anim1);
            rightdoor.BeginAnimation(MarginProperty, anim2);
            
        }

        private void Dark_anim_Completed(object sender, EventArgs e)
        {
            if (again)
            {
                again = false;
                GamePush gp = new GamePush(levelNumber);
                gp.Show();
                this.Close();
            }
        }

        private void Camanim1_Completed(object sender, EventArgs e)
        {
            TurnOn = true;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            DoubleAnimation txtAnimbigger = new DoubleAnimation();
            txtAnimbigger.To = 81;
            DoubleAnimation txtAnimsmaller = new DoubleAnimation();
            txtAnimsmaller.To = 76;
            txtAnimbigger.Duration = TimeSpan.FromSeconds(0.25);
            txtAnimsmaller.Duration = TimeSpan.FromSeconds(0.25);
           

            Point pt = e.GetPosition(this);
            double x = pt.X;
            double y = pt.Y;
            if (bridge.currentscreen==1&&TurnOn)
            {
                if (x >= 208 && x <= 324 && y >= 251 && y <= 287)
                { play.BeginAnimation(FontSizeProperty, txtAnimbigger);  }
                else { play.BeginAnimation(FontSizeProperty, txtAnimsmaller); }
                if (x >= 188 && x <= 343 && y >= 340 && y <= 373)
                { about.BeginAnimation(FontSizeProperty, txtAnimbigger); }
                else { about.BeginAnimation(FontSizeProperty, txtAnimsmaller); }
                if (x >= 111 && x <= 442 && y >= 421 && y <= 454)
                { instructions.BeginAnimation(FontSizeProperty, txtAnimbigger); }
                else { instructions.BeginAnimation(FontSizeProperty, txtAnimsmaller); }
                if (x >= 215 && x <= 316 && y >= 505 && y <= 538)
                { exit.BeginAnimation(FontSizeProperty, txtAnimbigger); }
                else { exit.BeginAnimation(FontSizeProperty, txtAnimsmaller); }


            }
            if (bridge.currentscreen == 2)
            {
                

                if (x >= 1230 && x <= 1276 && y >= 10 && y <= 83)
                {
                    oshadow.Opacity = 0;
                }
                else
                { oshadow.Opacity = 1; }
                if (x >= 1291 && x <= 1351 && y >= 10 && y <= 82)
                { Xshadow.Opacity = 0; }
                else { Xshadow.Opacity = 1; }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point pt = e.GetPosition(this);
                double x = pt.X;
                double y = pt.Y;
            if (TurnOn&&bridge.currentscreen == 1)
            {
                if (x >= 208 && x <= 324 && y >= 251 && y <= 287)
                {
                    TurnOn = false;
                    updateanim(to21, leftdoor.Margin, new Thickness(-703, 0, 309, 0), to22, rightdoor.Margin, new Thickness(297, 0, -691, 0));
                }
                if (x >= 188 && x <= 343 && y >= 340 && y <= 373)
                { a.Show(); }
                if (x >= 111 && x <= 442 && y >= 421 && y <= 454)
                { b.Show(); }
                if (x >= 215 && x <= 316 && y >= 505 && y <= 538)
                { App.Current.Shutdown(); }

            }
            if (TurnOn&&bridge.currentscreen==2)
            {
                

                if (x >= 1230 && x <= 1276 && y >= 10 && y <= 83)
                {
                    Instructions1 sc = new Instructions1();
                    sc.Show();
                }
                if (x >= 1291 && x <= 1351 && y >= 10 && y <= 82)
                { App.Current.Shutdown(); }
            }
        }

        private void paintbackround(int levnum)
        {
            if (bridge.levelcounter() < 10)
            {
                if (bridge.getPass(levelNumber))
                { back.Source = new BitmapImage(new Uri(@"images\green.jpg", UriKind.Relative)); }
                else { back.Source = new BitmapImage(new Uri(@"images\blue.jpg", UriKind.Relative)); }
                   
            }
            else
            {
               back.Source = new BitmapImage(new Uri(@"Images\winscreen.jpg", UriKind.Relative));
            }
        }
       
        DoubleAnimation anim = new DoubleAnimation();
        private static double OrigFontSize, MaxFontSize;
        
        private void Dooranimation_Completed2(object sender, EventArgs e)
        {
            screen1(Visibility.Visible);
            bridge.currentscreen = 1;
        }

        

       
       
        private void Dooranimation_Completed1(object sender, EventArgs e)
        {
            dooranimation1.Duration = TimeSpan.FromSeconds(3);
            dooranimation2.Duration = TimeSpan.FromSeconds(3);
            dooranimation1.To = new Thickness(-1585, 0, 1191, 0);
            dooranimation2.To = new Thickness(1292, 0, -1686, 0);
            rightdoor.BeginAnimation(MarginProperty, dooranimation2);
            leftdoor.BeginAnimation(MarginProperty, dooranimation1);
            bridge.currentscreen = 2;
            screen1(Visibility.Hidden);
        }

        private void screen1(Visibility show)
        {
            back1.Visibility = show;
            play.Visibility = show;
            about.Visibility = show;
            instructions.Visibility = show;
            exit.Visibility = show;
        }

        

        

        public void InitializeLeves()
        {
            int angle = 30;
            levels = new Model3DGroup[12];
            imageslevel = Directory.GetFiles("..\\..\\LevelsImages");
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = ((Model3DGroup)this.FindResource("LevelModel")).Clone();
                levels[i].Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), angle), new Point3D(0, 0, 0));
                ((ImageBrush)((DiffuseMaterial)((GeometryModel3D)levels[i].Children[0]).Material).Brush).ImageSource
                    = new BitmapImage(new Uri(imageslevel[i], UriKind.Relative));
                LevelsGroup.Children.Add(levels[i]);
                angle += 30;
            }
        }
    }
}
