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
        Image blueSlime = new Image();
        public BlueSlime()
        {
            taps = 1;
            blueSlime.Tapped += BlueSlime_Tapped;
            
        }

        private void BlueSlime_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (taps != 0)
            {
                taps--;
                GamePage.score += 20;
            }
            if (taps == 0)
            {
                getDeathImage();
            }
        }

        public override string getDeathIcon()
        {
            String path = "ms-appx:///Assets/Images/BlueSlimeSqueezedC.png";
            return path;
        }

        public override Image getDeathImage()
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
    
    }
}
