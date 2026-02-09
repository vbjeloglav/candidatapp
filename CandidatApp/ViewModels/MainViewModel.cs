using CandidatApp.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CandidatApp.ViewModels.Commands;

public class MainViewModel : INotifyPropertyChanged
{
	private object _currentViewModel;
	public object CurrentViewModel
	{
		get => _currentViewModel;
		set
		{
			_currentViewModel = value;
			OnPropertyChanged();
		}
	}

	public ICommand ShowCandidatesCommand { get; }
	public ICommand ShowOpenPositionsCommand { get; }
	public ICommand ShowInterviewsCommand { get; }

	public MainViewModel()
	{
		ShowCandidatesCommand = new RelayCommand(o => CurrentViewModel = new CandidateViewModel());
		ShowOpenPositionsCommand = new RelayCommand(o => CurrentViewModel = new PositionsViewModel());
		ShowInterviewsCommand = new RelayCommand(o => CurrentViewModel = new InterviewViewModel());
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string name = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}