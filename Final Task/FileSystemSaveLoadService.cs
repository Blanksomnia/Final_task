using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task
{
    internal class FileSystemSaveLoadService : ISaveLoadService
    {
        public string _path = @"C:\Profile";
        public void choose()
        {
            Console.WriteLine("Выберите сохранить(нажмите клавишу 1) или загрузить(нажмите клавишу 2) или создать профиль(нажмите клавишу 3) профиль: ");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    {
                        SaveData(_path);
                    }
                    break;
                case 2: 
                    { 
                        LoadData(_path); 
                    }
                    break;
                case 3: 
                    { 
                        createProfile(_path); 
                    }
                    break;
                default: 
                    { 
                        Console.WriteLine("ошибка"); 
                    }
                    break;

            }

        }


    }
}
