using Microsoft.Practices.Unity;
using MyLibraryService.Implentation;
using MyLibraryService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.App_Start
{
    public static class ServiceRegistry
    {
        public static void ConfigureService()
        {
            IUnityContainer container = new UnityContainer();

            RegisterService(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
      
        }

        private static void RegisterService(IUnityContainer container)
        {
            container.RegisterType<IBookStore, BookStore>();
        }
    }
}