using MyLinq;

IEnumerable<int> seq = MyClass.GetPrimes().Take(5);

foreach (var i in seq)
{
    Console.WriteLine(i);
}