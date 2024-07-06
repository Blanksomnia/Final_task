using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Final_Task
{
    internal class DiceGame : CasinoGameBase
    {
        private Random _random = new Random();
        private List<int> _list1 = new List<int>();
        private List<int> _list2 = new List<int>();
        private int Min = 1;
        private int Max = 7;
        public void inGame(string path)
        {
            bool result = true;
            int bat = new Exception().exeption();
            while (result)
            {
                if (bat == 0)
                {
                    bat = new Exception().exeption();
                }
                else
                {
                    result = false;
                }
            }
            var readStream = File.ReadLines(path).ElementAtOrDefault(0);
            var bones = 2;
            var num = 0;
            int result1player = 0;
            int result2player = 0;
            Console.WriteLine("dice roll - ");
            for (int i = 0; i < bones; i++)
            {
                num++;
                var random = _random.Next(Min, Max);
                _list1.Add(random);
                Console.WriteLine($"({readStream}) rolls the dice {num} ### fell out - {_list1[i]}");
            }
            
            for (int i = 0; i < bones; i++)
            {
                num++;
                var random = _random.Next(Min, Max);
                _list2.Add(random);
                Console.WriteLine($"(игрок 2) rolls the dice {num} ### fell out - {_list2[i]}");
            }
            foreach (int i in _list1)
            {
                result1player = result1player + i;
            }
            foreach (var i in _list2)
            {
                result2player = result2player + i;
            }
            Console.WriteLine($"result ({readStream}) - {result1player}");
            Console.WriteLine($"result (2 игрока) - {result2player}");
            PlayDiceGame(result1player, result2player, path, bat);
        }
    }
}
