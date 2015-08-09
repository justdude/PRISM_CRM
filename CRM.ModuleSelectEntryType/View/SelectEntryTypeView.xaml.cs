using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CRM.ModuleSelectEntryType.ViewModel;

namespace CRM.ModuleSelectEntryType.View
{
	/// <summary>
	/// Логика взаимодействия для SelectEntryTypeView.xaml
	/// </summary>
	public partial class SelectEntryTypeView : UserControl
	{
		public SelectEntryTypeView()
		{
			InitializeComponent();
			this.Loaded += SelectEntryTypeView_Loaded;
		}

		void SelectEntryTypeView_Loaded(object sender, RoutedEventArgs e)
		{
			DataContext = new SelectEntryViewModel();
		}
	}
}
