using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDALRepository.Interfaces
{
	public interface IConsumable
	{
		DateTime? GetFabricationDate(object id);
		DateTime? GetExpireDate(object id);
	}
}
