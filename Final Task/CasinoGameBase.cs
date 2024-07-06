using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_Task
{
    public abstract class CasinoGameBase
    {
        public string _path = new FileSystemSaveLoadService().path;
        public void PlayDiceGame(int point1, int point2, string path, int bet)
        {
            _path = path;
            if (point2 > point1)
            {
                WiOnLooseInvoke(Convert.ToInt32(File.ReadLines(_path).ElementAtOrDefault(1)), bet);
            }
            if (point1 > point2)
            {
                WiOnWinInvoke(Convert.ToInt32(File.ReadLines(_path).ElementAtOrDefault(1)), bet);
            }
            else if (point1 == point2)
            {
                WiOnDrawInvoke(Convert.ToInt32(File.ReadLines(_path).ElementAtOrDefault(1)), bet);
            }
        }
        public void PlayGameBlackJack(int point1, int point2, string path, int bet)
        {
            _path = path;
            if (point1 < 21 && point2 >= 21 || point1 > point2 && point2 < 21 && point1 < 21)
            {
                WiOnWinInvoke(Convert.ToInt32(File.ReadLines(_path).ElementAtOrDefault(1)), bet);
            }
            if (point2 < 21 && point1 >= 21 || point2 > point1 && point1 < 21 && point2 < 21)
            {
                WiOnLooseInvoke(Convert.ToInt32(File.ReadLines(_path).ElementAtOrDefault(1)), bet);
            }
            else if (point1 == point2)
            {
                WiOnDrawInvoke(Convert.ToInt32(File.ReadLines(_path).ElementAtOrDefault(1)), bet);
            }
        }
        private void WiOnWinInvoke(int _point, int bet)
        {
            Console.WriteLine("You win!");
            var point = _point;
            _point = _point + bet;
            Console.WriteLine($"youre points {point} + {bet} = {_point}");
            new FileSystemSaveLoadService()._SaveData(File.ReadLines(_path).ElementAtOrDefault(0), _point);
        }
        private void WiOnLooseInvoke(int _point, int bet)
        {
            Console.WriteLine("You loose!");
            var point = _point;
            _point = _point - bet;
            Console.WriteLine($"youre points {point} - {bet} = {_point}");
            new FileSystemSaveLoadService()._SaveData(File.ReadLines(_path).ElementAtOrDefault(0), _point);
        }
        private void WiOnDrawInvoke(int _point, int bet)
        {
            Console.WriteLine("Draw!");
            var point = _point;
            bet = bet / 2;
            _point = _point - bet;
            Console.WriteLine($"youre points {point} - {bet} = {_point}");
            new FileSystemSaveLoadService()._SaveData(File.ReadLines(_path).ElementAtOrDefault(0), _point);
        }

    }
}
