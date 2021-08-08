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
    /// Interaction logic for GamePush.xaml
    /// </summary>
    public partial class GamePush : Window
    {
        private DoubleAnimation d = new DoubleAnimation();
        private bool isTurnon = true;
        private DispatcherTimer tmAnim = new DispatcherTimer();
        DispatcherTimer scoreT = new DispatcherTimer();
        DispatcherTimer tmAnim1 = new DispatcherTimer();
        DispatcherTimer winmode_timer = new DispatcherTimer();
        DispatcherTimer timeMone = new DispatcherTimer();
        DispatcherTimer moneWinner = new DispatcherTimer();
        DispatcherTimer firstTimer = new DispatcherTimer();
        private double timeF = 0;
        DoubleAnimation camanim1 = new DoubleAnimation();
        Point3DAnimation camanim2 = new Point3DAnimation();
        Vector3DAnimation camanim3 = new Vector3DAnimation();
        Vector3DAnimation camanim4 = new Vector3DAnimation();
        private int stars = 0;
        private int score = 0, score2 = 0, timetoclose = 0;
        private int milsecond = 0;
        private MainWindow a = new MainWindow();
        private Cube []cubes = new Cube[55];
        private int t1tick = 0, twintick = 0;
        private Cube pushed;
        private int levelnum;
        private int cammode = 1;
        private int x_step = 0, y_step = 0;
        private int needtowin = 4;
        private int[,] board = new int[,] {{3,3,3,3,3,3,3,3,3}
                                          ,{3,0,0,0,0,0,0,0,3}
                                          ,{3,0,0,0,0,0,0,0,3}
                                          ,{3,0,0,0,0,0,0,0,3}
                                          ,{3,0,0,0,0,0,0,0,3}
                                          ,{3,0,0,0,0,0,0,0,3}
                                          ,{3,0,0,0,0,0,0,0,3}
                                          ,{3,0,0,0,0,0,0,0,3}
                                          ,{3,3,3,3,0,3,3,3,3}
                                          ,{3,3,3,3,3,3,3,3,3}}; // 9-red 8-win

       
        
        public GamePush(int levelNumber)
        {
            firstTimer.Tick += FirstTimer_Tick;
            firstTimer.Interval = TimeSpan.FromSeconds(0.5);
            moneWinner.Tick += MoneWinner_Tick;
            moneWinner.Interval = TimeSpan.FromSeconds(0.005);
            scoreT.Interval = TimeSpan.FromSeconds(0.01);
            scoreT.Tick += ScoreT_Tick;
            winmode_timer.Interval = TimeSpan.FromSeconds(0.5);
            winmode_timer.Tick += Winmode_timer_Tick;
            tmAnim.Tick += TmAnim_Tick;
            levelnum = levelNumber;
            d.Completed += D_Completed;
            InitializeComponent();
           
        }

        public void close()
        {
                    ThicknessAnimation dooranimation = new ThicknessAnimation();
                    dooranimation.Duration = TimeSpan.FromSeconds(3);
                    dooranimation.To = new Thickness(-688, 0, 296, 0);
                    leftdoor.BeginAnimation(MarginProperty, dooranimation);
                    dooranimation.To = new Thickness(307.2, 0, -709, 0);
                    dooranimation.Completed += Dooranimation_Completed;
                    rightdoor.BeginAnimation(MarginProperty, dooranimation);
        }

        public void open()
        {
                    ThicknessAnimation dooranimation = new ThicknessAnimation();
                    dooranimation.Duration = TimeSpan.FromSeconds(3);
                    dooranimation.From = new Thickness(307.2, 0, -709, 0);
                    dooranimation.To = new Thickness(1153, 0, -1547, 0);
                    rightdoor.BeginAnimation(MarginProperty, dooranimation);
                    dooranimation.From = new Thickness(-688, 0, 296, 0);
                    dooranimation.To = new Thickness(-1537, 1, 1143, 0);
                    leftdoor.BeginAnimation(MarginProperty, dooranimation);
        }

        private void FirstTimer_Tick(object sender, EventArgs e)
        {
            timeF +=0.5;
            
            if (timeF == 4)
            { makeDark(); }
            if (timeF == 4.5)
            {
                cam.FieldOfView = 42;//<PerspectiveCamera FieldOfView="35" NearPlaneDistance="0.1" FarPlaneDistance="Infinity" Position="" LookDirection="" UpDirection="" x:Name="cam">
                cam.Position = new Point3D(6.5,13,6);
                cam.LookDirection = new Vector3D(-0.4,-0.9,0.0);
                cam.UpDirection = new Vector3D(-0.9,0.4,0.0);
                ro1.Angle = 0;
                cameramove(43,new Point3D(6.5,13,-5),new Vector3D(-0.4,-0.9,0.0),new Vector3D(-0.9,0.4,0.0),3.5);//<PerspectiveCamera FieldOfView="35" NearPlaneDistance="0.1" FarPlaneDistance="Infinity" Position="" LookDirection="" UpDirection="" x:Name="cam">
            }
            if (timeF==7.5)
            { makeDark(); }
            if (timeF == 8)
            {//<PerspectiveCamera FieldOfView="43" NearPlaneDistance="0.1" FarPlaneDistance="Infinity" Position="" LookDirection="" UpDirection="">
                ro1.Angle = 0;
                cam.FieldOfView = 43;
                cam.Position = new Point3D(0.4,11,0.45);
                cam.LookDirection = new Vector3D(0.0, -1.0, 0.0);
                cam.UpDirection = new Vector3D(- 1.0,0.0,0.0);
                cameramove(55, new Point3D(10,27,0.4), new Vector3D(-0.3,-0.9,0.0), new Vector3D(-0.9,0.3,0.0), 3.5);
                // < PerspectiveCamera x: Name = "cam" FieldOfView = "55" NearPlaneDistance = "0.1" FarPlaneDistance = "Infinity" Position = "10,27,0.4" LookDirection = "-0.3,-0.9,0.0" UpDirection = "-0.9,0.3,0.0" />
            }
            if (timeF == 11.5)
            {
                cammode = 1;
                x.Visibility = Visibility.Visible;
                o.Visibility = Visibility.Visible;
                bridge.isfirst2 = false;
                
                scoreT.Start();
                firstTimer.Stop();
               
            }

        }

        private void MoneWinner_Tick(object sender, EventArgs e)
        {
            isTurnon = false;
            score = (int)(button.Width);
            score2 = (int)(button.Height);
            if (score2<milsecond)
            {
                star1.Opacity=1; 
                if (stars>1&& score2>= milsecond/stars) { star2.Opacity = 1; }
                if (stars==3&& (score2>=(milsecond/3)*2)) { star3.Opacity = 1; }
                label1.Text = "SCORE: "+score;
                
            }
            else
            { timetoclose++; }
            if (timetoclose ==30)
            {
                bridge.setPass(levelnum);
                moneWinner.Stop();
                close();
               }
        }

        private void ScoreT_Tick(object sender, EventArgs e)
        {
            milsecond++;
        }

        private void Winmode_timer_Tick(object sender, EventArgs e)
        {
           
            isTurnon = false; 
            twintick++;
            DoubleAnimation DAnim = new DoubleAnimation();
           
            if (twintick == 1)
            {
                pushed.MoveX(6, pushed.position.OffsetX, 0.5);
            }
            if (twintick == 2)
            {  
                pushed.MoveZ(needtowin + 1, pushed.position.OffsetZ, 0.5);
            }
            if (twintick == 3)
            {
                twintick = 0;
                if (needtowin != 0)
                {
                    isTurnon = true;
                    
                }
                else
                {
                    DAnim.Duration = TimeSpan.FromSeconds(3);
                    DAnim.From = 0;
                    DAnim.To = milsecond;
                    button.BeginAnimation(HeightProperty, DAnim);
                    score = 120000 - milsecond;
                    DAnim.From = 0;
                    DAnim.To = score;
                    button.BeginAnimation(WidthProperty, DAnim);
                    if (milsecond<20000) { stars = 3;}
                    else if (milsecond<50000) { stars = 2; }
                    else { stars = 1; }
                    scoreT.Stop();
                    moneWinner.Start();
                    winner.Visibility = Visibility.Visible;
                    label1.Visibility = Visibility.Visible;
                    star1.Visibility = Visibility.Visible;
                    star2.Visibility = Visibility.Visible;
                    star3.Visibility = Visibility.Visible;
                }
               
                winmode_timer.Stop();
            }

        }
        
        private void DAnim_Completed(object sender, EventArgs e)
        {

           
        }

        private void upDatelevel(int lvnm)
        { switch (lvnm) // 9 red 5 yellow 3 rightleft(lightgray) 2 black 1 updown(gray)
                {
                    case 1:
                        board = new int[,]     {{3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 }
                                          , {3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3}
                                          , {3 ,0 ,0 ,0 ,0, 0, 0, 0, 3}
                                          , {3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3}
                                          , {3 ,0 ,24,0 ,51,0 ,25,0 ,3}
                                          , {3 ,0 ,0 ,0 ,21,0 ,0 ,0 ,3}
                                          , {3 ,0 ,23,0 ,0 ,0 ,22,0 ,3}
                                          , {3 ,0 ,0 ,11,9 ,12,0 ,0 ,3}
                                          , {3 ,3 ,3 ,3 ,0 ,3 ,3 ,3 ,3}
                                          , {3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3}};
                        needtowin = 1;
                        break;
                    case 2:
                        needtowin = 1;
                        board = new int[,]     {{3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 }
                                          , {3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3}
                                          , {3 ,0 ,26,0 ,51,0,25, 0, 3}
                                          , {3 ,0 ,0 ,0 ,24,0 ,0 ,0 ,3}
                                          , {3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3}
                                          , {3 ,0 ,31,21,22,23,32,0 ,3}
                                          , {3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3}
                                          , {3 ,0 ,0 ,0 ,9 ,0 ,0 ,0 ,3}
                                          , {3 ,3 ,3 ,3 ,0 ,3 ,3 ,3 ,3}
                                          , {3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3}};
                        break;
                    case 3:
                        needtowin = 2;
                        board = new int[,]     {{3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 }
                                          , {3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3}
                                          , {3 ,0 ,22,0 ,0, 0,23, 0, 3}
                                          , {3 ,0 ,0 ,11,0 ,32,0 ,0 ,3}
                                          , {3 ,0 ,51,0 ,25,0 ,52,0 ,3}
                                          , {3 ,0 ,0 ,31,0 ,12,0 ,0 ,3}
                                          , {3 ,0 ,21,0 ,0 ,0 ,24,0 ,3}
                                          , {3 ,0 ,0 ,0 ,9 ,0 ,0 ,0 ,3}
                                          , {3 ,3 ,3 ,3 ,0 ,3 ,3 ,3 ,3}
                                          , {3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3}};
                        break;
                    case 4:
                        needtowin = 2;
                        board = new int[,]     {{3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 }
                                          , {3 ,0 ,0 ,0 ,27,0 ,0 ,0 ,3}
                                          , {3 ,0 ,0,28, 0, 0, 0, 0, 3}
                                          , {3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3}
                                          , {3 ,26,0 ,0 ,22,52,0 ,0 ,3} // 9 red 5 yellow 3 rightleft(lightgray) 2 black 1 updown(gray)
                                          , {3 ,0 ,11,31,0 ,51,0 ,0 ,3}
                                          , {3 ,0 ,24,0 ,0 ,23,0 ,0 ,3}
                                          , {3 ,0 ,0 ,0 ,9 ,0 ,0 ,21,3}
                                          , {3 ,3 ,3 ,3 ,0 ,3 ,3 ,3 ,3}
                                          , {3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3}};
                        break;
                    case 5:
                        needtowin = 2;
                        board = new int[,]     {{3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 }
                                          , {3 ,0 ,0 ,0 ,23,0 ,0 ,0 ,3}
                                          , {3 ,0 ,0 ,0 ,24, 0, 0, 0, 3}
                                          , {3 ,0 ,0 ,0 ,25,0 ,0 ,0 ,3}
                                          , {3 ,0 ,0 ,0 ,26,0 ,0 ,0 ,3}
                                          , {3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3}
                                          , {3 ,21,52,12,31,11,51,22,3}
                                          , {3 ,0 ,0 ,0 ,9 ,0 ,0 ,0 ,3}
                                          , {3 ,3 ,3 ,3 ,0 ,3 ,3 ,3 ,3}
                                          , {3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3}};
                        break;
                    case 6:
                        needtowin = 3;
                        board = new int[,]     {{3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 }
                                          , {3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3}
                                          , {3 ,0 ,51,0 ,52, 0,53, 0, 3}
                                          , {3 ,0 ,23,34,0 ,35,24,0 ,3}
                                          , {3 ,0 ,0 ,0 ,12,0 ,0 ,0 ,3}// 9 red 5 yellow 3 rightleft(lightgray) 2 black 1 updown(gray)
                                          , {3 ,0 ,22,33,31,32,21,0 ,3}
                                          , {3 ,0 ,0 ,0 ,11,0 ,0 ,0 ,3}
                                          , {3 ,0 ,0 ,0 ,9 ,0 ,0 ,0 ,3}
                                          , {3 ,3 ,3 ,3 ,0 ,3 ,3 ,3 ,3}
                                          , {3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3}};
                        break;
                    case 7:
                        needtowin = 3;
                        board = new int[,]     {{3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 }
                                          , {3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3}
                                          , {3 ,0 ,0 ,52,0,23, 0, 0, 3}
                                          , {3 ,0 ,27,32,0 ,53,31,24,3}
                                          , {3 ,0 ,0 ,0 ,22,0 ,0 ,0 ,3}
                                          , {3 ,26,0 ,0 ,11,0 ,25,0 ,3}
                                          , {3 ,0 ,0 ,28,51,0 ,0 ,0 ,3}
                                          , {3 ,0 ,0 ,0 ,9 ,21,0 ,0 ,3}
                                          , {3 ,3 ,3 ,3 ,0 ,3 ,3 ,3 ,3}
                                          , {3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3}};
                        break;
                    case 8:
                        needtowin = 3;
                        board = new int[,]     {{3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 }
                                          , {3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3}
                                          , {3 ,0 ,0 ,52,0 ,53, 0, 0, 3}
                                          , {3 ,0 ,27,31,26,32,28,0 ,3}
                                          , {3 ,0 ,0 ,0 ,51,0 ,0 ,0 ,3}
                                          , {3 ,0 ,23,0 ,24,0 ,25,0 ,3}
                                          , {3 ,22,0 ,11,0 ,12,0 ,21,3}
                                          , {3 ,0 ,0 ,0 ,9 ,0 ,0 ,0 ,3}// 9 red 5 yellow 3 rightleft(lightgray) 2 black 1 updown(gray)
                                          , {3 ,3 ,3 ,3 ,0 ,3 ,3 ,3 ,3}
                                          , {3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3}};
                        break;
                    case 9:
                        needtowin = 4;
                        board = new int[,]     {{3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 }
                                          , {3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3}
                                          , {3 ,0 ,27,32,0,33,28, 0, 3}
                                          , {3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3}
                                          , {3 ,26,53,24,31,23,54,25,3}
                                          , {3 ,0 ,0 ,51,0 ,52,0 ,0 ,3}
                                          , {3 ,0 ,22,0 ,0 ,0 ,21,0 ,3}
                                          , {3 ,0 ,0 ,0 ,9 ,0 ,0 ,0 ,3}
                                          , {3 ,3 ,3 ,3 ,0 ,3 ,3 ,3 ,3}
                                          , {3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3}};
                        break;
                    case 10:
                        needtowin = 4;
                        board = new int[,]     {{3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 }
                                          , {3 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,3}
                                          , {3 ,0 ,0 ,27,0,52,26, 0, 3}
                                          , {3 ,0 ,0 ,0 ,28,0 ,0 ,25,3}
                                          , {3 ,32,54,31,53,0 ,0 ,0 ,3}
                                          , {3 ,0 ,0 ,0 ,22,0 ,0 ,24,3}
                                          , {3 ,0 ,0 ,21,0 ,51,23,0 ,3}// 9 red 5 yellow 3 rightleft(lightgray) 2 black 1 updown(gray)
                                          , {3 ,0 ,0 ,0 ,9 ,0 ,0 ,0 ,3}
                                          , {3 ,3 ,3 ,3 ,0 ,3 ,3 ,3 ,3}
                                          , {3 ,3 ,3 ,3 ,3 ,3 ,3 ,3 ,3}};
                        break;
                } }

        private void TmAnim_Tick(object sender, EventArgs e)
        {
            t1tick++;
            if (t1tick == 2)
            {
                upDatelevel(levelnum);

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {

                        if (board[i, j] == 9)
                        {
                            cubes[9].MoveY(0, cubes[9].position.OffsetY, 0.2);
                            cubes[9].MoveX(3, cubes[9].position.OffsetX, 0.2);
                            cubes[9].MoveZ(0, cubes[9].position.OffsetZ, 0.2);
                            x_step = j;
                            y_step = i;
                        }

                        if (cubes[board[i, j]] != null && board[i, j] != 9)
                        {
                            
                            cubes[board[i, j]].MoveZ(4 - j, cubes[board[i, j]].position.OffsetZ, 0.2);
                            cubes[board[i, j]].MoveX(i - 4, cubes[board[i, j]].position.OffsetX, 0.2);
                            cubes[board[i, j]].MoveY(0, cubes[board[i, j]].position.OffsetY,0.2);
                        }
                    }
                }
            }
            if (t1tick == 3)
            {   
                tmAnim.Stop();
            }
        }   

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (isTurnon&& cubes[9].position.OffsetX==(int)cubes[9].position.OffsetX && cubes[9].position.OffsetZ == (int)cubes[9].position.OffsetZ)
            {
                if (e.Key == Key.C)
            {
                    turnoffforwhile(1);
                cammode++;
                if (cammode == 4)
                    cammode = 1;
                switch (cammode)
                {
                    case 1:{cameramove(55, new Point3D(10, 27, 0.4), new Vector3D(-0.3, -0.9, 0.0), new Vector3D(-0.9, 0.3, 0.0), 1);}
                         break;
                    case 2:{cameramove(45, new Point3D(23, 27, 23), new Vector3D(-0.5, -0.7, -0.5), new Vector3D(-0.5, 0.8, -0.5), 1);}
                         break;
                    case 3:{cameramove(42, new Point3D(20, 36, -20), new Vector3D(-0.4, -0.8, 0.4), new Vector3D(-0.5, 0.6, 0.6), 1);}
                        break;
                    default: cammode = 1;
                             cameramove(55, new Point3D(10, 27, 0.4), new Vector3D(-0.3, -0.9, 0.0), new Vector3D(-0.9, 0.3, 0.0), 1);
                        break;
                }            
            }
                if (e.Key == Key.Q)
                {
                    isTurnon = false;
                    close();
                    
                    
                }
                if (e.Key == Key.R)
                {
                    turnoffforwhile(1.4);
                    tmAnim.Interval = TimeSpan.FromSeconds(0.5);
                    t1tick = 0;
                    tmAnim.Start();

                    for (int i = 0; i < board.GetLength(0); i++)
                    {
                        for (int j = 0; j < board.GetLength(1); j++)
                        {

                            if (board[i, j] == 9)
                            { 
                                cubes[9].MoveX(0, cubes[9].position.OffsetX, 0.2);
                                cubes[9].MoveY(5, cubes[9].position.OffsetY, 0.2);
                                cubes[9].MoveZ(0, cubes[9].position.OffsetZ, 0.2);
                            }

                            if (cubes[board[i, j]] != null)
                            { 
                                cubes[board[i, j]].MoveZ(0, cubes[board[i, j]].position.OffsetZ,0.2);                              
                                cubes[board[i, j]].MoveX(0, cubes[board[i, j]].position.OffsetX, 0.2);        
                                cubes[board[i, j]].MoveY(5, cubes[board[i, j]].position.OffsetY, 0.2);
                            }
                        }
                    }
                }

                if ((e.Key == Key.Left || e.Key == Key.Right))
                {
                    int a = 1;
                    if (e.Key == Key.Left)
                        a = -1;
                    bool move = true;
                    if (board[y_step, x_step + 1 * a] != 0)
                    {
                        if (board[y_step, x_step + 1 * a] == 3 || cubes[9].position.OffsetY != 0 || cubes[board[y_step, x_step + 1 * a]].Getcolor() == "light gray" || cubes[board[y_step, x_step + 1 * a]].Getcolor() == "black")
                        { move = false; }
                        else if (board[y_step, x_step + 1 * a] != 0 && board[y_step, x_step + 2 * a] != 0) { move = false; }
                    }
                    if (move)
                    {
                        turnoffforwhile(0.5);
                        if (board[y_step, x_step + 1 * a] != 0)
                        {
                            if (cubes[board[y_step, x_step + 1 * a]].Getcolor() == "gray" || cubes[board[y_step, x_step + 1 * a]].Getcolor() == "yellow")
                            {
                                cubes[board[y_step, x_step + 1 * a]].MoveZ(cubes[board[y_step, x_step + 1 * a]].position.OffsetZ - 1 * a, cubes[board[y_step, x_step + 1 * a]].position.OffsetZ, 0.5);
                                board[y_step, x_step + 2 * a] = board[y_step, x_step + 1 * a];
                                board[y_step, x_step + 1 * a] = 0;
                            }
                        }
                        board[y_step, x_step] = 0;
                        board[y_step, x_step + 1 * a] = 9;
                        x_step += 1 * a;    
                        cubes[9].MoveZ(cubes[9].position.OffsetZ - 1 * a, cubes[9].position.OffsetZ,0.5);
                    }
                }
                if ((e.Key == Key.Down || e.Key == Key.Up))
                {
                    bool move = true;
                    int a = 1;
                    if (e.Key == Key.Up)
                        a = -1;
                    bool pushmode = false;
                    if (board[y_step + 1 * a, x_step] != 0)
                    {
                        if (x_step == 4 && y_step == 6 && cubes[board[y_step + 1*a, x_step]].Getcolor() == "yellow" && e.Key == Key.Down) { pushmode = true; }
                        
                        if (board[y_step + 1 * a, x_step] == 3 || cubes[9].position.OffsetY != 0 || cubes[board[y_step + 1 * a, x_step]].Getcolor() == "black" || cubes[board[y_step + 1 * a, x_step]].Getcolor() == "gray")
                        { move = false; }
                        else if (board[y_step + 1 * a, x_step] != 0 && board[y_step + 2 * a, x_step] != 0 && !pushmode) { move = false; }
                    }
                   
                    if (move)
                    {
                        turnoffforwhile(0.5);
                        if (board[y_step + 1 * a, x_step] != 0)
                        {
                            if (cubes[board[y_step + 1 * a, x_step]].Getcolor() == "light gray" || cubes[board[y_step + 1 * a, x_step]].Getcolor() == "yellow")
                            {
                                cubes[board[y_step + 1 * a, x_step]].MoveX(cubes[board[y_step + 1 * a, x_step]].position.OffsetX + 1 * a, cubes[board[y_step + 1 * a, x_step]].position.OffsetX, 0.5);
                                if (pushmode && e.Key == Key.Down)
                                {
                                    pushed = cubes[board[y_step + 1, x_step]];
                                    board[8, 9 - needtowin] = board[y_step + 1, x_step];
                                    board[y_step + 1, x_step] = 0;
                                    needtowin--;
                                    winmode_timer.Start();
                                }
                                board[y_step + 2 * a, x_step] = board[y_step + 1 * a, x_step];
                                board[y_step + 1 * a, x_step] = 0;
                            }
                        }

                        board[y_step, x_step] = 0;
                        board[y_step + 1 * a, x_step] = 9;
                        y_step += 1 * a;
                        cubes[9].MoveX(cubes[9].position.OffsetX + 1 * a, cubes[9].position.OffsetX, 0.5);
                    }
                }
            }
        }

        private void Dooranimation_Completed(object sender, EventArgs e)
        {          
                    a.Show();
                   this.Close();
        }
        
        private void Window_Activated(object sender, EventArgs e)
        {
           if (button.Margin != new Thickness(1000, 1000, 1000, 1000))
            {
                button.Margin = new Thickness(1000, 1000, 1000, 1000);
                bridge.currentlevel = levelnum;
                if (!bridge.isfirst2)
                {
                    turnoffforwhile(3);
                    x.Visibility = Visibility.Visible;
                    o.Visibility = Visibility.Visible;
                    scoreT.Start();
                    open();
                    
                }
                else
                {
                    DoubleAnimation dark_anim = new DoubleAnimation();
                    dark_anim.Duration = TimeSpan.FromSeconds(1);
                    dark_anim.From = 1;
                    dark_anim.To = 0;
                    dark.BeginAnimation(OpacityProperty, dark_anim);
                }
                //begin
               
                Model3DGroup c = ((Model3DGroup)FindResource("CubeModel")).Clone();
                cubes[9] = new Cube(0,0,-100,"red", c.Clone());
                AllCubes.Children.Add(cubes[9].CubeGame);
                cubes[54] = new Cube(0,0,-100,"yellow", c.Clone());
                AllCubes.Children.Add(cubes[54].CubeGame);
                cubes[53] = new Cube(0, 0, -100, "yellow", c.Clone());
                AllCubes.Children.Add(cubes[53].CubeGame);
                cubes[52] = new Cube(0, 0, -100, "yellow", c.Clone());
                AllCubes.Children.Add(cubes[52].CubeGame);
                cubes[51] = new Cube(0, 0, -100, "yellow", c.Clone());
                AllCubes.Children.Add(cubes[51].CubeGame);
                cubes[21] = new Cube(0,0,-100,"black", c.Clone());
                AllCubes.Children.Add(cubes[21].CubeGame);
                cubes[22] = new Cube(0, 0, -100, "black",c.Clone());
                AllCubes.Children.Add(cubes[22].CubeGame);
                cubes[23] = new Cube(0, 0, -100, "black", c.Clone());
                AllCubes.Children.Add(cubes[23].CubeGame);
                cubes[24] = new Cube(0, 0, -100, "black",  c.Clone());
                AllCubes.Children.Add(cubes[24].CubeGame);
                cubes[25] = new Cube(0, 0, -100, "black",  c.Clone());
                AllCubes.Children.Add(cubes[25].CubeGame);
                cubes[26] = new Cube(0, 0, -100, "black",  c.Clone());
                AllCubes.Children.Add(cubes[26].CubeGame);
                cubes[27] = new Cube(0, 0, -100, "black",  c.Clone());
                AllCubes.Children.Add(cubes[27].CubeGame);
                cubes[28] = new Cube(0, 0, -100, "black",  c.Clone());
                AllCubes.Children.Add(cubes[28].CubeGame);
                cubes[31] = new Cube(0,0,-100,"light gray", c.Clone());
                AllCubes.Children.Add(cubes[31].CubeGame);
                cubes[32] = new Cube(0, 0, -100, "light gray", c.Clone());
                AllCubes.Children.Add(cubes[32].CubeGame);
                cubes[33] = new Cube(0, 0, -100, "light gray",  c.Clone());
                AllCubes.Children.Add(cubes[33].CubeGame);
                cubes[34] = new Cube(0, 0, -100, "light gray",  c.Clone());
                AllCubes.Children.Add(cubes[34].CubeGame);
                cubes[35] = new Cube(0, 0, -100, "light gray",  c.Clone());
                AllCubes.Children.Add(cubes[35].CubeGame);
                cubes[11] = new Cube(0,0,-100,"gray", c.Clone());
                AllCubes.Children.Add(cubes[11].CubeGame);
                cubes[12] = new Cube(0, 0, -100, "gray", c.Clone());
                AllCubes.Children.Add(cubes[12].CubeGame);


                upDatelevel(levelnum);
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == 9)
                        {
                            y_step = i;
                            x_step = j;
                            cubes[9].position.OffsetX = i - 4;
                            cubes[9].position.OffsetZ = 4 - j;
                            DoubleAnimation DAnim = new DoubleAnimation();
                            DAnim.Completed += DAnim_Completed;
                            cubes[9].MoveY(0, 13, 3);
                        }
                        else if (cubes[board[i, j]] != null && board[i, j] != 9)

                        {
                            cubes[board[i, j]].position.OffsetX = i - 4;
                                cubes[board[i, j]].position.OffsetZ = 4 - j;
                            if (!bridge.isfirst2)
                            {
                                cubes[board[i, j]].position.OffsetY = 0;
                                
                            }
                            else
                            {
                                DoubleAnimation danim = new DoubleAnimation();
                                danim.From = -2;
                                danim.To = 0;
                                danim.Duration = TimeSpan.FromSeconds(3);
                                cubes[board[i, j]].MoveY(0, -2, 3);

                            }
                        }
                    }
                }
                if (bridge.isfirst2)
                {
                    turnoffforwhile(11.5);
                    firstTimer.Start();
                    cam.FieldOfView = 50;
                    cam.Position = new Point3D(8,9,8);
                    cam.LookDirection = new Vector3D(-0.5,-0.7,-0.5);
                    cam.UpDirection = new Vector3D(-0.5, 0.7, -0.5);//<PerspectiveCamera FieldOfView="50" NearPlaneDistance="0.1" FarPlaneDistance="Infinity" Position="8,9,8" LookDirection="" UpDirection="" x:Name="cam">
                    DoubleAnimation danim = new DoubleAnimation();
                    danim.From = 70;
                    danim.To = 0;
                    danim.Duration = TimeSpan.FromSeconds(4.7);
                    ro1.BeginAnimation(AxisAngleRotation3D.AngleProperty,danim);
                    
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isTurnon)
            {
                Point pt = e.GetPosition(this);
                double x = pt.X;
                double y = pt.Y;

                if (x >= 1230 && x <= 1276 && y >= 10 && y <= 83)
                {


                    Instructions1 sc = new Instructions1();
                    sc.Show();

                }
                if (x >= 1291 && x <= 1351 && y >= 10 && y <= 82)
                { App.Current.Shutdown(); }
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (isTurnon)
            {
                Point pt = e.GetPosition(this);
                double x = pt.X;
                double y = pt.Y;

                if (x >= 1230 && x <= 1276 && y >= 10 && y <= 83)
                {
                    oshadow.Opacity = 0;
                }
                else
                { oshadow.Opacity = 1; }
                if (x >= 1291 && x <= 1351 && y >= 10 && y <= 82)
                { Xshadow.Opacity=0; }
                else { Xshadow.Opacity = 1; }
            }
        }

        private void makeDark()
        {
            DoubleAnimation danim = new DoubleAnimation();
            danim.From = 0;
            danim.To = 1;
            danim.Duration = TimeSpan.FromSeconds(0.5);
            danim.AutoReverse = true;
            dark.BeginAnimation(OpacityProperty, danim);
        } 

        private void cameramove(double feild , Point3D position ,Vector3D lookD , Vector3D upD,double time)
        {
            camanim1.To = feild;
            camanim2.To = position;
            camanim3.To = lookD;
            camanim4.To = upD;
            camanim1.Duration = TimeSpan.FromSeconds(time);
            camanim2.Duration = TimeSpan.FromSeconds(time);
            camanim3.Duration = TimeSpan.FromSeconds(time);
            camanim4.Duration = TimeSpan.FromSeconds(time);
            cam.BeginAnimation(PerspectiveCamera.FieldOfViewProperty, camanim1);
            cam.BeginAnimation(PerspectiveCamera.PositionProperty, camanim2);
            cam.BeginAnimation(PerspectiveCamera.LookDirectionProperty, camanim3);
            cam.BeginAnimation(PerspectiveCamera.UpDirectionProperty, camanim4);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void turnoffforwhile(double second)
        {
            isTurnon = false;
            d.Duration = TimeSpan.FromSeconds(second);
            button.BeginAnimation(OpacityProperty, d);
        }

        private void D_Completed(object sender, EventArgs e)
        {
            isTurnon = true;
        }

        private void create(int curCube) // התקבלה החלטה לבסוף לא לממש את הפונקציה עקב חוסר החשיבות
        {// 9 red 5 yellow 3 rightleft(lightgray) 2 black 1 updown(gray)
            switch (curCube/10)
            {
                case 0: switch (curCube)
                    {
                        case 9: //red
                            break;
                        case 3: //demoblack
                            break;
                        case 0: // nothing
                            break;
                    }
                    break;
                case 5:  //yellow
                    break;
                case 3:  //lightgray
                    break;
                case 2: //black
                    break;
                case 1: //gray
                    break;
            }
        }
    }
}
