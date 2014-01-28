using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;
using ShopDALRepository.Interfaces;
using ShopServices.Interfaces;

namespace ShopServices.Services
{
	public class CosmeticService : Service<Cosmetic>, ICosmeticService
	{
		public CosmeticService(IRepository<Cosmetic> baseRepository) : base(baseRepository) { }
      
	}
}
