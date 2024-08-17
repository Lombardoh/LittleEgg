using UnityEditor;
using UnityEngine;

public class CreateScriptShortcut
{
    [MenuItem("Assets/Create C# Script Here %g")]
    private static void CreateScript()
    {
        var selectedObject = Selection.activeObject;
        string folderPath = "Assets";

        if (selectedObject != null)
        {
            folderPath = AssetDatabase.GetAssetPath(selectedObject);

            if (!AssetDatabase.IsValidFolder(folderPath))
            {
                folderPath = System.IO.Path.GetDirectoryName(folderPath);
            }
        }

        string scriptPath = AssetDatabase.GenerateUniqueAssetPath($"{folderPath}/NewScript.cs");

        System.IO.File.WriteAllText(scriptPath, GetDefaultScriptContent());
        AssetDatabase.Refresh();
        AssetDatabase.OpenAsset(AssetDatabase.LoadAssetAtPath<MonoScript>(scriptPath));
    }

    private static string GetDefaultScriptContent()
    {
        return
@"using UnityEngine;

public class NewScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}";
    }
}
