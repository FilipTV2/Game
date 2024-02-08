using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Warrior
    {
       
       //promenne staty ktere diky tomu mohu upravovat vsude 
        string jmeno;
        int utok = 10;
        int HP = 100;
        int obrana = 0;
        int zbran = 0;
        int XP = 0;
        int Gold = 50;
        int uzdravovacíPitíčko = 1;

        public Warrior(string jmeno) //aby si hrac dokazal zadat jmeno
        {
            this.jmeno = jmeno;
            Console.WriteLine("Dobrý den hráči jmenuji se " + jmeno);

        }
        public int GetCurrentLevel()
        {
            const int xpPerLevel = 50;
            const int xpPerLevelIncrease = 20;
            int xp = XP;

            if (xp < xpPerLevel) { return 1; }

            int level = 0;

            while (xp >= 0)
            {
                xp -= xpPerLevel + xpPerLevelIncrease * level;
                level++;
            }

            return level;
        }
        public void Stats() //pocatecnicke staty
        {

            Console.ForegroundColor = ConsoleColor.Red; // změní barvu na červenou
            Console.WriteLine("Moje HP je: " + HP);
            Console.ResetColor(); // změní barvu na základní
            Console.ForegroundColor = ConsoleColor.Cyan; // změní barvu na tyrkysova
            Console.WriteLine("Můj útok je: " + utok);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan; // změní barvu na tyrkysova
            Console.WriteLine("Moje zbraň má: " + zbran + "útoku");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue; // změní barvu na modrou
            Console.WriteLine("Moje obrana je: " + obrana);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green; // změní barvu na zelenou
            Console.WriteLine("Můj level je: " + GetCurrentLevel());
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow; // změní barvu na žlutou
            Console.WriteLine("Mám nazbíráno: " + Gold + " :Zlata");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Mám nazbíráno: " + uzdravovacíPitíčko + " uzdravovacich piticek");
            Console.ResetColor();
        }
        public int zivoty() //abych dokazal manipulovat s zivotama
        {
            int hp = HP;
            return hp;
        }
        public int Dmg() //dmg a critical
        {
            Random r = new Random();
            if (r.Next(4) == 0) //nam generuje cisla 0 a 3
            {//critical
                return 2 * (utok + zbran);
            }
            else

            {
                return (utok + zbran);
            }
        }
        public void HUB() //možnosti kam jít pro hráče
        {
            Console.WriteLine("Kam by jste chtěli jít napište kam chcete");
            Console.WriteLine("Moznosti:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1  : staty :");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2  : obchod :");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("3  : bar :");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("4  : souboj :");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("5  : kampaň :");
            Console.ResetColor();
        }
        public void obchod() //vse okolo obchodu
        {
            Console.WriteLine("Vítejte v obchodě");
            Console.WriteLine("Můžete si koupit:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("1  : zbraň : cena zbraně je 50gold za +5 utoku");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("2  : armor : cena armoru je 100gold za +5 obrany");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("3  : uzdravovací pitíčko : cena healthPotion je 20gold za +50 životů");
            Console.ResetColor();
            string prodavac = Console.ReadLine(); //rozcesti v baru
            if (prodavac == "zbran" || prodavac == "1")
            {
                if (Gold >= 50)
                {
                    zbran += 5;
                    Gold -= 50;
                    Console.WriteLine("gratuluji vylepšil jste svojí zbraň");
                }
                else
                {
                    Console.WriteLine("nemáš dostatek goldu");
                }
            }
            else if (prodavac == "armor" || prodavac == "2")
            {
                if (Gold >= 100)
                {
                    obrana += 5;
                    Gold -= 100;
                    Console.WriteLine("gratuluji vylepšil jste svuj armor");
                }
                else
                {
                    Console.WriteLine("nemáš dostatek goldu");
                }
            }
            else if (prodavac == "uzdravovací pitíčko" || prodavac == "3")
            {
                if (Gold >= 20)
                {
                    uzdravovacíPitíčko += 1;
                    Gold -= 20;
                    Console.WriteLine("gratuluji dostal jste 1 uzdravovaci piticko");
                }
                else
                {
                    Console.WriteLine("nemáš dostatek goldu");
                }
            }
            else
            {
                Console.WriteLine("nemám tušení co po mě chcete běžte pryč");
            }
            Console.WriteLine("tvůj zbytek goldu je: " + Gold);
        }
        public void bar() //vse okolo baru
        {
            Console.WriteLine("Vítejte v baru");
            Console.WriteLine("chcete obnovit životy nebo gamblit");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1  : zivoty : ztrata 20 goldu za doplnění všech životů");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("2  : gamble :");
            Console.ResetColor();
            string Barista = Console.ReadLine();//pro rozcesti v baru
            if (Barista == "zivoty" || Barista == "1")
            {
                if (Gold >= 20)
                {
                    Console.WriteLine("vaše životy byly obnoveny");
                    HP = 100;
                    Gold -= 20;
                }
                else
                {
                    Console.WriteLine("nemáš dostatek peněz");
                }
                Console.WriteLine("zbývá vám " + Gold + "Goldu");
            }
            else if (Barista == "gamble" || Barista == "2")
            {
                Console.WriteLine("kolik goldu chcete vsadit");
                int sázka = int.Parse(Console.ReadLine());
                if (sázka + Gold <= 0)
                {
                    Console.WriteLine("nemáte dostatek peněz na vsazení");
                }
                else
                {
                    Random gamble = new Random();
                    if (gamble.Next(2) == 0)
                    {
                        Gold -= sázka;
                        sázka *= 2;
                        Gold += sázka;
                        Console.WriteLine("vyhrali jste nyni mate: " + Gold);
                    }
                    else
                    {
                        Gold -= sázka;
                        Console.WriteLine("prohrali jste nyni mate: " + Gold);
                    }
                }
            }
            else
            {
                Console.WriteLine("nemám tušení co po mě chcete běžte pryč");
            }

        }
        public void souboj() //vse okolo souboje
        {
            Random typeOfEnemy = new Random();
            int x = typeOfEnemy.Next(10);
            if (x <= 2)
            {
                Console.Write("lucky you. You have encountered the weakest enemy the: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GOBLIN");
                Console.ResetColor();
                int enemyHP = 20 * GetCurrentLevel();
                int enemyDmg = 10 * GetCurrentLevel();
                int enemyDrop = 20 * GetCurrentLevel();
                Boj(enemyHP, enemyDmg, enemyDrop);

            }
            else if (x > 2 && x <= 4)
            {
                Console.Write("You have encountered: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GOBLIN LEADER");
                Console.ResetColor();
                int enemyHP = 40 * GetCurrentLevel();
                int enemyDmg = 20 * GetCurrentLevel();
                int enemyDrop = 30 * GetCurrentLevel();
                Boj(enemyHP, enemyDmg, enemyDrop);

            }
            else if (x > 4 && x <= 6)
            {
                Console.Write("You have encountered: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("TROLL");
                Console.ResetColor();
                int enemyHP = 80 * GetCurrentLevel();
                int enemyDmg = 15 * GetCurrentLevel();
                int enemyDrop = 50 * GetCurrentLevel();
                Boj(enemyHP, enemyDmg, enemyDrop);
            }
            else if (x == 7)
            {
                Console.Write("You have encountered: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("BANDIT");
                Console.ResetColor();
                int enemyHP = 120 * GetCurrentLevel();
                int enemyDmg = 20 * GetCurrentLevel();
                int enemyDrop = 100 * GetCurrentLevel();
                Boj(enemyHP, enemyDmg, enemyDrop);

            }
            else if (x == 8)
            {
                Console.Write("You have encountered: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("SMALL DRAGON");
                Console.ResetColor();
                int enemyHP = 150 * GetCurrentLevel();
                int enemyDmg = 20 * GetCurrentLevel();
                int enemyDrop = 200 * GetCurrentLevel();
                Boj(enemyHP, enemyDmg, enemyDrop);

            }
            else if (x == 9)
            {

                Console.WriteLine("I am sorry for you. You have encountered the biggest beast of them all: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("███      ██████       ██       ████      ████    ████    ██");
                Console.WriteLine("█████    ██    ██   ██  ██   ██        ██    ██  ██ ██   ██");
                Console.WriteLine("██  ███  ██████     ██  ██   ██  ████  ██    ██  ██  ██  ██");
                Console.WriteLine("█████    ██ ███    ████████  ██    ██  ██    ██  ██   ██ ██");
                Console.WriteLine("███      ██   ███  ██    ██    ████      ████    ██    ████");
                Console.ResetColor();
                int enemyHP = 200 * GetCurrentLevel();
                int enemyDmg = 25 * GetCurrentLevel();
                int enemyDrop = 300 * GetCurrentLevel();
                Boj(enemyHP, enemyDmg, enemyDrop);

            }
        }
        public void Boj(int enemyHP, int enemyDmg, int enemyDrop)
        {
            Console.WriteLine("protivník má " + enemyHP + "životů");
            Console.WriteLine("protivník má " + enemyDmg + "útoku");
            Console.WriteLine("protivník dá za zabití " + enemyDrop + "goldu a 6XP");
            Console.WriteLine("1  : utect : ztrata 10% goldu");
            Console.WriteLine("2  : boj : pro souboj s timto monstrem");
            string zdrhat = Console.ReadLine();
            if (zdrhat == "utect" || zdrhat == "1")
            {
                Gold -= Gold / 10;
            }
            else if (zdrhat == "2" || zdrhat == "boj")
            {

                while (enemyHP > 0 && HP > 0)
                {
                    Console.WriteLine("1  : utok :");
                    Console.WriteLine("2  : použít uzdravovací pitíčko :");
                    string akce = Console.ReadLine();
                    if (akce == "utok" || akce == "1")
                    {
                        enemyHP -= Dmg();
                        Console.WriteLine("protivníkovy zůstalo " + enemyHP + " HP");
                        int x = enemyDmg - obrana;
                        if (x < 0)
                        {
                            Console.WriteLine("odrazili jste ůtok vaše životy zůstali stejné");
                        }
                        else
                        {
                            HP = HP - x;
                            Console.WriteLine("po útoku protivníka vám zůstalo " + HP + " HP");
                        }

                    }
                    else if (akce == "použít uzdravovací pitíčko" || akce == "2")
                    {
                        if (uzdravovacíPitíčko > 0)
                        {

                            HP += 50;
                            if (HP > 100)
                            {
                                HP = 100;
                                Console.WriteLine("Nyní máte :" + HP + ": životů");
                            }
                            else
                            {
                                Console.WriteLine("Nyní máte :" + HP + ": životů");
                            }
                        }
                        else
                        {
                            Console.WriteLine("nevlastníte žádné uzdravovací pitíčka");
                        }
                    }
                    else
                    {
                        Console.WriteLine("napište znova co chcete dělat");
                    }
                    if (enemyHP <= 0)
                    {
                        Console.WriteLine("vyhral jsi tento souboj");
                        Gold += enemyDrop;
                        Console.WriteLine("ziskal jste " + enemyDrop + "goldu");
                        XP += 6;
                        Console.WriteLine("ziskal jsi 6xp");
                    }
                    else if (HP <= 0)
                    {
                        Console.WriteLine("je mi líto ale toto je váš konec");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("nevím co po mně chcete opakujte akci");
                Boj(enemyHP, enemyDmg, enemyDrop);
            }
        }
        public void kampaň() //vse okolo kampane
        {
            if (GetCurrentLevel() < 5)
            {
                Console.WriteLine("Nemáte dostatečný level na odemčení této úrovně");
                Console.WriteLine("Musíte mít 5. level");
                Console.WriteLine("Nyní máte " + GetCurrentLevel() + ". level");
            }
            else
            {
                Console.WriteLine("Omlouváme se, ale tento obsah eště nebyl přidán");
            }
        }
        public void konec() //co se stane potom co hrac umre
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  ██████        ██      ██      ██  ██████████        ██████    ██      ██  ██████████  ████████    ");
            Console.WriteLine("██             ████     ████  ████  ██              ██      ██   ██    ██   ██          ██      ██  ");
            Console.WriteLine("██  ████      ██  ██    ██  ██  ██  ██████          ██      ██    ██  ██    ██████      ████████    ");
            Console.WriteLine("██      ██   ████████   ██      ██  ██              ██      ██     ████     ██          ██    ██    ");
            Console.WriteLine("  ██████    ██      ██  ██      ██  ██████████        ██████        ██      ██████████  ██      ██  ");
            Console.ResetColor();
        }
    }
} 
    

