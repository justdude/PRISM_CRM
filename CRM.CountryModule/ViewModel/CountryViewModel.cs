using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.ViewModel;

namespace CRM.ModuleCountry.ViewModel
{
	public class CountryViewModel : BindableBase
	{
		private bool mvIsChanged;
		private string mvCountry;
		public Data.Country Current { get; private set; }

		public CountryViewModel(Data.Country current)
		{
			Current = current;
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
	}
}
