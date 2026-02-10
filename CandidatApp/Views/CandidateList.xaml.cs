using CandidatApp.DB;
using CandidatApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace CandidatApp.Views
{
    /// <summary>
    /// Interaction logic for CandidateList.xaml
    /// </summary>
    public partial class CandidateList : UserControl
    {
        public CandidateList()
        {
            InitializeComponent();
            DataContext = App.Services.GetRequiredService<CandidateViewModel>();
        }
    }
}
