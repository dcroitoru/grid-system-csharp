using System;

namespace CustomGridSystem.Core
{

    public static class Dispatcher
    {

        public static Action<ActionType, string> OnAction = (t, p) => { };

        public static void dispatch(ActionType type, string payload = "")
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
            Tree,
            Road,
            House
        }

        public enum HighlightType
        {
            Allow,
            Deny
        }

    }


}