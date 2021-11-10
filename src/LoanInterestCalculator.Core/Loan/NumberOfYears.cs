using System;

namespace LoanInterestCalculator.Core.Loan
{
    public readonly struct NumberOfYears : IComparable<NumberOfYears>
    {
        public NumberOfYears(int value)
        {
            Value = value;
        }
        public int Value { get; }

        /// <summary>Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.</summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings:
        /// <list type="table"><listheader><term> Value</term><description> Meaning</description></listheader><item><term> Less than zero</term><description> This instance precedes <paramref name="other" /> in the sort order.</description></item><item><term> Zero</term><description> This instance occurs in the same position in the sort order as <paramref name="other" />.</description></item><item><term> Greater than zero</term><description> This instance follows <paramref name="other" /> in the sort order.</description></item></list></returns>
        /// <footer><a href="https://docs.microsoft.com/en-us/dotnet/api/System.IComparable-1.CompareTo?view=netcore-6.0">`IComparable.CompareTo` on docs.microsoft.com</a></footer>
        public int CompareTo(NumberOfYears other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}