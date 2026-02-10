using CandidatApp.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CandidatApp.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly IServiceProvider _serviceProvider;
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

    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        ShowCandidatesCommand = new RelayCommand(_ =>
            CurrentViewModel = _serviceProvider.GetRequiredService<CandidateViewModel>());

        ShowOpenPositionsCommand = new RelayCommand(_ =>
            CurrentViewModel = _serviceProvider.GetRequiredService<PositionsViewModel>());

        ShowInterviewsCommand = new RelayCommand(_ =>
            CurrentViewModel = _serviceProvider.GetRequiredService<InterviewViewModel>());
    }

    public event PropertyChangedEventHandler PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string name = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}