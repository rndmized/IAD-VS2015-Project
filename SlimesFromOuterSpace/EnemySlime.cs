using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace SlimesFromOuterSpace
{
   public abstract class EnemySlime
    {
        String color;
        public int taps;

        public abstract Image getImage(int x);
        public abstract Image getImage();
        public abstract Image getDeathImage();
        public abstract String getIcon(int x);
        public abstract String getDeathIcon();

    }

}

   
