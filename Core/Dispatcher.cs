using static CustomGridSystem.Core.Constants;
using System;

namespace CustomGridSystem.Core
{

    public static class Dispatcher
    {        
        public static Action<ActionType, object?> OnAction = (t, p) => { };

        public static void dispatch(ActionType type, object? payload = null)
        {
            OnAction?.Invoke(type, payload);
        }
    }
}