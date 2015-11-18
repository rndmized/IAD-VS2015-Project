using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace SlimesFromOuterSpace
{
    public class RedSlime : EnemySlime

    {
        Image redSlime = new Image();
        public RedSlime()
        {
            taps = 1;
            redSlime.Tapped += RedSlime_Tapped;
            
        }

        private void RedSlime_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (taps != 0)
            {
                taps--;
                GamePage.score += 15;
            }
            if (taps == 0)
            {
                getDeathImage();
            }
        }

        public override string getDeathIcon()
        {
            String path = "ms-appx:///Assets/Images/RedSlimeSqueezedC.png";
            return path;
        }

        public override Image getDeathImage()
        {
            redSlime.Source = new BitmapImage(new Uri(getDeathIcon()));
            return redSlime;
        }

        public override string getIcon(int x)
        {
            String path;
            if (x > 4) {path = "ms-appx:///Assets/Images/Slime3-RTU.png"; }
            else {path = "ms-appx:///Assets/Images/Slime3-Right.png"; }     
            return path;
        }

        public override Image getImage()
        {
            return redSlime;
        }

        public override Image getImage(int x)
        {
            redSlime.Source = new BitmapImage(new Uri(getIcon(x)));
            return redSlime;
        }

    }
}
