using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopHelpers
{
	public class ConectionStringHelper
	{
		const string SettingsConnectionString = "ConnectionString";

		public static string ConnectionString { 
			get
			{
				return ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings[SettingsConnectionString]].ToString();
			} 
		}

	}
}
