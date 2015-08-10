using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Common.Interfaces;
using CRM.Database;

namespace CRM.Data
{
	public class Employee : IObjectBase
	{
		public string Id { get; set; }
		public string CountryID { get; set; }
		public string Name { get; set; }
		public DateTime BirthDate { get; set; }
		public float Salary { get; set; }

		public Employee()
		{
			BirthDate = DateTime.Now;
		}

		public static Employee CreateRand()
		{
			Random r = new Random();
			Employee empl = new Employee();
			empl.Id = Generator.GenerateID();
			empl.BirthDate = DateTime.Now;
			empl.Salary = (float)(r.NextDouble() * 100.0);
			empl.Name = "Employee " + empl.Id;

			return empl;
		}


		public bool Save()
		{
			bool res = true;

			try
			{

				switch (Status)
				{
					case Status.Added:
						this.Id = Generator.GenerateID();
						res = AddEmploye(this);
						break;
					case Status.Normal:
						break;
					case Status.Updated:
						res = UpdateEmploye(this);
						break;
					case Status.Deleted:
						res = DeleteEmploye(this);
						break;
					default:
						break;
				}
			}
			catch(Exception ex)
			{
				res = false;
			}

			return res;
		}

		private bool AddEmploye(Employee employee)
		{
			string str = modSQL.InsertEmployes(this);
			return CDatabase.Instance.ExecuteNonQuery(str);
		}

		private bool UpdateEmploye(Employee employee)
		{
			string str = modSQL.UpdateEmployes(this);
			return CDatabase.Instance.ExecuteNonQuery(str);
		}

		private bool DeleteEmploye(Employee employee)
		{
			string str = modSQL.DeleteEmployes(Id);
			return CDatabase.Instance.ExecuteNonQuery(str);
		}

		public Status Status
		{
			get;
			set;
		}
	}
}
