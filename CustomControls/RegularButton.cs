using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UTK.CustomButton
{
    [UxmlElement]
    public partial class RegularButton : VisualElement
    {
        private const string k_uxmlResourcesPathPrefix = "UTKUxml/Button/";
        private const string k_uxmlResourcesPath = k_uxmlResourcesPathPrefix + "RegularButton";
        private const string k_ussResourcesPath = "UTKUss/RegularButton";

        private const string k_regularButtonParentName = "regular-button-parent";
        private const string k_regularButtonName = "regular-button";
        private string _displayText = "Regular Button";
        private Length _width = 200;
        private Length _height = 35;
        private VisualElement _veRoot, _regularButtonParent;
        private Button _regularButton;
        public Button Avatar => _regularButton;
        [UxmlAttribute]
        public string DisplayText
        {
            get => _displayText;
            set { _displayText = value; ApplyDisplayText(); }
        }
        [UxmlAttribute]
        public Length Width
        {
            get => _width;
            set { _width = value; ApplyWidth(); }
        }
        [UxmlAttribute]
        public Length Height
        {
            get => _height;
            set { _height = value; ApplyHeight(); }
        }

        public RegularButton()
        {
            hierarchy.Clear();
            VisualTreeAsset asset = Resources.Load<VisualTreeAsset>(k_uxmlResourcesPath);
            _veRoot = asset.Instantiate();
            _regularButtonParent = _veRoot.Q<VisualElement>(k_regularButtonParentName);
            _regularButton = _veRoot.Q<Button>(k_regularButtonName);
            hierarchy.Add(_veRoot);

            Width = Length.Percent(100);

        }
        public RegularButton(string displayText)
        {
            hierarchy.Clear();
            VisualTreeAsset asset = Resources.Load<VisualTreeAsset>(k_uxmlResourcesPath);
            _veRoot = asset.Instantiate();
            _regularButtonParent = _veRoot.Q<VisualElement>(k_regularButtonParentName);
            _regularButton = _veRoot.Q<Button>(k_regularButtonName);
            hierarchy.Add(_veRoot);

            DisplayText = displayText;
            Width = Length.Percent(100);
            Height = new Length(20, LengthUnit.Pixel);
        }
        public RegularButton(string displayText, Length height)
        {
            hierarchy.Clear();
            VisualTreeAsset asset = Resources.Load<VisualTreeAsset>(k_uxmlResourcesPath);
            _veRoot = asset.Instantiate();
            _regularButtonParent = _veRoot.Q<VisualElement>(k_regularButtonParentName);
            _regularButton = _veRoot.Q<Button>(k_regularButtonName);
            hierarchy.Add(_veRoot);

            DisplayText = displayText;
            Width = Length.Percent(100);
            Height = height;
        }
        public RegularButton(string displayText, Length width, Length height)
        {
            hierarchy.Clear();
            VisualTreeAsset asset = Resources.Load<VisualTreeAsset>(k_uxmlResourcesPath);
            _veRoot = asset.Instantiate();
            _regularButtonParent = _veRoot.Q<VisualElement>(k_regularButtonParentName);
            _regularButton = _veRoot.Q<Button>(k_regularButtonName);
            hierarchy.Add(_veRoot);

            DisplayText = displayText;
            Width = width;
            Height = height;
        }
        private void ApplyHeight()
        {
            _veRoot.style.height = Height;
        }
        private void ApplyWidth()
        {
            _veRoot.style.width = Width;
        }
        private void ApplyDisplayText()
        {
            _regularButton.text = DisplayText;
        }
    }
}
