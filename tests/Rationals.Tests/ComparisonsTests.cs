using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Rationals.Tests
{
    public class ComparisonsTests
    {
        [Fact]
        public void Comparisons1()
        {
            // arrange
            var a = new Rational(1, 3);
            var b = new Rational(1, 2);
            var c = new Rational(2, 4);

            // assert
            Assert.True(a < b);
            Assert.True(a < c);
            Assert.False(a > b);
            Assert.False(a > c);

            Assert.False(b < a);
            Assert.False(c < a);
            Assert.True(b > a);
            Assert.True(c > a);

            Assert.True(a <= b);
            Assert.True(a <= c);
            Assert.False(a >= b);
            Assert.False(a >= c);

            Assert.False(b <= a);
            Assert.False(c <= a);
            Assert.True(b >= a);
            Assert.True(c >= a);

            Assert.True(b <= c);
            Assert.True(b >= c);
            Assert.True(c <= b);
            Assert.True(c >= b);
        }

        [Fact]
        public void Comparisons2()
        {
            // arrange
            var a = new Rational(32);
            var b = new Rational(2, -1);

            // assert
            Assert.True(a > b);
            Assert.True(a >= b);
            Assert.False(a < b);
            Assert.False(a <= b);

            Assert.False(b > a);
            Assert.False(b >= a);
            Assert.True(b < a);
            Assert.True(b <= a);
        }

        [Fact]
        public void ComparisonsNegativeDenominator()
        {
            // arrange
            var a = new Rational(3);
            var b = new Rational(-4, -1);

            // assert
            Assert.Equal(-1, a.CompareTo(b));
            Assert.False(a > b);
            Assert.False(a >= b);
            Assert.True(a < b);
            Assert.True(a <= b);

            Assert.Equal(+1, b.CompareTo(a));
            Assert.True(b > a);
            Assert.True(b >= a);
            Assert.False(b < a);
            Assert.False(b <= a);
        }

        [Fact]
        public void ComparisonsNaN1()
        {
            // arrange
            var a = Rational.NaN;
            var b = new Rational(3);

            // assert
            Assert.Equal(-1, a.CompareTo(b));
            Assert.False(a > b);
            Assert.False(a >= b);
            Assert.True(a < b);
            Assert.True(a <= b);

            Assert.Equal(+1, b.CompareTo(a));
            Assert.True(b > a);
            Assert.True(b >= a);
            Assert.False(b < a);
            Assert.False(b <= a);
        }

        [Fact]
        public void ComparisonsNaN2()
        {
            // arrange
            var a = Rational.NaN;
            var b = Rational.NaN;

            // assert
            Assert.Equal(0, a.CompareTo(b));
            Assert.False(a > b);
            Assert.True(a >= b);
            Assert.False(a < b);
            Assert.True(a <= b);

            Assert.Equal(0, b.CompareTo(a));
            Assert.False(b > a);
            Assert.True(b >= a);
            Assert.False(b < a);
            Assert.True(b <= a);
        }

        [Theory]
        [MemberData(nameof(GetDataForDOpComparisonsNaN))]
        public void DComparisonsNaNLess(double a, double b) => Assert.False(a < b);

        [Theory]
        [MemberData(nameof(GetDataForDOpComparisonsNaN))]
        public void DComparisonsNaNLessOrEquals(double a, double b) => Assert.False(a <= b);

        [Theory]
        [MemberData(nameof(GetDataForDOpComparisonsNaN))]
        public void DComparisonsNaNGreater(double a, double b) => Assert.False(a > b);

        [Theory]
        [MemberData(nameof(GetDataForDOpComparisonsNaN))]
        public void DComparisonsNaNGreaterOrEquals(double a, double b) => Assert.False(a >= b);

        [Theory]
        [MemberData(nameof(GetDataForDOpComparisonsNaN))]
        public void DComparisonsNaNOpEquals(double a, double b) => Assert.False(a == b);

        [Theory]
        [MemberData(nameof(GetDataForDOpComparisonsNaN))]
        public void DComparisonsNaNNotEquals(double a, double b) => Assert.True(a != b);

        public static IEnumerable<object[]> GetDataForDOpComparisonsNaN()
        {
            double[] samples = { double.NegativeInfinity, -1d, -0d, 0d, 1d, double.PositiveInfinity, };
            foreach (double d in samples)
            {
                yield return new object[] { double.NaN, d, };
                yield return new object[] { d, double.NaN, };
            }
            yield return new object[] { double.NaN, double.NaN, };
        }

        [Theory]
        [MemberData(nameof(GetDataForDEqCmpComparisonsNaN))]
        public void DComparisonsNaNCompareTo(double a, double b, int cmp) => Assert.Equal(cmp, a.CompareTo(b));

        [Theory]
        [MemberData(nameof(GetDataForDEqCmpComparisonsNaN))]
        public void DComparisonsNaNEquals(double a, double b, int cmp) => Assert.Equal(cmp == 0, a.Equals(b));

        public static IEnumerable<object[]> GetDataForDEqCmpComparisonsNaN()
        {
            double[] samples = { double.NaN, double.NegativeInfinity, -1d, 0d, 1d, double.PositiveInfinity, };
            for (int i = 0; i < samples.Length; i += 1)
            {
                for (int j = 0; j < samples.Length; j += 1)
                {
                    yield return new object[] { samples[i], samples[j], i.CompareTo(j), };
                }
            }
        }


        [Theory]
        [MemberData(nameof(GetDataForOpComparisonsNaN))]
        public void OpComparisonsNaNLess(Rational a, Rational b) => Assert.False(a < b);

        [Theory]
        [MemberData(nameof(GetDataForOpComparisonsNaN))]
        public void OpComparisonsNaNLessOrEquals(Rational a, Rational b) => Assert.False(a <= b);

        [Theory]
        [MemberData(nameof(GetDataForOpComparisonsNaN))]
        public void OpComparisonsNaNGreater(Rational a, Rational b) => Assert.False(a > b);

        [Theory]
        [MemberData(nameof(GetDataForOpComparisonsNaN))]
        public void OpComparisonsNaNGreaterOrEquals(Rational a, Rational b) => Assert.False(a >= b);

        [Theory]
        [MemberData(nameof(GetDataForOpComparisonsNaN))]
        public void OpComparisonsNaNOpEquals(Rational a, Rational b) => Assert.False(a == b);

        [Theory]
        [MemberData(nameof(GetDataForOpComparisonsNaN))]
        public void OpComparisonsNaNNotEquals(Rational a, Rational b) => Assert.True(a != b);

        public static IEnumerable<object[]> GetDataForOpComparisonsNaN()
        {
            Rational[] samples = { new Rational(1, -1), new Rational(-1), new Rational(0), new Rational(1), new Rational(-1, -1), };
            foreach (Rational d in samples)
            {
                yield return new object[] { Rational.NaN, d, };
                yield return new object[] { d, Rational.NaN, };
            }
            yield return new object[] { Rational.NaN, Rational.NaN, };
        }

        [Theory]
        [MemberData(nameof(GetDataForEqCmpComparisonsNaN))]
        public void ComparisonsNaNCompareTo(Rational a, Rational b, int cmp) => Assert.Equal(cmp, a.CompareTo(b));

        [Theory]
        [MemberData(nameof(GetDataForEqCmpComparisonsNaN))]
        public void ComparisonsNaNEqual(Rational a, Rational b, int cmp) => Assert.Equal(cmp == 0, a.Equals(b));

        public static IEnumerable<object[]> GetDataForEqCmpComparisonsNaN()
        {
            Rational[] samples = { Rational.NaN, new Rational(-1), new Rational(0), new Rational(1), };
            for (int i = 0; i < samples.Length; i += 1)
            {
                for (int j = 0; j < samples.Length; j += 1)
                {
                    yield return new object[] { samples[i], samples[j], i.CompareTo(j), };
                }
            }
        }

        [Fact]
        public void Equality1()
        {
            // arrange
            var p = new Rational(1, 2);
            var q = new Rational(1, 2);

            // assert
            Assert.True(p == q);
        }

        [Fact]
        public void Equality2()
        {
            // arrange
            var p = new Rational(1, 2);
            var q = new Rational(-1, 2);

            // assert
            Assert.False(p == q);
        }

        [Fact]
        public void Equality3()
        {
            // arrange
            var p = new Rational(1, 2);
            var q = new Rational(2, 4);

            // assert
            Assert.True(p == q);
        }

        [Fact]
        public void Equality4()
        {
            // arrange
            var p = new Rational(0, 1);
            var q = new Rational(0, 5);

            // assert
            Assert.True(p == q);
        }

        [Fact]
        public void Equality5()
        {
            // arrange
            var p = new Rational(2, 3);
            var q = new Rational(2, 4);

            // assert
            Assert.False(p == q);
        }

        [Fact]
        public void Equality6()
        {
            // arrange
            var p = new Rational(4, 2);
            const int q = 2;

            // assert
            Assert.True(p == q);
        }

        [Fact]
        public void EqualityNaN1()
        {
            // arrange
            var p = new Rational(4, 2);
            var q = Rational.NaN;

            // assert
            Assert.True(p != q);
            Assert.True(q != p);
        }

        [Fact]
        public void EqualityNaN2()
        {
            // arrange
            var p = Rational.NaN;
            var q = Rational.NaN;

            // assert
            Assert.True(p == q);
            Assert.True(q == p);
        }

        [Fact]
        public void Equals1()
        {
            // arrange
            var p = new Rational(4, 2);
            const int q = 2;

            // assert
            Assert.True(p.Equals(q));
        }

        [Fact]
        public void Equals2()
        {
            // arrange
            var p = new Rational(4, 2);
            const string q = "hello";

            // assert
            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.False(p.Equals(q));
        }

        [Fact]
        public void Equals3()
        {
            // arrange
            var p = new Rational(4, 2);
            var q = new Rational(3, 2);

            // assert
            Assert.False(p.Equals(q));
        }

        [Fact]
        public void GetHashCode_Different()
        {
            // arrange
            var p = new Rational(4, 2);
            var q = new Rational(-2, 1);

            // assert
            Assert.NotEqual(p.GetHashCode(), q.GetHashCode());
        }

        [Fact]
        public void GetHashCode_Same()
        {
            // arrange
            var p = new Rational(4, -2);
            var q = new Rational(-2, 1);

            // assert
            Assert.Equal(p.GetHashCode(), q.GetHashCode());
        }

        [Fact]
        public void Sorting_ListSort()
        {
            // arrange
            var rationals = new List<Rational>
            {
                2,
                32,
                -1,
                0,
                2,
                (Rational)4 / 5,
                (Rational)3 / 4,
                (Rational)2 / -1,
                32 / 2,
                64 / 4,
                (Rational)2 / 3
            };

            // action
            rationals.Sort();

            // assert
            var expected = new[] { -2, -1, 0, (Rational)2 / 3, (Rational)3 / 4, (Rational)4 / 5, 2, 2, 16, 16, 32 };
            Assert.Equal(expected, rationals);
        }

        [Fact]
        public void Sorting_OrderBy()
        {
            // arrange
            var rationals = new List<Rational>
            {
                (Rational)2 / 3,
                (Rational)4 / 3,
                (Rational)0 / 2,
                (Rational)0 / 3,
                1,
                (Rational)4 / 10,
                -1,
                (Rational)2 / -3,
                -(Rational)4 / 3,
                (Rational)0 / -2,
                -(Rational)0 / 3,
                -(Rational)4 / 10,
                -1
            };

            // action
            var sorted = rationals.OrderBy(x => x).ToList();

            // assert
            var expected = new[]
            {
                -(Rational)4 / 3, -1, -1, -(Rational)2 / 3, -(Rational)2 / 5, 0, 0, 0, 0, (Rational)2 / 5,
                (Rational)2 / 3, 1, (Rational)4 / 3
            };
            Assert.Equal(expected, sorted);
        }
    }
}
