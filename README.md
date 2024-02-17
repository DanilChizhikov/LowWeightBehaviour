# LowWeightBehaviour
![](https://img.shields.io/badge/unity-2022.3+-000.svg)

## Description
The current package is designed to demonstrate a simple and easy implementation of the ai behavior in your Unity project.

It demonstrates how to implement the system with minimal use of standard Unity classes, which greatly simplifies the 
code in the application.

## Table of Contents
- [Getting Started](#Getting-Started)
    - [Install manually (using .unitypackage)](#Install-manually-(using-.unitypackage))
    - [Install via UPM (using Git URL)](#Install-via-UPM-(using-Git-URL))
- [How to use](#How-to-use)
    - [Usage examples](#Usage-examples)
- [License](#License)

## Getting Started
Prerequisites:
- [GIT](https://git-scm.com/downloads)
- [Unity](https://unity.com/releases/editor/archive) 2022.3+

### Install manually (using .unitypackage)
1. Download the .unitypackage from [releases](https://github.com/DanilChizhikov/Localization/releases/) page.
2. Open LowWeightBehaviour.x.x.x.unitypackage

### Install via UPM (using Git URL)
1. Navigate to your project's Packages folder and open the manifest.json file.
2. Add this line below the "dependencies": { line
    - ```json title="Packages/manifest.json"
      "com.danilchizhikov.lwb": "https://github.com/DanilChizhikov/LowWeightBehaviour.git?path=Assets/LowWeightBehaviour",
      ```
UPM should now install the package.

## How to use
To use the behavior in your project, you need to create several additional classes:

1) Use IBehaviourEntity to indicate who is the entity for the current behavior
```csharp
namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleEntity : IBehaviourEntity
    {
        public int RandomCount { get; set; }
        public int WeightCount { get; set; }
    }
}
```
2) Create a separate class for actions configs, logic and factories

Config:
```csharp
namespace MBSCore.LowWeightBehaviour.Example
{
    internal abstract class ExampleActionConfig : BehaviourActionConfig { }
}
```
Action:
```csharp
namespace MBSCore.LowWeightBehaviour.Example
{
    internal abstract class ExampleAction<TConfig> : BehaviourAction<TConfig, ExampleEntity>
        where TConfig :ExampleActionConfig
    {
        public ExampleAction(TConfig config, ExampleEntity entity) : base(config, entity) { }
    }
}
```
Factory:
```csharp
namespace MBSCore.LowWeightBehaviour.Example
{
    internal abstract class ExampleActionFactory<TConfig, TAction> : BehaviourActionFactory<TConfig, ExampleEntity, TAction>
        where TConfig : ExampleActionConfig
        where TAction : ExampleAction<TConfig>
    { }
}
```
3) Create a separate class for decisions configs, logic and factories

Config:
```csharp
namespace MBSCore.LowWeightBehaviour.Example
{
    internal abstract class ExampleDecisionConfig : BehaviourDecisionConfig { }
}
```
Decision:
```csharp
namespace MBSCore.LowWeightBehaviour.Example
{
    internal abstract class ExampleDecision<TConfig> : BehaviourDecision<TConfig, ExampleEntity>
        where TConfig : ExampleDecisionConfig
    {
        public ExampleDecision(TConfig config, ExampleEntity entity) : base(config, entity) { }
    }
}
```
Factory:
```csharp
namespace MBSCore.LowWeightBehaviour.Example
{
    internal abstract class ExampleDecisionFactory<TConfig, TDecision> : BehaviourDecisionFactory<TConfig, ExampleEntity, TDecision>
        where TConfig : ExampleDecisionConfig
        where TDecision : ExampleDecision<TConfig>
    { }
}
```

4) Create a separate class for basic states

Logic:

Performs actions in this state and checks for transition to other states.
The order of execution:

| State            | Action | Type |
|------------------|--------|------|
| Enter To Actions | Action.Enter | Single |
| Enter To Transitions | Transition.Enter -> Decision.Enter | Single |
| Actions Processing | Action.Processing | Loop |
| Transition Processing | Transition.TryTransition -> Decision.GetDecision | Loop |
| Exit From Actions | Action.Exit | Single |
| Exit From Transition | Transition.Exit -> Decision.Exit | Single |

```csharp
using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleLogicState : LogicBehaviourState<ExampleEntity>
    {
        public ExampleLogicState(string name, ExampleEntity entity, IEnumerable<IBehaviourAction> actions,
            IEnumerable<LogicBehaviourTransition> transitions) : base(name, entity, actions, transitions) { }
    }
}
```
```csharp
namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleLogicStateFactory : LogicBehaviourStateFactory<ExampleEntity, ExampleLogicState>
    {
        public ExampleLogicStateFactory(IBehaviourActionFactoryService actionFactoryService,
            IBehaviourDecisionFactoryService decisionFactoryService) : base(actionFactoryService, decisionFactoryService) { }

        protected override ExampleLogicState Create(string name, IBehaviourAction[] actions, LogicBehaviourTransition[] transitions,
            ExampleEntity entity)
        {
            return new ExampleLogicState(name, entity, actions, transitions);
        }
    }
}
```
Random:

Selects a random state from his list to go to.
```csharp
namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleRandomState : RandomBehaviourState<ExampleEntity>
    {
        public ExampleRandomState(string name, ExampleEntity entity, RandomBehaviourTransition transition) :
            base(name, entity, transition) { }
    }
}
```
```csharp
namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleRandomStateFactory : RandomBehaviourStateFactory<ExampleEntity, ExampleRandomState>
    {
        protected override ExampleRandomState Create(string name, ExampleEntity entity, RandomBehaviourTransition transition)
        {
            return new ExampleRandomState(name, entity, transition);
        }
    }
}
```
Weight:

Selects a random state from his list to which you want to switch by means of a controlled random.
```csharp
namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleWeightState : WeightBehaviourState<ExampleEntity>
    {
        public ExampleWeightState(string name, ExampleEntity entity, WeightBehaviourTransition transition) :
            base(name, entity, transition) { }
    }
}
```
```csharp
namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleWeightStateFactory : WeightBehaviourStateFactory<ExampleEntity, ExampleWeightState>
    {
        protected override ExampleWeightState Create(string name, ExampleEntity entity, WeightBehaviourTransition transition)
        {
            return new ExampleWeightState(name, entity, transition);
        }
    }
}
```


### Usage examples
An example of creating all entities to use the system:
```csharp
using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleBehaviourScope
    {
        public IBehaviourGraphFactory GraphFactory { get; }

        public ExampleBehaviourScope()
        {
            var actionFactories = new HashSet<IBehaviourActionFactory>
            {
                new LogActionFactory(),
            };
            
            var actionFactoryService = new BehaviourActionFactoryService(actionFactories);
            var decisionFactories = new HashSet<IBehaviourDecisionFactory>
            {
                new RandomCountMoreOrEqualDecisionFactory(),
                new WeightCountMoreOrEqualDecisionFactory(),
            };
            
            var decisionFactoryService = new BehaviourDecisionFactoryService(decisionFactories);
            var stateFactories = new HashSet<IBehaviourStateFactory>
            {
                new ExampleLogicStateFactory(actionFactoryService, decisionFactoryService),
                new ExampleRandomStateFactory(),
                new ExampleWeightStateFactory()
            };
            
            var stateFactoryService = new BehaviourStateFactoryService(stateFactories);
            GraphFactory = new BehaviourGraphFactory(stateFactoryService);
        }
    }
}
```

## License

MIT