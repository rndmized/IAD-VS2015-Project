using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace SlimesFromOuterSpace
{
    public class GreenSlime : EnemySlime

    {
        Image greenSlime = new Image();

        public GreenSlime()
        {
            greenSlime.Tapped += GreenSlime_Tapped;
            taps = 1;
        }

        private void GreenSlime_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {

            if (taps != 0)
            {
                taps--;
                GamePage.score += 10;
            }
            if (taps == 0)
            {
                getDeathImage();
            }
        }

        public override string getDeathIcon()
        {
            String path = "ms-appx:///Assets/Images/GreenSlimeSqueezedC.png";
            return path;
        }

        public override Image getDeathImage()
        {
            greenSlime.Source = new BitmapImage(new Uri(getDeathIcon()));
            return greenSlime;
        }

        public override string getIcon(int x)
        {
            String path;
            if (x > 4) {path = "ms-appx:///Assets/Images/Slime1-RTU.png"; }
            else {path = "ms-appx:///Assets/Images/Slime1-Right.png"; }     
            return path;
        }

        public override Image getImage()
        {
            return greenSlime;
        }

        public override Image getImage(int x)
        {
            greenSlime.Source = new BitmapImage(new Uri(getIcon(x)));
            return greenSlime;
        }


    }
}
