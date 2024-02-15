using UnityEngine;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class BehaviourActionConfig : ScriptableObject, IBehaviourActionConfig
    {
        public string Name => name;
    }
}