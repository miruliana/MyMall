using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopDTO
{
	public class CosmeticDTO : ProductDTO
	{
		public DateTime? FabricationDate { get; set; }
		public DateTime? ExpireDate { get; set; }
	}
}
