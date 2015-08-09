using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace CRM.ModuleSelectEntryType.ViewModel
{
	public enum ListTarget
	{
		Employers,
		Countryes
	}

	public class SelectEntryViewModel : BindableBase
	{
		private ListTarget mvSelectedType;
		private readonly DelegateCommand mvSelectClick;

		public SelectEntryViewModel()
		{
			mvSelectClick = new DelegateCommand(OnTypeSelected);

			ItemsTypes = new List<string>();

			ItemsTypes.Add(ListTarget.Countryes.ToString());
			ItemsTypes.Add(ListTarget.Employers.ToString());
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

		public List<string> ItemsTypes
		{
			get;
			set;
		}

		public DelegateCommand SelectClick
		{
			get
			{
				return mvSelectClick;
			}
		}

		private void OnTypeSelected()
		{
			throw new NotImplementedException();
		}

	}//class
}
