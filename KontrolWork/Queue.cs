namespace KontrolWork;

public class Queue
{
    public int LengthArray = 10;
    private int startIndex;
    private int index;
    private int[] array;

    public Queue()
    {
        startIndex = 0;
        index = 0;
        array = new int[LengthArray];
    }

    public void Enqueue(int value)
    {
        if (index >= LengthArray)
        {
            Array.Resize(ref array, LengthArray * 2);
            LengthArray *= 2;
        }
        array[index] = value;
        index++;
    }

    public int Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        int value = array[0];
        for (int i = 1; i < index; i++)
        {
            array[i - 1] = array[i];
        }
        index--;
        startIndex++;
        return value;
    }

    public bool IsEmpty() => index == 0;
}
