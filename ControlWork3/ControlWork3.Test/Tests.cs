// <copyright file="Tests.cs" company="Alinafrolova05">
// Copyright (c) Alinafrolova05. All rights reserved.
// </copyright>

using ControlWork3;

/// <summary>
/// Tests for Vector class.
/// </summary>
public class Tests
{
    private Vector vector1;
    private Vector vector2;

    /// <summary>
    /// Initialization before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        this.vector1 = new Vector();
        this.vector2 = new Vector();
    }

    /// <summary>
    /// Test vector addition.
    /// </summary>
    [Test]
    public void TestAddVectors()
    {
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 4, 5, 6 };
        var expected = new List<int> { 5, 7, 9 };

        this.vector1.Add(list1);
        this.vector2.Add(list2);
        this.vector1.Add(list2);

        Assert.That(this.vector1.GetVector(), Is.EqualTo(expected));
    }

    /// <summary>
    /// Test exception when adding different lengths.
    /// </summary>
    [Test]
    public void TestAddVectorsDifferentLengthsThrowsException()
    {
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 4, 5 };

        this.vector1.Add(list1);

        Assert.Throws<ArgumentException>(() => this.vector1.Add(list2));
    }

    /// <summary>
    /// Test vector subtraction.
    /// </summary>
    [Test]
    public void TestSubtractVectors()
    {
        var list1 = new List<int> { 5, 7, 9 };
        var list2 = new List<int> { 1, 2, 3 };
        var expected = new List<int> { 4, 5, 6 };

        this.vector1.Add(list1);
        this.vector2.Add(list2);
        this.vector1.Subtract(list2);

        Assert.That(this.vector1.GetVector(), Is.EqualTo(expected));
    }

    /// <summary>
    /// Test exception when subtracting different lengths.
    /// </summary>
    [Test]
    public void TestSubtractVectorsDifferentLengthsThrowsException()
    {
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 4, 5 };

        this.vector1.Add(list1);

        Assert.Throws<ArgumentException>(() => this.vector1.Subtract(list2));
    }

    /// <summary>
    /// Test scalar multiplication.
    /// </summary>
    [Test]
    public void TestScalarMultiplicationVectors()
    {
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 4, 5, 6 };
        int expected = 32; // 1*4 + 2*5 + 3*6 = 32

        this.vector1.Add(list1);
        this.vector2.Add(list2);

        Assert.That(this.vector1.ScalarMultiplication(list2), Is.EqualTo(expected));
    }

    /// <summary>
    /// Test exception when scalar multiplying different lengths.
    /// </summary>
    [Test]
    public void TestScalarMultiplicationVectorsDifferentLengthsThrowsException()
    {
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 4, 5 };

        this.vector1.Add(list1);

        Assert.Throws<ArgumentException>(() => this.vector1.ScalarMultiplication(list2));
    }

    /// <summary>
    /// Test zero vector.
    /// </summary>
    [Test]
    public void TestIsNullVector_WithNullVector_ReturnsTrue()
    {
        var nullVector = new List<int> { 0, 0, 0, 0 };

        bool result = this.vector1.IsZero(nullVector);

        Assert.That(result, Is.True);
    }

    /// <summary>
    /// Test non-zero vector.
    /// </summary>
    [Test]
    public void TestIsNullVectorWithNonNullVectorReturnsFalse()
    {
        var nonNullVector = new List<int> { 0, 1, 0, 0 };

        bool result = this.vector1.IsZero(nonNullVector);

        Assert.That(result, Is.False);
    }

    /// <summary>
    /// Test empty vector.
    /// </summary>
    [Test]
    public void TestIsNullVectorWithEmptyVectorReturnsTrue()
    {
        var emptyVector = new List<int>();

        bool result = this.vector1.IsZero(emptyVector);

        Assert.That(result, Is.True);
    }

    /// <summary>
    /// Test vector with non-zero elements.
    /// </summary>
    [Test]
    public void TestIsNullVectorWithMixedVectorReturnsFalse()
    {
        var mixedVector = new List<int> { 0, 0, 5, 0, 0 };

        bool result = this.vector1.IsZero(mixedVector);

        Assert.That(result, Is.False);
    }
}
