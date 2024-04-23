using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace UTK.Editor
{
    public class UTKGroupAttribute: PropertyAttribute
    {
        public string groupName;
        public UTKGroupAttribute(string groupName)
        {
            this.groupName=groupName;
        }
    }
}