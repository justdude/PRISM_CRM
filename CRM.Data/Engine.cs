using CRM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data
{
	public class Engine
	{
		public static Engine Instance { get; private set; }

		static Engine()
		{
			Instance = new Engine();
		}

		public IEnumerable<Employee> LoadEmployes()
		{
			var list = new List<Employee>();

			var reader = CDatabase.Instance.Execute(modSQL.SelectEmployes());

			Employee employee = null;
			try
			{
				while (reader.Read())
				{
					employee = new Employee();
					employee.PersonID = reader.GetString(0);
					employee.Name = reader.GetString(1);
					employee.BirthDate = reader.GetDateTime(2);
					employee.Salary = reader.GetFloat(3);
					employee.CountryID = reader.GetString(4);
					list.Add(employee);
				}
			}
			catch
			{ }

			#region can remove
			if (list.Count == 0)
			{
				for (int i = 0; i < 5; i++)
				{
					list.Add(Employee.CreateRand());
				}
			}
			#endregion

			return list;
		}

		public IEnumerable<Country> LoadCountries()
		{
			#region can remove

			string[] cc = new string[] { "Ukraine", "USA", "Canada", "German", "Spain", "Poland" };
			
			#endregion

			var list = new List<Country>();

			var reader = CDatabase.Instance.Execute(modSQL.SelectCountryes());

			Country country = null;
			try
			{
				while(reader.Read())
				{
					country = new Country();
					country.CountryID = reader.GetString(0);
					country.Name = reader.GetString(1);
					list.Add(country);
				}
			}
			catch
			{ }

			#region can remove
			if (list.Count == 0)
			{

				for (int i = 0; i < cc.Length; i++)
				{
					list.Add(new Country() { CountryID = i.ToString(), Name = cc[i] });
				}
			}
			#endregion

			return list;
		}

	}
}
