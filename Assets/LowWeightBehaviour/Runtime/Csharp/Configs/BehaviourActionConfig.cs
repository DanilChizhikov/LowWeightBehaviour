using System;
using UnityEngine;

namespace MBSCore.LowWeightBehaviour.Csharp
{
    [Serializable]
    public abstract class BehaviourActionConfig : IBehaviourActionConfig
    {
        [SerializeField] private string _name = string.Empty;

        public string Name => _name;

        public BehaviourActionConfig()
        {
            _name = GetType().Name;
        }
    }
}