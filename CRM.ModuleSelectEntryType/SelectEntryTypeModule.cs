using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace CRM.ModuleSelectEntryType
{
	public class ModuleSelectEntryType: IModule
	{
		private const string ModuleName = "SelectEntryType";

		private IRegionManager modRegionManager;

		public ModuleSelectEntryType(IRegionManager regionManager)
		{
			modRegionManager = regionManager;
		}

		#region Члены IModule

		public void Initialize()
		{
			//this.modRegionManager.RegisterViewWithRegion(ModuleName, typeof(View.SelectEntryTypeView));
			modRegionManager.Regions[ModuleName].Add(new View.SelectEntryTypeView());
		}

		#endregion
	}
}
