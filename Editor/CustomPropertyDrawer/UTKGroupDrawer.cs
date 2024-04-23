using UnityEditor;
using UnityEngine.UIElements;

namespace UTK.Editor
{
    [CustomPropertyDrawer(typeof(UTKGroupAttribute))]  
    public class UTKGroupDrawer: PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            // Create a new VisualElement to be the root the property UI
            var container =new VisualElement();
            UTKGroupAttribute groupAttribute=attribute as UTKGroupAttribute;
            
            // Create drawer UI using C#
            var popup = new UnityEngine.UIElements.PopupWindow();
            popup.text = groupAttribute.groupName;
            // popup.Add(new PropertyField(property.FindPropertyRelative("m_AirPressure"), "Air Pressure (psi)"));
            // popup.Add(new PropertyField(property.FindPropertyRelative("m_ProfileDepth"), "Profile Depth (mm)"));
            // popup.Add(new PropertyField(property.FindPropertyRelative("Progress"), property.displayName));
            container.Add(popup);

            // Return the finished UI
            return container;
        }
    }
}