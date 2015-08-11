using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.ViewModel;
using CRM.Events.Events;
using Microsoft.Practices.Prism.PubSubEvents;
using System.ComponentModel;

namespace CRM.ModuleEmplyee.ViewModel
{
	public class EmployeeViewModel : BindableBase, IDataErrorInfo
	{
		private bool mvIsChanged;
		private string mvCountry;
		private IEventAggregator modEventAgrgator;
		public Data.Employee Current { get; private set; }

		public EmployeeViewModel(Data.Employee current, IEventAggregator eventAgrgator)
		{
			Current = current;
			modEventAgrgator = eventAgrgator;
		}

		//public string Country
		//{
		//	get
		//	{
		//		return mvCountry;
		//	}
		//	set
		//	{
		//		if (mvCountry == value)
		//			return;

		//		mvCountry = value;

		//		this.OnPropertyChanged(() => this.Country);
		//	}
		//}

		public bool IsChanged
		{
			get
			{
				return mvIsChanged;
			}
			set
			{
				modEventAgrgator.GetEvent<ItemChangedEvent>().Publish(this);
				//modEventAgrgator.GetEvent<ValidationInfoEvent>().Publish(new ValidationInfoEvent(OnStateChange));
				//if (mvIsChanged == value)
				//	return;

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

				Current.Salary = value;
				IsChanged = true;

				this.OnPropertyChanged(() => this.Salary);
			}
		}

		public void RaisePropertyesChanged()
		{
			this.OnPropertyChanged(() => this.Name);
			this.OnPropertyChanged(() => this.IsChanged);
			this.OnPropertyChanged(() => this.BirthDate);
			this.OnPropertyChanged(() => this.Salary);
		}
		#region Errors

		public string Error
		{
			get { throw new NotImplementedException(); }
		}

		public string this[string columnName]
		{
			get 
			{
				string error = null;

 				if (columnName == "Name")
				{
					if (string.IsNullOrWhiteSpace(Name) || Name.Length <= 10)
						return "Must be more than 10 symbols";
				}

				if (columnName == "BirthDate")
				{
					if (CRM.Common.Validation.DateRule.IsValid(BirthDate, out error))
					{

					}
				}

				return error;
			}
		}

		#endregion
	}
}
