using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_Task
{
    internal class FileSystemSaveLoadService : SaveLoadService
    {
        public string _path = @"C:\Profile";
        public string path = null;
        public string Choose()
        {
            if (File.Exists(_path) == false)
            {
                Directory.CreateDirectory(_path);
            }

            if ((Directory.GetFiles(_path, "*.txt").Length == 0))
            {
                path = createData(_path);
            }
            else if ((Directory.GetFiles(_path, "*.txt").Length != 0))
            {
                Console.Write("Select a profile - create(press 1) or upload(press 2): ");
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            path = createData(_path);
                        }
                        break;
                    case "2":
                        {
                           path = LoadData(_path);
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("error, please try again");
                        }
                        return Choose();
                }
            }
            return path;
        }
        public void _SaveData(string Name, int Point)
        {
            new CheckPoints().checkPoints(Point, Name, _path);
            Console.WriteLine($"Goodbya {Name}! Good luck next time!");
        }
 
    }
   
}
