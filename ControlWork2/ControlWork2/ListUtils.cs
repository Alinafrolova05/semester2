namespace ControlWork2;

using System.Collections.Generic;

/// <summary>
/// Utility class for working with lists.
/// </summary>
public static class ListUtils
{
    /// <summary>
    /// Extension method for sorting a list using bubble sort.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list that needs to be sorted.</param>
    /// <param name="comparer">An object that implements the IComparer.<T>
    /// interface for comparing list elements.</param>
    public static void Sort<T>(this List<T> list, IComparer<T> comparer)
    {
        int len = list.LenghtOfList();
        for (int i = 0; i < len - 1; i++)
        {
            for (int j = 0; j < len - i - 1; j++)
            {
                if (comparer.Compare(list.GetValue(j), list.GetValue(j + 1)) > 0)
                {
                    T temp = list.GetValue(j);
                    list.SetValue(j, list.GetValue(j + 1));
                    list.SetValue(j + 1, temp);
                }
            }
        }
    }
}
