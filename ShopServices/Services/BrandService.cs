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
	public class BrandService : Service<Brand>, IBrandService
	{
		 public BrandService(IRepository<Brand> baseRepository) : base(baseRepository) { }
	}
}
