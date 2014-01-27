using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;

namespace ShopDALRepository.Interfaces
{
	public interface IProduct
	{
		string GetName(object id);
		double GetPrice(object id);
	}
}
