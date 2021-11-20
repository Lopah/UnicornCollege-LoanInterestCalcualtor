using System.Windows;
using LoanInterestCalculator.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LoanInterestCalculator;

public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<LoanCalculatorViewModel>();
        services.AddSingleton((provider) =>
            new RepaymentCalendarViewModel(new(provider.GetRequiredService<LoanCalculatorViewModel>().Loan)));
        services.AddSingleton<MainWindow>();
        services.AddSingleton<RepaymentCalendarControl>();
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}