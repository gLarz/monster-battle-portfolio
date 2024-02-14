using System;

public class Monster
{
    public float HealthPoints { get; set; }
    public float AttackDamage { get; set; }
    public float DefensePoints { get; set; }
    public float Speed { get; set; }
    public string Race { get; set; }

    public Monster(float hp, float ad, float dp, float s, string race)
    {
        HealthPoints = hp;
        AttackDamage = ad;
        DefensePoints = dp;
        Speed = s;
        Race = race;
    }

    public void Attack(Monster opponent)
    {
        float damage = Math.Max(AttackDamage - opponent.DefensePoints, 0);
        opponent.HealthPoints -= damage;
        Typewrite($"{Race} attacks {opponent.Race} for {damage} damage!\n");
    }

    static void Typewrite(string message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message[i]);
            System.Threading.Thread.Sleep(60);
        }

    }
}

class Program
{
    static void Main(string[] args)
    {
        Monster monster1, monster2;

        Console.WriteLine("Enter Monster 1 attributes: (HP, AD, DP, S)");
        monster1 = CreateMonster();
        Console.WriteLine("Enter Monster 2 attributes: (HP, AD, DP, S)");
        monster2 = CreateMonster();

        if (monster1.Race == monster2.Race)
        {
            Console.WriteLine("Monsters cannot be of the same race!");
            return;
        }

        int round = 0;
        while (monster1.HealthPoints > 0 && monster2.HealthPoints > 0)
        {
            round++;
            if (monster1.Speed >= monster2.Speed)
            {
                monster1.Attack(monster2);
                if (monster2.HealthPoints > 0)
                    monster2.Attack(monster1);
            }
            else
            {
                monster2.Attack(monster1);
                if (monster1.HealthPoints > 0)
                    monster1.Attack(monster2);
            }
        }

        Console.WriteLine("Fight is over!");
        if (monster1.HealthPoints <= 0 && monster2.HealthPoints <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("It's a draw!");
        }
        else if (monster1.HealthPoints <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{monster2.Race} wins in {round} rounds!");
            PlayWinningSound();
            
            
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{monster1.Race} wins in {round} rounds!");
            PlayWinningSound();
        }
    }

    static Monster CreateMonster()
    {
        string[] races = { "Orc", "Troll", "Goblin" };
        float[] attributes = new float[4];
        string race;
        float hp, ad, dp, s;

        Console.Write("Race (1 = Orc, 2 = Troll, 3 = Goblin): ");
        int choice = int.Parse(Console.ReadLine());
        if (choice < 1 || choice > 3)
        {
            Console.WriteLine("Invalid race choice. Defaulting to Orc.");
            race = "Orc";
        }
        else
        {
            race = races[choice - 1];
        }

        Console.Write("HP: ");
        hp = float.Parse(Console.ReadLine());
        Console.Write("AD: ");
        ad = float.Parse(Console.ReadLine());
        Console.Write("DP: ");
        dp = float.Parse(Console.ReadLine());
        Console.Write("S: ");
        s = float.Parse(Console.ReadLine());

        return new Monster(hp, ad, dp, s, race);
    }

    static void PlayWinningSound()
    {
        Console.Beep(500, 200);
        Console.Beep(600, 200);
        Console.Beep(700, 200);
        Console.Beep(800, 200);
        Console.Beep(900, 200);
        Console.Beep(1000, 200);
        Console.Beep(1100, 200);
        Console.Beep(1200, 200);
        Console.Beep(1300, 200);
        Console.Beep(1400, 200);
        Console.Beep(1500, 200);
        Console.Beep(1600, 200);
    }
}


