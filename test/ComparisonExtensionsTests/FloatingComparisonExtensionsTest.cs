using ComparisonExtensions;
using Xunit;
using FluentAssertions;

namespace ComparisonExtensionsTests
{
    public class FloatingComparisonExtensionsTest
    {
        [Fact]
        public void EqualsTo_Double_ShouldReturnTrueForSameDoubles()
        {
            const double value = 0.3;

            value.EqualsTo(0.3).Should().BeTrue();
        }

        [Fact]
        public void EqualsTo_Double_ShouldReturnTrueForAddedDoubles()
        {
            (0.2 + 0.1).EqualsTo(0.3).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.01, 0.001)]
        [InlineData(-0.1, 0.1)]
        [InlineData(-0.00000000001, -0.00000000002)]
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
        public void IsZero_Double_ShouldReturnFalseForNonZeroValues(double value)
        {
            value.IsZero().Should().BeFalse();
        }

        [Theory]
        [InlineData(0.2, 0.1)]
        [InlineData(0.01, 0.001)]
        [InlineData(0.1, 0.0)]
        [InlineData(-0.00000000001, -0.00000000002)]
        public void IsGreaterThan_Double_ShouldReturnTrueWhenLeftIsGreaterThanRight(double left, double right)
        {
            left.IsGreaterThan(right).Should().BeTrue();
        }

        [Fact]
        public void IsGreaterThan_Double_ShouldReturnFalseForSameDoubles()
        {
            const double value = 0.3;

            value.IsGreaterThan(0.3).Should().BeFalse();
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
        public void IsGreaterThan_Double_ShouldReturnFalseWhenLeftIsLessThanRight(double left, double right)
        {
            left.IsGreaterThan(right).Should().BeFalse();
        }

        [Theory]
        [InlineData(0.2, 0.1)]
        [InlineData(0.01, 0.001)]
        [InlineData(0.1, 0.0)]
        [InlineData(-0.00000000001, -0.00000000002)]
        public void IsGreaterThanOrEquals_Double_ShouldReturnTrueWhenLeftIsGreaterThanRight(double left, double right)
        {
            left.IsGreaterThanOrEquals(right).Should().BeTrue();
        }

        [Fact]
        public void IsGreaterThanOrEquals_Double_ShouldReturnTrueForSameDoubles()
        {
            const double value = 0.3;

            value.IsGreaterThanOrEquals(0.3).Should().BeTrue();
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
        public void IsGreaterThanOrEquals_Double_ShouldReturnFalseWhenLeftIsLessThanRight(double left, double right)
        {
            left.IsGreaterThanOrEquals(right).Should().BeFalse();
        }

        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.001, 0.01)]
        [InlineData(0.0, 0.1)]
        [InlineData(-0.00000000002, -0.00000000001)]
        public void IsLessThan_Double_ShouldReturnTrueWhenLeftIsLessThanRight(double left, double right)
        {
            left.IsLessThan(right).Should().BeTrue();
        }

