using System;
using System.Collections.Generic;
using UnityEngine;

namespace MBSCore.LowWeightBehaviour
{
    [Serializable]
    public struct RandomBehaviourTransitionConfig
    {
        [SerializeField] private BehaviourStateConfig[] _stateConfigs;

        public IReadOnlyList<IBehaviourStateConfig> StateConfigs => _stateConfigs;
    }
}