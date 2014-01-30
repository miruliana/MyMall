using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopDTO;
using ShopServices.Services;

namespace ShopUI.Controllers
{
	public class CategoryApiController : ApiController
	{
		public ServicesManager Services
		{
			get { return ServicesManager.Instance; }
		}
		public IEnumerable<CategoriesDTO> GetByString(string searchTerm)
		{
			IEnumerable<CategoriesDTO> categories = Services.CategoryService.GetAll().Where(x => x.Name.Contains(searchTerm));
			if (categories == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return categories;
		}
		// GET api/<controller>
		public IEnumerable<CategoriesDTO> Get()
		{
			IEnumerable<CategoriesDTO> categories = Services.CategoryService.GetAll();

			if (categories == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return categories;
		}

		// GET api/<controller>/5
		public CategoriesDTO GetById(int id)
		{
			CategoriesDTO category = Services.CategoryService.GetById(id);
			if (category == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return category;
		}

		public HttpResponseMessage Post([FromBody] CategoriesDTO category)
		{
			category = Services.CategoryService.Insert(category);
			var response = Request.CreateResponse<CategoriesDTO>(HttpStatusCode.Created, category);
			string uri = Url.Link("DefaultApi", new { id = category.Id });
			response.Headers.Location = new Uri(uri);
			return response;

		}
		// PUT api/<controller>/5
		public void Put(int id, CategoriesDTO category)
		{
			category.Id = id;
			Services.CategoryService.Update(category);
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
			Services.CategoryService.Delete(id);
		}
	}
}