using System;
using System.Collections.Generic;
using UnityEngine;

namespace MBSCore.LowWeightBehaviour
{
    [Serializable]
    public struct WeightBehaviourTransitionConfig
    {
        [SerializeField] private WeightStateInfo[] _stateInfos;
        
        public IReadOnlyList<WeightStateInfo> StateInfos => _stateInfos;
    }
}