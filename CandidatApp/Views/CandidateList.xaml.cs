using CandidatApp.DB;
using CandidatApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
			DataContext = new CandidateViewModel();
		}
	}
}
