using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopDALRepository.Interfaces
{
	public interface IRepository<TEntity> : IDisposable
	{
        object CurrentContext { get; }
		IQueryable<TEntity> Entities { get; }
       	TEntity GetById(object id);
		IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filter);

		IQueryable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "");

		void Insert(TEntity entity);
		void Delete(object id);
		void Delete(TEntity entity);
		void Update(TEntity entity);
		  
		
	}
}
