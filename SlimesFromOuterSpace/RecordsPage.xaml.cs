using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SlimesFromOuterSpace
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RecordsPage : Page
    {
        int value;

        //Create localSettings Data Storage Container
        Windows.Storage.ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;


        public RecordsPage()
        {
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
            this.InitializeComponent();
            btnMenu.Tapped += BtnMenu_Tapped;
            checkScore();
            tblScore.Text = "Score: " + GamePage.score + " / Best Score: " + localSettings.Values["savedScore"];


        }

        private void BtnMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        public void checkScore()
        {
            if (localSettings.Values["savedScore"] == null) { localSettings.Values["savedScore"] = "0"; }
            value = Int32.Parse(localSettings.Values["savedScore"].ToString());
            if ( value < GamePage.score)
            {
                localSettings.Values["savedScore"] = GamePage.score.ToString();
            }
        }
    }
}
