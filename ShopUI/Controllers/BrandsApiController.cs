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
	public class BrandsApiController : ApiController
	{
		public ServicesManager Services
		{
			get { return ServicesManager.Instance; }
		}
		public IEnumerable<BrandDTO> GetByString(string searchTerm)
		{
			IEnumerable<BrandDTO> brands = Services.BrandService.GetAll().Where(x => x.Name.Contains(searchTerm));
			if (brands == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return brands;
		}
		// GET api/<controller>
		public IEnumerable<BrandDTO> Get()
		{
			IEnumerable<BrandDTO> brands = Services.BrandService.GetAll();

			if (brands == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return brands;
		}

		// GET api/<controller>/5
		public BrandDTO GetById(int id)
		{
			BrandDTO product = Services.BrandService.GetById(id);
			if (product == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return product;
		}

		public HttpResponseMessage Post([FromBody] BrandDTO brand)
		{
			brand = Services.BrandService.Insert(brand);
			var response = Request.CreateResponse<BrandDTO>(HttpStatusCode.Created, brand);
			string uri = Url.Link("DefaultApi", new { id = brand.Id });
			response.Headers.Location = new Uri(uri);
			return response;

		}
		// PUT api/<controller>/5
		public void Put(int id, BrandDTO brand)
		{
			brand.Id = id;
			Services.BrandService.Update(brand);
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
			Services.BrandService.Delete(id);
		}
	}
}