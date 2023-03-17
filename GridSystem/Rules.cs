using static CustomGridSystem.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGridSystem.GridSystem
{
    public class Rules
    {

        public static Dictionary<ToolType, ToolType[]> DenyRules = new()
        {
            { ToolType.Tree, new ToolType[] { ToolType.Road, ToolType.House} },
            { ToolType.Road, new ToolType[] { ToolType.House} },
            { ToolType.House, new ToolType[] { } }
        };

        public static bool CannotBuild(ToolType buildWith, ToolType buildOver)
        {
            var rule = DenyRules[buildWith];
            var cannotBuild = rule.Contains(buildOver);

            return cannotBuild;
        }
    }
}
