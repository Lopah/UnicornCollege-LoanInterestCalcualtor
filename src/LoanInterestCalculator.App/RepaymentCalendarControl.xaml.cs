using System.Collections.ObjectModel;
using LoanInterestCalculator.ViewModels;
using System.Windows.Controls;
using LoanInterestCalculator.Core.RepaymentCalendars;

namespace LoanInterestCalculator;

public partial class RepaymentCalendarControl : UserControl
{
    public RepaymentCalendarControl()
    {
        InitializeComponent();
    }

    public RepaymentCalendarControl(RepaymentCalendarViewModel repaymentCalendar) : this()
    {
        InitializeComponent();
        DataContext = repaymentCalendar;
        var collection = new ObservableCollection<RepaymentRow>(repaymentCalendar.RepaymentRows);
        RepaymentCalendarGrid.ItemsSource = collection;
    }
}