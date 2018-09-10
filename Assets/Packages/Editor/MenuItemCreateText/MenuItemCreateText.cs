using UnityEngine;
using UnityEditor;

public class MenuItemCreateText
{
    [MenuItem("Assets/Create/Text/Csv(.csv)", false, 82)]
    public static void CreateTextCsv()
    {
        CreateAssetFile("Csv.csv");
    }

    [MenuItem("Assets/Create/Text/Markdown(.md)", false, 82)]
    public static void CreateTextMarkdown()
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

        CreateAssetFile("Markdown.md");
    }

    [MenuItem("Assets/Create/Text/Text(.txt)", false, 82)]
    public static void CreateTextTxt()
    {
        CreateAssetFile("Text.txt");
    }

    public static void CreateAssetFile(string nameWithExtension, string contents = "")
    {
        string assetPath = GetCurrentAssetDirectoryPath();

        assetPath = assetPath + "/" + nameWithExtension;

        System.IO.File.WriteAllText(assetPath, contents);

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
}