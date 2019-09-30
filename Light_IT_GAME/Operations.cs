using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Light_IT_GAME
{
    class Operations
    {
        Player computer = new Player();
        Player human = new Player(100);
        //функция ввода имени игрока
        public void Name_input()
        {
            Console.Write("Enter your name, human: ");
            int x;
            string gamer_name=null;
            while (gamer_name == null) // проверка корректности ввода
            {
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out x) || input == "")
                {
                    Console.Write("Enter real name: ");
                }
                else
                {
                    gamer_name = input;
                }
            }
            human.Name = gamer_name;
        }
        //функция вывода на экран данных о здоровье игроков
        public void Information()
        {
            Console.WriteLine(computer.Name+" "+computer.Health+"hp");
            Console.WriteLine(human.Name + " " + human.Health + "hp");
        }
        //функция отвечающая за урон в диапазоне (18-25)
        void Small_damage_range(Player buf, Random rand)
        {
            int n = rand.Next(18, 25);
            if (buf.Health - n < 0)
            {
                n = buf.Health;
                buf.Health = 0;
            }
            else buf.Health = buf.Health - n;  
            Console.WriteLine($"{buf.Name} lost {n}hp");
        }
        //функция отвечающая за урон в диапазоне (10-35)
        void Big_damage_range(Player buf, Random rand)
        {
            int n = rand.Next(10, 35);
            if (buf.Health - n < 0)
            {
                n= buf.Health;
                buf.Health = 0;
            }
            else buf.Health = buf.Health - n;
            Console.WriteLine($"{buf.Name} lost {n}hp");
        }
        //функция отвечающая за лечение в диапазоне (10-35)
        bool Healing(Player buf, Random rand)
        {
            if (buf.Health == 100) return false;
            int n = rand.Next(18, 25);
            if (buf.Health + n > 100)
            {
                int a = buf.Health;
                buf.Health = 100;
                n = 100 - a;
            }
            else buf.Health = buf.Health + n;
            Console.WriteLine($"{buf.Name} healed by {n}hp");
            return true;
        }
        //функция для определения последовательности ходов
        void Move(int n, Random rand)
        {
            int i = rand.Next(1, 4);
            if (n == 0)
            {
                if (computer.Health < 35)// увеличение шанса на излечение
                {
                    i = rand.Next(1, 5);
                }
                switch (i)
                {
                    case (1):
                        Small_damage_range(computer, rand);
                        break;
                    case (2):
                        Big_damage_range(computer, rand);
                        break;
                    case (3):
                    case (4):
                        bool heal= Healing(computer, rand);
                        if (!heal) goto case (1);
                        break;
                }
            }
            else
            {
              switch (i)
                {
                    case (1):
                        Small_damage_range(human, rand);
                        break;
                    case (2):
                        Big_damage_range(human, rand);
                        break;
                    case (3):
                        bool heal=Healing(human, rand);
                        if (!heal) goto case (1);
                        break;
                }
            }
        }
        //управляющая функция 
        public void Game()
        {
            Console.WriteLine($"Hi, {human.Name}, get ready for destruction and press any key to START");
            Console.ReadKey();
            Console.WriteLine();
            Random rand =new Random();
            int whose_move;
            while(computer.Health>0 && human.Health>0)
            {
                Console.WriteLine("------------------------------------");
                whose_move = rand.Next(0, 2);
                Move(whose_move,rand);
                Console.WriteLine();
                Information();
                Console.ReadKey();
                Console.WriteLine();
            }
            if (computer.Health == 0) Console.WriteLine("I lost this time, but i`ll be back!!!");
            else Console.WriteLine("You lost, human!");
        }
    }
}
