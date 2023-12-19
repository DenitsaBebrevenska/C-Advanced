namespace TruckTour
{
	internal class Program
	{
		static void Main()
		{
			//The lorry will move one kilometer for each liter of petrol.
			int petrolPumpCount = int.Parse(Console.ReadLine());
			List<Pump> pumpList = PopulatePumpList(petrolPumpCount);
			bool fullRouteAchieved = false;

			while (!fullRouteAchieved)
			{
				int pumpsPassed = 0;
				int tankFuel = 0;

				for (int i = 0; i < pumpList.Count; i++)
				{
					pumpsPassed++;
					tankFuel += pumpList[i].Fuel;

					if (tankFuel < pumpList[i].DistanceToNextPump)
					{
						List<Pump> pumpsToSwap = pumpList.Take(pumpsPassed).ToList();
						pumpList.RemoveRange(0, pumpsPassed);
						pumpList.AddRange(pumpsToSwap);
						break;
					}

					tankFuel -= pumpList[i].DistanceToNextPump;

					if (i == pumpList.Count - 1)
					{
						fullRouteAchieved = true;
					}
				}
			}

			Console.WriteLine(pumpList[0].PumpID);
		}

		static List<Pump> PopulatePumpList(int petrolPumpCount)
		{
			List<Pump> pumpList = new List<Pump>();

			for (int i = 0; i < petrolPumpCount; i++)
			{
				int[] pumpArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
				pumpList.Add(new Pump(i, pumpArgs[0], pumpArgs[1]));
			}
			return pumpList;
		}
	}

	internal class Pump
	{
		public int PumpID { get; set; }

		public int Fuel { get; set; }

		public int DistanceToNextPump { get; set; }

		public Pump(int id, int fuel, int distance)
		{
			PumpID = id;
			Fuel = fuel;
			DistanceToNextPump = distance;
		}

	}
}
