public class ExamenETSA
{
    private static void Main (string[] args)
    {
        Console.WriteLine("Suerte en el examen!");
    }

    public static double funcionMatematica (double x, int n)
    {
        int i = 1;
        for (int j = 1; j < n && x > 2; j++)
        {
            i++;
            x++;
        }
        if (x == 3 || x == 5)
        {
            x = i + 4.6;
        }
        else if (x == 1)
        {
            x = i * 2.8;
        }
        else
        {
            x = x / 5;
        }

        return Math.Round(x, 2);
    }
}