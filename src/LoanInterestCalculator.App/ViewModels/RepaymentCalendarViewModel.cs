using LoanInterestCalculator.Core.RepaymentCalendars;
using System.Collections.Generic;

namespace LoanInterestCalculator.ViewModels;

public class RepaymentCalendarViewModel
{
    private RepaymentCalendar _repaymentCalendar;

    public RepaymentCalendarViewModel(RepaymentCalendar repaymentCalendar)
    {
        _repaymentCalendar = repaymentCalendar;
    }

    public IReadOnlyCollection<RepaymentRow> RepaymentRows { get; set; }
}