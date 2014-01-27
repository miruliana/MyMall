using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShopServices.Interfaces
{
	public interface IBaseService<TEntity> 
	{
		IQueryable<TEntity> Entities { get; }
		TEntity GetById(object id);
		IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filter);

		IQueryable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "");

		TEntity Insert(TEntity entity);
		void Delete(object id);
		void Update(TEntity entity);
	}
}
