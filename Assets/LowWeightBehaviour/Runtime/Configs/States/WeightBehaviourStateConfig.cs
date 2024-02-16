using UnityEngine;

namespace MBSCore.LowWeightBehaviour
{
    [CreateAssetMenu(menuName = "MBSCore/LowWeightBehaviour/Weight State Config", fileName = "New Weight State Config")]
    public sealed class WeightBehaviourStateConfig : BehaviourStateConfig
    {
        [SerializeField] private WeightBehaviourTransitionConfig _transitionConfig = default;
        
        public WeightBehaviourTransitionConfig TransitionConfig => _transitionConfig;
    }
}