namespace Bor;
public class Test
{
    public static bool TestBor()
    {
        Bor b = new();

        if (!b.Add("  he"))
        {
            return false;
        }

        if (b.CountSymbols() != 4)
        {
            return false;
        }

        if (!b.Add("he"))
        {
            return false;
        }

        if (b.CountSymbols() != 6)
        {
            return false;
        }

        if (!b.Add("  hers"))
        {
            return false;
        }

        if (b.CountSymbols() != 8 || b.Size() != 3)
        {
            return false;
        }

        if (!b.Add(" "))
        {
            return false;
        }

        if (b.CountSymbols() != 8 || b.Size() != 4)
        {
            return false;
        }

        if (!b.Add(""))
        {
            return false;
        }

        if (b.CountSymbols() != 8 || b.Size() != 5)
        {
            return false;
        }

        if (!b.Remove("he") || b.Size() != 4)
        {
            return false;
        }

        return true;
    }
}
