using MauiApp1.Services;
using MauiApp1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class ServiceLocator
    {
        private IServiceProvider _serviceProvider;

        public MainPageViewModels MainPageViewModels => 
            _serviceProvider.GetService<MainPageViewModels>(); // 依赖注入 IoC



        // 构造函数
        public ServiceLocator()
        {
            var serviceCollection = new ServiceCollection();
            /*  将MainPageViewModels 放到 serviceCollection 中 */
            serviceCollection.AddSingleton<MainPageViewModels>();
            /*  将接口类与实现类放到 serviceCollection */
            serviceCollection.AddSingleton<IKeyValueStorage,KeyValueStorege>();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
