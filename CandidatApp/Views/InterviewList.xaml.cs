using CandidatApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace CandidatApp.Views
{
	/// <summary>
	/// Interaction logic for InterviewList.xaml
	/// </summary>
	public partial class InterviewList : UserControl
	{
		public InterviewList()
		{
			InitializeComponent();
			DataContext = App.Services.GetRequiredService<InterviewViewModel>();
        }
	}
}