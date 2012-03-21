namespace StructureMap.AutoMocking
{
    public class NSubstituteAutoMocker<TARGETCLASS> : AutoMocker<TARGETCLASS> where TARGETCLASS : class
    {
        public NSubstituteAutoMocker()
        {
            _serviceLocator = new NSubstituteServiceLocator();
            _container = new AutoMockedContainer(_serviceLocator);
        }
    }
}