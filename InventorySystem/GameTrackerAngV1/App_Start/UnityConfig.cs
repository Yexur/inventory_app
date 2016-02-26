using System;
using System.Data.Entity;
using System.Net.Http;
using System.Web;
using GameTrackerAngV1.Models;
using GameTrackerAngV1.Persistance;
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Logic;
using GameTrackerAngV1.Persistance.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace GameTrackerAngV1.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
           // container.LoadConfiguration();

            // container.RegisterType<IProductRepository, ProductRepository>();
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<DbContext, GameTrackerContext>();

            container.RegisterType(typeof (IUserStore<ApplicationUser>), typeof (UserStore<ApplicationUser>));
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => HttpContext.Current.GetOwinContext().Authentication));

            //register the repositories
            container.RegisterType<ICategoryGroupRepository, CategoryGroupRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IItemStatusRepository, ItemStatusRepository>();
            container.RegisterType<IGenreRepository, GenreRepository>();
            container.RegisterType<ITrackingCodeRepository, TrackingCodeRepository>();
            container.RegisterType<IBoardGameRepository, BoardGameRepository>();
            container.RegisterType<IVideoGameRepository, VideoGameRepository>();

            //register the logic layer
            container.RegisterType<ICategoryGroupLogic,CategoryGroupLogic>();
            container.RegisterType<ICategoryLogic, CategoryLogic>();
            container.RegisterType<IItemStatusLogic, ItemStatusLogic>();
            container.RegisterType<IGenreLogic, GenreLogic>();
            container.RegisterType<ITrackingCodeLogic, TrackingCodeLogic>();
            container.RegisterType<IBoardGameLogic, BoardGameLogic>();
            container.RegisterType<IVideoGameLogic, VideoGameLogic>();
        }
    }
}
