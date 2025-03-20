namespace Bor;

internal class Program
{
    static void Main()
    {
        if (!Test.TestBor())
        {
            Console.WriteLine("Error!");
        }
    }
}
