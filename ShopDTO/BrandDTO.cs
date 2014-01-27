using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopDTO
{
	public class BrandDTO 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<ProductDTO> Products { get; set; }
	}
}
