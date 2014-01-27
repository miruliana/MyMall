using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopDTO
{
	public class DestinationDTO
	{
			public int Id { get; set; }
			public string Name { get; set; }
			public List<ProductTypesDTO> ProductTypes { get; set; }
			public List<CategoriesDTO> Categories { get; set; }
	}
}
