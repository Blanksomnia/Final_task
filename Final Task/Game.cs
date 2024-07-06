using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task
{
    internal class Game
    {
        private string path = new FileSystemSaveLoadService().Choose();
        public void StartGame()
        {
            Console.Write("Choose a game from the casino - ### Blackjack (press 1) ### dice game (press 2) : ");
            string variant = Console.ReadLine();
            if (variant == "1")
            {
                new BlackJack().inGame(path);
            }
            else if(variant == "2")
            {
                new DiceGame().inGame(path);
            }
            else
            {
                Console.WriteLine("error, please try again");
                StartGame();
            }
        }
    }
}
