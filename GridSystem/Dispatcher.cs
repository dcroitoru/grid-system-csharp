using GridSystem;
using System.Collections;
using System.Collections.Generic;

namespace LearningCsharpClassLibrary
{


    public class Dispatcher
    {

        Dispatcher Instance { get; set; } = new Dispatcher();
        public static Action<string, object> dispatchAction = (t, p) => { };


        public Dispatcher()
        {
            Instance = this;
        }

        public static void dispatch(string type, string payload = "")
        {
            Util.Log("should dispatch action");

            dispatchAction?.Invoke(type, payload);

        }

        public static IEnumerable next(string action)
        {
            yield return action;
        }

    }


}