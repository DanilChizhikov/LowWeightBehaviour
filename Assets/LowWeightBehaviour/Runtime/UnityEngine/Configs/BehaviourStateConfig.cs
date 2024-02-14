using System;
using System.Collections.Generic;
using UnityEngine;

namespace MBSCore.LowWeightBehaviour.UnityEngine
{
    public abstract class BehaviourStateConfig : ScriptableObject, IBehaviourStateConfig
    {
        [SerializeField] private BehaviourActionConfig[] _actionConfigs = Array.Empty<BehaviourActionConfig>();
        [SerializeField] private BehaviourTransitionConfig[] _transitionConfigs = Array.Empty<BehaviourTransitionConfig>();
        
        public string Name => name;
        public IReadOnlyList<IBehaviourActionConfig> ActionConfigs => _actionConfigs;
        public IReadOnlyList<IBehaviourTransitionConfig> TransitionConfigs => _transitionConfigs;
    }
}