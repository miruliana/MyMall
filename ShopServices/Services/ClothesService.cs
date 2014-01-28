using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;
using ShopMapper;
using ShopDALRepository.Interfaces;
using ShopDTO;
using ShopServices.Interfaces;

namespace ShopServices.Services
{
	public class ClothesService : Service<Clothes>, IClothesService
	{
		public ClothesService(IRepository<Clothes> baseRepository) : base(baseRepository) { }
      
		public IQueryable<ClothesDTO> GetAll()
		{
			IQueryable<Clothes> clothes = base.Get(null, q => q.OrderBy(d => d.Id));
			IQueryable<ClothesDTO> clothesDtoList = ClothesMapper.ClothesToClothesDtoList(clothes);
			return clothesDtoList;
            
        }
		public ClothesDTO GetById(int id)
		{
			return ClothesMapper.ClothesToClothesDto(base.GetById(id));
		}

		public ClothesDTO Insert(ClothesDTO product)
		{
			product = ClothesMapper.ClothesToClothesDto(base.Insert(ClothesMapper.ClothesDtoToClothes(product)));
			return product;            
        }

		public void Update(ClothesDTO product)
		{
			base.Update(ClothesMapper.ClothesDtoToClothes(product));
		}

		public void Delete(object id)
		{
			base.Delete(id);
		}
	}
}
