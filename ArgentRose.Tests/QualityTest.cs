using NUnit.Framework;

namespace ArgentRose.Tests;

[TestFixture]
public class QualityTest
{
    [Test]
    [Description("equality")]
    public void Equality()
    {
        Assert.That(QualityOf(8), Is.Not.EqualTo(QualityOf(30)));
    }

    private static Quality QualityOf(int value)
    {
        return new Quality(value);
    }
}