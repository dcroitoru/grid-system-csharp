using System;

namespace CustomGridSystem.Core
{

    public static class Dispatcher
    {

        public static Action<ActionType, string> OnAction = (t, p) => { };

        public static void dispatch(ActionType type, string payload = "")
        {
            //Util.Log("should dispatch action", type, payload);

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

    }


}