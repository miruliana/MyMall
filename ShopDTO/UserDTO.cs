using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDTO
{
	public class UserDTO : HashValuesDTO
	{
		public string Password { get; set; }
		public string UserEmailAddress { get; set; }
		
	}
}
