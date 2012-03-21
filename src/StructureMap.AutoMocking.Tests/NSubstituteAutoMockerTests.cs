using NSubstitute;
using NUnit.Framework;

namespace StructureMap.AutoMocking.Tests
{
    [TestFixture]
    public class NSubstituteAutoMockerTester
    {
        [Test]
        public void IfClassUnderTestReturnsAnObjectOfTypeTestClass()
        {
            var mocks = new NSubstituteAutoMocker<TestClass>();
            var test = mocks.ClassUnderTest;
            Assert.IsInstanceOf<TestClass>(test);
        }

        [Test]
        public void IfClassUnderTestIsNotNull()
        {
            var mocks = new NSubstituteAutoMocker<TestClass>();
            var test = mocks.ClassUnderTest;
            Assert.IsNotNull(test);
        }

        [Test]
        public void IfGetIClassUnderTestIsNotNull()
        {
            var mocks = new NSubstituteAutoMocker<TestClass>();
            var test = mocks.ClassUnderTest;
            Assert.IsNotNull(mocks.Get<ITestClass>());
        }

        [Test]
        public void IfGetITestClassIsSameAsClassUnderTestITestClass()
        {
            var mocks = new NSubstituteAutoMocker<TestClass>();
            var test = mocks.ClassUnderTest;
            Assert.AreSame(mocks.Get<ITestClass>(), test.TestClass1);
        }

        [Test]
        public void IfDependecyReturnsValueWhenSet()
        {
            var mocks = new NSubstituteAutoMocker<TestClass>();
            var test = mocks.ClassUnderTest;
            var itest = mocks.Get<ITestClass>();
            itest.returnInt().Returns(3);
            Assert.AreEqual(3, test.returnInt());
        }

    }

    public class TestClass
    {
        private ITestClass _test;

        public ITestClass TestClass1
        {
            get { return _test; }
        }

        public TestClass(ITestClass test)
        {
            _test = test;
        }

        public int returnInt()
        {
            return _test.returnInt();
        }
    }

    public interface ITestClass
    {
        int returnInt();
    }
}