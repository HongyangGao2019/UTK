using UnityEngine;

namespace UTK.Editor
{
    public class UTKRangeAttribute : PropertyAttribute
    {
        public float min;
        public float max;

        public UTKRangeAttribute(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
    }
}
