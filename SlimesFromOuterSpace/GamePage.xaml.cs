using System;
using System.Threading.Tasks;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SlimesFromOuterSpace
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {

        #region Variable Declarations
       
        double SPAWNTIMER = 2000;
        int minScore;


        int stage = 1;
        float difficultyIncrease = 0.15f;
        float minEnemies = 1;
        float maxEnemies = 3;
        private int time = 30;
        private DispatcherTimer Timer, Spawner;
        Random rnd = new Random();
        public static int score = 0;
 
        #endregion
        public GamePage()
        {
            this.InitializeComponent();
            score = 0;
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Spawner = new DispatcherTimer();
            Spawner.Interval = TimeSpan.FromMilliseconds(SPAWNTIMER);
            Spawner.Tick += Spawner_Tick;
            startTimers();
        }
        #region Timer
        //start Timers - Starts Time and Spawner timers
        private void startTimers()
        {
            Timer.Start();
            Spawner.Start();
        }
        /*end of startTimers method*/

        //Spawn tick
        private void Spawner_Tick(object sender, object e)
        {
            spawn();
        }
        /*end of Spawner tick method*/
       
        //Timer tick
        private void Timer_Tick(object sender, object e)
        {
            
            if (time > 0)
            {
                time--;
                tblDisplay.Text = string.Format("00:0{0}:{1}", time / 60, time % 60);
                updateScore(); 
            }
            else
            {
                Timer.Stop();
                Spawner.Stop();
                grdGame.Children.Clear();
                nextStage();
            }
        }
        //end of timer tick method
        #endregion
        #region Spawner
        //Creates Slimes every X time
        private void spawn()
        {
                grdGame.Children.Clear();
                int enemyNum = rnd.Next((int)minEnemies, (int)maxEnemies);
                for (int k = 0; k <= enemyNum; k++)
                {
                   createSlime();
                }
            
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
                              //end of spawn method
        #endregion
        #region Slime Creation
        //Creates Image with picture of the slime, sets it in a random location and adds it to the grid. Sets counter to 0.
        private void createSlime()
        {
            //Creating new slime Image
            EnemySlime es;


            //Set slime location
            int x = rnd.Next(0, 7);
            int y = rnd.Next(0, 6);
            
            switch (rnd.Next(1, 4))
            {
                default:
                case 1:
                    es = new GreenSlime();
                    break;
                case 2:
                    es = new RedSlime();
                    break;
                case 3:
                    es = new BlueSlime();
                    break;
            }

            es.getImage().SetValue(Grid.RowProperty, y);
            es.getImage().SetValue(Grid.ColumnProperty, x);
            //add Slime to the grid
            grdGame.Children.Add(es.getImage(x));
        }
        #endregion
        #region Score 
        //Increments Score and set TextBlock to result.
        public void updateScore()
        {
            tblScore.Text = "Score: " + score.ToString();
        }
        //end of score method

        private Boolean checkScore()
        {
            minScore += (int) (300 * ((stage * difficultyIncrease)+1));
            if (score >= minScore)
            {     
                stage++;
                tblStage.Text = "Stage " + (stage);
                return true;
            }
            else
            {
                return false;
            }
        }//Check if score is over minScore to reach next Stage
        #endregion
        #region Stage
        public void nextStage()
        {
            if (checkScore())
            {
                minEnemies *= difficultyIncrease+1;
                maxEnemies *= difficultyIncrease+1;
                SPAWNTIMER -= (SPAWNTIMER * difficultyIncrease);
                Spawner.Interval = TimeSpan.FromMilliseconds(SPAWNTIMER);
                time = 30;
                startTimers();
            }
            else
            {
                this.Frame.Navigate(typeof(RecordsPage));
            }
        }
    
        #endregion

    }
}
