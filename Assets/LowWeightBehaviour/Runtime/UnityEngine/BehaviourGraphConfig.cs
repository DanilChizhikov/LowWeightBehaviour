using System;
using System.Collections.Generic;
using UnityEngine;

namespace MBSCore.LowWeightBehaviour.UnityEngine
{
    [CreateAssetMenu(menuName = "MBSCore/LowWeightBehaviour/Graph Config", fileName = "New Graph Config")]
    public sealed class BehaviourGraphConfig : ScriptableObject, IBehaviourGraphConfig
    {
        [SerializeField] private BehaviourStateConfig _enterStateConfig = default;
        [SerializeField] private BehaviourStateConfig[] _stateConfigs = Array.Empty<BehaviourStateConfig>();

        public IBehaviourStateConfig EnterStateConfig => _enterStateConfig;
        public IReadOnlyList<IBehaviourStateConfig> StateConfigs => _stateConfigs;
    }
}