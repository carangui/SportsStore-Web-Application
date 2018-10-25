using SportsStore.UnitTests.App_Start;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructuremapMvc), "End")]

namespace SportsStore.UnitTests.App_Start {
	using System.Web.Mvc;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
	using SportsStore.UnitTests.DependencyResolution;
    using StructureMap;
    
	public static class StructuremapMvc
    {
        #region Public Properties

        public static StructureMapDependencyScope StructureMapDependencyScope { get; set; }

        #endregion
		#region Public Methods and Operators
		
		public static void End()
        {
            StructureMapDependencyScope.Dispose();
        }
		
        public static void Start()
        {
            IContainer container = IoC.Initialize();
            StructureMapDependencyScope = new StructureMapDependencyScope(container);
            DependencyResolver.SetResolver(StructureMapDependencyScope);
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
        }
        #endregion
    }
}