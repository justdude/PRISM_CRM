using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Events.Events;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.ViewModel;

namespace CRM.ModuleCountry.ViewModel
{
	public class CountryViewModel : BindableBase, IDataErrorInfo
	{
		private bool mvIsChanged;
		private string mvCountry;
		private Microsoft.Practices.Prism.PubSubEvents.IEventAggregator modEventAgregator;
		private string modContent;
		public Data.Country Current { get; private set; }

		public CountryViewModel(Data.Country current, IEventAggregator eventAgregator)
		{
			Current = current;
			this.modEventAgregator = eventAgregator;
		}

		public bool IsChanged
		{
			get
			{
				return mvIsChanged;
			}
			set
			{
				if (mvIsChanged == value)
					return;

				mvIsChanged = value;

				this.OnPropertyChanged(() => this.IsChanged);
			}
		}

		public string Name
		{
			get
			{
				return Current.Name;
			}
			set
			{
				if (Current.Name == value)
					return;

				Current.Name = value;
				IsChanged = true;

				this.OnPropertyChanged(() => this.Name);
			}
		}

		public void RaisePropertyesChanged()
		{
			this.OnPropertyChanged(() => this.Name);
			this.OnPropertyChanged(() => this.IsChanged);
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is CountryViewModel))
				return false;

			return (((CountryViewModel)obj).Current.Id == this.Current.Id);
		}

		#region Члены IDataErrorInfo

		public string Error
		{
			get { throw new NotImplementedException(); }
		}

		public string this[string columnName]
		{
			get
			{
				modContent = null;

				if (columnName == "Name")
				{
					if (string.IsNullOrWhiteSpace(Name))
					{
						modContent = "Name cannot be empty";
					}
				}

				modEventAgregator.GetEvent<ValidationInfoEvent>().Publish(this);

				return modContent;
			}
		}

		#endregion

		public bool IsHasError
		{
			get
			{
				return !string.IsNullOrWhiteSpace(modContent);
			}
		}
	}
}
