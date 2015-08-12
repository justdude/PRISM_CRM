using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Common.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.ViewModel;
using CRM.Events;
using CRM.Data;
using Microsoft.Practices.Prism.PubSubEvents;
using CRM.ModuleCountry.ViewModel;
using CRM.Events.Events;

namespace CRM.ModuleEmplyee.ViewModel
{
	public class EmployesItemsViewModel : BindableBase, IDataButtons
	{
		private readonly IEventAggregator eventAggregator;

		private EmployeeViewModel mvSelectedItem;
		private CountryViewModel mvSelectedCountry;

		private readonly DelegateCommand mvAddCommand;
		private readonly DelegateCommand mvDeleteCommand;
		private readonly DelegateCommand mvSaveCommand;
		private readonly DelegateCommand mvRefreshCommand;
		private readonly DelegateCommand mvCloseCommand;
		private bool mvIsBlocked;
		private bool mvIsHasError;

		public EmployesItemsViewModel(IEventAggregator eventAgg)
		{
			eventAggregator = eventAgg;
			Employers = new ObservableCollection<EmployeeViewModel>();

			mvAddCommand = new DelegateCommand(OnAdd, CanAdd);
			mvDeleteCommand = new DelegateCommand(OnDeleteSelected, CanDelete);
			mvSaveCommand = new DelegateCommand(OnSaveSelected, CanSave);
			mvRefreshCommand = new DelegateCommand(OnRefresh, CanRefresh);
			mvCloseCommand = new DelegateCommand(OnClose);
			eventAggregator.GetEvent<StateChangedEvent>().Subscribe(OnDataChanged);
			eventAggregator.GetEvent<ItemChangedEvent>().Subscribe(OnSelectedChanged, ThreadOption.PublisherThread, true, Filter);
			LoadData();
		}

		public ObservableCollection<EmployeeViewModel> Employers { get; set; }
		public ObservableCollection<CountryViewModel> Countries { get; set; }

		public CountryViewModel SelectedCountry
		{
			get
			{
				return mvSelectedCountry;
			}
			set
			{
				if (mvSelectedCountry == value)
					return;

				mvSelectedCountry = value;

				this.OnPropertyChanged(() => this.SelectedCountry);
			}
		}

		public EmployeeViewModel SelectedItem
		{
			get
			{
				return mvSelectedItem;
			}
			set
			{
				if (mvSelectedItem == value)
					return;

				mvSelectedItem = value;

				RaiseRefresh();
				LoadCountry(mvSelectedItem);

				this.OnPropertyChanged(() => this.SelectedItem);
			}
		}

		public string SelectedItemName
		{
			get
			{
				if (IsSelected == false)
					return string.Empty;

				return SelectedItem.Name;
			}
			set
			{
				if (!IsSelected || SelectedItem.Name == value)
					return;

				SelectedItem.Name = value;

				RaiseRefresh();

				this.OnPropertyChanged(() => this.SelectedItemName);
			}
		}

		public bool IsEnabled
		{
			get
			{
				return mvIsBlocked;
			}
			set
			{
				if (mvIsBlocked == value)
					return;

				mvIsBlocked = value;

				this.OnPropertyChanged(() => this.IsEnabled);
			}
		}

		public bool IsChanged
		{
			get
			{
				return SelectedItem != null && SelectedItem.IsChanged;
			}
		}

		public bool IsHasError
		{
			get
			{
				return mvIsHasError;
			}
			set
			{
				if (mvIsHasError == value)
					return;

				mvIsHasError = value;

				RefreshCommands();

				this.OnPropertyChanged(() => this.IsHasError);
			}
		}

		public bool IsSelected
		{
			get
			{
				return SelectedItem != null && SelectedItem.Current != null;
			}
		}

		private void RaisePropertyesChanged()
		{
			if (IsSelected)
				SelectedItem.RaisePropertyesChanged();

			this.OnPropertyChanged(() => this.IsHasError);
			this.OnPropertyChanged(() => this.IsSelected);
			this.OnPropertyChanged(() => this.IsEnabled);
		}

		#region Члены IDataButtons

		public DelegateCommand AddCommand
		{
			get
			{
				return mvAddCommand;
			}
		}

