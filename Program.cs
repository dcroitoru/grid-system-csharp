using CustomGridSystem.Core;
using CustomGridSystem.GridSystem;

var gridSystem = new GridSystem();

gridSystem.grid.OnChanged += (GridType value) =>
{
    //Util.Log("on grid changed handler");
    Util.LogColl(value);

};


Dispatcher.dispatch(Dispatcher.ActionType.SetCurrent, "1-1");
Dispatcher.dispatch(Dispatcher.ActionType.StartSelection);
Dispatcher.dispatch(Dispatcher.ActionType.SetCurrent, "2-1");
Dispatcher.dispatch(Dispatcher.ActionType.SetCurrent, "3-1");
Dispatcher.dispatch(Dispatcher.ActionType.SetCurrent, "4-1");
Dispatcher.dispatch(Dispatcher.ActionType.StopSelection);


/*Dispatcher.dispatch("cancel", "cancel payload");
Dispatcher.dispatch("clear", "clear payload");*/



