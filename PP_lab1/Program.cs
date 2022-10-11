using System.Runtime.Serialization.Formatters;

internal class Program
{
    static object locker = new();
    private static void Main(string[] args)
    {
        int elementCount;
        int threadCount;
        Console.WriteLine("Введите кол-во потоков");
        while (!int.TryParse(Console.ReadLine(), out threadCount) 
            || (threadCount < 4))
        {
            Console.WriteLine("Число введено неверно. Попробуйте ещё раз");
        }
        Console.WriteLine("Введите кол-во элементов");
        while (!int.TryParse(Console.ReadLine(), out elementCount) 
            || (elementCount < 1) )
        {
            Console.WriteLine("Число введено неверно. Попробуйте ещё раз");
        }
        int[] array = new int[elementCount];
        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-1000, 1000);
        }
        double[] returns = new double[threadCount];
        Thread[] threadAvarange = new Thread[threadCount];
        for (int i = 0; i < threadAvarange.Length; i++)
        {

            threadAvarange[i] = new Thread(() => { returns[i] = (ThreadArray(array, i, threadCount)); });
            threadAvarange[i].Start();
            threadAvarange[i].Join();

        }
        Console.WriteLine(returns.Average());
        Console.ReadKey();
    }

    static double ThreadArray(object? paramArray, object? totalI, object? threadCount)
    {
        int beg, h, end;
        double avarange = 0;
        int[]? array = paramArray as int[];
        int nt = Convert.ToInt32(totalI);
        int count = Convert.ToInt32(threadCount);
        h = array.Length / count;
        beg = h * nt; end = beg + h;
        if (nt == count - 1)
        {
            end = array.Length;
        }
        for (int i = beg; i < end; i++)
        {
            avarange += array[i];
        }
        return avarange / array.Length;
    }

}