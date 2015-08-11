using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace CRM.ModuleEmplyee
{
	public class CountryModule : IModule
	{
		private const string ModuleName = "CountryModule";

		private IRegionManager modRegionManager;

		public CountryModule(IRegionManager regionManager)
		{
			modRegionManager = regionManager;
		}

		#region Члены IModule

		public void Initialize()
		{
			this.modRegionManager.RegisterViewWithRegion(ModuleName, typeof(View.EmployeeView));
			//_regionManager.Regions["RoleSelection"].Add(new ModuleRoleSelection.View.RoleSelectionView(eventagg));
		}

		#endregion
	}
}