        [Fact]
        public void IsLessThan_Double_ShouldReturnFalseForSameDoubles()
        {
            const double value = 0.3;

            value.IsLessThan(0.3).Should().BeFalse();
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
        public void IsLessThan_Double_ShouldReturnFalseWhenLeftIsGreaterThanRight(double left, double right)
        {
            left.IsLessThan(right).Should().BeFalse();
        }


        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.001, 0.01)]
        [InlineData(0.0, 0.1)]
        [InlineData(-0.00000000002, -0.00000000001)]
        public void IsLessThanOrEquals_Double_ShouldReturnTrueWhenLeftIsLessThanRight(double left, double right)
        {
            left.IsLessThanOrEquals(right).Should().BeTrue();
        }

        [Fact]
        public void IsLessThanOrEquals_Double_ShouldReturnTrueForSameDoubles()
        {
            const double value = 0.3;

            value.IsLessThanOrEquals(0.3).Should().BeTrue();
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
        public void IsLessThanOrEquals_Double_ShouldReturnFalseWhenLeftIsLessThanRight(double left, double right)
        {
            left.IsLessThanOrEquals(right).Should().BeFalse();
        }

        [Fact]
        public void EqualsTo_Float_ShouldReturnTrueForSameFloats()
        {
            const float value = (float) 0.3;

            value.EqualsTo((float) 0.3).Should().BeTrue();
        }

        [Fact]
        public void EqualsTo_Float_ShouldReturnTrueForAddedFloats()
        {
            ((float) (0.2 + 0.1)).EqualsTo((float) 0.3).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.01, 0.001)]
        [InlineData(-0.1, 0.1)]
        [InlineData(-0.00000000001, -0.00000000002)]
        public void EqualsTo_Float_ShouldReturnFalseForDifferentFloats(float left, float right)
        {
            left.EqualsTo(right).Should().BeFalse();
        }

        [Fact]
        public void EqualsTo_Float_ShouldWorkWellWithIntegers()
        {
            ((float) (0.1 + 0.2 + 0.7)).EqualsTo(1).Should().BeTrue();
        }

        [Fact]
        public void IsZero_Float_ShouldReturnTrueForZero()
        {
            const float value = (float) 0.0;

            value.IsZero().Should().BeTrue();
        }

        [Fact]
        public void IsZero_Float_ShouldReturnTrueAddedFloats()
        {
            ((float) (0.3 - 0.2 - 0.1)).IsZero().Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1)]
        [InlineData(0.01)]
        [InlineData(-0.01)]
        [InlineData(-0.00000000001)]
        [InlineData(0.00000000001)]
        [InlineData(float.NegativeInfinity)]
        [InlineData(float.PositiveInfinity)]
        public void IsZero_Float_ShouldReturnFalseForNonZeroValues(float value)
        {
            value.IsZero().Should().BeFalse();
        }

        [Theory]
        [InlineData(0.2, 0.1)]
        [InlineData(0.01, 0.001)]
        [InlineData(0.1, 0.0)]
        [InlineData(-0.00000000001, -0.00000000002)]
        public void IsGreaterThan_Float_ShouldReturnTrueWhenLeftIsGreaterThanRight(float left, float right)
        {
            left.IsGreaterThan(right).Should().BeTrue();
        }

        [Fact]
        public void IsGreaterThan_Float_ShouldReturnFalseForSameFloats()
        {
            const float value = (float) 0.3;

            value.IsGreaterThan((float) 0.3).Should().BeFalse();
        }

        [Fact]
        public void IsGreaterThan_Float_ShouldReturnFalseForAddedAndSameFloats()
        {
            ((float) (0.2 + 0.1)).IsGreaterThan((float) 0.3).Should().BeFalse();
        }

        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.001, 0.01)]
        [InlineData(0.0, 0.1)]
        [InlineData(-0.00000000002, -0.00000000001)]
        public void IsGreaterThan_Float_ShouldReturnFalseWhenLeftIsLessThanRight(float left, float right)
        {
            left.IsGreaterThan(right).Should().BeFalse();
        }

        [Theory]
        [InlineData(0.2, 0.1)]
        [InlineData(0.01, 0.001)]
        [InlineData(0.1, 0.0)]
        [InlineData(-0.00000000001, -0.00000000002)]
        public void IsGreaterThanOrEquals_Float_ShouldReturnTrueWhenLeftIsGreaterThanRight(float left, float right)
        {
            left.IsGreaterThanOrEquals(right).Should().BeTrue();
        }

        [Fact]
        public void IsGreaterThanOrEquals_Float_ShouldReturnTrueForSameFloats()
        {
            const float value = (float) 0.3;

            value.IsGreaterThanOrEquals((float) 0.3).Should().BeTrue();
        }

        [Fact]
        public void IsGreaterThanOrEquals_Float_ShouldReturnTrueForAddedAndSameFloats()
        {
            ((float) (0.2 + 0.1)).IsGreaterThanOrEquals((float) 0.3).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.001, 0.01)]
        [InlineData(0.0, 0.1)]
        [InlineData(-0.00000000002, -0.00000000001)]
        public void IsGreaterThanOrEquals_Float_ShouldReturnFalseWhenLeftIsLessThanRight(float left, float right)
        {
            left.IsGreaterThanOrEquals(right).Should().BeFalse();
        }

        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.001, 0.01)]
        [InlineData(0.0, 0.1)]
        [InlineData(-0.00000000002, -0.00000000001)]
        public void IsLessThan_Float_ShouldReturnTrueWhenLeftIsLessThanRight(float left, float right)
        {
            left.IsLessThan(right).Should().BeTrue();
        }

        [Fact]
        public void IsLessThan_Float_ShouldReturnFalseForSameFloats()
        {
            const float value = (float) 0.3;

            value.IsLessThan((float) 0.3).Should().BeFalse();
        }

        [Fact]
        public void IsLessThan_Float_ShouldReturnFalseForAddedAndSameFloats()
        {
            (0.2 + 0.1).IsLessThan(0.3).Should().BeFalse();
        }

        [Theory]
        [InlineData(0.2, 0.1)]
        [InlineData(0.01, 0.001)]
        [InlineData(0.1, 0.0)]
        [InlineData(-0.00000000001, -0.00000000002)]
        public void IsLessThan_Float_ShouldReturnFalseWhenLeftIsGreaterThanRight(float left, float right)
        {
            left.IsLessThan(right).Should().BeFalse();
        }


        [Theory]
        [InlineData(0.1, 0.2)]
        [InlineData(0.001, 0.01)]
        [InlineData(0.0, 0.1)]
        [InlineData(-0.00000000002, -0.00000000001)]
        public void IsLessThanOrEquals_Float_ShouldReturnTrueWhenLeftIsLessThanRight(float left, float right)
        {
            left.IsLessThanOrEquals(right).Should().BeTrue();
        }

        [Fact]
        public void IsLessThanOrEquals_Float_ShouldReturnTrueForSameFloats()
        {
            const float value = (float) 0.3;

            value.IsLessThanOrEquals((float) 0.3).Should().BeTrue();
        }

        [Fact]
        public void IsLessThanOrEquals_Float_ShouldReturnTrueForAddedAndSameFloats()
        {
            ((float) (0.2 + 0.1)).IsLessThanOrEquals((float) 0.3).Should().BeTrue();
        }

        [Theory]
        [InlineData(0.2, 0.1)]
        [InlineData(0.01, 0.001)]
        [InlineData(0.1, 0.0)]
        [InlineData(-0.00000000001, -0.00000000002)]
        public void IsLessThanOrEquals_Float_ShouldReturnFalseWhenLeftIsLessThanRight(float left, float right)
        {
            left.IsLessThanOrEquals(right).Should().BeFalse();
        }
    }
}