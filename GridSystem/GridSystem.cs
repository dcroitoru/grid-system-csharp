using static CustomGridSystem.Core.Constants;
using GridType = System.Collections.Generic.Dictionary<string, CustomGridSystem.Core.Constants.ToolType>;
using System.Collections.Generic;
using System;
using CustomGridSystem.Core;
using System.Linq;

namespace CustomGridSystem.GridSystem
{
    public class GridSystem
    {

        public Grid gridHighlight { get; } = new("hover");
        public Grid gridPermanent { get; } = new("hover");
        public ToolType ToolType { get => _toolType; }

        Dictionary<ActionType, Action<object>> _actionMap;
        Dictionary<ToolType, Func<Point, Point, Point[]>> _createHighlightFnMap;

        private string? _startKey;
        private string? _currentKey;
        private ToolType _toolType;
        private Func<Point, Point, Point[]>? _highlightFn ;


        public GridSystem()
        {

            Dispatcher.OnAction += handleAction;



            _actionMap = new Dictionary<ActionType, Action<object>>
            {
                {ActionType.Clear, clear},
                {ActionType.SetCurrent, setCurrent },
                {ActionType.StartSelection, startSelection },
                {ActionType.StopSelection, stopSelection },

                {ActionType.SetTool, setTool},

            };




            _createHighlightFnMap = new Dictionary<ToolType, Func<Point, Point, Point[]>> {
                {ToolType.Tree, Geometry.CreateArea },
                {ToolType.Road, Geometry.CreateHalfPerimeter },
                {ToolType.House, Geometry.CreatePoint }
            };

            _toolType = ToolType.Tree;
            _highlightFn = _createHighlightFnMap[ToolType];
        }

        void handleAction(ActionType type, object payload)
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
            if (key == _currentKey) return;

            if (_startKey != null)
            {

                //Util.Log("should set dragging", payload);

                var p0 = Point.KeyToPoint(_startKey);
                var p1 = Point.KeyToPoint(key);
                var points = _highlightFn(p0, p1);

                GridType dict = Util.CreateGridApplyTool(points, ToolType.Allow);
                //    new();
                //h.Select(Point.PointToKey).ToList().ForEach(item => dict.Add(item, ToolType.Allow));

                gridHighlight.clear();
                gridHighlight.set(dict);



            }
            else
            {
                //Util.Log("should set current", payload);
                GridType value = new() { { key, ToolType.Allow } };
                gridHighlight.clear();
                gridHighlight.set(value);

            }

            _currentKey = key;
        }

        void clear(object payload)
        {
            Util.Log("should handle clear", payload);
            gridHighlight.clear();
        }

        void startSelection(object payload)
        {
            _startKey = _currentKey;
            Util.Log("should start selection at", _startKey);
        }

        void stopSelection(object payload)
        {
            Util.Log("should stop selection between", _startKey, _currentKey);

            var dict = Util.TransformGridApplyTool(gridHighlight.Value(), ToolType);
            gridPermanent.set(dict);
            gridHighlight.clear();
            _startKey = null;
            //_currentKey = null;
        }

        void setTool(object payload)
        {
            _toolType = (ToolType)payload;
            _highlightFn = _createHighlightFnMap[ToolType];
                
            Util.Log("should set current tool", ToolType);
        }

        void DefaultHandler(object payload)
        {
            Util.Log("no handler for action");
        }

    }
}
