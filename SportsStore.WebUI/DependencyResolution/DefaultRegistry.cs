namespace SportsStore.WebUI.DependencyResolution
{
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Concrete;

    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan => 
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            For<IProductRepository>().Use<EFProductRepository>();
        }
        #endregion
    }
}