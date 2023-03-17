using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGridSystem.Core
{
    public static class Constants
    {

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
            None,
            Allow,
            Deny,
            Tree,
            Road,
            House,
        }

        public enum HighlightType
        {
            Allow,
            Deny
        }

    }
}
