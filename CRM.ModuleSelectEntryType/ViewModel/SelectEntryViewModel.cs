using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Common.Interfaces;
using CRM.ModuleSelectEntryType.Enums;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.ServiceLocation;

namespace CRM.ModuleSelectEntryType.ViewModel
{
	public class SelectEntryViewModel : BindableBase
	{
		private ListTarget mvSelectedType;
		private readonly DelegateCommand mvSelectActionCommand;
		private readonly DelegateCommand mvExitCommand;

		public SelectEntryViewModel()
		{
			mvSelectActionCommand = new DelegateCommand(OnTypeSelected);
			mvExitCommand = new DelegateCommand(OnCloseClick);
		}

		public ListTarget SelectedType
		{
			get
			{
				return mvSelectedType;
			}
			set
			{
				if (mvSelectedType == value)
					return;

				mvSelectedType = value;

				this.OnPropertyChanged(() => this.SelectedType);
			}
		}

		public DelegateCommand SelectActionCommand
		{
			get
			{
				return mvSelectActionCommand;
			}
		}

		public DelegateCommand ExitCommand
		{
			get
			{
				return mvExitCommand;
			}
		}

		private void OnTypeSelected()
		{
			var windowsHelper = ServiceLocator.Current.GetInstance<IWindowsHelper>();

			switch (SelectedType)
			{
				case ListTarget.Employers:
					windowsHelper.ShowEmployeWindow();
					break;
				case ListTarget.Countryes:
					windowsHelper.ShowCountryWindow();
					break;
				default:
					break;
			}
		}

		private void OnCloseClick()
		{
			var windowsHelper = ServiceLocator.Current.GetInstance<IWindowsHelper>();
			windowsHelper.CloseApp();
		}

	}//class
}
