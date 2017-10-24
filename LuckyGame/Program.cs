using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LuckyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine("Для выхода из игры нажмите любую клавишу");
            Console.ReadKey();
        }
    }
    class Game
    {
       private static int MinValue { get; set; }
       private static int MaxValue { get; set; }
        private static Random random = new Random();
      
        private int Validate()
        {
            int res;
            Console.Write("Введите число :");
            while (!int.TryParse(Console.ReadLine(), out res)) Console.WriteLine("Вы ввели не правильное число");
            return res;
        }

        private int GetMaxValue()
        {
            int res;
            Console.WriteLine("Введите максимальное значение промежутка");
            while (!int.TryParse(Console.ReadLine(), out res) && !(res>0)) Console.WriteLine("Вы ввели не правильное значение");
            return res;
        }
        private int GetMinValue()
        {
            int res;
            Console.WriteLine("Введите минимальное  значение промежутка");
            while (!int.TryParse(Console.ReadLine(), out res) && !(res > 0)) Console.WriteLine("Вы ввели не правильное значение");
            return res;
        }
        public void RangeInput()
        {
            MinValue = GetMinValue();//Получение минимального значения
            MaxValue = GetMaxValue();//Получение максимального значения
            if (MinValue > MaxValue)
            {
                Console.WriteLine("Вы ввели неправильный промежуток {0}>{1} ",MinValue,MaxValue);
                this.RangeInput();
            }
        }
        private void PlanNumber()//Игрок загадывает
        {
            Console.WriteLine("Загадайте число и нажмите <Enter>");
            Console.ReadKey();
            bool status=false;
            int Temp = 1;

            while (Temp>0)
            {
                

                Console.WriteLine("Вы загадали число = {0} ", Temp);

                Console.WriteLine("1-Больше, 2 -Меньше");
                int n = Validate();
                if (n == 1) {
                    Temp = (MaxValue - MinValue) / 2;//Временная перемена 
                    MinValue = Temp;
                }
                if (n == 2)
                {
                    Temp = (MaxValue - MinValue) / 2;
                    MaxValue = Temp;
                }
            }
            Console.WriteLine("Я угадал число");

        }
        private void GuessNumber()//Игрок отгадывает
        {
            Console.WriteLine("Я загадал число");
            int temp = random.Next(MinValue, MaxValue);
            int userNumber = 0;
            while(temp != userNumber)
            {
                userNumber = Validate();
                if (userNumber > temp)
                {
                    Console.WriteLine("Я загадал число меньше");

                }
                if (temp > userNumber)
                {
                    Console.WriteLine("Я загадал число больше");

                }
                if (temp == userNumber) Console.WriteLine("Ты отгадал число");
            }

        }
        
        public Game()
        {
            Console.WriteLine("------------------Угадайка---------------------");
            RangeInput();
            Menu();
            
        }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("1-Загадать, и компьютер будет отгадывать, 2-Компьютер загадывает, вы отгадываете. 0 - выйти из программы");
            switch (Console.ReadLine())
            {
                case "0":
                    
                    break;
                case "1":
                    this.PlanNumber();
                    break;
                case "2":
                    this.GuessNumber();
                    break;
                default:
                    Console.WriteLine("Вы выбрали неверный пункт меню");
                    this.Menu();
                    break;

            }
        }

        
    }
}
