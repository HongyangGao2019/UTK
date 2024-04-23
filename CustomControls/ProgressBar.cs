using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace UTK.Misc
{
    [UxmlElement]
    public partial class ProgressBar : VisualElement
    {
        #region Resources Reference Path
        private const string k_uxmlResourcesPathPrefix = "UTKUxml/Misc/";
        private const string k_uxmlResourcesPath = k_uxmlResourcesPathPrefix + "ProgressBar";

        #endregion Resources Reference Path

        #region Custom Enum
        public enum FillTypes
        {
            Horizontal_FromLeft,
            Horizontal_FromRight,
            Vertical_FromTop,
            Vertical_FromBottom,
        }
        #endregion Custom Enum

        #region Uxml Components Name
        private const string k_progressBarParent = "progress-bar-parent";
        private const string k_progressBarBg = "progress-bar-bg";
        private const string k_progressBarFg = "progress-bar-fg";
        #endregion Uxml Components Name

        #region Private Variables
        private float _width = 300;
        private float _height = 50;
        private float _radius = 20;
        private float _outlineWidth = 0;
        private Color _outlineColor = new Color(0.9f, 0.9f, 0.3f);
        private float _progress = 1;
        private Color _fgColor = Color.green;
        private Color _bgColor = Color.black;
        private FillTypes _fillType = FillTypes.Horizontal_FromLeft;
        private VisualElement _progressBar, barParent, background, foreground;
        #endregion Private Variables

        #region Public Properties (UxmlAttribute)
        [UxmlAttribute]
        public float Width
        {
            get => _width;
            set
            {
                _width = value;
                barParent.style.width = _width;
            }
        }
        [UxmlAttribute]
        public float Height
        {
            get => _height;
            set
            {
                _height = value;
                barParent.style.height = _height;
            }
        }

        [UxmlAttribute]
        public float OutlineWidth
        {
            get => _outlineWidth;
            set
            {
                _outlineWidth = value;
                ApplyInnerStrokes();
            }
        }
        [UxmlAttribute]
        public Color OutlineColor
        {
            get => _outlineColor;
            set
            {
                _outlineColor = value;
                ApplyInnerStrokesColor();
            }
        }
        [UxmlAttribute]
        public float Radius
        {
            get => _radius;
            set
            {
                _radius = value;
                ApplyRadius();
            }
        }
        [UxmlAttribute, Range(0, 1), CreateProperty]
        public float Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                switch (FillType)
                {
                    case FillTypes.Horizontal_FromLeft:
                        {
                            Length lengthX = new Length();
                            lengthX.value = (Progress - 1) * barParent.style.width.value.value;
                            lengthX.unit = LengthUnit.Pixel;
                            foreground.style.translate = new StyleTranslate(new Translate(lengthX, 0));
                            break;
                        }
                    case FillTypes.Horizontal_FromRight:
                        {
                            Length lengthX = new Length();
                            lengthX.value = (1 - Progress) * barParent.style.width.value.value;
                            lengthX.unit = LengthUnit.Pixel;
                            foreground.style.translate = new StyleTranslate(new Translate(lengthX, 0));
                            break;
                        }
                    case FillTypes.Vertical_FromTop:
                        {
                            Length lengthY = new Length();
                            lengthY.value = (Progress - 1) * barParent.style.height.value.value;
                            lengthY.unit = LengthUnit.Pixel;
                            foreground.style.translate = new StyleTranslate(new Translate(0, lengthY));
                            break;
                        }
                    case FillTypes.Vertical_FromBottom:
                        {
                            Length lengthY = new Length();
                            lengthY.value = (1 - Progress) * barParent.style.height.value.value;
                            lengthY.unit = LengthUnit.Pixel;
                            foreground.style.translate = new StyleTranslate(new Translate(0, lengthY));
                            break;
                        }

                }
            }
        }
        [UxmlAttribute]
        public FillTypes FillType
        {
            get => _fillType;
            set
            {
                _fillType = value;
                Progress = _progress;
            }
        }
        [UxmlAttribute]
        public Color FgColor
        {
            get => _fgColor;
            set
            {
                _fgColor = value;
                foreground.style.backgroundColor = _fgColor;
            }
        }
        [UxmlAttribute]
        public Color BgColor
        {
            get => _bgColor;
            set
            {
                _bgColor = value;
                background.style.backgroundColor = _bgColor;
            }
        }
        #endregion Public Properties (UxmlAttribute)

        #region Constructor Methods
        public ProgressBar()
        {
            hierarchy.Clear();
            VisualTreeAsset progressBarAsset = Resources.Load<VisualTreeAsset>(k_uxmlResourcesPath);
            _progressBar = progressBarAsset.Instantiate();
            barParent = _progressBar.Q<VisualElement>(k_progressBarParent);
            foreground = _progressBar.Q<VisualElement>(k_progressBarFg);
            background = _progressBar.Q<VisualElement>(k_progressBarBg);
            foreground.style.backgroundColor = FgColor;
            background.style.backgroundColor = BgColor;
            barParent.style.width = Width;
            barParent.style.height = Height;
            _progressBar.style.flexShrink = 0;

            ApplyRadius();
            ApplyInnerStrokes();
            hierarchy.Add(_progressBar);
        }
        #endregion Constructor Methods

        #region Private Methods
        private void ApplyInnerStrokes()
        {
            background.style.borderLeftWidth = OutlineWidth;
            background.style.borderRightWidth = OutlineWidth;
            background.style.borderTopWidth = OutlineWidth;
            background.style.borderBottomWidth = OutlineWidth;
        }
        private void ApplyInnerStrokesColor()
        {
            background.style.borderLeftColor = OutlineColor;
            background.style.borderRightColor = OutlineColor;
            background.style.borderTopColor = OutlineColor;
            background.style.borderBottomColor = OutlineColor;
        }
        private void ApplyRadius()
        {
            background.style.borderTopLeftRadius = Radius + OutlineWidth;
            background.style.borderTopRightRadius = Radius + OutlineWidth;
            background.style.borderBottomLeftRadius = Radius + OutlineWidth;
            background.style.borderBottomRightRadius = Radius + OutlineWidth;
            foreground.style.borderTopLeftRadius = Radius;
            foreground.style.borderTopRightRadius = Radius;
            foreground.style.borderBottomLeftRadius = Radius;
            foreground.style.borderBottomRightRadius = Radius;
        }
        #endregion Private Methods
    }
}

