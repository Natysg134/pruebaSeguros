//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Seguros.Models;

//namespace Seguros.DAL
//{
//    public class UnitOfWork : IDisposable
//    {
//        private SegurosContext context = new SegurosContext();
//        private GenericRepository<Seguro> Seguros;
//        public GenericRepository<Seguro> Seguro
//        {
//            get
//            {
//                return this.Seguros ?? new GenericRepository<Seguro>(context);
//            }
//        }
//        public void Save()
//        {
//            context.SaveChanges();
//        }
//        private bool disposed = false;
//        protected virtual void Dispose(bool disposing)
//        {
//            if (!this.disposed)
//            {
//                if (disposing)
//                {
//                    context.Dispose();
//                }
//            }
//            this.disposed = true;
//        }
//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//    }
//}