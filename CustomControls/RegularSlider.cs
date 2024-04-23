using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace UTK.CustomSlider
{
    [UxmlElement]
    public partial class RegularSlider : VisualElement
    {
        private const string k_uxmlResourcesPathPrefix = "UTKUxml/Slider/";
        private const string k_uxmlResourcesPath = k_uxmlResourcesPathPrefix + "RegularSlider";
        private const string k_regularSliderCssResourcesPath = "UTKUss/RegularSlider";
        private const string k_regularSliderParentName = "regular-slider-parent";
        private const string k_regularSliderName = "regular-slider";
        private const string k_defaultLabelDisplay = "Regular Slider";

        private Length _width = 300;
        private Length _height = 35;
        private string _displayText = "Regular Slider";
        private float _sliderValue = 1f;
        private float _startValue = 0f;
        private float _endValue = 10f;
        private VisualElement _veRoot, _regularSliderParent;
        private Slider _regularSlider;

        public Slider Avatar => _regularSlider;

        [UxmlAttribute]
        public Length Width
        {
            get { return _width; }
            set
            {
                _width = value;
                SetWidth();
            }
        }
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
        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                _displayText = value;
                SetDisplayText();
            }
        }
        [UxmlAttribute]
        public float SliderValue
        {
            get { return _sliderValue; }
            set
            {
                _sliderValue = value;
                SetSliderValue();
            }
        }
        [UxmlAttribute]
        public float StartValue
        {
            get { return _startValue; }
            set
            {
                _startValue = value;
                SetStartValue();
            }
        }
        [UxmlAttribute]
        public float EndValue
        {
            get { return _endValue; }
            set
            {
                _endValue = value;
                SetEndValue();
            }
        }

        public RegularSlider()
        {
            hierarchy.Clear();
            VisualTreeAsset asset = Resources.Load<VisualTreeAsset>(k_uxmlResourcesPath);
            _veRoot = asset.Instantiate();
            _regularSliderParent = _veRoot.Q<VisualElement>(k_regularSliderParentName);
            _regularSlider = _veRoot.Q<Slider>(k_regularSliderName);
            // styleSheets.Add(Resources.Load<StyleSheet>(k_regularButtonUssResourcesPath));
            hierarchy.Add(_veRoot);
        }
        public RegularSlider(string displayName, float startValue, float endValue)
        {
            hierarchy.Clear();
            VisualTreeAsset asset = Resources.Load<VisualTreeAsset>(k_uxmlResourcesPath);
            _veRoot = asset.Instantiate();
            _regularSliderParent = _veRoot.Q<VisualElement>(k_regularSliderParentName);
            _regularSlider = _veRoot.Q<Slider>(k_regularSliderName);
            DisplayText = displayName;
            StartValue = startValue;
            EndValue = endValue;
            // styleSheets.Add(Resources.Load<StyleSheet>(k_regularButtonUssResourcesPath));
            hierarchy.Add(_veRoot);
        }

        private void SetDisplayText()
        {
            _regularSlider.label = DisplayText;
        }
        private void SetWidth()
        {
            _regularSliderParent.style.width = Width;
        }
        private void SetHeight()
        {
            _regularSliderParent.style.height = Height;
        }
        private void SetSliderValue()
        {
            _regularSlider.value = SliderValue;
        }
        private void SetStartValue()
        {
            _regularSlider.lowValue = StartValue;
        }
        private void SetEndValue()
        {
            _regularSlider.highValue = EndValue;
        }
        // public RegularSlider():this(null)
        // {
        //     base.label=this.k_defaultLabelDisplay;
        // }
        // public RegularSlider(float start, float end, bool showInputField,SliderDirection direction = SliderDirection.Horizontal, float pageSize = 0f)
        // : this(null, start, end,showInputField, direction, pageSize)
        // {
        //     base.label=this.k_defaultLabelDisplay;
        // }
        // public RegularSlider(string label,float start = 0f, float end = 10f, bool showInputField=false, SliderDirection direction = SliderDirection.Horizontal, float pageSize = 0f)
        //     : base(label, start, end, direction, pageSize)
        // {
        //     base.showInputField=showInputField;
        //     styleSheets.Clear();
        //     styleSheets.Add(Resources.Load<StyleSheet>(this.k_regularSliderCssResourcesPath));
        // }
    }
}
