using CandidatApp.DB;
using CandidatApp.Services;
using CandidatApp.Services.Interfaces;
using CandidatApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CandidatApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {

        public static IServiceProvider Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            services.AddDbContext<CandidatappContext>();
            services.AddTransient<MainViewModel>(); 
            
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddTransient<CandidateViewModel>();

            services.AddScoped<IPositionService, PositionService>();
            services.AddTransient<PositionsViewModel>();

            services.AddScoped<IInterviewService, InterviewService>();
            services.AddTransient<InterviewViewModel>();

            Services = services.BuildServiceProvider();

            base.OnStartup(e);
        }
    }
}
