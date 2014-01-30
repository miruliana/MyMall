using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;
using ShopDALRepository.Interfaces;
using ShopDTO;
using ShopMapper;
using ShopServices.Interfaces;

namespace ShopServices.Services
{
	public class BrandService : Service<Brand>, IBrandService
	{
		 public BrandService(IRepository<Brand> baseRepository) : base(baseRepository) { }
		 public IQueryable<BrandDTO> GetAll()
		 {
			 IQueryable<Brand> brands = base.Get(null, q => q.OrderBy(d => d.Id));
			 IQueryable<BrandDTO> brandsDtoList = BrandMapper.BrandToBrandDtoList(brands);
			 return brandsDtoList;

		 }
		 public BrandDTO GetById(int id)
		 {
			 return BrandMapper.BrandToBrandDto(base.GetById(id));
		 }

		 public BrandDTO Insert(BrandDTO brandDto)
		 {
			 brandDto = BrandMapper.BrandToBrandDto(base.Insert(BrandMapper.BrandDtoToBrand(brandDto)));
			 return brandDto;
		 }

		 public void Update(BrandDTO brandDto)
		 {
			 base.Update(BrandMapper.BrandDtoToBrand(brandDto));
		 }

		 public void Delete(object id)
		 {
			 base.Delete(id);
		 }
	}
}
