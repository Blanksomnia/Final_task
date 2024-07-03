using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task
{
    public abstract class CasinoGameBase
    {
        public void PlayGameBone(int point1, int point2)
        {
            if (point1 < point2)
            {
                WiOnLooseInvoke();
            }
            if (point2 < point1)
            {
                WiOnWinInvoke();
            }
            else if (point1 == point2)
            {
                WiOnDrawInvoke();
            }
        }
        public void PlayGameBlackJack(int point1, int point2)
        {
            if (point1 < 21 && point2 >= 21 || point1 < point2)
            {
                WiOnWinInvoke();
            }
            if (point2 < 21 && point1 >= 21 || point2 < point1)
            {
                WiOnLooseInvoke();
            }
            else if (point1 == point2 || point1 >= 21 && point2 >= 21)
            {
                WiOnDrawInvoke();
            }
        }
        private static void WiOnWinInvoke()
        {
            var object1 = new Profile();
            var object2 = new FileSystemSaveLoadService();
            Console.WriteLine("YOU WIN!");
            object1.Point = object1.Point + 10;
            Console.WriteLine($"youre Points {object1.Point}");
            object2.choose();
        }
        private static void WiOnLooseInvoke()
        {
            var object1 = new Profile();
            var object2 = new FileSystemSaveLoadService();
            Console.WriteLine("YOU LOSE!");
            object1.Point = object1.Point - 10;
            Console.WriteLine($"youre Points {object1.Point}");
            object2.choose();
        }
        private static void WiOnDrawInvoke()
        {
            var object1 = new Profile();
            var object2 = new FileSystemSaveLoadService();
            Console.WriteLine("NO WINER");
            object1.Point = object1.Point - 5;
            Console.WriteLine($"youre Points {object1.Point}");
            object2.choose();
        }

    }
}
