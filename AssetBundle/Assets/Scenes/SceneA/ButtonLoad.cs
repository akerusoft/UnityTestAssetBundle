using AssetBundles;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonLoad : MonoBehaviour
{
    private const string SCENE_NAME = "SceneB";
    private const string ASSET_BUNDLE_NAME = "scene_b";

    public void OnPressedButtonLoad()
    {
        StopWatch.Start();
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        yield return StartCoroutine(Initialize());

        // Load level.
        yield return StartCoroutine(InitializeLevelAsync(SCENE_NAME, false));
    }

    // Initialize the downloading url and AssetBundleManifest object.
    protected IEnumerator Initialize()
    {
        // Don't destroy this gameObject as we depend on it to run the loading script.
        DontDestroyOnLoad(gameObject);

#if UNITY_EDITOR
        AssetBundleManager.SetSourceAssetBundleURL("file://" + Application.streamingAssetsPath + "/AssetBundles/");
#else
        AssetBundleManager.SetSourceAssetBundleURL(Application.streamingAssetsPath + "/AssetBundles/");
#endif
        AssetBundleManager.ActiveVariants = new string[] { "en" };

        // Initialize AssetBundleManifest which loads the AssetBundleManifest object.
        var request = AssetBundleManager.Initialize();

        if (request != null)
            yield return StartCoroutine(request);
    }

    protected IEnumerator InitializeLevelAsync(string levelName, bool isAdditive)
    {
        // This is simply to get the elapsed time for this phase of AssetLoading.
        float startTime = Time.realtimeSinceStartup;

        // Load level from assetBundle.
        AssetBundleLoadOperation request = AssetBundleManager.LoadLevelAsync(ASSET_BUNDLE_NAME, levelName, isAdditive);
        if (request == null)
            yield break;
        yield return StartCoroutine(request);

        // Calculate and display the elapsed time.
        float elapsedTime = Time.realtimeSinceStartup - startTime;
        Debug.Log("Finished loading scene " + levelName + " in " + elapsedTime + " seconds");
    }
}
