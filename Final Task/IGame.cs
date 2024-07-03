using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task
{
    internal class IGame
    {
        public void StartGame()
        {
            var object1 = new Profile();
            if(object1.Name == null) 
            {
                new FileSystemSaveLoadService().choose();
            }
            Console.WriteLine("выберите игру из козино - ### блэкджэк (нажмите 1) ### игра в кости (нажмите 2) ###");
            int variant = int.Parse(Console.ReadLine());
            if (variant == 1)
            {
                new BlackJack().inGame();
            }
            if(variant == 2)
            {
                new GameInBones().inGame();
            }
        }
    }
}
