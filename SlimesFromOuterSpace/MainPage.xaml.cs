using System;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SlimesFromOuterSpace
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static int score = 0;
        public MainPage()
        {
            this.InitializeComponent();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
            btnStartGame.Click += BtnStartGame_Click;
            btnCheckRecords.Click += BtnCheckRecords_Click;
            btnExit.Click += BtnExit_Click;
            score = 0;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
            //end program?
        }

        private void BtnCheckRecords_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RecordsPage));
        }

        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GamePage));
        }
    }
}
