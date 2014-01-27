using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;
using ShopDALRepository.Interfaces;
using ShopDALModel.BaseModel;

namespace ShopDALRepository.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected ShopContext context;
		protected DbSet<TEntity> dbSet;

		public Repository()
		{
            if (context == null)
            {
                context = new ShopContext();
            }
			
			this.dbSet = context.Set<TEntity>();
		}
        public Repository(ShopContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public object CurrentContext
        {
            get { return (object)this.context; }
        }

		public IQueryable<TEntity> Entities
		{
			get { return dbSet; }
		}

		public virtual TEntity GetById(object id)
		{
			return dbSet.Find(id);
		}

		public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filter = null)
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}
			return query;
		}

		public virtual IQueryable<TEntity> Get(
		   Expression<Func<TEntity, bool>> filter = null,
		   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
		   string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return orderBy(query);
			}
			else
			{
				return query;
			}
		}


		public virtual void Insert(TEntity entity)
		{
			dbSet.Add(entity);
		}

		public virtual void Delete(object id)
		{
			TEntity entityToDelete = dbSet.Find(id);
			if (entityToDelete != null)
			Delete(entityToDelete);
		}

		public virtual void Delete(TEntity entityToDelete)
		{
			if (context.Entry(entityToDelete).State == EntityState.Detached)
			{
				dbSet.Attach(entityToDelete);
			}
			dbSet.Remove(entityToDelete);
		}

		public virtual void Update(TEntity entityToUpdate)  
		{
			var entry = context.Entry<TEntity>(entityToUpdate);
			var pkey = dbSet.Create().GetType().GetProperty("Id").GetValue(entityToUpdate);
			if (entry.State == EntityState.Detached)
			{
				var set = context.Set<TEntity>();
				TEntity attachedEntity = set.Find(pkey);

				if (attachedEntity != null)
				{
					var attachedEntry = context.Entry(attachedEntity);
					attachedEntry.CurrentValues.SetValues(entityToUpdate);
				}
				else
				{
					entry.State = EntityState.Modified; // This should attach entity
				}
			}
			//dbSet.Attach(entityToUpdate);
			//context.Entry(entityToUpdate).State = EntityState.Modified;
		}

		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
