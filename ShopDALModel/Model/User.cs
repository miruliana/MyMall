using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDALModel.BaseModel;

namespace ShopDAL.Model
{
	[Table("Users")]
	public class User : HashValues
	{
		public string Password { get; set; }
		public string UserEmailAddress { get; set; }
	}
}
