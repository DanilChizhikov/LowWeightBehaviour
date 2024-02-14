using UnityEngine;

namespace MBSCore.LowWeightBehaviour.UnityEngine
{
    public abstract class BehaviourStateConfig : ScriptableObject, IBehaviourStateConfig
    {
        public string Name => name;
    }
}