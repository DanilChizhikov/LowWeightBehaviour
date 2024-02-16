using UnityEngine;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class BehaviourDecisionConfig : ScriptableObject, IBehaviourDecisionConfig
    {
        [SerializeField, Tooltip("Is this decision reverse?")] private bool _isReverse = false;
        
        public string Name => name;
        public bool IsReverse => _isReverse;
    }
}