using UnityEngine;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class BehaviourStateConfig : ScriptableObject, IBehaviourStateConfig
    {
        public string Name => name;
    }
}