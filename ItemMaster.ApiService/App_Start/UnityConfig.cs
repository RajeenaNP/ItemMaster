using ItemMaster.BusinessSevices;
using ItemMaster.BusinessSevices.Contracts;
using ItemMaster.Repository;
using ItemMaster.Repository.Contracts;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ItemMaster.ApiService
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IItemMasterService, ItemMasterService>();
            container.RegisterType<IItemMasterRepository, ItemMasterRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}