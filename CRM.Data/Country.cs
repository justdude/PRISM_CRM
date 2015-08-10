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
		public string Id { get; set; }
		public string Name { get; set; }

		public Status Status
		{
			get;
			set;
		}

		public bool Save()
		{
			return true;
		}
	}
}
