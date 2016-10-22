using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Text;

public class CreateAssetBundle
{
    [MenuItem("Tools/Build All AssetBundles")]
    static public void BuildAssetBundleAll()
    {
        string outputPath;

        {
            string[] folderNames = { "Assets", "StreamingAssets", "AssetBundles", EditorUserBuildSettings.activeBuildTarget.ToString() };

            StringBuilder sb = new StringBuilder();
            string parentFolder = "";

            foreach (string folderName in folderNames)
            {
                sb.Append(folderName);
                string folderPath = sb.ToString();

                if (!AssetDatabase.IsValidFolder(folderPath))
                {
                    Debug.Log("Not exist folder. path:" + folderPath + ", parentFolder:" + parentFolder + ", folderName:" + folderName);
                    AssetDatabase.CreateFolder(parentFolder, folderName);
                }

                parentFolder = folderPath;
                sb.Append("/");
            }

            if (0 < sb.Length)
                sb.Remove(sb.Length - 1, 1);

            outputPath = sb.ToString();
        }

        BuildPipeline.BuildAssetBundles(outputPath,
                                        BuildAssetBundleOptions.DeterministicAssetBundle |
                                        BuildAssetBundleOptions.ChunkBasedCompression,
                                        EditorUserBuildSettings.activeBuildTarget);
    }
}
