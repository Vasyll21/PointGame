using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointGame
{
    class Game
    {
        private int[,] game_mas;
        private object[,] closed_mas;
        private int player = 0;
        private int computer = 0;
        private int first;
        private int second;

        public void Init(int x, int y)
        {
            first = x;
            second = y;
            int k = -3;
            int h = 1;
            game_mas = new int[first, second];
            closed_mas = new object[first, second];
            Random r = new Random();
            for (int i = 0; i < x; i++)
            {
                if (i == x - 2)
                    k++;
                k += 3;
                if (k >= x)
                    k = 0;
                h += k;
                if (i % 3 == 0 && i != 0)
                {
                    h += i / 3;
                    k++;
                }

                for (int j = 0; j < y; j++)
                {
                    if (h >= 10)
                        h = 1;
                    game_mas[i, j] = h;
                    closed_mas[i, j] = "?";
                    h++;
                }
                h = 1;
            }
            Permutation();
            Display();
        }

        public void Read()
        {
            Console.WriteLine("Гра почалась!");
            Console.WriteLine("==============================================================");
            Init(9, 9);
        }

        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine("---------------------");
            for (int i = 0; i < first; i++)
            {
                for (int j = 0; j < second; j++)
                {
                    Console.Write(" " + closed_mas[i, j]);
                    if (j == 2)
                        Console.Write("|");
                    if (j == 5)
                        Console.Write("|");
                    if (j == 8)
                        Console.Write("|");
                }
                Console.WriteLine();
                if (i == 2)
                    Console.WriteLine("---------------------");
                if (i == 5)
                    Console.WriteLine("---------------------");
                if (i == 8)
                    Console.WriteLine("---------------------");
            }
            Console.WriteLine();
        }


        public void PlayerCourse()
        {
            IfEnd();
            int x, y;
            bool a = true;
            Console.WriteLine("Ваш хід!");
            Console.WriteLine();
            while (a == true)
            {
                coordinats:
                Console.WriteLine("Введіть свої координати (від 1 до 9 і не забувайте про відкриті поля)");
                Console.Write("\t x = ");
                x = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("\t y = ");
                y = Convert.ToInt32(Console.ReadLine()) - 1;
                if (x >= 0 && x <= 8 && y >= 0 && y <= 8)
                {
                    if (Convert.ToString(closed_mas[x, y]) == "?")
                    {
                        player += game_mas[x, y];
                        closed_mas[x, y] = game_mas[x, y];
                        a = false;
                        Console.WriteLine("Ваш рахунок:" + player);
                    }
                    else Console.WriteLine("Це поле вже відкрите, введіть інше!");
                }
                else
                {
                    Console.WriteLine("Координати повинні бути від 1 до 9!");
                    goto coordinats;
                }
            }
        }

        public void ComputerCourse()
        {
            IfEnd();
            Console.WriteLine("Хід опонента!");
            Console.WriteLine();
            AiTurn();
        }

        private void AiTurn()
        {
            int x, y, count = 0, countI = 0;

            bool a = true;
            Random r = new Random();

            while (a == true)
            {
                x = r.Next(0, first);
                y = r.Next(0, second);
                if (Convert.ToString(closed_mas[x, y]) == "?")
                {
                    countI += AIProccess(x, y, count, countI);
                    if (countI == 0)
                    {

                    }
                    if (countI >= 5)
                    {
                        a = AIResult(x, y);
                    }

                }
            }
        }

        private int AIProccess(int x, int y, int count, int countI)
        {
            count = 0;
            for (int i = 0; i < game_mas.GetLength(1); i++)
            {
                if (game_mas[x, i] == 9)
                {
                    count += 1;
                    if (game_mas[i, y] == 9)
                    {
                        count += 1;
                    }
                }
                if (game_mas[x, i] == 8)
                {
                    count += 1;
                    if (game_mas[i, y] == 8)
                    {
                        count += 1;
                    }
                }
                if (game_mas[x, i] == 7)
                {
                    count += 1;
                    if (game_mas[i, y] == 7)
                    {
                        count += 1;
                    }
                }
                if (count > 3)
                {
                    countI++;
                    break;
                }
            }
            return countI;
        }

        private bool AIResult(int x, int y)
        {
            Console.WriteLine("Координати опонента");
            Console.Write("\t x = " + x + 1);
            Console.Write("\t y = " + y + 1);
            Console.WriteLine();
            computer += game_mas[x, y];
            closed_mas[x, y] = game_mas[x, y];
            Console.WriteLine("Рахунок опонента:" + computer);
            return false;
        }

        public void FinalScore()
        {
            if (player > computer)
                Console.WriteLine("Ви виграли з рахунком " + player + ":" + computer);
            else if (computer > player)
                Console.WriteLine("Ви програли з рахунком " + player + ":" + computer);
            else Console.WriteLine("Нічия з рахунком " + player + ":" + computer);
        }

        public void IfEnd()
        {
            int k = 0;
            for (int i = 0; i < first; i++)
            {
                for (int j = 0; j < second; j++)
                {
                    if (Convert.ToString(closed_mas[i, j]) != "?")
                    {
                        k++;
                    }
                }
            }

            if (k == closed_mas.Length)
            {
                FinalScore();
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void Permutation()
        {
            for (int o = 0; o < 5; o++)
            {
                Random r = new Random();
                object k;
                int t1 = r.Next(0, 3);
                int t2 = r.Next(0, 3);
                int v = r.Next(0, 2);

                while (t1 == t2)
                {
                    t2 = r.Next(0, 3);
                }

                if (t1 != 0)
                {
                    t1 *= 3;
                }

                if (t2 != 0)
                {
                    t2 *= 3;
                }

                for (int i = 0; i < first; i++)
                {
                    for (int j = 0; j < second; j++)
                    {
                        if (v == 0)
                        {
                            //Перестановка по рядкам
                            if (i == t1)
                            {
                                k = closed_mas[i, j];
                                closed_mas[i, j] = closed_mas[t2, j];
                                closed_mas[t2, j] = k;
                            }

                            if (i == t1 + 1)
                            {
                                k = closed_mas[i, j];
                                closed_mas[i, j] = closed_mas[t2 + 1, j];
                                closed_mas[t2 + 1, j] = k;
                            }

                            if (i == t1 + 2)
                            {
                                k = closed_mas[i, j];
                                closed_mas[i, j] = closed_mas[t2 + 2, j];
                                closed_mas[t2 + 2, j] = k;
                            }
                        }
                        else
                        {
                            //Перестановка по стовпцям
                            if (j == t1)
                            {
                                k = closed_mas[i, j];
                                closed_mas[i, j] = closed_mas[i, t2];
                                closed_mas[i, t2] = k;
                            }

                            if (j == t1 + 1)
                            {
                                k = closed_mas[i, j];
                                closed_mas[i, j] = closed_mas[i, t2 + 1];
                                closed_mas[i, t2 + 1] = k;
                            }

                            if (j == t1 + 2)
                            {
                                k = closed_mas[i, j];
                                closed_mas[i, j] = closed_mas[i, t2 + 2];
                                closed_mas[i, t2 + 2] = k;
                            }
                        }
                    }
                }
            }
        }
    }
}
