using System.Runtime.CompilerServices;

namespace ComparisonExtensions
{
    public static class DoubleFloatingComparisonExtensions
    {
        private const double DoublePrecision = 0.000000000001;

        /// <summary>
        /// Checks for equality of two numbers with a certain precision value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // ReSharper disable once InconsistentNaming
        public static bool EqualsTo(this double left, double right)
        {
            if (double.IsPositiveInfinity(left) && double.IsPositiveInfinity(right))
            {
                return true;
            }

            if (double.IsNegativeInfinity(left) && double.IsNegativeInfinity(right))
            {
                return true;
            }

            return left - right is < DoublePrecision and > -DoublePrecision;
        }

        /// <summary>
        /// Checks if the number is Zero with a certain precision value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZero(this double value)
        {
            return value is < DoublePrecision and > -DoublePrecision;
        }

        /// <summary>
        /// Checks if the number is greater than the second number with a certain precision value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGreaterThan(this double left, double right)
        {
            return left - right > DoublePrecision;
        }

        /// <summary>
        /// Checks if the number is greater than or equals to the second number with a certain precision value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGreaterThanOrEquals(this double left, double right)
        {
            if (double.IsPositiveInfinity(left) && double.IsPositiveInfinity(right))
            {
                return true;
            }

            if (double.IsNegativeInfinity(left) && double.IsNegativeInfinity(right))
            {
                return true;
            }

            return left - right > -DoublePrecision;
        }

        /// <summary>
        /// Checks if the number is less than the second number with a certain precision value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLessThan(this double left, double right)
        {
            return right - left > DoublePrecision;
        }

        /// <summary>
        /// Checks if the number is less than or equals to the second number with a certain precision value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLessThanOrEquals(this double left, double right)
        {
            if (double.IsPositiveInfinity(left) && double.IsPositiveInfinity(right))
            {
                return true;
            }

            if (double.IsNegativeInfinity(left) && double.IsNegativeInfinity(right))
            {
                return true;
            }

            return right - left > -DoublePrecision;
        }
    }
}