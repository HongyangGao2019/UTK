using UnityEngine;
using UnityEngine.UIElements;

namespace UTK.CustomScrollView
{
    [UxmlElement]
    public partial class RegularScrollView : VisualElement
    {
        private const string k_uxmlResourcesPathPrefix = "UTKUxml/ScrollView/";
        private const string k_uxmlResourcesPath = k_uxmlResourcesPathPrefix + "RegularScrollView";
        private const string k_regularScrollViewParentName = "regular-scroll-view-parent";
        private const string k_regularScrollViewName = "regular-scroll-view";
        private Length _width = 300;
        private Length _height = 120;
        private VisualElement _veRoot, _regularScrollViewParent;
        private ScrollView _regularScrollView;
        public ScrollView Avatar => _regularScrollView;

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
        public RegularScrollView()
        {
            hierarchy.Clear();
            VisualTreeAsset asset = Resources.Load<VisualTreeAsset>(k_uxmlResourcesPath);
            _veRoot = asset.Instantiate();
            _regularScrollViewParent = _veRoot.Q<VisualElement>(k_regularScrollViewParentName);
            _regularScrollView = _veRoot.Q<ScrollView>(k_regularScrollViewName);
            hierarchy.Add(_veRoot);
        }

        private void SetWidth()
        {
            _regularScrollViewParent.style.width = Width;
        }
        private void SetHeight()
        {
            _regularScrollViewParent.style.height = Height;
        }
    }
}
