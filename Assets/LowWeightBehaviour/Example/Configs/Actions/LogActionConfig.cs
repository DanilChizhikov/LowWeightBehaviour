using UnityEngine;

namespace MBSCore.LowWeightBehaviour.Example
{
    internal abstract class LogActionConfig : ExampleActionConfig
    {
        [SerializeField] private string _message = string.Empty;
        
        public string Message => _message;
    }
}