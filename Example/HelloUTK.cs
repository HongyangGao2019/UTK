using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class HelloUTK : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/HelloUTK")]
    public static void ShowExample()
    {
        HelloUTK wnd = GetWindow<HelloUTK>();
        wnd.titleContent = new GUIContent("HelloUTK");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);
    }
}
