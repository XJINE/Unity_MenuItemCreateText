using UnityEngine;
using UnityEditor;

public class MarkdownTextCreator
{
    [MenuItem("Assets/Create/Markdown")]
    public static void Create()
    {
        // NOTE:
        // Following code doesn't works well.
        //
        // TextAsset textAsset = new TextAsset();
        // if (textAsset == null)
        // {
        //     Debug.Log("textAsset is null.");
        // }
        // AssetDatabase.CreateAsset(textAsset, "MarkdownText.md");

        string assetPath = GetCurrentAssetDirectoryPath();

        assetPath = assetPath + "/MarkdownText.md";

        System.IO.File.WriteAllText(assetPath, "");

        AssetDatabase.Refresh();

        Object asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);

        StartSelectedAssetRename(asset);
    }

    public static string GetCurrentAssetDirectoryPath()
    {
        string assetPath = Application.dataPath;

        foreach (Object obj in Selection.GetFiltered(typeof(Object), SelectionMode.Assets))
        {
            assetPath = AssetDatabase.GetAssetPath(obj);

            if (System.IO.File.Exists(assetPath))
            {
                assetPath = System.IO.Path.GetDirectoryName(assetPath);
                break;
            }
        }

        return assetPath;
    }

    public static void StartSelectedAssetRename(Object asset)
    {
        EditorWindow projectWindow = EditorWindow.GetWindow
            (typeof(EditorWindow).Assembly.GetType("UnityEditor.ProjectBrowser"));

        Selection.activeObject = asset;

        EditorUtility.FocusProjectWindow();

        projectWindow.SendEvent(Event.KeyboardEvent(KeyCode.F2.ToString()));
    }

    private static void CheckUnity3DWindowNames()
    {
        // NOTE:
        // This function is used to check Unity window name. So mainly for debug.

        EditorWindow[] editorWindows = Resources.FindObjectsOfTypeAll<EditorWindow>();

        foreach (EditorWindow editorWindow in editorWindows)
        {
            Debug.Log(editorWindow.GetType().ToString());
        }
    }
}
