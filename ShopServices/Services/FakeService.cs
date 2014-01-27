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
      
    
    public class FakeService : Service<Clothes>, IFakeService
    {
      //public FakeService(IRepository<Clothes> baseRepository, IUnitOfWork unitOfWork) : base(baseRepository, unitOfWork) { }
		public FakeService(IRepository<Clothes> baseRepository) : base(baseRepository) { }
      
        public IEnumerable<object> GetAll()
        {
            return null;
        }
        public object GetById(int id)
        {
            return null;
        }

        public object Insert(object product)
        {
            return null;
        }

        public void Update(object product)
        {
            //base.Update(ClothesMapper.ClothesDtoToClothes(product));
        }

        public void Delete(object id)
        {
            base.Delete(id);
        }
    }
}
