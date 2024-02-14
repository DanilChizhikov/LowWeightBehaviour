using System;
using System.Collections.Generic;
using UnityEngine;

namespace MBSCore.LowWeightBehaviour.Csharp
{
    [Serializable]
    public abstract class BehaviourStateConfig : IBehaviourStateConfig
    {
        [SerializeField] private string _name = string.Empty;
        [SerializeField] private BehaviourActionConfig[] _actionConfigs = Array.Empty<BehaviourActionConfig>();
        [SerializeField] private BehaviourTransitionConfig[] _transitionConfigs = Array.Empty<BehaviourTransitionConfig>();
        
        public string Name => _name;
        public IReadOnlyList<IBehaviourActionConfig> ActionConfigs => _actionConfigs;
        public IReadOnlyList<IBehaviourTransitionConfig> TransitionConfigs => _transitionConfigs;

        public BehaviourStateConfig()
        {
            _name = GetType().Name;
        }
    }
}