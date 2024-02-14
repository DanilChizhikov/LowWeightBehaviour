using UnityEngine;

namespace MBSCore.LowWeightBehaviour.UnityEngine
{
    public abstract class BehaviourActionConfig : ScriptableObject, IBehaviourActionConfig
    {
        public string Name => name;
    }
}