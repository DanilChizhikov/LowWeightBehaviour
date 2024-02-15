using System;
using System.Collections.Generic;
using UnityEngine;

namespace MBSCore.LowWeightBehaviour
{
    [CreateAssetMenu(menuName = "MBSCore/LowWeightBehaviour/Logic State Config", fileName = "New Logic State Config")]
    public sealed class LogicBehaviourStateConfig : BehaviourStateConfig
    {
        [SerializeField] private BehaviourActionConfig[] _actionConfigs = Array.Empty<BehaviourActionConfig>();
        [SerializeField] private LogicBehaviourTransitionConfig[] _transitionConfigs = Array.Empty<LogicBehaviourTransitionConfig>();
        
        public IReadOnlyList<IBehaviourActionConfig> ActionConfigs => _actionConfigs;
        public IReadOnlyList<LogicBehaviourTransitionConfig> TransitionConfigs => _transitionConfigs;
    }
}