namespace RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main()
        {
            char[,] bunnyLair = SpawnBunnyLair();
            int playerRowLocation = -1;
            int playerColLocation = -1;

            for (int i = 0; i < bunnyLair.GetLength(0); i++)
            {
                string currentRow = Console.ReadLine();

                for (int j = 0; j < bunnyLair.GetLength(1); j++)
                {
                    bunnyLair[i, j] = currentRow[j];

                    if (currentRow[j] == 'P')
                    {
                        playerRowLocation = i;
                        playerColLocation = j;
                    }
                }
            }

            List<char> movementList = Console.ReadLine().ToCharArray().ToList();
            int[] lastPosition = new int[] { playerRowLocation, playerColLocation };

            for (int i = 0; i < movementList.Count; i++)
            {
                switch (movementList[i])
                {
                    case 'L':
                        playerColLocation--;
                        break;
                    case 'R':
                        playerColLocation++;
                        break;
                    case 'U':
                        playerRowLocation--;
                        break;
                    case 'D':
                        playerRowLocation++;
                        break;
                }

                if (ExitsTheLair(playerRowLocation, playerColLocation, bunnyLair))
                {
                    bunnyLair[lastPosition[0], lastPosition[1]] = '.';
                    MultiplyBunnies(bunnyLair);
                    PrintLairFinalState(bunnyLair);
                    Console.WriteLine($"won: {lastPosition[0]} {lastPosition[1]}");
                    break;
                }

                if (KilledByBunny(playerRowLocation, playerColLocation, bunnyLair))
                {
                    bunnyLair[lastPosition[0], lastPosition[1]] = '.';
                    MultiplyBunnies(bunnyLair);
                    PrintLairFinalState(bunnyLair);
                    Console.WriteLine($"dead: {playerRowLocation} {playerColLocation}");
                    break;
                }

                bunnyLair[lastPosition[0], lastPosition[1]] = '.';
                lastPosition[0] = playerRowLocation;
                lastPosition[1] = playerColLocation;

                MultiplyBunnies(bunnyLair);

                if (KilledByBunny(lastPosition[0], lastPosition[1], bunnyLair))
                {
                    PrintLairFinalState(bunnyLair);
                    Console.WriteLine($"dead: {lastPosition[0]} {lastPosition[1]}");
                    break;
                }
            }
        }

        static void PrintLairFinalState(char[,] bunnyLair)
        {
            for (int i = 0; i < bunnyLair.GetLength(0); i++)
            {
                for (int j = 0; j < bunnyLair.GetLength(1); j++)
                {
                    Console.Write(bunnyLair[i, j]);
                }

                Console.WriteLine();
            }
        }

        static char[,] SpawnBunnyLair()
        {
            int[] matrixDetails = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = matrixDetails[0];
            int cols = matrixDetails[1];
            char[,] bunnyLair = new char[rows, cols];
            return bunnyLair;
        }

        static void MultiplyBunnies(char[,] bunnyLair)
        {
            List<int[]> coordinateNewbornBunnies = new List<int[]>();

            for (int i = 0; i < bunnyLair.GetLength(0); i++)
            {
                for (int j = 0; j < bunnyLair.GetLength(1); j++)
                {
                    if (bunnyLair[i, j] != 'B')
                    {
                        continue;
                    }

                    List<int[]> coordinatesMultiplication = new List<int[]>()
                    {
                        new int[]{i - 1, j},
                        new int[]{i + 1, j},
                        new int[]{i, j - 1},
                        new int[]{i, j + 1}
                    };

                    for (int k = 0; k < coordinatesMultiplication.Count; k++)
                    {
                        if (!AreValidCoordinates(coordinatesMultiplication[k], bunnyLair)
                            || bunnyLair[coordinatesMultiplication[k][0], coordinatesMultiplication[k][1]] == 'B')
                        {
                            continue;
                        }

                        coordinateNewbornBunnies.Add(coordinatesMultiplication[k]);
                    }
                }
            }

            for (int i = 0; i < coordinateNewbornBunnies.Count; i++)
            {
                bunnyLair[coordinateNewbornBunnies[i][0], coordinateNewbornBunnies[i][1]] = 'B';
            }
        }

        static bool KilledByBunny(int playerRowLocation, int playerColLocation, char[,] bunnyLair)
        {
            return bunnyLair[playerRowLocation, playerColLocation] == 'B';
        }

        static bool ExitsTheLair(int playerRowLocation, int playerColLocation, char[,] bunnyLair)
        {
            return playerRowLocation < 0 || playerRowLocation >= bunnyLair.GetLength(0) ||
                   playerColLocation < 0 || playerColLocation >= bunnyLair.GetLength(1);
        }

        static bool AreValidCoordinates(int[] coordinates, char[,] bunnyLair)
        {
            int row = coordinates[0];
            int col = coordinates[1];

            return row >= 0 && row < bunnyLair.GetLength(0)
                && col >= 0 && col < bunnyLair.GetLength(1);
        }
    }
}
