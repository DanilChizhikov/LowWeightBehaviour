using System;
using System.Collections.Generic;
using UnityEngine;

namespace MBSCore.LowWeightBehaviour
{
    [Serializable]
    public struct LogicBehaviourTransitionConfig
    {
        [SerializeField] private BehaviourStateConfig _trueState;
        [SerializeField] private BehaviourStateConfig _falseState;
        [SerializeField] private BehaviourDecisionConfig[] _decisionConfigs;

        public IBehaviourStateConfig TrueState => _trueState;
        public IBehaviourStateConfig FalseState => _falseState;
        public IReadOnlyList<IBehaviourDecisionConfig> DecisionConfigs => _decisionConfigs;
    }
}