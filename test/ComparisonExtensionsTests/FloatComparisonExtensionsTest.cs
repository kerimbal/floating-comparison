using System.Collections.Generic;
using System.Linq;
using ComparisonExtensions;
using FluentAssertions;
using Xunit;

namespace ComparisonExtensionsTests
{
    public class FloatComparisonExtensionsTest
    {
        public record FloatEqualityScenario(float Left, float Right, string Name = null)
        {
            public override string ToString() => this.Name ?? $"left = {this.Left}, right = {this.Right}";
        }

        public record FloatZeroScenario(float Value, bool ExpectZero, string Name = null)
        {
            public override string ToString() => this.Name ?? $"value = {this.Value}, expectZero = {this.ExpectZero}";
        }

        public record FloatComparisonScenario(float Left, float Right, bool LeftIsGreaterThanRight, string Name = null)
        {
            public override string ToString() => this.Name ?? $"left = {this.Left}, right = {this.Right}, leftIsGreaterThanRight = {this.LeftIsGreaterThanRight}";
        }

        public record FloatNoComparisonScenario(float Left, float Right, string Name = null)
        {
            public override string ToString() => this.Name ?? $"left = {this.Left}, right = {this.Right}";
        }

        public static IEnumerable<object[]> EqualTestCasesData => EqualTestCases.Select(testCase => new object[] { testCase });
        private static IEnumerable<FloatEqualityScenario> EqualTestCases
        {
            get
            {
                yield return new(0.1f, 0.1f);
                yield return new(-0.1f, -0.1f);
                yield return new(0.000000001f, 0.000000001f);
                yield return new(float.PositiveInfinity, float.PositiveInfinity);
                yield return new(float.NegativeInfinity, float.NegativeInfinity);
                yield return new(float.Epsilon, 0.0f);
                yield return new(0.0f, float.Epsilon);

                yield return new(0.1f + 0.2f + 0.7f, 1, "works well with integers");
                yield return new(0.1f + 0.2f, 0.3f, "true when adding positive");
                yield return new(-0.1f + 0.3f, 0.2f, "true when adding negative");

                
                float originalWeight, comparisonWeight;

                // do math on it to change the value and come back to the "same" value
                originalWeight = 100f;
                comparisonWeight = originalWeight + 123.5f;
                comparisonWeight = comparisonWeight * .33333333333f;
                comparisonWeight = comparisonWeight / .33333333333f;
                comparisonWeight = comparisonWeight - 123.5f;
                yield return new(originalWeight, comparisonWeight, "both nearly 100");

                // do math on it to change the value and come back to the "same" value
                originalWeight = 1f;
                comparisonWeight = originalWeight + 123.5f;
                comparisonWeight = comparisonWeight * .33333333333f;
                comparisonWeight = comparisonWeight / .33333333333f;
                comparisonWeight = comparisonWeight - 123.5f;
                yield return new(originalWeight, comparisonWeight, "both nearly 1");
                
            }
        }

        public static IEnumerable<object[]> NotEqualTestCasesData => NotEqualTestCases.Select(testCase => new object[] { testCase });
        private static IEnumerable<FloatEqualityScenario> NotEqualTestCases
        {
            get
            {
                yield return new(0.1f, 0.2f);
                yield return new(0.01f, 0.001f);
                yield return new(-0.1f, 0.1f);
                yield return new(-0.0000001f, -0.0000002f);
                yield return new(float.MaxValue, float.PositiveInfinity);
                yield return new(float.MinValue, float.NegativeInfinity);
                yield return new(float.PositiveInfinity, float.NegativeInfinity);
                yield return new(float.NegativeInfinity, float.PositiveInfinity);
                yield return new(float.NaN, float.NaN);
                yield return new(float.NaN, 0.1f);
                yield return new(float.NaN, 0.0f);
                yield return new(0.0f, float.NaN);
                yield return new(0.1f, float.NaN);
                yield return new(float.Epsilon, float.NaN);
            }
        }

        public static IEnumerable<object[]> ZeroTestCasesData => ZeroTestCases.Select(testCase => new object[] { testCase });
        private static IEnumerable<FloatZeroScenario> ZeroTestCases
        {
            get
            {
                // these are zero
                yield return new(0.0f, true);
                yield return new(float.Epsilon, true, "epsilon");
                yield return new(0.3f - 0.2f - 0.1f, true, "added floats");

                // these are not zero
                yield return new(0.1f, false);
                yield return new(0.01f, false);
                yield return new(-0.01f, false);
                yield return new(-0.0000001f, false);
                yield return new(0.0000001f, false);
                yield return new(float.NegativeInfinity, false);
                yield return new(float.PositiveInfinity, false);
                yield return new(float.NaN, false);
            }
        }

        public static IEnumerable<object[]> ComparisonTestCasesData => ComparisonTestCases.Select(testCase => new object[] { testCase });
        private static IEnumerable<FloatComparisonScenario> ComparisonTestCases
        {
            get
            {
                // these are where left is larger than right
                yield return new(0.2f, 0.1f, true);
                yield return new(0.01f, 0.001f, true);
                yield return new(0.1f, 0.0f, true);
                yield return new(0.002f, 0.001f, true, "3 digit precision (pos)");
                yield return new(0.0002f, 0.0001f, true, "4 digit precision (pos)");
                yield return new(0.00002f, 0.00001f, true, "5 digit precision (pos)");
                yield return new(0.000002f, 0.000001f, true, "6 digit precision (pos)");
                //yield return new(0.0000002f, 0.0000001f, true, false, "7 digit precision (pos)"); // too small for float to tell the difference
                yield return new(-0.001f, -0.002f, true, "3 digit precision (neg)");
                yield return new(-0.0001f, -0.0002f, true, "4 digit precision (neg)");
                yield return new(-0.00001f, -0.00002f, true, "5 digit precision (neg)");
                yield return new(-0.000001f, -0.000002f, true, "6 digit precision (neg)");
                //yield return new(-0.0000001f, -0.0000002f, true, false, "7 digit precision (neg)"); // too small for float to tell the difference
                yield return new(float.PositiveInfinity, float.MaxValue, true);
                yield return new(float.PositiveInfinity, float.NegativeInfinity, true);
                yield return new(float.PositiveInfinity, float.Epsilon, true);
                yield return new(float.MinValue, float.NegativeInfinity, true);
            }
        }

