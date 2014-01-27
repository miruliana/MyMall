using ShopDALRepository;
using ShopDALRepository.Interfaces;
using ShopDALRepository.Repositories;
using ShopServices.Interfaces;
using ShopServices.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShopServices.Services
{
    public class ServicesManager
    {
        private IClothesService clothesService;
        private ICosmeticService cosmeticService;
        private IBrandService brandService;


        public ClothesService ClothesService
        {
            get
            {
                if (clothesService != null) 
					return clothesService as ClothesService;
				clothesService = WindsorService.Resolve<IClothesService>(WindsorService.Resolve<IClothesRepository>());
                SaveToContext();
				return clothesService as ClothesService;
            }
        }
        public CosmeticService CosmeticService
        {
            get
            {
                if (cosmeticService != null)
					return cosmeticService as CosmeticService;
				cosmeticService = WindsorService.Resolve<ICosmeticService>(WindsorService.Resolve<ICosmeticRepository>());
                SaveToContext();
				return cosmeticService as CosmeticService;
            }
        }
        public BrandService BrandService
        {
            get
            {
                if (brandService != null) return brandService as BrandService;
				brandService =  WindsorService.Resolve<IBrandService>(WindsorService.Resolve<IBrandRepository>());
                SaveToContext();
                return brandService as BrandService;
            }
        }
       

        // nested class used for lazy initialization
        private class FactoryCreator
        {
            internal const string HTTPCONTEXTKEY = "ShopFactory";
            private static ServicesManager _uniqueInstance;
            private static object _syncRoot = new object();

            internal static ServicesManager UniqueInstance
            {
                get
                {
                    _uniqueInstance = HttpContext.Current.Items[HTTPCONTEXTKEY] as ServicesManager;
                    if (_uniqueInstance != null) return _uniqueInstance;
                    lock (_syncRoot)
                    {
                        _uniqueInstance = new ServicesManager();
                        HttpContext.Current.Items.Add(HTTPCONTEXTKEY, _uniqueInstance);
                    }
                    return _uniqueInstance;
                }
            }

            internal static void UpdateInstance(ServicesManager updatedFactory)
            {
                HttpContext.Current.Items[HTTPCONTEXTKEY] = updatedFactory;
            }
        }

        public static ServicesManager Instance
        {
            get { return FactoryCreator.UniqueInstance; }
        }

        private void SaveToContext()
        {
            FactoryCreator.UpdateInstance(this);
        }
    }
}
