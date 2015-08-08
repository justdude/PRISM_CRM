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
			return new List<Employee>()
			{
				Employee.CreateRand(),
				Employee.CreateRand(),
				Employee.CreateRand(),
				Employee.CreateRand(),
				Employee.CreateRand(),
				Employee.CreateRand()
			};
		}

	}
}
