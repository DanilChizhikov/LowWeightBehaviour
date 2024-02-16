using System;
using UnityEngine;

namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class LogAction : ExampleAction<LogActionConfig>
    {
        private readonly LogType _logType;

        public LogAction(LogActionConfig config, ExampleEntity entity) : base(config, entity)
        {
            _logType = GetLogType(config);
        }
        
        public override void Enter()
        {
            SendLog("[Enter] " + Config.Message);
        }

        public override void Processing()
        {
            SendLog("[Processing] " + Config.Message);
        }

        public override void Exit()
        {
            SendLog("[Exit] " + Config.Message);
        }

        private LogType GetLogType(LogActionConfig config) => config switch
        {
            DebugLogActionConfig => LogType.Log,
            WarningLogActionConfig => LogType.Warning,
            ErrorLogActionConfig => LogType.Error,
            _ => LogType.Log,
        };

        private void SendLog(string message)
        {
            switch (_logType)
            {
                case LogType.Log: Debug.Log(message);
                    break;
                case LogType.Warning: Debug.LogWarning(message);
                    break;
                case LogType.Error: Debug.LogError(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}