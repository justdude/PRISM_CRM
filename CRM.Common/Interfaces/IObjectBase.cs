using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Interfaces
{
	public enum Status
	{
		Added,
		Normal,
		Updated,
		Deleted
	}

	public interface IObjectBase
	{
		Status Status { get; set; }
		void Save();
	}
}
