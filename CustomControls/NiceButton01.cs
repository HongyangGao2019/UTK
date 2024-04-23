using UnityEngine;
using UnityEngine.UIElements;

namespace UTK.CustomButton
{
    [UxmlElement]
    public partial class NiceButton01 : VisualElement
    {

        private const string k_uxmlResourcesPathPrefix = "UTKUxml/Button/";
        private const string k_uxmlResourcesPath = k_uxmlResourcesPathPrefix + "NiceButton01";
        private const string k_niceButton01Parent = "nice-button01-parent";
        private const string k_niceButton01 = "nice-button01";
        private VisualElement _veRoot, _niceButton01Parent;
        private Button _niceButton01;
        private Button Avatar => _niceButton01;
        private string _displayText = "Nice Button 01";
        [UxmlAttribute]
        public string DisplayText
        {
            get => _displayText;
            set
            {
                _displayText = value;
                ApplyDisplayText(_displayText);
            }
        }

        public NiceButton01()
        {
            hierarchy.Clear();
            VisualTreeAsset niceButton01Asset = Resources.Load<VisualTreeAsset>(k_uxmlResourcesPath);
            _veRoot = niceButton01Asset.Instantiate();
            _niceButton01Parent = _veRoot.Q<VisualElement>(k_niceButton01Parent);
            _niceButton01 = _veRoot.Q<Button>(k_niceButton01);
            ApplyDisplayText(_displayText);
            hierarchy.Add(_veRoot);
        }
        public NiceButton01(string displayText)
        {
            hierarchy.Clear();
            VisualTreeAsset niceButton01Asset = Resources.Load<VisualTreeAsset>(k_uxmlResourcesPath);
            _veRoot = niceButton01Asset.Instantiate();
            _niceButton01Parent = _veRoot.Q<VisualElement>(k_niceButton01Parent);
            _niceButton01 = _veRoot.Q<Button>(k_niceButton01);
            ApplyDisplayText(displayText);
            hierarchy.Add(_veRoot);
        }




        private void ApplyDisplayText(string displayText)
        {
            _niceButton01.text = displayText;
        }
    }
}
