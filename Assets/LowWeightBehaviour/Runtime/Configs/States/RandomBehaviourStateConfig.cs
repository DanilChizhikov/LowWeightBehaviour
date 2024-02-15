using UnityEngine;

namespace MBSCore.LowWeightBehaviour
{
    [CreateAssetMenu(menuName = "MBSCore/LowWeightBehaviour/Random State Config", fileName = "New Random State Config")]
    public sealed class RandomBehaviourStateConfig : BehaviourStateConfig
    {
        [SerializeField] private RandomBehaviourTransitionConfig _transitionConfig = default;
        
        public RandomBehaviourTransitionConfig TransitionConfig => _transitionConfig;
    }
}