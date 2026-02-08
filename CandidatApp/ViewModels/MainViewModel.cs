using CandidatApp.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

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

	public class RelayCommand : ICommand
	{
		private readonly Action<object> _execute;
		private readonly Func<object, bool> _canExecute;

		public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			_execute(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
	}
}