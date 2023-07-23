using System.Collections.Generic;
using System.Linq;
using ComparisonExtensions;
using FluentAssertions;
using Xunit;

namespace ComparisonExtensionsTests
{
    public class DoubleComparisonExtensionsTest
    {
        public record DoubleEqualityScenario(double Left, double Right, string Name = null)
        {
            public override string ToString() => this.Name ?? $"left = {this.Left}, right = {this.Right}";
        }

        public record DoubleZeroScenario(double Value, bool ExpectZero, string Name = null)
        {
            public override string ToString() => this.Name ?? $"value = {this.Value}, expectZero = {this.ExpectZero}";
        }

        public record DoubleComparisonScenario(double Left, double Right, bool LeftIsGreaterThanRight, string Name = null)
        {
            public override string ToString() => this.Name ?? $"left = {this.Left}, right = {this.Right}, leftIsGreaterThanRight = {this.LeftIsGreaterThanRight}";
        }

        public record DoubleNoComparisonScenario(double Left, double Right, string Name = null)
        {
            public override string ToString() => this.Name ?? $"left = {this.Left}, right = {this.Right}";
        }

        public static IEnumerable<object[]> EqualTestCasesData => EqualTestCases.Select(testCase => new object[] { testCase });
        private static IEnumerable<DoubleEqualityScenario> EqualTestCases
        {
            get
            {
                yield return new(0.1d, 0.1d);
                yield return new(-0.1d, -0.1d);
                yield return new(0.000000001d, 0.000000001d);
                yield return new(double.PositiveInfinity, double.PositiveInfinity);
                yield return new(double.NegativeInfinity, double.NegativeInfinity);
                yield return new(double.Epsilon, 0.0d);
                yield return new(0.0d, double.Epsilon);

                yield return new(0.1d + 0.2d + 0.7d, 1, "works well with integers");
                yield return new(0.1d + 0.2d, 0.3d, "true when adding positive");
                yield return new(-0.1d + 0.3d, 0.2d, "true when adding negative");


                double originalWeight, comparisonWeight;

                // do math on it to change the value and come back to the "same" value
                originalWeight = 100d;
                comparisonWeight = originalWeight + 123.5d;
                comparisonWeight = comparisonWeight * .33333333333d;
                comparisonWeight = comparisonWeight / .33333333333d;
                comparisonWeight = comparisonWeight - 123.5d;
                yield return new(originalWeight, comparisonWeight, "both nearly 100");

                // do math on it to change the value and come back to the "same" value
                originalWeight = 1d;
                comparisonWeight = originalWeight + 123.5d;
                comparisonWeight = comparisonWeight * .33333333333d;
                comparisonWeight = comparisonWeight / .33333333333d;
                comparisonWeight = comparisonWeight - 123.5d;
                yield return new(originalWeight, comparisonWeight, "both nearly 1");

                // do math on it to change the value and come back to the "same" value
                originalWeight = 0.00001d;
                comparisonWeight = originalWeight + 123.5d;
                comparisonWeight = comparisonWeight * .33333333333d;
                comparisonWeight = comparisonWeight / .33333333333d;
                comparisonWeight = comparisonWeight - 123.5d;
                yield return new(originalWeight, comparisonWeight, "both nearly 0");
            }
        }

        public static IEnumerable<object[]> NotEqualTestCasesData => NotEqualTestCases.Select(testCase => new object[] { testCase });
        private static IEnumerable<DoubleEqualityScenario> NotEqualTestCases
        {
            get
            {
                yield return new(0.1d, 0.2d);
                yield return new(0.01d, 0.001d);
                yield return new(-0.1d, 0.1d);
                yield return new(-0.0000001d, -0.0000002d);
                yield return new(double.MaxValue, double.PositiveInfinity);
                yield return new(double.MinValue, double.NegativeInfinity);
                yield return new(double.PositiveInfinity, double.NegativeInfinity);
                yield return new(double.NegativeInfinity, double.PositiveInfinity);
                yield return new(double.NaN, double.NaN);
                yield return new(double.NaN, 0.1d);
                yield return new(double.NaN, 0.0d);
                yield return new(0.0d, double.NaN);
                yield return new(0.1d, double.NaN);
                yield return new(double.Epsilon, double.NaN);
            }
        }

