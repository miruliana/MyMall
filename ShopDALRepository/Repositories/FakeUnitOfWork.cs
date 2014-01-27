using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;
using ShopDALRepository.Interfaces;
using ShopDALRepository.Repositories;

namespace ShopDALRepository.Repositories
{
    public class FakeUnitOfWork :  IDisposable, IUnitOfWork
    {
        #region Fields

        private readonly ShopContext _context;

        #endregion Fields

        #region Methods

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IUnitOfWork Members

        /// <summary>
        /// Opens database connection and begins transaction.
        /// </summary>
        public void BeginTransaction()
        {

        }

        /// <summary>
        /// Commits the changes to the data store.
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }


        /// <summary>
        /// Rollbacks transaction and closes database connection.
        /// </summary>
        public void Rollback()
        {

        }
        #endregion

        #endregion Methods

        #region Ctors

        public FakeUnitOfWork()
        {
            
                _context = new ShopContext();
        }

        #endregion Ctors
    }

}
