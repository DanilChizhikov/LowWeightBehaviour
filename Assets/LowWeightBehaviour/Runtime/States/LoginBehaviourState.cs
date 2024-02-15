using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class LoginBehaviourState<TActionConfig, TEntity, TAction> : BehaviourState<TEntity>
        where TEntity : IBehaviourEntity
        where TActionConfig : BehaviourActionConfig
        where TAction : BehaviourAction<TActionConfig, TEntity>
    {
        private readonly List<TAction> _actions;
        private readonly int _actionCount;
        private readonly List<LogicBehaviourTransition> _transitions;
        private readonly int _transitionCount;

        private bool _isEntered;
        
        public LoginBehaviourState(string name, TEntity entity, IEnumerable<TAction> actions,
            IEnumerable<LogicBehaviourTransition> transitions) : base(name, entity)
        {
            _actions = new List<TAction>(actions);
            _actionCount = _actions.Count;
            _transitions = new List<LogicBehaviourTransition>(transitions);
            _transitionCount = _transitions.Count;
            _isEntered = false;
        }

        public override void Enter()
        {
            if (_isEntered)
            {
                return;
            }
            
            EnterActions();
            EnterTransitions();
            _isEntered = true;
        }

        public override void Processing()
        {
            if (!_isEntered)
            {
                return;
            }
            
            ProcessingActions();
        }

        public override void Exit()
        {
            if (!_isEntered)
            {
                return;
            }
            
            ExitActions();
            ExitTransitions();
            _isEntered = false;
        }

        public override bool TryGetNextState(out IBehaviourState nextState)
        {
            for (int i = 0; i < _transitionCount; i++)
            {
                if (_transitions[i].TryTransition(out nextState))
                {
                    return true;
                }
            }

            nextState = null;
            return false;
        }

        private void EnterActions()
        {
            for (int i = 0; i < _actionCount; i++)
            {
                _actions[i].Enter();
            }
        }

        private void EnterTransitions()
        {
            for (int i = 0; i < _transitionCount; i++)
            {
                _transitions[i].Enter();
            }
        }

        private void ProcessingActions()
        {
            for (int i = 0; i < _actionCount; i++)
            {
                _actions[i].Processing();
            }
        }
        
        private void ExitActions()
        {
            for (int i = 0; i < _actionCount; i++)
            {
                _actions[i].Exit();
            }
        }

        private void ExitTransitions()
        {
            for (int i = 0; i < _transitionCount; i++)
            {
                _transitions[i].Exit();
            }
        }
    }
}