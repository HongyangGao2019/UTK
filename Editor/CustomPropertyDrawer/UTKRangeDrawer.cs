using System;
using System.Drawing;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using UTK.CustomSlider;
using UTK.CustomButton;
using UTK.Misc;

namespace UTK.Editor
{
    [CustomPropertyDrawer(typeof(UTKRangeAttribute))]  
    public class UTKRangeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container=new VisualElement();
            UTKRangeAttribute range=attribute as UTKRangeAttribute;
            if(property.propertyType==SerializedPropertyType.Integer)
            {
                Slider slider=new Slider(property.displayName,Convert.ToInt32(range.min), Convert.ToInt32(range.max));
                slider.showInputField=true;
                slider.BindProperty(property);

                container.Add(slider);
                // IntegerField integerField=new IntegerField(property.displayName);
                // integerField.BindProperty(property);
                // container.Add(integerField);
            }
            else if(property.propertyType==SerializedPropertyType.Float)
            {  
                Slider slider=new Slider(property.displayName,range.min,range.max);
                slider.BindProperty(property);
                container.Add(slider);
            }
            else
            {
                Label label=new Label("Check if not integer or float type.");
                container.Add(label);
            }
            return container;
        }
    }
}
