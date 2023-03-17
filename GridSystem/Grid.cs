using CustomGridSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CustomGridSystem.GridSystem
{
    public class Grid
    {

        public Action<GridType> OnChanged = (g) => { };
        GridType _value = new();
        GridType _oldValue = new();
        public Grid(string name)
        {
            Util.Log("grid created", name);
        }

        public GridType Value() => _value;            
        public bool get(string key) => _value.ContainsKey(key);

        public void set(GridType kvs)
        {
            foreach (var kv in kvs) _value[kv.Key] = kv.Value;
            OnChanged(_value);
        }

        public void clear()
        {
            _value.Clear();
            OnChanged(_value);
        }

        public void clearInternal()
        {
            _value.Clear();
        }

        
    }
}
