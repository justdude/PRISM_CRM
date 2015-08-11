using CRM.Events.Events;
using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CRM.ModuleEmplyee.View
{
	/// <summary>
	/// Логика взаимодействия для EmployeeView.xaml
	/// </summary>
	public partial class EmployeeView : UserControl
	{
		private IEventAggregator cachedEvents;
		public EmployeeView(IEventAggregator eventagg)
		{
			InitializeComponent();
			cachedEvents = eventagg;
			this.Loaded += EmployeeView_Loaded;
			this.dpBorn.SelectedDateChanged += dpBorn_SelectedDateChanged;
		}

		void EmployeeView_Loaded(object sender, RoutedEventArgs e)
		{
			cachedEvents.GetEvent<ComboChangeEvent>().Subscribe(OnSelectedItemChanged);

			//cachedEvents.GetEvent<ValidationInfoEvent>().Subscribe(OnCheckValid);

			DataContext = new ModuleEmplyee.ViewModel.EmployesItemsViewModel(cachedEvents);
		}

		private void OnSelectedItemChanged(object obj)
		{
			this.cmbCountryes.SelectedItem = obj;
		}

		void dpBorn_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			cachedEvents.GetEvent<StateChangedEvent>().Publish(DataContext);
		}

		//private void OnCheckValid(object obj)
		//{
		//	ValidationInfoEvent ev = obj as ValidationInfoEvent;
		//	if (ev == null)
		//		return;

		//	ev.IsValid = IsValid(this);
		//}

		//public static bool IsValid(DependencyObject parent)
		//{
		//	if (Validation.GetHasError(parent))
		//		return false;

		//	// Validate all the bindings on the children
		//	for (int i = 0; i != VisualTreeHelper.GetChildrenCount(parent); ++i)
		//	{
		//		DependencyObject child = VisualTreeHelper.GetChild(parent, i);
		//		if (!IsValid(child)) { return false; }
		//	}

		//	return true;
		//}

	}
}