        public static IEnumerable<object[]> ZeroTestCasesData => ZeroTestCases.Select(testCase => new object[] { testCase });
        private static IEnumerable<DoubleZeroScenario> ZeroTestCases
        {
            get
            {
                // these are zero
                yield return new(0.0d, true);
                yield return new(double.Epsilon, true, "epsilon");
                yield return new(0.3d - 0.2d - 0.1d, true, "added doubles");

                // these are not zero
                yield return new(0.1d, false);
                yield return new(0.01d, false);
                yield return new(-0.01d, false);
                yield return new(-0.0000001d, false);
                yield return new(0.0000001d, false);
                yield return new(double.NegativeInfinity, false);
                yield return new(double.PositiveInfinity, false);
                yield return new(double.NaN, false);
            }
        }

        public static IEnumerable<object[]> ComparisonTestCasesData => ComparisonTestCases.Select(testCase => new object[] { testCase });
        private static IEnumerable<DoubleComparisonScenario> ComparisonTestCases
        {
            get
            {
                // these are where left is larger than right
                yield return new(0.2d, 0.1f, true);
                yield return new(0.01d, 0.001f, true);
                yield return new(0.1d, 0.0f, true);
                yield return new(0.002d, 0.001d, true, "3 digit precision (pos)");
                yield return new(0.0002d, 0.0001d, true, "4 digit precision (pos)");
                yield return new(0.00002d, 0.00001d, true, "5 digit precision (pos)");
                yield return new(0.000002d, 0.000001d, true, "6 digit precision (pos)");
                yield return new(0.0000002d, 0.0000001d, true, "7 digit precision (pos)");
                yield return new(0.00000002d, 0.00000001d, true, "8 digit precision (pos)");
                yield return new(0.000000002d, 0.000000001d, true, "9 digit precision (pos)");
                yield return new(0.0000000002d, 0.0000000001d, true, "10 digit precision (pos)");
                yield return new(-0.001d, -0.002d, true, "3 digit precision (neg)");
                yield return new(-0.0001d, -0.0002d, true, "4 digit precision (neg)");
                yield return new(-0.00001d, -0.00002d, true, "5 digit precision (neg)");
                yield return new(-0.000001d, -0.000002d, true, "6 digit precision (neg)");
                yield return new(-0.0000001d, -0.0000002d, true, "7 digit precision (neg)");
                yield return new(-0.00000001d, -0.00000002d, true, "8 digit precision (neg)");
                yield return new(-0.000000001d, -0.000000002d, true, "9 digit precision (neg)");
                yield return new(-0.0000000001d, -0.0000000002d, true, "10 digit precision (neg)");
                yield return new(double.PositiveInfinity, double.MaxValue, true);
                yield return new(double.PositiveInfinity, double.NegativeInfinity, true);
                yield return new(double.PositiveInfinity, double.Epsilon, true);
                yield return new(double.MinValue, double.NegativeInfinity, true);
            }
        }

        public static IEnumerable<object[]> NoComparisonTestCasesData => NoComparisonTestCases.Select(testCase => new object[] { testCase });
        private static IEnumerable<DoubleNoComparisonScenario> NoComparisonTestCases
        {
            get
            {
                // comparison is always false when NaN is involved
                yield return new(double.NegativeInfinity, double.NaN);
                yield return new(double.NaN, double.NegativeInfinity);
            }
        }

        [Theory]
        [MemberData(nameof(EqualTestCasesData))]
        public void EqualsTo_ShouldReturnTrueForSameDoubles(DoubleEqualityScenario scenario)
        {
            scenario.Left.EqualsTo(scenario.Right).Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(NotEqualTestCasesData))]
        public void EqualsTo_ShouldReturnFalseForDifferentDoubles(DoubleEqualityScenario scenario)
        {
            scenario.Left.EqualsTo(scenario.Right).Should().BeFalse();
        }


