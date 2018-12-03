using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadExample : MonoBehaviour {

    void Start()
    {
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "unitychan.eae"));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("UnityChan");
        Instantiate(prefab);

        myLoadedAssetBundle.Unload(false);
    }
}
