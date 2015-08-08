using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace CRM.ModuleSelectEntryType
{
	public class SelectEntryTypeModule : IModule
	{
		private const string ModuleName = "SelectEntryType";

		private IRegionManager modRegionManager;

		public SelectEntryTypeModule(IRegionManager regionManager)
		{
			modRegionManager = regionManager;
		}

		#region Члены IModule

		public void Initialize()
		{
			modRegionManager.Regions[ModuleName].Add(new View.SelectEntryTypeView());
		}

		#endregion
	}
}
