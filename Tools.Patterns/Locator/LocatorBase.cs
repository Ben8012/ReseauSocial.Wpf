using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Patterns.Locator
{
    public abstract class LocatorBase
    {
        private IServiceProvider Container { get; init; }

        protected LocatorBase()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            Container = services.BuildServiceProvider();
        }

        public T GetResource<T>()
        {
            return Container.GetService<T>();
        }

        protected abstract void ConfigureServices(IServiceCollection services);
    }
}
