using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using LoanInterestCalculator.Helpers;

namespace LoanInterestCalculator.Converters;
[ValueConversion(typeof(Enum), typeof(IEnumerable<(Enum Value, string Description)>))]
public class EnumToDescriptionConverter : MarkupExtension, IValueConverter
{
    public override object ProvideValue(IServiceProvider serviceProvider) => this;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
    EnumHelper.GetAllValuesAndDescription(value.GetType());

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
}