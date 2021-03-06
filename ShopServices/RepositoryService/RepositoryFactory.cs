﻿using ShopDALRepository.Interfaces;
using ShopDALRepository.Repositories;
using ShopHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ShopServices.Windsor;
using ShopServices;

namespace ShopDALRepository
{
    public class RepositoryFactory
    {
        private readonly RepositoryFactory rpf;

        private IBrandRepository brandRepository;
        private ICosmeticRepository cosmeticRepository;
        private IClothesRepository clothesRepository;
	    private ICategoryRepository categoryRepository;
	    private IUserRepository userRepository;

        public RepositoryFactory(bool boolParameter) { }
        public RepositoryFactory()
        {
            rpf = HttpContext.Current.Items[ConfigurationHelper.HttpContextKey] as RepositoryFactory;

            if (rpf == null)
            {
                rpf = new RepositoryFactory(false);
                SaveToHttpContext();
            }
        }
		public ICategoryRepository CategoryRepository
		{
			get
			{
				if (rpf.categoryRepository == null)
				{
					rpf.categoryRepository = WindsorService.Resolve<ICategoryRepository>();
					SaveToHttpContext();
				}
				return rpf.categoryRepository;
			}
		}

        public IBrandRepository BrandRepository
        {
            get
            {
                if (rpf.brandRepository == null)
                {
	                rpf.brandRepository = WindsorService.Resolve<IBrandRepository>();
                    SaveToHttpContext();
                }
                return rpf.brandRepository;
            }
        }

        public IClothesRepository ClothesRepository
        {
            get
            {
                if (rpf.clothesRepository == null)
                {
					rpf.clothesRepository = WindsorService.Resolve<IClothesRepository>();
                    SaveToHttpContext();
                }
                return rpf.clothesRepository;
            }
        }
        public ICosmeticRepository CosmeticRepository
        {
            get
            {
                if (rpf.cosmeticRepository == null)
                {
					rpf.cosmeticRepository = WindsorService.Resolve<ICosmeticRepository>();
                    SaveToHttpContext();
                }
                return rpf.cosmeticRepository;
            }
        }
		public IUserRepository UserRepository
		{
			get
			{
				if (rpf.userRepository == null)
				{
					rpf.userRepository = WindsorService.Resolve<IUserRepository>();
					SaveToHttpContext();
				}
				return rpf.userRepository;
			}
		}

        private void SaveToHttpContext()
        {
            HttpContext.Current.Items[ConfigurationHelper.HttpContextKey] = rpf;
        }


    }
}
