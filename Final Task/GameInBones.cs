using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task
{
    internal class GameInBones : CasinoGameBase
    {
        private Random _random = new Random();
        private List<int> _list1 = new List<int>();
        private List<int> _list2 = new List<int>();
        private int Min = 1;
        private int Max = 7;
        public void inGame()
        {
            var object1 = new Profile();
            var bones = 2;
            var num = 0;
            int result1player = 0;
            int result2player = 0;
            Console.WriteLine("бросок кубиков - ");
            for (int i = 0; i < bones; i++)
            {
                num++;
                var random = _random.Next(Min, Max);
                _list1.Add(random);
                Console.WriteLine($"бросок кубика {num}, ({object1.Name}) ### выпало - {_list1[i]}");
            }
            for (int i = 0; i < bones; i++)
            {
                num++;
                var random = _random.Next(Min, Max);
                _list2.Add(random);
                Console.WriteLine($"бросок кубика {num}, (игрока 2) ### выпало - {random}");
            }
            foreach (int i in _list1)
            {
                result1player = result1player + i;
            }
            foreach (var i in _list2)
            {
                result2player = result2player + i;
            }
            Console.WriteLine($"итог ({object1.Name}) - {result1player}");
            Console.WriteLine($"итог (2 игрока) - {result2player}");
            PlayGameBone(result1player, result2player);
            new IGame().StartGame();
        }
    }
}
