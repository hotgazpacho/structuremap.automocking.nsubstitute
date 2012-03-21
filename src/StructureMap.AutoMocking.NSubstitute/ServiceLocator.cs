using System;

namespace StructureMap.AutoMocking
{
    class NSubstituteServiceLocator : ServiceLocator
    {
        private readonly NSubstituteFactory _substitutes = new NSubstituteFactory();

        public T Service<T>() where T : class
        {
            return (T)_substitutes.CreateMock(typeof(T));
        }

        public object Service(Type serviceType)
        {
            return _substitutes.CreateMock(serviceType);
        }

        public T PartialMock<T>(params object[] args) where T : class
        {
            return (T)_substitutes.CreateMock(typeof(T));
        }
    }
}