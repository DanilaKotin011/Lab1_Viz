using System;

namespace Lab1Viz
{
	public class HW1
	{
		public static long QueueTime(int[] customers, int n)
		{
			int size = customers.Length;
			int[] mas = new int[n];
			for (int z = 0; z < n; z++) mas[z] = 0;
			int i = 0;
			long time = 0;
			for (int j = 0; j < n; j++)
			{
				if (mas[j] == 0)
				{
					if (i > size) break;
					mas[j] = customers[i];
					i++;
				}
			}
			while (i < size)
			{
				int min = mas[0];
				for (int j = 0; j < n; j++) if (min > mas[j]) min = mas[j];
				time += min;
				for (int j = 0; j < n; j++) mas[j] -= min;
				for (int j = 0; j < n; j++)
				{
					if (mas[j] == 0)
					{
						if (i >= size) break;
						mas[j] = customers[i];
						i++;
					}
				}
			}
			int max = 0;
			for (int j = 0; j < n; j++) if (max < mas[j]) max = mas[j];
			time += max;
			return time;
		}
	}

    class Program
    {
        static void Main(string[] args)
        {
			long time;
			int[] mas1 = new int[3] { 5, 3, 4 };
			time = HW1.QueueTime(mas1, 1);
            Console.WriteLine($"{time}");

			int[] mas2 = new int[4] { 10,2,3,3 };
			time = HW1.QueueTime(mas2, 2);
			Console.WriteLine($"{time}");

			int[] mas3 = new int[3] { 2,3,10 };
			time = HW1.QueueTime(mas3, 2);
			Console.WriteLine($"{time}");
		}
    }
}
