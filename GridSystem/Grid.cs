using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSystemCSharp
{    public class Grid
    {

        public Action<GridType> OnChanged = (g) => { };
        GridType _value = new();
        public Grid(string name) {
            Util.Log("grid created", name);
        }

        public void set((string key, string value)[] kvs)
        {
            foreach (var kv in kvs)
            {
                _value[kv.key] = kv.value;

            }

            OnChanged(_value);
        }

        public void set(GridType kvs) 
        {
            foreach (var kv in kvs)
            {
                _value[kv.Key] = kv.Value;

            }

            OnChanged(_value);
        }

        public bool get(string key)
        {
            return _value.ContainsKey(key);
        }

        public void clear()
        {
            _value.Clear();
            OnChanged(_value);
        }
    }

    public class GridType : Dictionary<string, string> { }
}
