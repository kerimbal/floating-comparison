﻿using System.Runtime.CompilerServices;

namespace ComparisonExtensions
{
    public static class FloatFloatingComparisonExtensions
    {
        private const float FloatPrecision = (float) 0.0000001;
                
        /// <summary>
        /// Checks for equality of two numbers with a certain precision value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // ReSharper disable once InconsistentNaming
        public static bool EqualsTo(this float left, float right)
        {
            if (float.IsPositiveInfinity(left) && float.IsPositiveInfinity(right))
            {
                return true;
            }

            if (float.IsNegativeInfinity(left) && float.IsNegativeInfinity(right))
            {
                return true;
            }

            return left - right is < FloatPrecision and > -FloatPrecision;
        }

        /// <summary>
        /// Checks if the number is Zero with a certain precision value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZero(this float value)
        {
            return value is < FloatPrecision and > -FloatPrecision;
        }

        /// <summary>
        /// Checks if the number is greater than the second number with a certain precision value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGreaterThan(this float left, float right)
        {
            return left - right > FloatPrecision;
        }

        /// <summary>
        /// Checks if the number is greater than or equals to the second number with a certain precision value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGreaterThanOrEquals(this float left, float right)
        {
            if (float.IsPositiveInfinity(left) && float.IsPositiveInfinity(right))
            {
                return true;
            }

            if (float.IsNegativeInfinity(left) && float.IsNegativeInfinity(right))
            {
                return true;
            }

            return left - right > -FloatPrecision;
        }

        /// <summary>
        /// Checks if the number is less than the second number with a certain precision value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLessThan(this float left, float right)
        {
            return right - left > FloatPrecision;
        }

        /// <summary>
        /// Checks if the number is less than or equals to the second number with a certain precision value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLessThanOrEquals(this float left, float right)
        {
            if (float.IsPositiveInfinity(left) && float.IsPositiveInfinity(right))
            {
                return true;
            }

            if (float.IsNegativeInfinity(left) && float.IsNegativeInfinity(right))
            {
                return true;
            }

            return right - left > -FloatPrecision;
        }
    }
}