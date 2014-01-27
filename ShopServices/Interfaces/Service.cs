using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ShopDALRepository.Interfaces;
using ShopDAL.Model;
using ShopDALRepository.Repositories;

namespace ShopServices.Interfaces
{
	public class Service<T> : IBaseService<T> where T : class , new()
	{
		private readonly IRepository<T> _baseRepository;
		private readonly IUnitOfWork _unitOfWork;

		public Service(IRepository<T> baseRepository, IUnitOfWork unitOfWork)
		{
			if (baseRepository == null)
				throw new ArgumentNullException("baseRepository");

			if (unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			_baseRepository = baseRepository;
			_unitOfWork = unitOfWork;
		}
        public Service(IRepository<T> baseRepository)
        {
            if (baseRepository == null)
                throw new ArgumentNullException("baseRepository");
                       
            _baseRepository = baseRepository;
            if (_unitOfWork == null)                
                _unitOfWork = new UnitOfWork(_baseRepository.CurrentContext);
        }
		public IQueryable<T> Entities
		{
			get { return this._baseRepository.Entities; }
		}

		public T GetById(object id)
		{
			return this._baseRepository.GetById(id);
		}
		
		public IQueryable<T> Find(Expression<Func<T, bool>> where)
		{
			return this._baseRepository.Find(where);
		}
		public IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			string includeProperties = "")
		{
			return this._baseRepository.Get(filter, orderBy, includeProperties);
		}
		public T Insert(T entity)
		{
			this._baseRepository.Insert(entity);
            if (_unitOfWork != null)
			    _unitOfWork.Commit();
			return entity;
		}

		public void Delete(object id)
		{
			this._baseRepository.Delete(id);
            if (_unitOfWork != null)
			    _unitOfWork.Commit();
		}

		public void Delete(T entity)
		{
			this._baseRepository.Delete(entity);
			if (_unitOfWork != null)
				_unitOfWork.Commit();
		}

		public void Update(T entity)
		{
			this._baseRepository.Update(entity);
            if (_unitOfWork != null)
                _unitOfWork.Commit();
		}
	}
}
