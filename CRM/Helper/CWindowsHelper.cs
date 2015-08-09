using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Common.Interfaces;
using CRM.View;

namespace CRM.Helper
{
	public class CWindowsHelper : IWindowsHelper
	{

		#region Члены IWindowsHelper

		public void ShowEmployeWindow()
		{
			EmployeeShell wind = new EmployeeShell();
			wind.Owner = App.Current.MainWindow;
			wind.Owner.Hide();
			wind.ShowDialog();
			wind.Owner.Show();
		}

		public void ShowCountryWindow()
		{
			throw new NotImplementedException();
		}

		public void CloseApp()
		{
			App.Current.Shutdown();
		}

		#endregion
	}
}
