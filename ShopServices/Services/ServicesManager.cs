using ShopDALRepository;
using ShopDALRepository.Interfaces;
using ShopDALRepository.Repositories;
using ShopServices.AuthenticationService;
using ShopServices.AuthenticationService.Interfaces;
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
	    private ICategoryService categoryService;
	    private IUserService userService;
	    private IFormsAuthenticationService formsAuthenticationService;
	    private IMembershipService membershipService;

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
		public CategoryService CategoryService
		{
			get
			{
				if (categoryService != null) return categoryService as CategoryService;
				categoryService = WindsorService.Resolve<ICategoryService>(WindsorService.Resolve<ICategoryRepository>());
				SaveToContext();
				return categoryService as CategoryService;
			}
		}
		public UserService UserService
		{
			get
			{
				if (userService != null) return userService as UserService;
				userService = WindsorService.Resolve<IUserService>(WindsorService.Resolve<IUserRepository>());
				SaveToContext();
				return userService as UserService;
			}
		}
		public IFormsAuthenticationService FormsAuthenticationService
		{
			get
			{
				if (formsAuthenticationService != null) return formsAuthenticationService as IFormsAuthenticationService;
				formsAuthenticationService = new FormsAuthenticationService();
				SaveToContext();
				return formsAuthenticationService;
			}
		}

		public IMembershipService MembershipService
		{
			get
			{
				if (membershipService != null) return membershipService as IMembershipService;
				membershipService = new AccountMembershipService();
				SaveToContext();
				return membershipService;
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
					_uniqueInstance = HttpContextFactory.Current.Items[HTTPCONTEXTKEY] as ServicesManager;
                    if (_uniqueInstance != null) return _uniqueInstance;
                    lock (_syncRoot)
                    {
                        _uniqueInstance = new ServicesManager();
						HttpContextFactory.Current.Items.Add(HTTPCONTEXTKEY, _uniqueInstance);
                    }
                    return _uniqueInstance;
                }
            }

            internal static void UpdateInstance(ServicesManager updatedFactory)
            {
				HttpContextFactory.Current.Items[HTTPCONTEXTKEY] = updatedFactory;
            }
        }

        public static ServicesManager Instance
        {
            get { return FactoryCreator.UniqueInstance; }
        }

        private  void SaveToContext()
        {
			FactoryCreator.UpdateInstance(this);
        }
		
    }
}
