using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_Task
{
    internal class CheckPoints : SaveLoadService
    {
        public void checkPoints(int Point, string Name, string _path)
        {
            if (Point <= 0)
            {
                Console.WriteLine("No money? Kicked!");
            }
            else if (Point > 1000)
            {
                Console.WriteLine("You wasted half of your bank money in casino’s bar");
                Point = Point / 2;
                SaveData(_path, Name, Point);
            }
            else
            {
                SaveData(_path, Name, Point);
            }
        }
    }
}
