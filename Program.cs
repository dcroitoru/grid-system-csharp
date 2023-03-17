using CustomGridSystem.Core;
using CustomGridSystem.GridSystem;

var gridSystem = new GridSystem();

gridSystem.gridHighlight.OnChanged += (GridType value) =>
{
    //Util.Log("on temp grid changed handler", value.Count);
    Util.LogColl(value);


};

gridSystem.gridPermanent.OnChanged += (GridType value) =>
{
    //Util.Log("on perma grid changed handler", value.Count);
    Util.Log("new grid value:");
    Util.LogColl(value);
};





Dispatcher.dispatch(ActionType.SetTool, ToolType.Tree);


Dispatcher.dispatch(ActionType.SetCurrent, "0-0");
Dispatcher.dispatch(ActionType.StartSelection);
Dispatcher.dispatch(ActionType.SetCurrent, "3-3");
Dispatcher.dispatch(ActionType.StopSelection);


Dispatcher.dispatch(ActionType.SetTool, ToolType.Road);

Dispatcher.dispatch(ActionType.SetCurrent, "0-0");
Dispatcher.dispatch(ActionType.StartSelection);
Dispatcher.dispatch(ActionType.SetCurrent, "5-0");
Dispatcher.dispatch(ActionType.StopSelection);


/*Dispatcher.dispatch("cancel", "cancel payload");
Dispatcher.dispatch("clear", "clear payload");*/


/*var interval = Geometry.createInterval(0, 4);
Util.LogColl(interval);

var seg1 = Geometry.createSegmentOnX(interval, 0);
var seg2 = Geometry.createSegmentOnY(interval, 0);

Util.LogColl(seg1);
Util.LogColl(seg2);

var rect = Geometry.createArea(new Point(0, 0), new Point(4, 2));
Util.LogColl(rect);

var dict = rect.ToDictionary(item => Point.PointToKey(item), value => "allow");
Util.LogColl(dict);*/
