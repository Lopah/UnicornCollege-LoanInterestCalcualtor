using LoanInterestCalculator.ViewModels;
using System.Windows.Controls;

namespace LoanInterestCalculator;

public partial class RepaymentCalendarControl : UserControl
{
    private readonly RepaymentCalendarViewModel _repaymentCalendarViewModel;
    public RepaymentCalendarControl()
    {

    }
    public RepaymentCalendarControl(RepaymentCalendarViewModel repaymentCalendar)
    {
        InitializeComponent();
        _repaymentCalendarViewModel = repaymentCalendar;
        DataContext = _repaymentCalendarViewModel;
    }
}