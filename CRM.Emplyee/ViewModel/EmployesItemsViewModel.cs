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

namespace CRM.ModuleEmplyee.ViewModel
{
	public class EmployesItemsViewModel : BindableBase, IDataButtons
	{
		private EmployeeViewModel mvSelectedItem;
		private readonly DelegateCommand mvAddCommand;
		private readonly DelegateCommand mvDeleteCommand;
		private readonly DelegateCommand mvSaveCommand;
		private readonly DelegateCommand mvRefreshCommand;
		private readonly DelegateCommand mvCloseCommand;
		private bool mvIsBlocked;
		private string mvName;
		private bool mvIsHasError;

		public EmployesItemsViewModel()
		{
			Employers = new ObservableCollection<EmployeeViewModel>();

			mvAddCommand = new DelegateCommand(OnAdd, CanAdd);
			mvDeleteCommand = new DelegateCommand(OnDeleteSelected, CanDelete);
			mvSaveCommand = new DelegateCommand(OnSaveSelected, CanSave);
			mvRefreshCommand = new DelegateCommand(OnRefresh, CanRefresh);
			mvCloseCommand = new DelegateCommand(OnClose);
		}

		public ObservableCollection<EmployeeViewModel> Employers { get; set; }

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
				IsEnabled = mvSelectedItem == null;

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
			return !IsEnabled && !IsChanged;
		}

		private bool CanSave()
		{
			return !IsEnabled && IsChanged && !IsHasError;
		}

		private bool CanDelete()
		{
			return !IsEnabled && !IsChanged;
		}

		private bool CanAdd()
		{
			return !IsEnabled && !IsChanged;
		}

		private void OnClose()
		{
			throw new NotImplementedException();
		}

		private void OnRefresh()
		{
			throw new NotImplementedException();
		}

		private void OnSaveSelected()
		{
			throw new NotImplementedException();
		}

		private void OnDeleteSelected()
		{
			throw new NotImplementedException();
		}

		private void OnAdd()
		{
			IsEnabled = true;

			SelectedItem = new EmployeeViewModel(Data.Employee.CreateRand());
		}

		#endregion
	}
}
