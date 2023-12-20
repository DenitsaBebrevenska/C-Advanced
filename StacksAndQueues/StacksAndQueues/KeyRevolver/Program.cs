using System.Collections;

namespace KeyRevolver
{
	internal class Program
	{
		static void Main()
		{
			//•	On the first line of input, you will receive the price of each bullet – an integer in the range [0…100].
			// •	On the second line, you will receive the size of the gun barrel – an integer in the range [1…5000].
			// •	On the third line, you will receive the bullets – a space-separated integer sequence with [1…100] integers.
			// •	On the fourth line, you will receive the locks – a space-separated integer sequence with [1…100] integers.
			// •	On the fifth line, you will receive the value of the intelligence – an integer in the range [1…100000].

			int bulletPrice = int.Parse(Console.ReadLine());
			int barrelSize = int.Parse(Console.ReadLine());
			Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
			Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
			int valueOfIntelligence = int.Parse(Console.ReadLine());
			Queue<Barrel> barrels = new Queue<Barrel>();

			for (int i = 0; i < barrelSize; i++)
			{
				barrels.Enqueue(new Barrel(bullets));
			}

			int currentLock = locks.Dequeue();
			Barrel currentBarrel = barrels.Dequeue();

			while (locks.Count > 0 && barrels.Count > 0)
			{
				if (bullets.Pop() <= currentLock)
				{
					Console.WriteLine("Bang!");
					currentLock = locks.Dequeue();
				}
				else
				{
					Console.WriteLine("Ping!");
				}

				totalBulletCount --;
				bulletsPerBarrel--;

				if (bulletsPerBarrel == 0)
				{
					if (totalBulletCount == 0)
					{
						continue;
					}

					Console.WriteLine("Reloading!");
					bulletsPerBarrel = 
				}
			}

		}

		internal class Barrel
		{
			public Stack<int> Bullets { get; set; }

			public Barrel(Stack<int> bullets)
			{
				Bullets = new Stack<int>();
			}
		}
	}
}
