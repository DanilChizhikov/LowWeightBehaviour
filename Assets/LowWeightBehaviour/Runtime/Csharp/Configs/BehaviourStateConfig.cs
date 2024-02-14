using System;
using UnityEngine;

namespace MBSCore.LowWeightBehaviour.Csharp
{
    [Serializable]
    public abstract class BehaviourStateConfig : IBehaviourStateConfig
    {
        [SerializeField] private string _name = string.Empty;
        
        public string Name => _name;

        public BehaviourStateConfig()
        {
            _name = GetType().Name;
        }
    }
}