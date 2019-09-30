using System;

namespace Light_IT_GAME
{
    class Program
    {
    
        static void Main(string[] args)
        {
            Operations obj = new Operations();
            obj.Name_input();
            obj.Game();
            Console.ReadKey();
        }
    }
}
