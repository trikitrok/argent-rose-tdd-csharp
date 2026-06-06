namespace ArgentRose.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class QualityTest
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;

        [Test]
        [Description("Should maintain quality within bounds when increased")]
        public void ShouldMaintainQualityWithinBoundsWhenIncreased()
        {
            var quality = QualityOf(45);
            var increased = quality.Increase(10);
            Assert.That(increased, Is.EqualTo(QualityOf(MaxQuality)));
        }

        [Test]
        [Description("Should maintain quality within bounds when decreased")]
        public void ShouldMaintainQualityWithinBoundsWhenDecreased()
        {
            var quality = QualityOf(5);
            var decreased = quality.Decrease(10);
            Assert.That(decreased, Is.EqualTo(QualityOf(MinQuality)));
        }

        [Test]
        [Description("Should drop to zero")]
        public void ShouldDropToZero()
        {
            var quality = QualityOf(25);
            Assert.That(quality.DropToZero(), Is.EqualTo(QualityOf(MinQuality)));
        }

        [TestCase(10, 5, 15)]
        [TestCase(10, 50, 50)]
        [TestCase(0, 0, 0)]
        [Description("Increase tests")]
        public void IncreaseTests(int initial, int delta, int expected)
        {
            Assert.That(QualityOf(initial).Increase(delta), Is.EqualTo(QualityOf(expected)));
        }

        [TestCase(10, 5, 5)]
        [TestCase(10, 15, 0)]
        [TestCase(50, 0, 50)]
        [Description("Decrease tests")]
        public void DecreaseTests(int initial, int delta, int expected)
        {
            Assert.That(QualityOf(initial).Decrease(delta), Is.EqualTo(QualityOf(expected)));
        }

        [Test]
        [Description("Should be immutable")]
        public void ShouldBeImmutable()
        {
            var initial = QualityOf(10);
            initial.Increase(5);
            Assert.That(initial, Is.EqualTo(QualityOf(10)));
        }

        [Test]
        [Description("equality")]
        public void Equality()
        {
            var quality = QualityOf(25);
            Assert.That(QualityOf(25), Is.Not.EqualTo(QualityOf(30)));
        }

        private static Quality QualityOf(int value)
        {
            return new Quality(value);
        }
    }
}