using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dobrý den, vítejte v mé hře, prosím zadejte jméno své postavy");//jmeno postavy
            Warrior hra = new Warrior(Console.ReadLine());

            while (hra.zivoty() > 0)
            {
                Console.WriteLine("-------------------------------------------------------------------");

                hra.HUB();//rozcesti
                string cesta = Console.ReadLine();
                if (cesta == "staty" || cesta == "1")
                {
                    hra.Stats();
                }
                else if (cesta == "obchod" || cesta == "2")
                {
                    hra.obchod();
                }
                else if (cesta == "bar" || cesta == "3")
                {
                    hra.bar();
                }
                else if (cesta == "souboj" || cesta == "4")
                {
                    hra.souboj();
                }
                else if (cesta == "kampaň" || cesta == "5" || cesta == "kampan")
                {
                    hra.kampaň();
                }
                else
                {
                    Console.WriteLine("Nevím co po mně chcete opakuji akci");
                }
            }
            hra.konec();

        }
    }
}