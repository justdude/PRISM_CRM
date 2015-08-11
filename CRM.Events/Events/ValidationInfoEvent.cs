using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Events.Events
{
	public class ValidationInfoEvent : MessageBase
	{
		public bool IsValid { get; set; }
	}
}
