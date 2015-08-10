using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CRM.Common.Validation
{
	public class DateRule : ValidationRule
	{
		private static DateTime CurrentDate = new DateTime(1985, 1, 1);

		public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
		{
			DateTime orderDate = (DateTime)value;

			if (orderDate < DateTime.Now)
				return new ValidationResult(false, "Please, enter date before Now()");

			return new ValidationResult(orderDate < CurrentDate, "No less than 01/01/1985");
		}
	}
}
