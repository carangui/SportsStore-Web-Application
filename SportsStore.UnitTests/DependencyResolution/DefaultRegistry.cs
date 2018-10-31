    namespace SportsStore.UnitTests.DependencyResolution {
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Concrete;
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
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
            //For<IExample>().Use<Example>();
            For<IProductRepository>().Use<EFProductRepository>();
            For<IOrderProcessor>().Use<EmailOrderProcessor>();
        }
        #endregion
    }
}