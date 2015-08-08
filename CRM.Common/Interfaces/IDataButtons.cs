using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;

namespace CRM.Common.Interfaces
{
	public interface IDataButtons
	{
		DelegateCommand AddCommand { get; set; }
		DelegateCommand DeleteCommand { get; set; }
		DelegateCommand SaveCommand { get; set; }
		DelegateCommand RefreshCommand { get; set; }
		DelegateCommand CloseCommand { get; set; }
	}
}
