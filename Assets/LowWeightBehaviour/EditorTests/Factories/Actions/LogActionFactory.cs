namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class LogActionFactory : TestActionFactory<LogActionConfig, LogAction>
    {
        protected override LogAction Create(LogActionConfig config, TestEntity entity)
        {
            return new LogAction(config, entity); 
        }
    }
}