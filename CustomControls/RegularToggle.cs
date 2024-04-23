using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace UTK.CustomToggle
{
    [UxmlElement]
    public partial class RegularToggle : VisualElement
    {
        private const string k_uxmlResourcesPathPrefix = "UTKUxml/Toggle/";
        private const string k_uxmlResourcesPath = k_uxmlResourcesPathPrefix + "RegularToggle";
        private const string k_regularToggleParentName = "regular-toggle-parent";
        private const string k_regularToggleName = "regular-toggle";
        private const string k_defaultLabelDisplay = "Regular Toggle";

        private Length _width = 300;
        private Length _height = 35;
        private string _displayLabel = "Regular Toggle";
        private VisualElement _veRoot, _regularToggleParent;
        private Toggle _regularToggle;
        public Toggle Avatar => _regularToggle;
        [UxmlAttribute]
        public Length Width { get { return _width; } set { _width = value; SetWidth(); } }
        [UxmlAttribute]
        public Length Height
        {
            get { return _height; }
            set
            {
                _height = value;
                SetHeight();
            }
        }
        [UxmlAttribute]
        public string DisplayLabel
        {
            get { return _displayLabel; }
            set
            {
                _displayLabel = value;
                SetDisplayText();
            }
        }

        public RegularToggle()
        {
            hierarchy.Clear();
            VisualTreeAsset asset = Resources.Load<VisualTreeAsset>(k_uxmlResourcesPath);
            _veRoot = asset.Instantiate();
            _regularToggleParent = _veRoot.Q<VisualElement>(k_regularToggleParentName);
            _regularToggle = _veRoot.Q<Toggle>(k_regularToggleName);

            Width = new Length(100, LengthUnit.Percent);

            hierarchy.Add(_veRoot);
        }
        private void SetWidth()
        {
            _veRoot.style.width = Width;
        }
        private void SetHeight()
        {
            _veRoot.style.height = Height;
        }
        private void SetDisplayText()
        {
            _regularToggle.label = DisplayLabel;
        }
    }
}