        [Theory]
        [MemberData(nameof(ZeroTestCasesData))]
        public void IsZero_ShouldReturnTrueForZero(DoubleZeroScenario scenario)
        {
            scenario.Value.IsZero().Should().Be(scenario.ExpectZero);
        }


        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsGreaterThan_ShouldReturnTrueWhenLeftIsGreaterThanRight(DoubleComparisonScenario scenario)
        {
            scenario.Left.IsGreaterThan(scenario.Right).Should().Be(scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsGreaterThan_ShouldReturnFalseWhenLeftIsLessThanRight(DoubleComparisonScenario scenario)
        {
            scenario.Right.IsGreaterThan(scenario.Left).Should().Be(!scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(NoComparisonTestCasesData))]
        public void IsGreaterThan_ShouldReturnFalseWhenNoComparison(DoubleNoComparisonScenario scenario)
        {
            scenario.Right.IsGreaterThan(scenario.Left).Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(EqualTestCasesData))]
        public void IsGreaterThan_ShouldReturnFalseForSameDoubles(DoubleEqualityScenario scenario)
        {
            scenario.Left.IsGreaterThan(scenario.Right).Should().BeFalse();
        }


        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsGreaterThanOrEquals_ShouldReturnTrueWhenLeftIsGreaterThanRight(DoubleComparisonScenario scenario)
        {
            scenario.Left.IsGreaterThanOrEquals(scenario.Right).Should().Be(scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsGreaterThanOrEquals_ShouldReturnFalseWhenLeftIsLessThanRight(DoubleComparisonScenario scenario)
        {
            scenario.Right.IsGreaterThanOrEquals(scenario.Left).Should().Be(!scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(NoComparisonTestCasesData))]
        public void IsGreaterThanOrEquals_ShouldReturnFalseWhenNoComparison(DoubleNoComparisonScenario scenario)
        {
            scenario.Right.IsGreaterThanOrEquals(scenario.Left).Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(EqualTestCasesData))]
        public void IsGreaterThanOrEquals_ShouldReturnTrueForSameDoubles(DoubleEqualityScenario scenario)
        {
            scenario.Left.IsGreaterThanOrEquals(scenario.Right).Should().BeTrue();
        }


        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsLessThan_ShouldReturnTrueWhenLeftIsLessThanRight(DoubleComparisonScenario scenario)
        {
            scenario.Left.IsLessThan(scenario.Right).Should().Be(!scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsLessThan_ShouldReturnFalseWhenLeftIsGreaterThanRight(DoubleComparisonScenario scenario)
        {
            scenario.Right.IsLessThan(scenario.Left).Should().Be(scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(NoComparisonTestCasesData))]
        public void IsLessThan_ShouldReturnFalseWhenNoComparison(DoubleNoComparisonScenario scenario)
        {
            scenario.Right.IsLessThan(scenario.Left).Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(EqualTestCasesData))]
        public void IsLessThan_ShouldReturnFalseForSameDoubles(DoubleEqualityScenario scenario)
        {
            scenario.Left.IsLessThan(scenario.Right).Should().BeFalse();
        }


        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsLessThanOrEquals_ShouldReturnTrueWhenLeftIsLessThanRight(DoubleComparisonScenario scenario)
        {
            scenario.Left.IsLessThanOrEquals(scenario.Right).Should().Be(!scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsLessThanOrEquals_ShouldReturnFalseWhenLeftIsGreaterThanRight(DoubleComparisonScenario scenario)
        {
            scenario.Right.IsLessThanOrEquals(scenario.Left).Should().Be(scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(NoComparisonTestCasesData))]
        public void IsLessThanOrEquals_ShouldReturnFalseWhenNoComparison(DoubleNoComparisonScenario scenario)
        {
            scenario.Right.IsLessThanOrEquals(scenario.Left).Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(EqualTestCasesData))]
        public void IsLessThanOrEquals_ShouldReturnTrueForSameDoubles(DoubleEqualityScenario scenario)
        {
            scenario.Left.IsLessThanOrEquals(scenario.Right).Should().BeTrue();
        }
    }
}
