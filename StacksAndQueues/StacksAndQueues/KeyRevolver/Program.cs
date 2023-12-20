namespace KeyRevolver
{
    internal class Program
    {
        static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int valueOfIntelligence = int.Parse(Console.ReadLine());
            int totalBullets = bullets.Count;

            while (locks.Count > 0)
            {
                int currentLock = locks.Peek();

                while (bullets.Count > 0)
                {
                    bool targetShot = false;
                    int currentBullet = bullets.Pop();

                    if (currentBullet <= currentLock)
                    {
                        Console.WriteLine("Bang!");
                        locks.Dequeue();
                        targetShot = true;
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }

                    if (bullets.Count % barrelSize == 0 && bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                    }

                    if (targetShot)
                    {
                        break;
                    }
                }

                if (bullets.Count == 0 && locks.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }
                
            }
            Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence - (totalBullets - bullets.Count) * bulletPrice}");
        }
    }
}