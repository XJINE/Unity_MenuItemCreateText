#if UNITY_EDITOR

using UnityEditor;

public class MenuItemCreateText
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

    [MenuItem("Assets/Create/Text/Csv(.csv)", false, 82)]
    public static void CreateTextCsv()
    {
        AssetCreationHelper.CreateAssetInCurrentDirectory("", "Csv.csv");
    }

    [MenuItem("Assets/Create/Text/Markdown(.md)", false, 82)]
    public static void CreateTextMarkdown()
    {
        AssetCreationHelper.CreateAssetInCurrentDirectory("", "Markdown.md");
    }

    [MenuItem("Assets/Create/Text/Text(.txt)", false, 82)]
    public static void CreateTextTxt()
    {
        AssetCreationHelper.CreateAssetInCurrentDirectory("", "Text.txt");
    }
}

#endif // UNITY_EDITOR