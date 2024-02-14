using System;
using UnityEngine;

namespace MBSCore.LowWeightBehaviour.Csharp
{
    [Serializable]
    public abstract class BehaviourDecisionConfig : IBehaviourDecisionConfig
    {
        [SerializeField] private string _name = string.Empty;
        [SerializeField, Tooltip("Is this decision reverse?")] private bool _isReverse = false;

        public string Name => _name;
        public bool IsReverse => _isReverse;

        public BehaviourDecisionConfig()
        {
            _name = GetType().Name;
        }
    }
}