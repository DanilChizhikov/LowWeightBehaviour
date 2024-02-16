using UnityEngine;

namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal abstract class LogActionConfig : TestActionConfig
    {
        [SerializeField] private string _message = string.Empty;
        
        public string Message => _message;
    }
}