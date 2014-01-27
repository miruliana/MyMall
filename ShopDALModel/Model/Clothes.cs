using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDALModel.BaseModel;

namespace ShopDAL.Model
{
	public class Clothes : Product
	{
		public int TypeId { get; set; }
		public string Colection { get; set; }
	}
}
