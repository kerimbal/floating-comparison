using System.Runtime.CompilerServices;

namespace ComparisonExtensions
{
    public static class FloatingComparisonExtensions
    {
        private const double DoublePrecision = 0.000000000000001;
        private const float FloatPrecision = (float) 0.000000000000001;

        /// <summary>
        /// Checks for equality of two numbers with a certain precison value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsTo(this double left, double right)
        {
            return left - right is < DoublePrecision and > -DoublePrecision;
        }

        /// <summary>
        /// Checks if the number is Zero with a certain precison value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZero(this double value)
        {
            return value is < DoublePrecision and > -DoublePrecision;
        }

        /// <summary>
        /// Checks if the number is greater than the second number with a certain precison value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGreaterThan(this double left, double right)
        {
            return left - right > DoublePrecision;
        }

        /// <summary>
        /// Checks if the number is greater than or equals to the second number with a certain precison value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGreaterThanOrEquals(this double left, double right)
        {
            return left - right > -DoublePrecision;
        }

        /// <summary>
        /// Checks if the number is less than the second number with a certain precison value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLessThan(this double left, double right)
        {
            return right - left > DoublePrecision;
        }

        /// <summary>
        /// Checks if the number is less than or equals to the second number with a certain precison value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLessThanOrEquals(this double left, double right)
        {
            return right - left > -DoublePrecision;
        }
        
        /// <summary>
        /// Checks for equality of two numbers with a certain precison value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsTo(this float left, float right)
        {
            return left - right is < FloatPrecision and > -FloatPrecision;
        }

        /// <summary>
        /// Checks if the number is Zero with a certain precison value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZero(this float value)
        {
            return value is < FloatPrecision and > -FloatPrecision;
        }

        /// <summary>
        /// Checks if the number is greater than the second number with a certain precison value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGreaterThan(this float left, float right)
        {
            return left - right > FloatPrecision;
        }

        /// <summary>
        /// Checks if the number is greater than or equals to the second number with a certain precison value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGreaterThanOrEquals(this float left, float right)
        {
            return left - right > -FloatPrecision;
        }

        /// <summary>
        /// Checks if the number is less than the second number with a certain precison value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLessThan(this float left, float right)
        {
            return right - left > FloatPrecision;
        }

        /// <summary>
        /// Checks if the number is less than or equals to the second number with a certain precison value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLessThanOrEquals(this float left, float right)
        {
            return right - left > -FloatPrecision;
        }
    }
}