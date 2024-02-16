namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class LogActionFactory : ExampleActionFactory<LogActionConfig, LogAction>
    {
        protected override LogAction Create(LogActionConfig config, ExampleEntity entity)
        {
            return new LogAction(config, entity); 
        }
    }
}