    namespace SportsStore.UnitTests.DependencyResolution
{
    using System;
    using System.Web.Mvc;
    using StructureMap;
    using StructureMap.Graph;
    using StructureMap.Graph.Scanning;
    using StructureMap.Pipeline;
    using StructureMap.TypeRules;

    public class ControllerConvention : IRegistrationConvention {
        #region Public Methods and Operators

        public void Process(Type type, Registry registry)
        {
            if (type.CanBeCastTo<Controller>() && !type.IsAbstract)
                registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
        }

        public void ScanTypes(TypeSet types, Registry registry)
        {
            var typeList = types.AllTypes();
            foreach (var type in typeList)
            {
                if (type.CanBeCastTo<Controller>() && !type.IsAbstract)
                    registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
            }
        }
        #endregion
    }
}