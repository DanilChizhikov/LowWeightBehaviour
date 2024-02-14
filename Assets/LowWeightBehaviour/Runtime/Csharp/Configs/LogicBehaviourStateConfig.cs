using System;
using System.Collections.Generic;
using UnityEngine;

namespace MBSCore.LowWeightBehaviour.Csharp
{
    [Serializable]
    public abstract class LogicBehaviourStateConfig : BehaviourStateConfig
    {
        [SerializeField] private BehaviourActionConfig[] _actionConfigs = Array.Empty<BehaviourActionConfig>();
        [SerializeField] private BehaviourTransitionConfig[] _transitionConfigs = Array.Empty<BehaviourTransitionConfig>();
        
        public IReadOnlyList<IBehaviourActionConfig> ActionConfigs => _actionConfigs;
        public IReadOnlyList<IBehaviourTransitionConfig> TransitionConfigs => _transitionConfigs;
    }
}