using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CRM.Common.Validation
{
	public class FloatRule : ValidationRule
	{
		public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
		{
			bool res = false;
			float parsedData = 0;

			res = float.TryParse(value as string, out parsedData);

			return new ValidationResult(res, "You can input only float numbers");
		}
	}
}
