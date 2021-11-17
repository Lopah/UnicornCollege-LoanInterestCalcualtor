﻿using System.Windows;
using LoanInterestCalculator.ViewModels;

namespace LoanInterestCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LoanCalculatorViewModel _loanCalculatorViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _loanCalculatorViewModel = new();
            DataContext = _loanCalculatorViewModel;
        }
    }
}