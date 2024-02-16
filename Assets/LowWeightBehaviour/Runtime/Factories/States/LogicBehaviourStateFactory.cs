using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class LogicBehaviourStateFactory<TEntity, TState> : BehaviourStateFactory<LogicBehaviourStateConfig, TEntity, TState>
        where TEntity : IBehaviourEntity
        where TState : LogicBehaviourState<TEntity>
    {
        private readonly IBehaviourActionFactoryService _actionFactoryService;
        private readonly IBehaviourDecisionFactoryService _decisionFactoryService;

        public LogicBehaviourStateFactory(IBehaviourActionFactoryService actionFactoryService,
            IBehaviourDecisionFactoryService decisionFactoryService)
        {
            _actionFactoryService = actionFactoryService;
            _decisionFactoryService = decisionFactoryService;
        }

        protected sealed override TState Create(LogicBehaviourStateConfig config, TEntity entity)
        {
            IBehaviourAction[] actions = GetActions(config.ActionConfigs, entity);
            LogicBehaviourTransition[] transitions = GetTransitions(config.TransitionConfigs, entity);
            return Create(config.Name, actions, transitions, entity);
        }

        protected abstract TState Create(string name, IBehaviourAction[] actions, LogicBehaviourTransition[] transitions,
            TEntity entity);
        
        private IBehaviourAction[] GetActions(IReadOnlyList<IBehaviourActionConfig> configs, IBehaviourEntity entity)
        {
            int configsCount = configs.Count;
            var actions = new IBehaviourAction[configsCount];
            for (int i = 0; i < configsCount; i++)
            {
                actions[i] = _actionFactoryService.Create(configs[i], entity);
            }

            return actions;
        }

        private LogicBehaviourTransition[] GetTransitions(IReadOnlyList<LogicBehaviourTransitionConfig> configs,
            IBehaviourEntity entity)
        {
            int configsCount = configs.Count;
            var transitions = new LogicBehaviourTransition[configsCount];
            for (int i = 0; i < configsCount; i++)
            {
                LogicBehaviourTransitionConfig config = configs[i];
                IBehaviourState trueState = GetState(config.TrueState, entity);
                IBehaviourState falseState = GetState(config.FalseState, entity);
                IBehaviourDecision[] decisions = GetDecisions(config.DecisionConfigs, entity);
                transitions[i] = new LogicBehaviourTransition(trueState, falseState, decisions);
            }

            return transitions;
        }

        private IBehaviourDecision[] GetDecisions(IReadOnlyList<IBehaviourDecisionConfig> configs,
            IBehaviourEntity entity)
        {
            int configsCount = configs.Count;
            var decisions = new IBehaviourDecision[configsCount];
            for (int i = 0; i < configsCount; i++)
            {
                decisions[i] = _decisionFactoryService.Create(configs[i], entity);
            }

            return decisions;
        }
    }
}