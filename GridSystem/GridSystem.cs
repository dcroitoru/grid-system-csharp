using System.Collections.Generic;
using System;
namespace GridSystemCSharp
{
    public class GridSystem
    {

        public Grid grid { get; } = new("hover");

        Dictionary<Dispatcher.ActionType, Action<object>> _actionMap;

        private string _startKey;
        private string _currentKey;


        public GridSystem()
        {
            _actionMap = new Dictionary<Dispatcher.ActionType, Action<object>>
            {
                {Dispatcher.ActionType.Clear, clear},
                {Dispatcher.ActionType.SetCurrent, setCurrent },
                {Dispatcher.ActionType.StartSelection, startSelection },
                {Dispatcher.ActionType.StopSelection, stopSelection },

            };

            Dispatcher.OnAction += handleAction;
        }

        void handleAction(Dispatcher.ActionType type, object payload)
        {
            //Util.Log("should handle action in system", type, payload);
            var handler = _actionMap.ContainsKey(type) == true ? _actionMap[type] : DefaultHandler;
            handler(payload);
        }

        void setCurrent(object payload)
        {

            // Should check if started dragging
            // if dragging, set highlight grid by applying a function of start, current and selected tool
            // otherwise set highlight grid to a function of current cell and selected tool


            string? key = payload.ToString();
            if (key == null) return;

            Util.Log("should set current", payload);
            GridType value = new() { { key, "allow" } };
            grid.clear();
            grid.set(value);

            _currentKey = key;


        }

        void cancel(object payload)
        {
            Util.Log("should handle cancel", payload);
        }

        void clear(object payload)
        {
            Util.Log("should handle clear", payload);
            grid.clear();
        }

        void startSelection(object payload)
        {
            _startKey = _currentKey;
            Util.Log("should start selection at", _startKey);

        }

        void stopSelection(object payload)
        {
            Util.Log("should stop selection between", _startKey, _currentKey);

        }

        void DefaultHandler(object payload)
        {
            Util.Log("no handler for action");
        }

    }
}
