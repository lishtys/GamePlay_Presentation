using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildAsset : MonoBehaviour
{


    [MenuItem("Asset/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        Debug.Log("Build Assets");
        string dir = Application.dataPath + "/../../Platform/Windows/";

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
