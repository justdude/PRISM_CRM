﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CRM.ModuleSelectEntryType.Converters
{
	//public class EnumConverter : IValueConverter
	//{
	//	public object Convert(object value, Type targetType, object parameter,
	//					 System.Globalization.CultureInfo culture)
	//	{
	//		Enum enumValue = default(Enum);
	//		if (parameter is Type)
	//		{
	//			enumValue = (Enum)Enum.Parse((Type)parameter, value.ToString());
	//		}
	//		return enumValue;
	//	}

	//	public object ConvertBack(object value, Type targetType, object parameter,
	//							  System.Globalization.CultureInfo culture)
	//	{
	//		int returnValue = 0;
	//		if (parameter is Type)
	//		{
	//			returnValue = (int)Enum.Parse((Type)parameter, value.ToString());
	//		}
	//		return returnValue;
	//	}
	//}

	public class EnumConverter : IValueConverter
	{
		#region IValueConverter Members
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (parameter.Equals(value))
				return true;

			else return false;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return parameter;
		}
		#endregion
	}
}
