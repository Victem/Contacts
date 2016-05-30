using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Ninject;

namespace Contacts.WebUI.Infrastructure
{
    public class NinjectResolver : IDependencyResolver
    {

        protected IKernel kernel;


        public NinjectResolver(IKernel kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("Container");
            }
            this.kernel = kernel;
        }


              

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return kernel.GetAll(serviceType);
            }
            catch (Exception)
            {

                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            
        }
    }
}
