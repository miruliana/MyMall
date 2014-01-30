using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopDTO
{
	public abstract class ProductDTO
	{
		public int Id { get; set; }
		//public int SizeId { get; set; }
		public int BrandId { get; set; }
		//public int DestinationId { get; set; }
		//public int ColourId { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int CategoryId { get; set; }
	}
}
