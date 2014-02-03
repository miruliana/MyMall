using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopServices.Services;
using ShopDTO;

namespace ShopUI.Controllers
{
	public class ClothesApiController : ApiController
	{
		public ServicesManager Services
		{
			get { return ServicesManager.Instance; }
		}
		// GET api/<controller>
		public IEnumerable<ClothesDTO> Get()
		{
			IEnumerable<ClothesDTO> clothes = Services.ClothesService.GetAll();

			if (clothes == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return clothes;
		}

		// GET api/<controller>/5
		public ClothesDTO GetById(int id)
		{
			ClothesDTO product = Services.ClothesService.GetById(id);
			if (product == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return product;
		}

		public HttpResponseMessage Post([FromBody] ClothesDTO product)
		{
			product = Services.ClothesService.Insert(product);
			var response = Request.CreateResponse<ClothesDTO>(HttpStatusCode.Created, product);
			string uri = Url.Link("DefaultApi", new { id = product.Id });
			response.Headers.Location = new Uri(uri);
			return response;

		}
		// PUT api/<controller>/5
		public void Put(int id, ClothesDTO product)
		{
			product.Id = id;
			Services.ClothesService.Update(product);
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
			Services.ClothesService.Delete(id);
		}
		
	}
}