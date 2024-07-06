
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Final_Task
{
    public abstract class SaveLoadService
    {
        public string createData(string path)
        {
            Console.Write("come up with a name for your profile: ");
            string name = Console.ReadLine();
            var FileName = name + ".txt";
            var _path = Path.Combine(path, FileName);
            new FileSystemSaveLoadService().path = _path;
            using (var readStream = File.CreateText(_path))
            {
                readStream.WriteLine(name);
                readStream.WriteLine(50);
            }
            Console.WriteLine($" Welcome - {name}! /// Youre points - {50}");
            return _path;
            
        }
        public void SaveData(string path, string name, int point)
        {
            var FileName = name + ".txt";
            var _path = Path.Combine(path, FileName);
            using (var readStream = File.CreateText(_path))
            {
                readStream.WriteLine(name);
                readStream.WriteLine(point);
            }
        }
        public string LoadData(string path)
        {
            var txtFiles = Directory.EnumerateFiles(path, "*.txt", SearchOption.AllDirectories);
            Console.WriteLine("################################");
            foreach (string File in txtFiles)
            {
                string result = File.Replace(path + @"\", "").Replace(".txt", "");
                Console.WriteLine($"player's name - {result}");
            }
            Console.WriteLine("################################");
            Console.Write("enter the name of the profile: ");
            string findFile = Console.ReadLine();
            var FileName = findFile + ".txt";
            var _path = Path.Combine(path, FileName);
            if (File.Exists(_path) == true)
            {
                using var _readStream = File.OpenText(_path);
                var readStream = File.ReadLines(_path).ElementAtOrDefault(0);
                string name = readStream;
                readStream = File.ReadLines(_path).ElementAtOrDefault(1);
                int point = Convert.ToInt32(readStream);
                Console.WriteLine($" Welcome - {name}! /// youre points - {point}");
                return _path;
            }
            else
            {
                Console.WriteLine("wrong name, please try again: ");
                return LoadData(path);
            }
        }
    }
    public interface ISaveLoadService<T>
    {
       void Save(T data, string path);
        T Load(string path);
    }
    
}
