using System;
using Prism.Commands;
using Prism.Mvvm;
using xrm.Parsing;

namespace xrm.Views
{
	public class ParsingViewModel : BindableBase
	{
		private readonly IParsing _parsing;
		private ParsingState _state;
		private ulong _count;


		public ParsingViewModel(IParsing parsing)
		{
			_parsing = parsing;
			Start = new DelegateCommand(StartParsing, CanStartParsing);
			Pause = new DelegateCommand(PauseParsing, CanPauseParsing);
			Stop = new DelegateCommand(StopParsing, CanStopParsing);
			State = ParsingState.Stopped;

			_parsing.DownloadedEvent += _parsing_DownloadedEvent;
			_parsing.OnCompleDownloadedEvent += (sender, args) => 
			{
				StopParsing();
				OnCompleDownloadedEvent?.Invoke(sender, args);
			};
		}

		public event EventHandler CollectionUpdateEvent;
		public event EventHandler OnCompleDownloadedEvent;

		private void _parsing_DownloadedEvent( object sender, DownloadedEventArgs e )
		{
			Count = e.Count;
		}

		public DelegateCommand Stop { get; set; }

		public DelegateCommand Pause { get; set; }

		public DelegateCommand Start { get; set; }

		public ParsingState State
		{
			get { return _state; }
			set
			{
				_state = value;
				RaisePropertyChanged();
				Start.RaiseCanExecuteChanged();
				Stop.RaiseCanExecuteChanged();
				Pause.RaiseCanExecuteChanged();
			}
		}

		public ulong Count
		{
			get { return _count; }
			set
			{
				_count = value;
				RaisePropertyChanged();
			}
		}

		private void StartParsing()
		{
			switch (State)
			{
				case ParsingState.Paused:
					State = ParsingState.Running;
					_parsing.PauseResume();
					break;
				case ParsingState.Stopped:
					State = ParsingState.Running;
					_parsing.Start();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private bool CanStartParsing()
		{
			return State==ParsingState.Stopped || State==ParsingState.Paused;
		}

		private void StopParsing()
		{
			State = ParsingState.Stopped;
			_parsing.Stop();
			CollectionUpdateEvent?.Invoke( this, new EventArgs() );
		}

		private bool CanStopParsing()
		{
			return State==ParsingState.Running || State==ParsingState.Paused;
		}

		private void PauseParsing()
		{
			State=ParsingState.Paused;
			_parsing.PauseResume();
			CollectionUpdateEvent?.Invoke(this,new EventArgs());
		}

		private bool CanPauseParsing()
		{
			return State==ParsingState.Running;
		}

	}

	public enum ParsingState
	{
		Running,
		Paused,
		Stopped
	}
}