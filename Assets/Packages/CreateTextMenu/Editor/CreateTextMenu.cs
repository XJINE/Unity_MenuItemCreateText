using UnityEditor;

public class CreateTextMenu
{
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