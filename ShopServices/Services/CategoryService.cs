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
	public class CategoryService : Service<Category>, ICategoryService
	{
		public CategoryService(IRepository<Category> baseRepository) : base(baseRepository) { }
		public IQueryable<CategoriesDTO> GetAll()
		{
			IQueryable<Category> categories = base.Get(null, q => q.OrderBy(d => d.Id));
			IQueryable<CategoriesDTO> categoriesDtoList = CategoriesMapper.CategoryToCategoryDtoList(categories);
			return categoriesDtoList;
		}
		public CategoriesDTO GetById(int id)
		{
			return CategoriesMapper.CategoryToCategoryDto(base.GetById(id));
		}

		public CategoriesDTO Insert(CategoriesDTO categoriesDto)
		{
			categoriesDto = CategoriesMapper.CategoryToCategoryDto(base.Insert(CategoriesMapper.CategoryDtoToCategory(categoriesDto)));
			return categoriesDto;
		}

		public void Update(CategoriesDTO categoriesDto)
		{
			base.Update(CategoriesMapper.CategoryDtoToCategory(categoriesDto));
		}

		public void Delete(object id)
		{
			base.Delete(id);
		}
	}
}
