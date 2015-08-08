using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace CRM.ModuleEmplyee
{
	public class EmployeeModule : IModule
	{
		private const string ModuleName = "EmployeeModule";

		private IRegionManager modRegionManager;

		public EmployeeModule(IRegionManager regionManager)
		{
			modRegionManager = regionManager;
		}

		#region Члены IModule

		public void Initialize()
		{
			modRegionManager.Regions[ModuleName].Add(new View.EmployeeView());
			//_regionManager.Regions["RoleSelection"].Add(new ModuleRoleSelection.View.RoleSelectionView(eventagg));
		}

		#endregion
	}
}
