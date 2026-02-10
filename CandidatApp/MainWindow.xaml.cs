using CandidatApp.DB;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CandidatApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = App.Services.GetRequiredService<MainViewModel>();
        }

		private void Window_Loaded(Object sender, RoutedEventArgs e)
		{
			using (CandidatappContext db = new CandidatappContext())
			{ }
		}
		private void OpenOutlook_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start
					(new System.Diagnostics.ProcessStartInfo
					{
						FileName = "mailto:",
						UseShellExecute = true
					});
			}
			catch
			{
				MessageBox.Show("Outlook nije pronađen na ovom računaru.");
			}
		}

	}
}