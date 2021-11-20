using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LoanInterestCalculator.Core.RepaymentCalendars;

namespace LoanInterestCalculator.Helpers;

/// <summary>
/// This should ideally be in infrastructure, but oh well.
/// </summary>
public static class EnumerableToCsvHelper
{
    private static string GetFormattedLine<T>(T type)
    {
        var sb = new StringBuilder();
        foreach (var propertyInfo in type!.GetType().GetProperties())
        {
            sb.Append(propertyInfo.GetValue(type));
            sb.Append(',');
        }

        sb.Append('\n');
        return sb.ToString();
    }
    public static async Task GenerateCsv(IEnumerable<RepaymentRow> repaymentRows, Stream stream)
    {
        await using var write = new StreamWriter(stream);
        foreach (var repaymentRow in repaymentRows)
        {
            var line = GetFormattedLine(repaymentRow);
            await write.WriteLineAsync(line);
        }

        await write.FlushAsync();
        await stream.FlushAsync();
    }
}