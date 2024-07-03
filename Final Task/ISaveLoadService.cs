
using System;
using System.IO;
using System.Xml.Linq;

namespace Final_Task
{
    public abstract class ISaveLoadService : Profile
    {
        public void createProfile(string path)
        {
            Console.WriteLine("придумайте имя для профиля: ");
            Name = Console.ReadLine();
            var FileName = Name + ".txt";
            var _path = Path.Combine(path, FileName);
            using (var readStream = File.CreateText(_path))
            {
                readStream.WriteLine(Name);
                readStream.WriteLine(Point);
            }
            Console.WriteLine($"имя - {Name} /// очки - {Point}");
        }

        public void SaveData(string path)
        {
            var FileName = Name + ".txt";
            var _path = Path.Combine(path, FileName);
            using (var readStream = File.CreateText(_path))
            {
                readStream.WriteLine(Name);
                readStream.WriteLine(Point);
            }
            var readStream1 = File.ReadLines(_path).ElementAtOrDefault(0);
            Name = readStream1;
            readStream1 = File.ReadLines(_path).ElementAtOrDefault(1);
            Point = Convert.ToInt32(readStream1);
            Console.WriteLine($"имя - {Name} /// очки - {Point}");
        }
        public void LoadData(string path)
        {
            var txtFiles = Directory.EnumerateFiles(path, "*.txt", SearchOption.AllDirectories);
            foreach (string File in txtFiles)
            {
                 Console.WriteLine(File);
            }
            Console.WriteLine("введите название профиля: ");
            var findFile = Console.ReadLine();
            var FileName = findFile + ".txt";
            var _path = Path.Combine(path, FileName);
            var readStream = File.ReadLines(_path).ElementAtOrDefault(0);
            Name = readStream;
            readStream = File.ReadLines(_path).ElementAtOrDefault(1);
            Point = Convert.ToInt32(readStream);
            Console.WriteLine($"имя - {Name} /// очки - {Point}");

        }
    }
}
