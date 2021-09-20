using ComparisonExtensions;
using Xunit;
using FluentAssertions;

namespace ComparisonExtensionsTests
{
    public class FloatingComparisonExtensionsTest
    {
        [Theory]
        [InlineData(0.1, 0.1)]
        [InlineData(-0.1, -0.1)]
        [InlineData(0.000000001, 0.000000001)]
        [InlineData(double.PositiveInfinity, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, double.NegativeInfinity)]
        [InlineData(double.Epsilon, 0.0)]
        [InlineData(0.0, double.Epsilon)]
        public void EqualsTo_Double_ShouldReturnTrueForSameDoubles(double left, double right)
        {
            left.EqualsTo(right).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.2, 0.3)]
        [InlineData(-0.1, 0.3, 0.2)]
        public void EqualsTo_Double_ShouldReturnTrueForAddedDoubles(double value1, double value2, double result)
        {
            (value1 + value2).EqualsTo(result).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.01, 0.001)]
        [InlineData(-0.1, 0.1)]
        [InlineData(-0.00000000001, -0.00000000002)]
        [InlineData(double.MaxValue, double.PositiveInfinity)]
        [InlineData(double.MinValue, double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity, double.NegativeInfinity)]
        [InlineData(double.NegativeInfinity, double.PositiveInfinity)]
        [InlineData(double.NaN, double.NaN)]
        [InlineData(double.NaN, 0.1)]
        [InlineData(double.NaN, 0.0)]
        [InlineData(0.0, double.NaN)]
        [InlineData(0.1, double.NaN)]
        [InlineData(double.Epsilon, double.NaN)]
        public void EqualsTo_Double_ShouldReturnFalseForDifferentDoubles(double left, double right)
        {
            left.EqualsTo(right).Should().BeFalse();
        }

        [Fact]
        public void EqualsTo_Double_ShouldWorkWellWithIntegers()
        {
            (0.1 + 0.2 + 0.7).EqualsTo(1).Should().BeTrue();
        }

        [Fact]
        public void IsZero_Double_ShouldReturnTrueForZero()
        {
            const double value = 0.0;

            value.IsZero().Should().BeTrue();
        }

        [Fact]
        public void IsZero_Double_ShouldReturnTrueForEpsilon()
        {
            double.Epsilon.IsZero().Should().BeTrue();
        }

        [Fact]
        public void IsZero_Double_ShouldReturnTrueAddedDoubles()
        {
            (0.3 - 0.2 - 0.1).IsZero().Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1)]
        [InlineData(0.01)]
        [InlineData(-0.01)]
        [InlineData(-0.00000000001)]
        [InlineData(0.00000000001)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NaN)]
        public void IsZero_Double_ShouldReturnFalseForNonZeroValues(double value)
        {
            value.IsZero().Should().BeFalse();
        }

        [Theory]
        [InlineData(0.2, 0.1)]
        [InlineData(0.01, 0.001)]
        [InlineData(0.1, 0.0)]
        [InlineData(-0.00000000001, -0.00000000002)]
        [InlineData(double.PositiveInfinity, double.MaxValue)]
        [InlineData(double.PositiveInfinity, double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity, double.Epsilon)]
        [InlineData(double.MinValue, double.NegativeInfinity)]
        public void IsGreaterThan_Double_ShouldReturnTrueWhenLeftIsGreaterThanRight(double left, double right)
        {
            left.IsGreaterThan(right).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.1)]
        [InlineData(-0.1, -0.1)]
        [InlineData(0.000000001, 0.000000001)]
        [InlineData(double.PositiveInfinity, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, double.NegativeInfinity)]
        [InlineData(double.Epsilon, 0.0)]
        [InlineData(0.0, double.Epsilon)]
        [InlineData(0.0, double.NaN)]
        [InlineData(double.NaN, 0.0)]
        [InlineData(double.NaN, double.NaN)]
        public void IsGreaterThan_Double_ShouldReturnFalseForSameDoubles(double left, double right)
        {
            left.IsGreaterThan(right).Should().BeFalse();
        }

        [Fact]
        public void IsGreaterThan_Double_ShouldReturnFalseForAddedAndSameDoubles()
        {
            (0.2 + 0.1).IsGreaterThan(0.3).Should().BeFalse();
        }

        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.001, 0.01)]
        [InlineData(0.0, 0.1)]
        [InlineData(-0.00000000002, -0.00000000001)]
        [InlineData(double.NegativeInfinity, double.MinValue)]
        [InlineData(double.NegativeInfinity, double.NaN)]
        [InlineData(double.MaxValue, double.PositiveInfinity)]
        [InlineData(double.NaN, double.NegativeInfinity)]
        public void IsGreaterThan_Double_ShouldReturnFalseWhenLeftIsLessThanRight(double left, double right)
        {
            left.IsGreaterThan(right).Should().BeFalse();
        }

        [Theory]
        [InlineData(0.2, 0.1)]
        [InlineData(0.01, 0.001)]
        [InlineData(0.1, 0.0)]
        [InlineData(-0.00000000001, -0.00000000002)]
        [InlineData(double.PositiveInfinity, double.MaxValue)]
        [InlineData(double.PositiveInfinity, double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity, double.Epsilon)]
        [InlineData(double.MinValue, double.NegativeInfinity)]
        public void IsGreaterThanOrEquals_Double_ShouldReturnTrueWhenLeftIsGreaterThanRight(double left, double right)
        {
            left.IsGreaterThanOrEquals(right).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.1)]
        [InlineData(-0.1, -0.1)]
        [InlineData(0.000000001, 0.000000001)]
        [InlineData(double.PositiveInfinity, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, double.NegativeInfinity)]
        [InlineData(double.Epsilon, 0.0)]
        [InlineData(0.0, double.Epsilon)]
        public void IsGreaterThanOrEquals_Double_ShouldReturnTrueForSameDoubles(double left, double right)
        {
            left.IsGreaterThanOrEquals(right).Should().BeTrue();
        }

        [Fact]
        public void IsGreaterThanOrEquals_Double_ShouldReturnTrueForAddedAndSameDoubles()
        {
            (0.2 + 0.1).IsGreaterThanOrEquals(0.3).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.001, 0.01)]
        [InlineData(0.0, 0.1)]
        [InlineData(-0.00000000002, -0.00000000001)]
        [InlineData(double.NegativeInfinity, double.MinValue)]
        [InlineData(double.MaxValue, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, double.NaN)]
        [InlineData(double.NaN, double.NegativeInfinity)]
        public void IsGreaterThanOrEquals_Double_ShouldReturnFalseWhenLeftIsLessThanRight(double left, double right)
        {
            left.IsGreaterThanOrEquals(right).Should().BeFalse();
        }

        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.001, 0.01)]
        [InlineData(0.0, 0.1)]
        [InlineData(-0.00000000002, -0.00000000001)]
        [InlineData(double.NegativeInfinity, double.MinValue)]
        [InlineData(double.MaxValue, double.PositiveInfinity)]
        public void IsLessThan_Double_ShouldReturnTrueWhenLeftIsLessThanRight(double left, double right)
        {
            left.IsLessThan(right).Should().BeTrue();
        }


        [Theory]
        [InlineData(0.1, 0.1)]
        [InlineData(-0.1, -0.1)]
        [InlineData(0.000000001, 0.000000001)]
        [InlineData(double.PositiveInfinity, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, double.NegativeInfinity)]
        [InlineData(double.Epsilon, 0.0)]
        [InlineData(0.0, double.Epsilon)]
        [InlineData(0.0, double.NaN)]
        [InlineData(double.NaN, 0.0)]
        [InlineData(double.NaN, double.NaN)]
        public void IsLessThan_Double_ShouldReturnFalseForSameDoubles(double left, double right)
        {
            left.IsLessThan(right).Should().BeFalse();
        }

        [Fact]
        public void IsLessThan_Double_ShouldReturnFalseForAddedAndSameDoubles()
        {
            (0.2 + 0.1).IsLessThan(0.3).Should().BeFalse();
        }

        [Theory]
        [InlineData(0.2, 0.1)]
        [InlineData(0.01, 0.001)]
        [InlineData(0.1, 0.0)]
        [InlineData(-0.00000000001, -0.00000000002)]
        [InlineData(double.MinValue, double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity, double.MaxValue)]
        [InlineData(double.NaN, double.NegativeInfinity)]
        [InlineData(double.NegativeInfinity, double.NaN)]
        public void IsLessThan_Double_ShouldReturnFalseWhenLeftIsGreaterThanRight(double left, double right)
        {
            left.IsLessThan(right).Should().BeFalse();
        }


        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.001, 0.01)]
        [InlineData(0.0, 0.1)]
        [InlineData(-0.00000000002, -0.00000000001)]
        [InlineData(double.NegativeInfinity, double.MinValue)]
        [InlineData(double.MaxValue, double.PositiveInfinity)]
        public void IsLessThanOrEquals_Double_ShouldReturnTrueWhenLeftIsLessThanRight(double left, double right)
        {
            left.IsLessThanOrEquals(right).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.1)]
        [InlineData(-0.1, -0.1)]
        [InlineData(0.000000001, 0.000000001)]
        [InlineData(double.PositiveInfinity, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, double.NegativeInfinity)]
        [InlineData(double.Epsilon, 0.0)]
        [InlineData(0.0, double.Epsilon)]
        public void IsLessThanOrEquals_Double_ShouldReturnTrueForSameDoubles(double left, double right)
        {
            left.IsLessThanOrEquals(right).Should().BeTrue();
        }

        [Fact]
        public void IsLessThanOrEquals_Double_ShouldReturnTrueForAddedAndSameDoubles()
        {
            (0.2 + 0.1).IsLessThanOrEquals(0.3).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.2, 0.1)]
        [InlineData(0.01, 0.001)]
        [InlineData(0.1, 0.0)]
        [InlineData(-0.00000000001, -0.00000000002)]
        [InlineData(double.PositiveInfinity, double.MaxValue)]
        [InlineData(double.PositiveInfinity, double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity, double.Epsilon)]
        [InlineData(double.MinValue, double.NegativeInfinity)]
        public void IsLessThanOrEquals_Double_ShouldReturnFalseWhenLeftIsGreaterThanRight(double left, double right)
        {
            left.IsLessThanOrEquals(right).Should().BeFalse();
        }






        [Theory]
        [InlineData(0.1, 0.1)]
        [InlineData(-0.1, -0.1)]
        [InlineData(0.000000001, 0.000000001)]
        [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
        [InlineData(float.NegativeInfinity, float.NegativeInfinity)]
        [InlineData(float.Epsilon, 0.0)]
        [InlineData(0.0, float.Epsilon)]
        public void EqualsTo_Float_ShouldReturnTrueForSameFloats(float left, float right)
        {
            left.EqualsTo(right).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.2, 0.3)]
        [InlineData(-0.1, 0.3, 0.2)]
        public void EqualsTo_Float_ShouldReturnTrueForAddedFloats(float value1, float value2, float result)
        {
            (value1 + value2).EqualsTo(result).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.01, 0.001)]
        [InlineData(-0.1, 0.1)]
        [InlineData(-0.0000001, -0.0000002)]
        [InlineData(float.MaxValue, float.PositiveInfinity)]
        [InlineData(float.MinValue, float.NegativeInfinity)]
        [InlineData(float.PositiveInfinity, float.NegativeInfinity)]
        [InlineData(float.NegativeInfinity, float.PositiveInfinity)]
        [InlineData(float.NaN, float.NaN)]
        [InlineData(float.NaN, 0.1)]
        [InlineData(float.NaN, 0.0)]
        [InlineData(0.0, float.NaN)]
        [InlineData(0.1, float.NaN)]
        [InlineData(float.Epsilon, float.NaN)]
        public void EqualsTo_Float_ShouldReturnFalseForDifferentFloats(float left, float right)
        {
            left.EqualsTo(right).Should().BeFalse();
        }

        [Fact]
        public void EqualsTo_Float_ShouldWorkWellWithIntegers()
        {
            ((float)0.1 + (float)0.2 + (float)0.7).EqualsTo(1).Should().BeTrue();
        }

        [Fact]
        public void IsZero_Float_ShouldReturnTrueForZero()
        {
            const float value = (float)0.0;

            value.IsZero().Should().BeTrue();
        }

        [Fact]
        public void IsZero_Float_ShouldReturnTrueForEpsilon()
        {
            float.Epsilon.IsZero().Should().BeTrue();
        }

        [Fact]
        public void IsZero_Float_ShouldReturnTrueAddedFloats()
        {
            ((float)0.3 - (float)0.2 - (float)0.1).IsZero().Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1)]
        [InlineData(0.01)]
        [InlineData(-0.01)]
        [InlineData(-0.0000001)]
        [InlineData(0.0000001)]
        [InlineData(float.NegativeInfinity)]
        [InlineData(float.PositiveInfinity)]
        [InlineData(float.NaN)]
        public void IsZero_Float_ShouldReturnFalseForNonZeroValues(float value)
        {
            value.IsZero().Should().BeFalse();
        }

        [Theory]
        [InlineData(0.2, 0.1)]
        [InlineData(0.01, 0.001)]
        [InlineData(0.1, 0.0)]
        [InlineData(-0.000001, -0.000002)]
        [InlineData(float.PositiveInfinity, float.MaxValue)]
        [InlineData(float.PositiveInfinity, float.NegativeInfinity)]
        [InlineData(float.PositiveInfinity, float.Epsilon)]
        [InlineData(float.MinValue, float.NegativeInfinity)]
        public void IsGreaterThan_Float_ShouldReturnTrueWhenLeftIsGreaterThanRight(float left, float right)
        {
            left.IsGreaterThan(right).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.1)]
        [InlineData(-0.1, -0.1)]
        [InlineData(0.0000001, 0.0000001)]
        [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
        [InlineData(float.NegativeInfinity, float.NegativeInfinity)]
        [InlineData(float.Epsilon, 0.0)]
        [InlineData(0.0, float.Epsilon)]
        [InlineData(0.0, float.NaN)]
        [InlineData(float.NaN, 0.0)]
        [InlineData(float.NaN, float.NaN)]
        public void IsGreaterThan_Float_ShouldReturnFalseForSameFloats(float left, float right)
        {
            left.IsGreaterThan(right).Should().BeFalse();
        }

        [Fact]
        public void IsGreaterThan_Float_ShouldReturnFalseForAddedAndSameFloats()
        {
            ((float)0.2 + (float)0.1).IsGreaterThan((float)0.3).Should().BeFalse();
        }

        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.001, 0.01)]
        [InlineData(0.0, 0.1)]
        [InlineData(-0.0000002, -0.0000001)]
        [InlineData(float.NegativeInfinity, float.MinValue)]
        [InlineData(float.NegativeInfinity, float.NaN)]
        [InlineData(float.MaxValue, float.PositiveInfinity)]
        [InlineData(float.NaN, float.NegativeInfinity)]
        public void IsGreaterThan_Float_ShouldReturnFalseWhenLeftIsLessThanRight(float left, float right)
        {
            left.IsGreaterThan(right).Should().BeFalse();
        }

        [Theory]
        [InlineData(0.2, 0.1)]
        [InlineData(0.01, 0.001)]
        [InlineData(0.1, 0.0)]
        [InlineData(-0.0000001, -0.0000002)]
        [InlineData(float.PositiveInfinity, float.MaxValue)]
        [InlineData(float.PositiveInfinity, float.NegativeInfinity)]
        [InlineData(float.PositiveInfinity, float.Epsilon)]
        [InlineData(float.MinValue, float.NegativeInfinity)]
        public void IsGreaterThanOrEquals_Float_ShouldReturnTrueWhenLeftIsGreaterThanRight(float left, float right)
        {
            left.IsGreaterThanOrEquals(right).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.1)]
        [InlineData(-0.1, -0.1)]
        [InlineData(0.0000001, 0.0000001)]
        [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
        [InlineData(float.NegativeInfinity, float.NegativeInfinity)]
        [InlineData(float.Epsilon, 0.0)]
        [InlineData(0.0, float.Epsilon)]
        public void IsGreaterThanOrEquals_Float_ShouldReturnTrueForSameFloats(float left, float right)
        {
            left.IsGreaterThanOrEquals(right).Should().BeTrue();
        }

        [Fact]
        public void IsGreaterThanOrEquals_Float_ShouldReturnTrueForAddedAndSameFloats()
        {
            (0.2 + 0.1).IsGreaterThanOrEquals(0.3).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.001, 0.01)]
        [InlineData(0.0, 0.1)]
        [InlineData(-0.0000002, -0.0000001)]
        [InlineData(float.NegativeInfinity, float.MinValue)]
        [InlineData(float.MaxValue, float.PositiveInfinity)]
        [InlineData(float.NegativeInfinity, float.NaN)]
        [InlineData(float.NaN, float.NegativeInfinity)]
        public void IsGreaterThanOrEquals_Float_ShouldReturnFalseWhenLeftIsLessThanRight(float left, float right)
        {
            left.IsGreaterThanOrEquals(right).Should().BeFalse();
        }

        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.001, 0.01)]
        [InlineData(0.0, 0.1)]
        [InlineData(-0.000002, -0.000001)]
        [InlineData(float.NegativeInfinity, float.MinValue)]
        [InlineData(float.MaxValue, float.PositiveInfinity)]
        public void IsLessThan_Float_ShouldReturnTrueWhenLeftIsLessThanRight(float left, float right)
        {
            left.IsLessThan(right).Should().BeTrue();
        }


        [Theory]
        [InlineData(0.1, 0.1)]
        [InlineData(-0.1, -0.1)]
        [InlineData(0.0000001, 0.0000001)]
        [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
        [InlineData(float.NegativeInfinity, float.NegativeInfinity)]
        [InlineData(float.Epsilon, 0.0)]
        [InlineData(0.0, float.Epsilon)]
        [InlineData(0.0, float.NaN)]
        [InlineData(float.NaN, 0.0)]
        [InlineData(float.NaN, float.NaN)]
        public void IsLessThan_Float_ShouldReturnFalseForSameFloats(float left, float right)
        {
            left.IsLessThan(right).Should().BeFalse();
        }

        [Fact]
        public void IsLessThan_Float_ShouldReturnFalseForAddedAndSameFloats()
        {
            ((float)0.2 + (float)0.1).IsLessThan((float)0.3).Should().BeFalse();
        }

        [Theory]
        [InlineData(0.2, 0.1)]
        [InlineData(0.01, 0.001)]
        [InlineData(0.1, 0.0)]
        [InlineData(-0.0000001, -0.0000002)]
        [InlineData(float.MinValue, float.NegativeInfinity)]
        [InlineData(float.PositiveInfinity, float.MaxValue)]
        [InlineData(float.NaN, float.NegativeInfinity)]
        [InlineData(float.NegativeInfinity, float.NaN)]
        public void IsLessThan_Float_ShouldReturnFalseWhenLeftIsGreaterThanRight(float left, float right)
        {
            left.IsLessThan(right).Should().BeFalse();
        }


        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.001, 0.01)]
        [InlineData(0.0, 0.1)]
        [InlineData(-0.0000002, -0.0000001)]
        [InlineData(float.NegativeInfinity, float.MinValue)]
        [InlineData(float.MaxValue, float.PositiveInfinity)]
        public void IsLessThanOrEquals_Float_ShouldReturnTrueWhenLeftIsLessThanRight(float left, float right)
        {
            left.IsLessThanOrEquals(right).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.1)]
        [InlineData(-0.1, -0.1)]
        [InlineData(0.0000001, 0.0000001)]
        [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
        [InlineData(float.NegativeInfinity, float.NegativeInfinity)]
        [InlineData(float.Epsilon, 0.0)]
        [InlineData(0.0, float.Epsilon)]
        public void IsLessThanOrEquals_Float_ShouldReturnTrueForSameFloats(float left, float right)
        {
            left.IsLessThanOrEquals(right).Should().BeTrue();
        }

        [Fact]
        public void IsLessThanOrEquals_Float_ShouldReturnTrueForAddedAndSameFloats()
        {
            ((float)0.2 + (float)0.1).IsLessThanOrEquals((float)0.3).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.2, 0.1)]
        [InlineData(0.01, 0.001)]
        [InlineData(0.1, 0.0)]
        [InlineData(-0.0000001, -0.0000002)]
        [InlineData(float.PositiveInfinity, float.MaxValue)]
        [InlineData(float.PositiveInfinity, float.NegativeInfinity)]
        [InlineData(float.PositiveInfinity, float.Epsilon)]
        [InlineData(float.MinValue, float.NegativeInfinity)]
        public void IsLessThanOrEquals_Float_ShouldReturnFalseWhenLeftIsGreaterThanRight(float left, float right)
        {
            left.IsLessThanOrEquals(right).Should().BeFalse();
        }

    }
}