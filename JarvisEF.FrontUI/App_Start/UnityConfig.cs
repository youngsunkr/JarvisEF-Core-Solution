using JarvisEF.Business;
using JarvisEF.Business.Implementations;
using JarvisEF.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace JarvisEF.FrontUI.App_Start
{
    /// <summary>
    /// https://technotipstutorial.blogspot.com/2018/05/part-56-repository-pattern-3-dependency.html
    /// </summary>
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IEmployeeBusiness, EmployeeBusiness>();

            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
