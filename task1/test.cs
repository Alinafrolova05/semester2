using NUnit.Framework;
using ConvertTheString;

namespace YourProject.Tests;

/// <summary>
/// Test converting.
/// </summary>
[TestFixture]
public class Tests
{
    private BWT convertStr;

    /// <summary>
    /// This is a simple test with tree examples.
    /// </summary>
    [Test]
    public void SimpleTest()
    {
        string str1 = "abacaba$";
        string str2 = "abracadabra$";
        string str3 = "hello$";

        Assert.That(this.convertStr.ToConvert(str1), Is.EqualTo("abc$baaa"));
        Assert.That(this.convertStr.ToConvert(str2), Is.EqualTo("ard$rcaaaabb"));
        Assert.That(this.convertStr.ToConvert(str3), Is.EqualTo("oh$ell"));
    }
}
