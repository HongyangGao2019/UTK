using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

namespace UTK.CustomScrollView
{
    [UxmlElement]
    public partial class NiceScrollView01 : ScrollView
    {
        public NiceScrollView01()
        {
        }

        public NiceScrollView01(ScrollViewMode scrollViewMode) : base(scrollViewMode)
        {
        }

    }
}
