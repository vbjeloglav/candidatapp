using CandidatApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace CandidatApp.Views
{
	/// <summary>
	/// Interaction logic for OpenPositionList.xaml
	/// </summary>
	public partial class PositionList : UserControl
	{
		public PositionList()
		{
			InitializeComponent();
			DataContext = App.Services.GetRequiredService<PositionsViewModel>();
		}
	}
}