		public DelegateCommand DeleteCommand
		{
			get
			{
				return mvDeleteCommand;
			}
		}

		public DelegateCommand SaveCommand
		{
			get
			{
				return mvSaveCommand;
			}
		}

		public DelegateCommand RefreshCommand
		{
			get
			{
				return mvRefreshCommand;
			}
		}

		public DelegateCommand CloseCommand
		{
			get
			{
				return mvCloseCommand;
			}
		}

		#endregion

		#region Methods

		private void LoadData()
		{
			IsEnabled = false;

			if (Countries == null)
			{
				Countries = new ObservableCollection<CountryViewModel>();
			}
			if (Employers == null)
			{
				Employers = new ObservableCollection<EmployeeViewModel>();
			}

			Employers.Clear();
			Countries.Clear();

			var countries = Engine.Instance.LoadCountries().Select(p => new CountryViewModel(p, eventAggregator));
			var employers = Engine.Instance.LoadEmployes().Select(p => new EmployeeViewModel(p, eventAggregator));

			foreach (var item in countries)
			{
				Countries.Add(item);
			}

			foreach (var item in employers)
			{
				Employers.Add(item);
			}

			IsEnabled = true;
		}

		private void LoadCountry(EmployeeViewModel target)
		{
			if (target == null)
			{
				SelectedCountry = null;
				return;
			}
			else
			{
				var country = Countries.FirstOrDefault(p => p.Current.Id == target.Current.CountryID);
				if (country != null)
				{
					SelectedCountry = country;
					eventAggregator.GetEvent<ComboChangeEvent>().Publish(SelectedCountry);
				}
			}

		}

		private void OnDataChanged(object obj)
		{
			//EmployesItemsViewModel vm = obj as EmployesItemsViewModel;
			//if (vm != null && vm == this)
			//{
			//	this.OnPropertyChanged(() => IsHasError);
			//	RefreshCommands();
			//}
		}

		private void OnSelectedChanged(object obj)
		{
			RefreshCommands();
		}

		private bool Filter(object obj)
		{
			EmployeeViewModel empl = obj as EmployeeViewModel;
			return empl != null && Employers.Contains(empl);
		}

		private void RefreshCommands()
		{
			RefreshCommand.RaiseCanExecuteChanged();
			SaveCommand.RaiseCanExecuteChanged();
			DeleteCommand.RaiseCanExecuteChanged();
			AddCommand.RaiseCanExecuteChanged();
			CloseCommand.RaiseCanExecuteChanged();
		}

		private bool CanRefresh()
		{
			return IsEnabled;
		}

		private bool CanSave()
		{
			return IsEnabled && !IsHasError && IsSelected;
		}

		private bool CanDelete()
		{
			return IsEnabled && IsSelected;
		}

		private bool CanAdd()
		{
			return IsEnabled;
		}

		private void OnClose()
		{
			var mess = CEventSystem.Current.GetEvent<Events.CloseWindowEvent>();
		}

		public void OnStateChanged()
		{
			RaiseRefresh();
		}

		private void OnRefresh()
		{
			SelectedItem = null;
			RaiseRefresh();

			LoadData();

			RaiseRefresh();
		}

		private void RaiseRefresh()
		{
			RaisePropertyesChanged();
			RefreshCommands();
		}

		private void OnSaveSelected()
		{
			if (SelectedItem.Current.Status == Status.Normal)
			{
				SelectedItem.Current.Status = Status.Updated;
			}

			SelectedItem.Current.CountryID = SelectedCountry.Current.Id;
			SelectedItem.Current.Save();
			SelectedItem = null;

			RaiseRefresh();
		}

		private void OnDeleteSelected()
		{
			SelectedItem.Current.Status = Status.Deleted;
			SelectedItem.Current.Save();

			this.Employers.Remove(SelectedItem);
			SelectedItem = null;

			RaiseRefresh();
		}

		private void OnAdd()
		{
			SelectedItem = new EmployeeViewModel(new Data.Employee(), eventAggregator);

			SelectedItem.Current.Status = Status.Added;

			this.Employers.Add(SelectedItem);

			RaiseRefresh();
		}

		#endregion

	}
}
