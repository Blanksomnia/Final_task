using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task
{
    internal class Exception
    {
        private int Min = 10;
        private int Max = 100;
        public int exeption()
        {
            Console.Write("make a bet 10 - 100 points: ");
            var _bet = int.Parse(Console.ReadLine());
            if (_bet >= Min && _bet <= Max)
            {
                return _bet;
            }
            else
            {
                Console.WriteLine("error, please try again");
                return 0;
            }
        }
    }
}
