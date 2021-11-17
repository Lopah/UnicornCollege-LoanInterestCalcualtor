using LoanInterestCalculator.Core.RepaymentCalendars;
using System.Collections.Generic;
using System.Linq;

namespace LoanInterestCalculator.ViewModels;

public class RepaymentCalendarViewModel
{
    private readonly RepaymentCalendar _repaymentCalendar;

    public RepaymentCalendarViewModel(RepaymentCalendar repaymentCalendar)
    {
        _repaymentCalendar = repaymentCalendar;
    }

    public IReadOnlyCollection<RepaymentRow> RepaymentRows => _repaymentCalendar.RepaymentRows().ToList();
}