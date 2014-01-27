using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;
using ShopDALRepository.Interfaces;

namespace ShopDALRepository.Interfaces
{
	public interface IClothesRepository : IRepository<Clothes>, IProduct, IWeareable
	{
		
	}
}
