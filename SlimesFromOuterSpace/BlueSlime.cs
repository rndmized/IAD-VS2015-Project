using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace SlimesFromOuterSpace
{
    public class BlueSlime : EnemySlime

    {
        //Creates Image Object
        Image blueSlime = new Image();

        //Class Constructor
        public BlueSlime()
        {
            //Sets Taps to 1
            taps = 1;
            //Create tapped method for Image
            blueSlime.Tapped += BlueSlime_Tapped;
            
        }

        //When Blue Slime Image is tapped checks its health points, increments score and change image if mob is dead
        private void BlueSlime_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (taps != 0)//Check number of taps, if it is different than 0...
            {
                taps--;//Decreases taps by one 
            }//end if
            if (taps == 0)//Checks taps value, if it equals 0 the mob is dead.
            {
                GamePage.score += 20; //Score goes up
                getDeathImage(); //Change objects image to defeated mob image.
            }
        }

        #region Image handling


        public override string getDeathIcon()
        {
            String path = "ms-appx:///Assets/Images/BlueSlimeSqueezedC.png";
            return path;
        }//Returns string path of defeated mob PNG

        public override Image getDeathImage()//Returns image with a new bitmap of defeated mob
        {
            blueSlime.Source = new BitmapImage(new Uri(getDeathIcon()));
            return blueSlime;
        }

        public override string getIcon(int x)
        {
            String path;
            if (x > 4) {path = "ms-appx:///Assets/Images/Slime2-RTU.png"; }
            else {path = "ms-appx:///Assets/Images/Slime2-Right.png"; }     
            return path;
        }

        public override Image getImage()
        { 
            return blueSlime;
        }

        public override Image getImage(int x)
        {
            blueSlime.Source = new BitmapImage(new Uri(getIcon(x)));
            return blueSlime;
        }
    # endregion
    }
}
