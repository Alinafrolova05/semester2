using ControlWork;
using NUnit.Framework;

namespace ControlWork.Test
{
    public class Tests
    {
        List<int> list;

        [SetUp]
        public void Setup()
        {
            list = new List<int>();
        }

        [Test]
        public void Test()
        {

            list.Add(1);
            list.Add(2);
            list.Add(0);
            list.Add(5);
            list.Add(0);

            var nullChecker = new IntNullChecker();

            int nullCount = NullCounter.CountNulls(list, nullChecker);

            Assert.That(nullCount, Is.EqualTo(2));
        }
    }
}
