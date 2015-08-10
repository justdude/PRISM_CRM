using CRM.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data
{
	public class Country : IObjectBase
	{
		public string CountryID { get; set; }
		public string Name { get; set; }

		public Status Status
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public void Save()
		{
			throw new NotImplementedException();
		}
	}
}
