using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.ViewModel;

namespace CRM.ModuleEmplyee.ViewModel
{
	public class CountryViewModel : BindableBase
	{
		private bool mvIsChanged;
		private string mvCountry;
		public Data.Employee Current { get; private set; }

		public CountryViewModel(Data.Employee current)
		{
			Current = current;
			Country = "Ukraine";
		}

		public string Country
		{
			get
			{
				return mvCountry;
			}
			set
			{
				if (mvCountry == value)
					return;

				mvCountry = value;

				this.OnPropertyChanged(() => this.Country);
			}
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

		public DateTime BirthDate
		{
			get
			{
				return Current.BirthDate;
			}
			set
			{
				if (Current.BirthDate == value)
					return;

				Current.BirthDate = value;
				IsChanged = true;

				this.OnPropertyChanged(() => this.BirthDate);
			}
		}

		public float Salary
		{
			get
			{
				return Current.Salary;
			}
			set
			{
				if (Current.Salary == value)
					return;

				Current.Salary = value;
				IsChanged = true;

				this.OnPropertyChanged(() => this.Salary);
			}
		}

		public void RaisePropertyesChanged()
		{
			this.OnPropertyChanged(() => this.Country);
			this.OnPropertyChanged(() => this.Name);
			this.OnPropertyChanged(() => this.IsChanged);
			this.OnPropertyChanged(() => this.BirthDate);
			this.OnPropertyChanged(() => this.Salary);
		}
	}
}
