using System;
using System.Reflection;

namespace StructureMap.AutoMocking
{
    public class NSubstituteFactory
    {
        private readonly Type mockOpenType;

        public NSubstituteFactory()
        {
            Assembly NSubstitute = Assembly.Load("NSubstitute");
            mockOpenType = NSubstitute.GetType("NSubstitute.Substitute");
            if (mockOpenType == null)
                throw new InvalidOperationException("Unable to find Type NSubstitute.Substitute in assembly " + NSubstitute.Location);
        }

        public object CreateMock(Type type)
        {
            MethodInfo[] methods = mockOpenType.GetMethods();
            foreach (MethodInfo method in methods)
            {
                if (method.ContainsGenericParameters && method.GetGenericArguments().Length == 1)
                {
                    var generic = method.MakeGenericMethod(type);
                    return generic.Invoke(null, new object[1] { null });
                }
            }
            return null;
        }

    }
}