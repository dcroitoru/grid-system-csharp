﻿using CustomGridSystem.Core;
using CustomGridSystem.GridSystem;

var gridSystem = new GridSystem();

gridSystem.grid.OnChanged += (GridType value) =>
{
    //Util.Log("on grid changed handler");
    Util.LogColl(value);

};


Dispatcher.dispatch(Dispatcher.ActionType.SetCurrent, "1-1");
Dispatcher.dispatch(Dispatcher.ActionType.StartSelection);
Dispatcher.dispatch(Dispatcher.ActionType.SetCurrent, "4-5");
Dispatcher.dispatch(Dispatcher.ActionType.StopSelection);

Dispatcher.dispatch(Dispatcher.ActionType.StartSelection);
Dispatcher.dispatch(Dispatcher.ActionType.SetCurrent, "9-9");
Dispatcher.dispatch(Dispatcher.ActionType.StopSelection);


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