        public static IEnumerable<object[]> NoComparisonTestCasesData => NoComparisonTestCases.Select(testCase => new object[] { testCase });
        private static IEnumerable<FloatNoComparisonScenario> NoComparisonTestCases
        {
            get
            {
                // comparison is always false when NaN is involved
                yield return new(float.NegativeInfinity, float.NaN);
                yield return new(float.NaN, float.NegativeInfinity);
            }
        }

        [Theory]
        [MemberData(nameof(EqualTestCasesData))]
        public void EqualsTo_ShouldReturnTrueForSameFloats(FloatEqualityScenario scenario)
        {
            scenario.Left.EqualsTo(scenario.Right).Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(NotEqualTestCasesData))]
        public void EqualsTo_ShouldReturnFalseForDifferentFloats(FloatEqualityScenario scenario)
        {
            scenario.Left.EqualsTo(scenario.Right).Should().BeFalse();
        }


        [Theory]
        [MemberData(nameof(ZeroTestCasesData))]
        public void IsZero_ShouldReturnTrueForZero(FloatZeroScenario scenario)
        {
            scenario.Value.IsZero().Should().Be(scenario.ExpectZero);
        }


        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsGreaterThan_ShouldReturnTrueWhenLeftIsGreaterThanRight(FloatComparisonScenario scenario)
        {
            scenario.Left.IsGreaterThan(scenario.Right).Should().Be(scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsGreaterThan_ShouldReturnFalseWhenLeftIsLessThanRight(FloatComparisonScenario scenario)
        {
            scenario.Right.IsGreaterThan(scenario.Left).Should().Be(!scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(NoComparisonTestCasesData))]
        public void IsGreaterThan_ShouldReturnFalseWhenNoComparison(FloatNoComparisonScenario scenario)
        {
            scenario.Right.IsGreaterThan(scenario.Left).Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(EqualTestCasesData))]
        public void IsGreaterThan_ShouldReturnFalseForSameFloats(FloatEqualityScenario scenario)
        {
            scenario.Left.IsGreaterThan(scenario.Right).Should().BeFalse();
        }


        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsGreaterThanOrEquals_ShouldReturnTrueWhenLeftIsGreaterThanRight(FloatComparisonScenario scenario)
        {
            scenario.Left.IsGreaterThanOrEquals(scenario.Right).Should().Be(scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsGreaterThanOrEquals_ShouldReturnFalseWhenLeftIsLessThanRight(FloatComparisonScenario scenario)
        {
            scenario.Right.IsGreaterThanOrEquals(scenario.Left).Should().Be(!scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(NoComparisonTestCasesData))]
        public void IsGreaterThanOrEquals_ShouldReturnFalseWhenNoComparison(FloatNoComparisonScenario scenario)
        {
            scenario.Right.IsGreaterThanOrEquals(scenario.Left).Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(EqualTestCasesData))]
        public void IsGreaterThanOrEquals_ShouldReturnTrueForSameFloats(FloatEqualityScenario scenario)
        {
            scenario.Left.IsGreaterThanOrEquals(scenario.Right).Should().BeTrue();
        }


        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsLessThan_ShouldReturnTrueWhenLeftIsLessThanRight(FloatComparisonScenario scenario)
        {
            scenario.Left.IsLessThan(scenario.Right).Should().Be(!scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsLessThan_ShouldReturnFalseWhenLeftIsGreaterThanRight(FloatComparisonScenario scenario)
        {
            scenario.Right.IsLessThan(scenario.Left).Should().Be(scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(NoComparisonTestCasesData))]
        public void IsLessThan_ShouldReturnFalseWhenNoComparison(FloatNoComparisonScenario scenario)
        {
            scenario.Right.IsLessThan(scenario.Left).Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(EqualTestCasesData))]
        public void IsLessThan_ShouldReturnFalseForSameFloats(FloatEqualityScenario scenario)
        {
            scenario.Left.IsLessThan(scenario.Right).Should().BeFalse();
        }


        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsLessThanOrEquals_ShouldReturnTrueWhenLeftIsLessThanRight(FloatComparisonScenario scenario)
        {
            scenario.Left.IsLessThanOrEquals(scenario.Right).Should().Be(!scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(ComparisonTestCasesData))]
        public void IsLessThanOrEquals_ShouldReturnFalseWhenLeftIsGreaterThanRight(FloatComparisonScenario scenario)
        {
            scenario.Right.IsLessThanOrEquals(scenario.Left).Should().Be(scenario.LeftIsGreaterThanRight);
        }

        [Theory]
        [MemberData(nameof(NoComparisonTestCasesData))]
        public void IsLessThanOrEquals_ShouldReturnFalseWhenNoComparison(FloatNoComparisonScenario scenario)
        {
            scenario.Right.IsLessThanOrEquals(scenario.Left).Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(EqualTestCasesData))]
        public void IsLessThanOrEquals_ShouldReturnTrueForSameFloats(FloatEqualityScenario scenario)
        {
            scenario.Left.IsLessThanOrEquals(scenario.Right).Should().BeTrue();
        }
    }
}
