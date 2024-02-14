using System;
using System.Collections.Generic;
using UnityEngine;

namespace MBSCore.LowWeightBehaviour.UnityEngine
{
    public sealed class BehaviourTransitionConfig : ScriptableObject, IBehaviourTransitionConfig
    {
        [SerializeField] private BehaviourStateConfig _trueState;
        [SerializeField] private BehaviourStateConfig _falseState;
        [SerializeField] private BehaviourDecisionConfig[] _decisionConfigs = Array.Empty<BehaviourDecisionConfig>();

        public IBehaviourStateConfig TrueState => _trueState;
        public IBehaviourStateConfig FalseState => _falseState;
        public IReadOnlyList<IBehaviourDecisionConfig> DecisionConfigs => _decisionConfigs;
    }
}