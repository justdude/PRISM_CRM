﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CRM.Common.Validation
{
	public class NameEmptyRule : ValidationRule
	{

		public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
		{
			string str = value as string;

			return new ValidationResult(!string.IsNullOrWhiteSpace(str), "Cannot be null");
		}
	}
}
