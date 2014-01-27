using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServices
{
	public class ConfigurationHelper
	{
		const string SettingsHttpcontextkey = "HTTPCONTEXTKEY";
	
		public static string HttpContextKey { get { return ConfigurationManager.AppSettings[SettingsHttpcontextkey]; } }
		
	}
}
