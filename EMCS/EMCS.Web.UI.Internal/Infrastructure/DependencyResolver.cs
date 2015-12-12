using EMCS.Data.Abstract;
using EMCS.Data.DataModel;
using EMCS.Data.Repositories;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EMCS.Web.UI.Internal.Infrastructure
{
    public class DependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public DependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet( serviceType );
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll( serviceType );
        }

        private void AddBindings()
        {
            kernel.Bind( typeof( IEMCSRepositoryBase<> ) ).To( typeof( EMCSRepositoryBase<> ) );
        }
    }
}