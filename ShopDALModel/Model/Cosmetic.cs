using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDALModel.BaseModel;

namespace ShopDAL.Model
{
	public class Cosmetic : Product
	{
		public DateTime? FabricationDate { get; set; }
        public DateTime? ExpireDate { get; set; }
	}
}
