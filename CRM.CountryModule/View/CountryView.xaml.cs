﻿using System;
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
using Microsoft.Practices.Prism.PubSubEvents;

namespace CRM.CountryModule.View
{
	/// <summary>
	/// Interaction logic for CountryView.xaml
	/// </summary>
	public partial class CountryView : UserControl
	{
		private IEventAggregator cachedEventAgregator;

		public CountryView(IEventAggregator eventagg)
		{
			cachedEventAgregator = eventagg;
			InitializeComponent();
			Loaded += CountryView_Loaded;
		}

		void CountryView_Loaded(object sender, RoutedEventArgs e)
		{
			DataContext = new CRM.ModuleCountry.ViewModel.CountryItemsViewModel(cachedEventAgregator);
		}
	}
}
