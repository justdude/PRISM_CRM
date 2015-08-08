using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;

namespace CRM.Boot
{
	public class BootStrapper : UnityBootstrapper
	{
		protected override System.Windows.DependencyObject CreateShell()
		{
			return this.Container.Resolve<MainWindow>();
		}

		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();
		}

		protected override IModuleCatalog CreateModuleCatalog()
		{
			return base.CreateModuleCatalog();

			//ModuleCatalog moduleCatalog = (ModuleCatalog)base.CreateModuleCatalog();

			//moduleCatalog.AddModule(typeof(Emplyee.EmployeeModule));
			//return moduleCatalog;
		}

		protected override void InitializeModules()
		{
			ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
			moduleCatalog.AddModule(typeof(ModuleEmplyee.EmployeeModule));
			base.InitializeModules();
		}

		protected override void InitializeShell()
		{
			base.InitializeShell();

			App.Current.MainWindow = (MainWindow)Shell;
			App.Current.MainWindow.Show();
		}
	}
}
