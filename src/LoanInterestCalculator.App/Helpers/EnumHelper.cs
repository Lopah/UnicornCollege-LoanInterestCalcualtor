using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace LoanInterestCalculator.Helpers;

public static class EnumHelper
{
    public static string Description(this Enum value)
    {
        var attributes = value.GetType().GetField(value.ToString())!.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes.Any())
        {
            return (attributes.First() as DescriptionAttribute)!.Description;
        }

        var textInfo = CultureInfo.CurrentCulture.TextInfo;
        var test = textInfo.ToTitleCase(textInfo.ToLower(value.ToString().Replace("_", " ")));
        return test;
    }

    public static IEnumerable<(Enum Value, string Description)> GetAllValuesAndDescription(Type t)
    {
        if (!t.IsEnum)
        {
            throw new ArgumentException($"{nameof(t)} must be an enum type.");
        }

        return Enum.GetValues(t).Cast<Enum>().Select((e) => (e, e.Description()));
    }
}