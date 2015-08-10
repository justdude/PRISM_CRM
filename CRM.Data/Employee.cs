using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Common.Interfaces;

namespace CRM.Data
{
	public class Employee : IObjectBase
	{
		public string PersonID { get; set; }
		public string CountryID { get; set; }
		public string Name { get; set; }
		public DateTime BirthDate { get; set; }
		public float Salary { get; set; }

		public static Employee CreateRand()
		{
			Random r = new Random();
			Employee empl = new Employee();
			empl.BirthDate = DateTime.Now;
			empl.Salary = (float)(r.NextDouble() * 100.0);
			empl.Name = "Employee " + DateTime.Now.Millisecond;

			return empl;
		}


		public void Save()
		{
			
		}

		public Status Status
		{
			get;
			set;
		}
	}
}
