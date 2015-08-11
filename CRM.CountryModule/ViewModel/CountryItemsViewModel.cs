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

namespace CRM.ModuleEmplyee.ViewModel
{
	public class EmployesItemsViewModel : BindableBase, IDataButtons
	{
		private CountryViewModel mvSelectedItem;
		private readonly DelegateCommand mvAddCommand;
		private readonly DelegateCommand mvDeleteCommand;
		private readonly DelegateCommand mvSaveCommand;
		private readonly DelegateCommand mvRefreshCommand;
		private readonly DelegateCommand mvCloseCommand;
		private bool mvIsBlocked;
		private bool mvIsHasError;

		public EmployesItemsViewModel()
		{
			Employers = new ObservableCollection<CountryViewModel>();

			mvAddCommand = new DelegateCommand(OnAdd, CanAdd);
			mvDeleteCommand = new DelegateCommand(OnDeleteSelected, CanDelete);
			mvSaveCommand = new DelegateCommand(OnSaveSelected, CanSave);
			mvRefreshCommand = new DelegateCommand(OnRefresh, CanRefresh);
			mvCloseCommand = new DelegateCommand(OnClose);

			LoadData();
		}

		private void LoadData()
		{
			IsEnabled = false;

			if (Countries == null)
			{
				Countries = new ObservableCollection<Country>();
			}
			if (Employers == null)
			{
				Employers = new ObservableCollection<EmployeeViewModel>();
			}
			
			Employers.Clear();
			Countries.Clear();

			var countries = new ObservableCollection<Data.Country>(CRM.Data.Engine.Instance.LoadCountries());
			var employers = Engine.Instance.LoadEmployes().Select(p => new EmployeeViewModel(p));

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

		public ObservableCollection<EmployeeViewModel> Employers { get; set; }
		public ObservableCollection<Data.Country> Countries { get; set; }

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
				//IsEnabled = mvSelectedItem == null;

				RaiseRefresh();

				this.OnPropertyChanged(() => this.SelectedItem);
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
			SelectedItem = new EmployeeViewModel(new Data.Employee());

			SelectedItem.Current.Status = Status.Added;

			this.Employers.Add(SelectedItem);

			RaiseRefresh();
		}

		#endregion

	}
}
