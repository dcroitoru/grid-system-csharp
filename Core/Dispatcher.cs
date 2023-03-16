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

        public enum ActionType
        {
            SetCurrent,
            Clear,
            StartSelection,
            StopSelection,
            SetTool
        }

        public enum ToolType
        {
            None,
            Allow,
            Deny,
            Tree,
            Road,
            House,
        }

        public enum HighlightType
        {
            Allow,
            Deny
        }

    }


}