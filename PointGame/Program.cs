using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Default;

            int k = 0;
            int menuItem;
            bool game = true;

            do
            {
                Console.Clear();
                Console.WriteLine("==============================================================");
                Console.WriteLine("Виберіть дію:");
                Console.WriteLine();
                Console.WriteLine(" [1] - нова гра");
                Console.WriteLine();
                Console.WriteLine(" [0] - вихід з програми");
                Console.WriteLine();
                Console.Write("Введіть значення: ");

                menuItem = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("==============================================================");
                switch (menuItem)
                {
                    case 1:
                        Game mygame = new Game();
                        mygame.Read();
                        while (game == true)
                        {
                            k++;
                            mygame.PlayerCourse();
                            mygame.ComputerCourse();
                            mygame.Display();
                            if (k > 5)
                            {
                                Console.WriteLine("Продовжити? : 1 - так, 2 - ні");
                                int item = Convert.ToInt32(Console.ReadLine());
                                if (item == 2)
                                    game = false;
                            }
                        }
                        mygame.FinalScore();
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Гарного Вам дня!)");
                        break;
                }
            } while (menuItem != 0);
        }
    }
}

