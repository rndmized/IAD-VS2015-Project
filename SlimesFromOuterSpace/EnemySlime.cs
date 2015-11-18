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
        //Number of taps needed to kill the mob
        public int taps;
        
        //Abstract Methods to be inherited
        public abstract Image getImage(int x);//Returns Image based on position
        public abstract Image getImage();//Returns Image regardless position
        public abstract Image getDeathImage();//Returns image of defeated mob
        public abstract String getIcon(int x);//Returns picture source path of mob based on position
        public abstract String getDeathIcon();//Returns picture source path of a defeated enemy 

    }//end of EnemySlime Class

}

   
