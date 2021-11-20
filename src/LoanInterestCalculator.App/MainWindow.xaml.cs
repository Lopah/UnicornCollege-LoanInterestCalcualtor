using System.Windows;
using LoanInterestCalculator.Core.RepaymentCalendars;
using LoanInterestCalculator.ViewModels;

namespace LoanInterestCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(LoanCalculatorViewModel loanCalculatorViewModel)
        {
            InitializeComponent();
            DataContext = loanCalculatorViewModel;
        }
    }
}