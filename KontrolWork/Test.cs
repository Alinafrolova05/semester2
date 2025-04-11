using KontrolWork;
using NUnit.Framework;
class Test
{
    private Queue queue;

    [SetUp]
    public void Setup()
    {
        queue = new();
    }

    [Test]
    public void SimpleTest()
    {
        for (var i = 0; i < 10; ++i)
        {
            queue.Enqueue(i);
        }
        queue.Enqueue(10);
        queue.Enqueue(11);

        queue.Dequeue();
        queue.Dequeue();

        int[] checkArray = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

        for (var i = 0; i < checkArray.Length; ++i)
        {
            Assert.AreEqual(checkArray[i], queue.Dequeue());
        }
    }

    [Test]
    public void ExceptionTest()
    {
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }
}
