using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Heroes_of_Code_and_Logic_VII
{
    public class Status
    { 
        public int HP { get; set; }
        public int MP { get; set; }

        public Status(int hp, int mp)
        {
            this.HP = hp;
            this.MP = mp;
        }
    }
    class Program
    {
        static void Main()
        {
            Dictionary<string, Status> heroList = new Dictionary<string, Status>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                int hp = int.Parse(info[1]);
                int mp = int.Parse(info[2]);
                heroList.Add(name, new Status(hp, mp));
            }

            string infoCmd;
            while ((infoCmd = Console.ReadLine()) != "End")
            {
                string[] info = infoCmd.Split(" - ");
                string cmd = info[0];
                string heroName = info[1];

                if (heroList.ContainsKey(heroName))
                {
                    if (cmd == "CastSpell")
                    {
                        int mpNeeded = int.Parse(info[2]);
                        string spellName = info[3];

                        if (heroList.ContainsKey(heroName))
                        {
                            if (heroList[heroName].MP >= mpNeeded)
                            {
                                heroList[heroName].MP -= mpNeeded;
                                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroList[heroName].MP} MP!");
                            }
                            else
                            {
                                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                            }
                        }
                    }
                    else if (cmd == "TakeDamage")
                    {
                        int damage = int.Parse(info[2]);
                        string attacker = info[3];

                        if (heroList.ContainsKey(heroName))
                        {
                            heroList[heroName].HP -= damage;
                            if (heroList[heroName].HP > 0)
                            {
                                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroList[heroName].HP} HP left!");
                            }
                            else
                            {
                                heroList.Remove(heroName);
                                Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            }
                        }
                    }
                    else if (cmd == "Recharge")
                    {
                        int amount = int.Parse(info[2]);
                        if (heroList.ContainsKey(heroName))
                        {
                            int curr = heroList[heroName].MP;
                            heroList[heroName].MP += amount;
                            if (heroList[heroName].MP > 200)
                            {
                                amount = 200 - curr;
                                heroList[heroName].MP = 200;
                            }
                            Console.WriteLine($"{heroName} recharged for {amount} MP!");
                        }
                    }
                    else if (cmd == "Heal")
                    {
                        int amount = int.Parse(info[2]);
                        if (heroList.ContainsKey(heroName))
                        {
                            int curr = heroList[heroName].HP;
                            heroList[heroName].HP += amount;
                            if (heroList[heroName].HP > 100)
                            {
                                amount = 100 - curr;
                                heroList[heroName].HP = 100;
                            }
                            Console.WriteLine($"{heroName} healed for {amount} HP!");
                        }
                    }
                }
            }

            foreach (var hero in heroList.OrderByDescending(x =>x.Value.HP).ThenBy(x => x.Key))
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP:{hero.Value.HP}");
                Console.WriteLine($"  MP:{hero.Value.MP}");
            }
        }
    }
}
