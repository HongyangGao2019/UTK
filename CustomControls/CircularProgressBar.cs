using UnityEngine;
using UnityEngine.UIElements;
using UTK.Editor;

namespace UTK.Misc
{
    [UxmlElement]
    public partial class CircularProgressBar : VisualElement
    {
        private const string k_uxmlResourcesPathPrefix = "UTKUxml/Misc/";
        private const string k_uxmlResourcesPath = k_uxmlResourcesPathPrefix + "CircularProgressBar";
        private const string k_circularBarParent = "circular-bar-parent";
        private const string k_circularBarBg = "circular-bar-bg";
        private const string k_upLeftFg = "up-left-fg";
        private const string k_upRightFg = "up-right-fg";
        private const string k_downLeftFg = "down-left-fg";
        private const string k_downRightFg = "down-right-fg";


        private Color _circularBgColor = Color.black;
        private Color _circularFgColor = Color.cyan;
        private float _progress = 1;
        private float _borderWidth = 20;
        private float _barRadius = 100f;

        private VisualElement _circularProgressBar, _circularBarParent, _circularBarBg, _upLeftFg, _upRightFg, _downLeftFg, _downRightFg;
        [UxmlAttribute, Header("Custom")]
        public Color CircularBgColor
        {
            get { return _circularBgColor; }
            set
            {
                _circularBgColor = value;
                ApplyBgColor();
            }
        }
        [UxmlAttribute]
        public Color CircularFgColor
        {
            get { return _circularFgColor; }
            set
            {
                _circularFgColor = value;
                ApplyFgColor();
            }
        }
        // #region 
        [UxmlAttribute, Range(0, 1)]
        // #endregion
        public float Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                ApplyProgress();
            }
        }
        [UxmlAttribute]
        public float BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;
                ApplyBarBorderWidth();
            }
        }
        [UxmlAttribute]
        public float BarRadius
        {
            get { return _barRadius; }
            set
            {
                _barRadius = value;
                ApplyBarRadius();
            }
        }

        public CircularProgressBar()
        {
            hierarchy.Clear();
            VisualTreeAsset circularProgressBarAsset = Resources.Load<VisualTreeAsset>(k_uxmlResourcesPath);
            _circularProgressBar = circularProgressBarAsset.Instantiate();
            _circularBarParent = _circularProgressBar.Q<VisualElement>(k_circularBarParent);
            _circularBarBg = _circularProgressBar.Q<VisualElement>(k_circularBarBg);
            _upLeftFg = _circularProgressBar.Q<VisualElement>(k_upLeftFg);
            _upRightFg = _circularProgressBar.Q<VisualElement>(k_upRightFg);
            _downLeftFg = _circularProgressBar.Q<VisualElement>(k_downLeftFg);
            _downRightFg = _circularProgressBar.Q<VisualElement>(k_downRightFg);
            ApplyBarRadius();
            ApplyFgColor();
            ApplyBgColor();
            ApplyBarBorderWidth();
            ApplyProgress();
            _circularProgressBar.style.flexShrink = 0;
            hierarchy.Add(_circularProgressBar);
        }

        private void ApplyFgColor()
        {
            _upLeftFg.style.backgroundColor = CircularFgColor;
            _upRightFg.style.backgroundColor = CircularFgColor;
            _downLeftFg.style.backgroundColor = CircularFgColor;
            _downRightFg.style.backgroundColor = CircularFgColor;
        }
        private void ApplyBgColor()
        {
            _circularBarBg.style.backgroundColor = CircularBgColor;
        }
        private void ApplyBarBorderWidth()
        {
            _circularBarBg.style.borderLeftWidth = BorderWidth;
            _circularBarBg.style.borderRightWidth = BorderWidth;
            _circularBarBg.style.borderTopWidth = BorderWidth;
            _circularBarBg.style.borderBottomWidth = BorderWidth;
        }
        private void ApplyBarRadius()
        {
            _circularBarParent.style.width = BarRadius * 2;
            _circularBarParent.style.height = BarRadius * 2;
            _circularBarBg.style.borderTopLeftRadius = BarRadius * 2;
            _circularBarBg.style.borderTopRightRadius = BarRadius * 2;
            _circularBarBg.style.borderBottomLeftRadius = BarRadius * 2;
            _circularBarBg.style.borderBottomRightRadius = BarRadius * 2;
        }
        private void ApplyProgress()
        {
            float partProgress = Progress * 4f - Mathf.Floor(Progress * 4f);
            if (Mathf.Floor(Progress * 4f) == 0)
            {
                RotateVE(_upLeftFg, -90f, 0f, partProgress);
                RotateVE(_upRightFg, -90f, 0f, 0f);
                RotateVE(_downRightFg, -90f, 0f, 0f);
                RotateVE(_downLeftFg, -90f, 0f, 0f);
            }
            if (Mathf.Floor(Progress * 4f) == 1)
            {
                RotateVE(_upLeftFg, -90f, 0f, 1f);
                RotateVE(_upRightFg, -90f, 0f, partProgress);
                RotateVE(_downRightFg, -90f, 0f, 0f);
                RotateVE(_downLeftFg, -90f, 0f, 0f);
            }
            if (Mathf.Floor(Progress * 4f) == 2)
            {
                RotateVE(_upLeftFg, -90f, 0f, 1f);
                RotateVE(_upRightFg, -90f, 0f, 1f);
                RotateVE(_downRightFg, -90f, 0f, partProgress);
                RotateVE(_downLeftFg, -90f, 0f, 0f);
            }
            if (Mathf.Floor(Progress * 4f) == 3)
            {
                RotateVE(_upLeftFg, -90f, 0f, 1f);
                RotateVE(_upRightFg, -90f, 0f, 1f);
                RotateVE(_downRightFg, -90f, 0f, 1f);
                RotateVE(_downLeftFg, -90f, 0f, partProgress);
            }
            if (Mathf.Floor(Progress * 4f) == 4)
            {
                RotateVE(_upLeftFg, -90f, 0f, 1f);
                RotateVE(_upRightFg, -90f, 0f, 1f);
                RotateVE(_downRightFg, -90f, 0f, 1f);
                RotateVE(_downLeftFg, -90f, 0f, 1f);
            }
        }
        private void RotateVE(VisualElement ve, float startDegree, float endDegree, float progress)
        {
            Angle angle = new Angle(Mathf.Lerp(startDegree, endDegree, progress), AngleUnit.Degree);
            ve.style.rotate = new StyleRotate(new Rotate(angle));
        }
    }
}
