using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDALRepository.Interfaces
{
	public interface IWeareable
	{
		string GetCollection(object id);
	}
}
