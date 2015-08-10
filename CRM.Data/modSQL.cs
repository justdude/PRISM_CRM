using CRM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Database
{
	public static class modSQL
	{
		#region Country

		public static string SelectCountryes()
		{
			return @"select * from Countryes";
		}

		public static string InsertCountry(Country c)
		{
			string query = @"INSERT INTO Countryes(Id,CountryName) VALUES('{0}', '{1}');";
			return string.Format(query, c.CountryID, c.Name);
		}

		public static string UpdateCountry(Country c)
		{
			string query = @"UPDATE Countryes SET City='{0}' WHERE Id='{1}';";
			return string.Format(query, c.Name, c.CountryID);
		}

		public static string DeleteCountry(string id)
		{
			string query = string.Format(@"DELETE from Countryes WHERE Id='{0}';", id);
			return query;
		}

		#endregion

		#region Employe

		public static string SelectEmployes()
		{
			return @"select * from Employes";
		}

		public static string InsertCountry(Employee empl)
		{
			string query = @"INSERT INTO Employes(Id,EmployeName,BirthDate,Salary,CountryID) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');";
			return string.Format(query, empl.PersonID, empl.Name, empl.BirthDate, empl.Salary, empl.CountryID);
		}

		public static string UpdateCountry(Employee empl)
		{
			string query = @"UPDATE Employes SET City='{0}' WHERE Id='{1}';";
			return string.Format(query, c.Name, c.CountryID);
		}

		public static string DeleteCountry(string id)
		{
			string query = string.Format(@"DELETE from Employes WHERE Id='{0}';", id);
			return query;
		}

		#endregion

	}
}
