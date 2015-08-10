using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Events
{
	public class Token : SubscriptionToken
	{
		public Token(Action<SubscriptionToken> unsubscribeAction)
			: base(unsubscribeAction)
		{}

		public string ID { get; set; }
	}
}
