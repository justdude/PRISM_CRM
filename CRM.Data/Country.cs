using CRM.Common.Interfaces;
using CRM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data
{
	public class Country : IObjectBase
	{
		public string Id { get; set; }
		public string Name { get; set; }

		public Status Status
		{
			get;
			set;
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
						res = AddCountry(this);
						break;
					case Status.Normal:
						break;
					case Status.Updated:
						res = UpdateCountry(this);
						break;
					case Status.Deleted:
						res = DeleteCountry(Id);
						break;
					default:
						break;
				}
			}
			catch (Exception ex)
			{
				res = false;
			}

			return res;
		}

		private bool AddCountry(Country country)
		{
			string str = modSQL.InsertCountry(country);
			return CDatabase.Instance.ExecuteNonQuery(str);
		}

		private bool UpdateCountry(Country country)
		{
			string str = modSQL.UpdateCountry(country);
			return CDatabase.Instance.ExecuteNonQuery(str);
		}

		private bool DeleteCountry(string id)
		{
			string str = modSQL.DeleteCountry(id);
			return CDatabase.Instance.ExecuteNonQuery(str);
		}
	}
}
