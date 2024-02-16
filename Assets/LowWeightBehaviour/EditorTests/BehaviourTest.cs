using NUnit.Framework;

namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class BehaviourTest
    {
        private TestBehaviourScope _behaviourScope;
        
        [SetUp]
        public void Setup()
        {
            _behaviourScope = new TestBehaviourScope();
        }
        
        [Test]
        public void CreateBehaviourTest()
        {
            
        }
    }
}
